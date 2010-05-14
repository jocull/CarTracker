namespace CarTracker
{
    partial class frmLogoDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuClose = new System.Windows.Forms.MenuItem();
            this.pctImage = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuClose);
            // 
            // mnuClose
            // 
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // pctImage
            // 
            this.pctImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pctImage.Location = new System.Drawing.Point(0, 0);
            this.pctImage.Name = "pctImage";
            this.pctImage.Size = new System.Drawing.Size(240, 268);
            this.pctImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // frmLogoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pctImage);
            this.Menu = this.mainMenu1;
            this.Name = "frmLogoDetail";
            this.Text = "Logo Detail View";
            this.Resize += new System.EventHandler(this.frmLogoDetail_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctImage;
        private System.Windows.Forms.MenuItem mnuClose;
    }
}