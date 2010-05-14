namespace CarTracker
{
    partial class frmManageCar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mnuSave;

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
            this.mnuSave = new System.Windows.Forms.MainMenu();
            this.mnuRemove = new System.Windows.Forms.MenuItem();
            this.mnuClose = new System.Windows.Forms.MenuItem();
            this.lstSightings = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // mnuSave
            // 
            this.mnuSave.MenuItems.Add(this.mnuRemove);
            this.mnuSave.MenuItems.Add(this.mnuClose);
            // 
            // mnuRemove
            // 
            this.mnuRemove.Text = "Remove";
            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
            // 
            // mnuClose
            // 
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // lstSightings
            // 
            this.lstSightings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSightings.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lstSightings.FullRowSelect = true;
            this.lstSightings.Location = new System.Drawing.Point(0, 0);
            this.lstSightings.Name = "lstSightings";
            this.lstSightings.Size = new System.Drawing.Size(240, 268);
            this.lstSightings.TabIndex = 0;
            this.lstSightings.View = System.Windows.Forms.View.List;
            this.lstSightings.ItemActivate += new System.EventHandler(this.mnuRemove_Click);
            // 
            // frmManageCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lstSightings);
            this.Menu = this.mnuSave;
            this.Name = "frmManageCar";
            this.Text = "Manage Sightings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSightings;
        private System.Windows.Forms.MenuItem mnuRemove;
        private System.Windows.Forms.MenuItem mnuClose;
    }
}