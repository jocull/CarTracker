using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarTracker
{
    public partial class frmManageCar : Form
    {
        public Sightings mSighting = null;

        public frmManageCar(Sightings sighting)
        {
            InitializeComponent();
            mSighting = sighting;
            RefreshItems();
        }

        private void RefreshItems()
        {
            int previousIndex = -1;
            if (lstSightings.SelectedIndices.Count > 0)
                previousIndex = lstSightings.SelectedIndices[0];

            lstSightings.Items.Clear();
            foreach (DateTime date in mSighting.SightingDates)
            {
                ListViewItem item = new ListViewItem(date.ToString());
                item.Tag = date;
                lstSightings.Items.Add(item);
            }

            if (previousIndex > -1 && previousIndex < lstSightings.Items.Count)
            {
                lstSightings.Items[previousIndex].Selected = true;
                lstSightings.Items[previousIndex].Focused = true;
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuRemove_Click(object sender, EventArgs e)
        {
            if (lstSightings.SelectedIndices.Count > 0)
            {
                DateTime sighting = (DateTime)lstSightings.Items[lstSightings.SelectedIndices[0]].Tag;

                bool result = Program.ShowQuestion("Are you sure you want to remove this sighting?\n" + sighting);

                if (result)
                {
                    mSighting.SightingDates.Remove(sighting);
                    RefreshItems();
                }
            }
        }
    }
}