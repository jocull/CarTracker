using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarTracker
{
    public partial class frmLogoDetail : Form
    {
        private Image mSourceImage;

        public frmLogoDetail()
        {
            InitializeComponent();
        }

        public frmLogoDetail(string imgPath)
        {
            mSourceImage = (Image)(new Bitmap(imgPath));
            InitializeComponent();
        }

        private int setThumb()
        {
            int square = 0;
            int x = 0;
            int y = 0;

            if (this.Width > this.Height)
                square = this.Height;
            else
                square = this.Width;

            pctImage.Width = square;
            pctImage.Height = square;

            x = (this.Width / 2) - (pctImage.Width / 2);
            y = (this.Height / 2) - (pctImage.Height / 2);

            pctImage.Location = new Point(x, y);

            return square;
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogoDetail_Resize(object sender, EventArgs e)
        {
            int target = setThumb();
            if (mSourceImage.Width > pctImage.Width || mSourceImage.Height > pctImage.Height)
                pctImage.Image = Program.ResizeImage(mSourceImage, target);
            else
                pctImage.Image = mSourceImage;
        }
    }
}