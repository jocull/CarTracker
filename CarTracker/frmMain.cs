using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace CarTracker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Text = Program.AppName;
            
            lstSightings.SmallImageList = new ImageList();
            lstSightings.SmallImageList.ImageSize = new Size(1, 1);

            OptimizeLogos();
            RefreshItems();
            setThumb();
        }

        private void RefreshItems()
        {
            int previousIndex = -1;
            if (lstSightings.SelectedIndices.Count > 0)
                previousIndex = lstSightings.SelectedIndices[0];

            //Get our car names in order before we list...
            Program.CarSightings.Sort(new SightingSorter(true));

            lstSightings.Clear();

            if (lstSightings.LargeImageList != null)
                lstSightings.LargeImageList.Dispose();

            if (lstSightings.View == View.LargeIcon)
            {
                lstSightings.LargeImageList = new ImageList();
                lstSightings.LargeImageList.ImageSize = new Size(Program.LogoSquare, Program.LogoSquare);
            }

            int imageIndex = -1;
            foreach (Sightings sighting in Program.CarSightings)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sighting.CarName + " - " + sighting.SightingDates.Count;
                item.Tag = sighting;

                if (sighting.CarLogo != null && lstSightings.View == View.LargeIcon)
                {
                    imageIndex++;
                    lstSightings.LargeImageList.Images.Add(sighting.CarLogo);
                    item.ImageIndex = imageIndex;
                }

                lstSightings.Items.Add(item);
            }

            //Reselect
            if (previousIndex > -1 && previousIndex < lstSightings.Items.Count)
            {
                lstSightings.Items[previousIndex].Selected = true;
                lstSightings.Items[previousIndex].Focused = true;
                lstSightings.EnsureVisible(previousIndex);
            }

            //Save when we refresh for safety.
            Program.WriteSightings();
        }

        private void frmMain_Closing(object sender, CancelEventArgs e)
        {
            //Form is closing down... save data!
            Program.WriteSightings();
        }

        private void mnuAddSighting_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                Sightings sighting = (Sightings)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;
                
                sighting.SightingDates.Add(DateTime.Now);

                lstSightings.Items[lstSightings.SelectedIndices[0]].Text = sighting.CarName + " - " + sighting.SightingDates.Count;
                
                //Program.ShowMessage("Sighting added!\n" + sighting.CarName + " @ " + sighting.SightingDates[sighting.SightingDates.Count - 1]);
                pctThumbsUp.Visible = true;
                lstSightings.Enabled = false;
                lstSightings.Visible = false;
                
                Program.WriteSightings();
            }
        }

        private void mnuAddCar_Click(object sender, EventArgs e)
        {
            frmAddEditCar addForm = new frmAddEditCar();
            addForm.ShowDialog();
            if (addForm.txtCarName.Text.Trim().Length > 0)
            {
                Sightings sighting = new Sightings(addForm.txtCarName.Text.Trim(), addForm.txtFilename.Text.Trim(), new List<DateTime>());
                Program.CarSightings.Add(sighting);
            }

            RefreshItems();
        }

        private void mnuEditCar_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                Sightings sighting = (Sightings)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;

                frmAddEditCar editForm = new frmAddEditCar(sighting);
                editForm.ShowDialog();
                if (editForm.mSightings != null)
                {
                    sighting.CarName = editForm.txtCarName.Text.Trim();
                    sighting.CarLogoFileName = editForm.txtFilename.Text.Trim();
                }

                RefreshItems();
            }
        }

        private void mnuRemoveCar_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                Sightings sighting = (Sightings)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;

                bool result = Program.ShowQuestion("Are you sure you want to remove this car?\n" + sighting.CarName);

                if (result)
                {
                    Program.CarSightings.Remove(sighting);
                    RefreshItems();
                }
            }
        }

        private void mnuManageSightings_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                Sightings sighting = (Sightings)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;

                if (sighting.SightingDates.Count == 0)
                {
                    Program.ShowMessage(sighting.CarName + " has no sightings.");
                    return;
                }

                frmManageCar manageForm = new frmManageCar(sighting);
                manageForm.ShowDialog();

                RefreshItems();
            }
        }

        private void mnuLogoDetail_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                Sightings sighting = (Sightings)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;

                frmLogoDetail logoForm = new frmLogoDetail(Path.Combine(Program.LogoPath, sighting.CarLogoFileName));
                logoForm.ShowDialog();
                logoForm.Dispose();
            }
        }

        private void mnuBackupDB_Click(object sender, EventArgs e)
        {
            Program.WriteSightings();
            string dbfile = Program.ExportDatabaseSightings();
            Program.ShowMessage("Sightings exported to:\n" + dbfile);
        }

        private void mnuBackupExcel_Click(object sender, EventArgs e)
        {
            Program.WriteSightings();
            string dbfile = Program.ExportExcelSightings();
            Program.ShowMessage("Sightings exported to:\n" + dbfile);
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            Program.WriteSightings();
            string dbfile = Program.SightingsBackup();
            Program.ShowMessage("Sightings backed up to:\n" + dbfile);
        }

        private void mnuClearSightings_Click(object sender, EventArgs e)
        {
            bool result = Program.ShowQuestion("Are you sure you want to clear all car sightings? THIS IS PERMANENT.");
            if (result)
            {
                foreach (Sightings sighting in Program.CarSightings)
                    sighting.SightingDates.Clear();

                RefreshItems();
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            OptimizeLogos();
            RefreshItems();
            setThumb();
        }

        private void mnuListTypeToggle_Click(object sender, EventArgs e)
        {
            if (lstSightings.View == View.LargeIcon)
                lstSightings.View = View.List;
            else
                lstSightings.View = View.LargeIcon;
            RefreshItems();
        }

        private void setThumb()
        {
            int square = 0;
            int x = 0;
            int y = 0;

            if (this.Width > this.Height)
                square = this.Height;
            else
                square = this.Width;

            pctThumbsUp.Width = square;
            pctThumbsUp.Height = square;

            x = (this.Width / 2) - (pctThumbsUp.Width / 2);
            y = (this.Height / 2) - (pctThumbsUp.Height / 2);

            pctThumbsUp.Location = new Point(x, y);
        }

        private void pctThumbsUp_Click(object sender, EventArgs e)
        {
            pctThumbsUp.Visible = false;
            lstSightings.Enabled = true;
            lstSightings.Visible = true;

            if (lstSightings.SelectedIndices.Count > 0)
            {
                lstSightings.Items[lstSightings.SelectedIndices[0]].Focused = false;
                lstSightings.Items[lstSightings.SelectedIndices[0]].Selected = true;
            }
            lstSightings.Focus();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (pctThumbsUp.Visible == true)
                pctThumbsUp_Click(null, null);
        }

        private void OptimizeLogos()
        {
            //Set logo square size.
            Program.LogoSquare = lstSightings.ClientRectangle.Width / 4; //90; //lstSightings.Width / 2 - 60;

            Image newLogo = null; //Reusable image object
            foreach (Sightings sighting in Program.CarSightings)
            {
                if (sighting.CarLogo != null)
                {
                    newLogo = null;
                    //newLogo = Program.ResizeImage(sighting.CarLogo, Program.LogoSquare);
                    newLogo = Program.ResizeImage2(Path.Combine(Program.LogoPath, sighting.CarLogoFileName), Program.LogoSquare);
                    sighting.CarLogo.Dispose();
                    sighting.CarLogo = newLogo;
                }
            }
        }

        private void mnuRemoveLast_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                Sightings sighting = (Sightings)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;

                if (sighting.SightingDates.Count == 0)
                    Program.ShowMessage(sighting.CarName + " has no sightings to remove.");
                else
                {
                    DateTime last = sighting.SightingDates[sighting.SightingDates.Count - 1];
                    bool response = Program.ShowQuestion("Are you sure you want to remove this sighting for " + sighting.CarName + "?\n" + last.ToString());
                    if (response)
                    {
                        sighting.SightingDates.Remove(last);

                        lstSightings.Items[lstSightings.SelectedIndices[0]].Text = sighting.CarName + " - " + sighting.SightingDates.Count;
                        Program.WriteSightings();
                    }
                }
            }
        }
    }
}