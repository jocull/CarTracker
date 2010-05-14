using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarTracker
{
    public partial class frmAddEditCar : Form
    {
        public Sightings mSightings = null;

        public frmAddEditCar()
        {
            InitializeComponent();
        }

        public frmAddEditCar(Sightings sightingObj)
        {
            InitializeComponent();
            txtCarName.Text = sightingObj.CarName;
            txtFilename.Text = sightingObj.CarLogoFileName;
            mSightings = sightingObj;
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            txtCarName.Text = "";
            txtFilename.Text = "";
            mSightings = null;
            this.Close();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}