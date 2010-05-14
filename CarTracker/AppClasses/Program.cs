using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using OpenNETCF.Drawing.Imaging;

namespace CarTracker
{
    static class Program
    {
        public static string AppName = "Car Tracker!";
        public static string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        public static string LogoPath = Path.Combine(Program.AppPath, "logos");
        public static string ExportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "CarTracker");
        public static string SightingFile = Path.Combine(AppPath, "sightings.txt");
        public static List<Sightings> CarSightings = new List<Sightings>();
        public static int LogoSquare = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ReadSightings();
            if (!Directory.Exists(ExportPath))
                Directory.CreateDirectory(ExportPath);
            Application.Run(new frmMain());
        }

        public static void ReadSightings()
        {
            StreamReader sr = null;
            try
            {
                if (!File.Exists(SightingFile))
                    return;

                sr = new StreamReader(SightingFile);
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    CarSightings.Add(new Sightings(line));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't read from sightings file! Error:\n" + ex.Message, Program.AppName);
                Application.Exit();
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public static void WriteSightings()
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(SightingFile);
                foreach (Sightings sighting in Program.CarSightings)
                {
                    sw.WriteLine(sighting.Serialize());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't write to sightings file! Error:\n" + ex.Message, Program.AppName);
                Application.Exit();
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        public static string SightingsBackup()
        {
            string exportFile = Path.Combine(ExportPath, "CarSightings_BACKUP_" + String.Format("{0:MM-dd-yy_HH-mm-ss}", DateTime.Now) + ".txt");
            if (File.Exists(SightingFile))
                File.Copy(SightingFile, exportFile);

            return exportFile;
        }

        public static string ExportDatabaseSightings()
        {
            string exportFile = Path.Combine(ExportPath, "CarSightings_DB_" + String.Format("{0:MM-dd-yy_HH-mm-ss}", DateTime.Now) + ".txt");

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(exportFile);
                foreach (Sightings sighting in Program.CarSightings)
                {
                    foreach (DateTime date in sighting.SightingDates)
                    {
                        sw.WriteLine("\"" + sighting.CarName + "\"\t\"" + Program.ODBCDateTimeFormat(date) + "\"");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't write to sightings file! Error:\n" + ex.Message, Program.AppName);
                Application.Exit();
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return exportFile;
        }

        public static string ExportExcelSightings()
        {
            string exportFile = Path.Combine(ExportPath, "CarSightings_EXCEL_" + String.Format("{0:MM-dd-yy_HH-mm-ss}", DateTime.Now) + ".txt");

            StreamWriter sw = null;
            StringBuilder sb;
            int maxLength = 0;

            try
            {
                sw = new StreamWriter(exportFile);
                foreach (Sightings sighting in Program.CarSightings)
                {
                    if (sighting.SightingDates.Count > maxLength)
                        maxLength = sighting.SightingDates.Count;
                }

                sb = new StringBuilder();
                for (int i = 0; i < Program.CarSightings.Count - 1; i++)
                {
                    sb.Append(Program.CarSightings[i].CarName + "\t");
                }
                sw.WriteLine(sb.ToString());

                for (int i = 0; i < maxLength; i++)
                {
                    sb = new StringBuilder();
                    for (int j = 0; j < Program.CarSightings.Count - 1; j++)
                    {
                        if (Program.CarSightings[j].SightingDates.Count > i)
                            sb.Append(Program.CarSightings[j].SightingDates[i] + "\t");
                        else
                            sb.Append("\t");
                    }
                    sw.WriteLine(sb.ToString());
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't write to excel export file! Error:\n" + ex.Message, Program.AppName);
                Application.Exit();
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return exportFile;
        }

        public static string ODBCDateTimeFormat(DateTime datetime)
        {
            //http://msdn.microsoft.com/en-us/library/ms190234%28SQL.90%29.aspx
            //yyyy-mm-dd hh:mm:ss[.fff]
            return String.Format("{0:yyyy-MM-dd HH:mm:ss}", datetime);
        }

        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static bool ShowQuestion(string message)
        {
            DialogResult dr = MessageBox.Show(message, Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static Image ResizeImage(Image source, int targetSize)
        {
            int targetH, targetW;
            if (source.Height > source.Width)
            {
                targetH = targetSize;
                targetW = (int)(source.Width * ((float)targetSize / (float)source.Height));
            }
            else
            {
                targetW = targetSize;
                targetH = (int)(source.Height * ((float)targetSize / (float)source.Width));
            }

            Rectangle sourceSize = new Rectangle(0,0,source.Width,source.Height);
            Bitmap newImage = new Bitmap(targetSize, targetSize, PixelFormat.Format24bppRgb);

            int logoX, logoY;
            logoX = targetSize / 2 - targetW / 2;
            logoY = targetSize / 2 - targetH / 2;

            //gr.DrawImage(newImage, new Rectangle(logoX, logoY, targetW, targetH), 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, new ImageAttributes());

            using (Graphics g = Graphics.FromImage(newImage))
            {
                //Fill with white first...
                g.FillRegion(new SolidBrush(Color.White), new Region(new Rectangle(0, 0, targetSize, targetSize)));
                //Then copy on our logo...
                g.DrawImage(source, new Rectangle(logoX, logoY, targetW, targetH), sourceSize, GraphicsUnit.Pixel);
            }

            return newImage;
        }

        public static Image ResizeImage2(string filename, int targetSize)
        {
            ImagingFactory iFactory = new ImagingFactory();
            IImage iiImage;
            IImage iiImageThumb;
            iFactory.CreateImageFromFile(filename, out iiImage);

            ImageInfo source;
            iiImage.GetImageInfo(out source);

            uint targetH, targetW;
            if (source.Height > source.Width)
            {
                targetH = (uint)targetSize;
                targetW = (uint)(source.Width * ((float)targetSize / (float)source.Height));
            }
            else
            {
                targetW = (uint)targetSize;
                targetH = (uint)(source.Height * ((float)targetSize / (float)source.Width));
            }

            iiImage.GetThumbnail(targetW, targetH, out iiImageThumb);

            IBitmapImage ibImage;
            iFactory.CreateBitmapFromImage(iiImageThumb, targetW, targetH, PixelFormat.Format24bppRgb, InterpolationHint.InterpolationHintBicubic, out ibImage);

            return (Image)ImageUtils.IBitmapImageToBitmap(ibImage);
        }
    }
}