using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace CarTracker
{
    public class Sightings
    {
        public string CarName;
        private string _carLogoFileName = "";
        public string CarLogoFileName
        {
            get
            {
                return _carLogoFileName;
            }
            set
            {
                _carLogoFileName = value;
                if (value != null && value.Length > 0 && File.Exists(Path.Combine(Program.LogoPath, value)))
                    this.CarLogo = new Bitmap(Path.Combine(Program.LogoPath, value));
                else
                    this.CarLogo = new Bitmap(Path.Combine(Program.LogoPath, "unknown.jpg"));
            }
        }
        public Image CarLogo;
        public List<DateTime> SightingDates = new List<DateTime>();

        public Sightings()
        {
        }

        public Sightings(string deserialize)
        {
            string[] split = deserialize.Split('\t');
            this.CarName = split[0];
            if (split.Length > 1 && split[1].Trim().Length > 0) //Has image?
            {
                this.CarLogoFileName = split[1];
            }
            else
            {
                //Load default image.
                this.CarLogo = new Bitmap(Path.Combine(Program.LogoPath, "unknown.jpg"));
            }

            for (int i = 2; i < split.Length; i++)
            {
                this.SightingDates.Add(new DateTime(long.Parse(split[i])));
            }
        }

        public Sightings(string car, string logoFilename, List<DateTime> dates)
        {
            this.CarName = car;
            this.CarLogoFileName = logoFilename;
            this.SightingDates = dates;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder(CarName);

            sb.Append("\t" + CarLogoFileName);

            foreach (DateTime date in SightingDates)
                sb.Append("\t" + date.Ticks.ToString());
            
            return sb.ToString();            
        }
    }
}
