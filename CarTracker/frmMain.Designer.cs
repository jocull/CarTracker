namespace CarTracker
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuAddSighting = new System.Windows.Forms.MenuItem();
            this.mnuMenu = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuAddCar = new System.Windows.Forms.MenuItem();
            this.mnuEditCar = new System.Windows.Forms.MenuItem();
            this.mnuRemoveCar = new System.Windows.Forms.MenuItem();
            this.mnuManageSightings = new System.Windows.Forms.MenuItem();
            this.mnuLogoDetail = new System.Windows.Forms.MenuItem();
            this.mnuClearSightings = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuBackup = new System.Windows.Forms.MenuItem();
            this.mnuBackupDB = new System.Windows.Forms.MenuItem();
            this.mnuBackupExcel = new System.Windows.Forms.MenuItem();
            this.mnuListTypeToggle = new System.Windows.Forms.MenuItem();
            this.lstSightings = new System.Windows.Forms.ListView();
            this.pctThumbsUp = new System.Windows.Forms.PictureBox();
            this.mnuRemoveLast = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuAddSighting);
            this.mainMenu1.MenuItems.Add(this.mnuMenu);
            // 
            // mnuAddSighting
            // 
            this.mnuAddSighting.Text = "Add Sighting";
            this.mnuAddSighting.Click += new System.EventHandler(this.mnuAddSighting_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.MenuItems.Add(this.menuItem1);
            this.mnuMenu.MenuItems.Add(this.mnuLogoDetail);
            this.mnuMenu.MenuItems.Add(this.mnuClearSightings);
            this.mnuMenu.MenuItems.Add(this.menuItem2);
            this.mnuMenu.MenuItems.Add(this.mnuListTypeToggle);
            this.mnuMenu.Text = "Menu";
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.mnuAddCar);
            this.menuItem1.MenuItems.Add(this.mnuEditCar);
            this.menuItem1.MenuItems.Add(this.mnuRemoveCar);
            this.menuItem1.MenuItems.Add(this.mnuManageSightings);
            this.menuItem1.MenuItems.Add(this.mnuRemoveLast);
            this.menuItem1.Text = "Manage Cars";
            // 
            // mnuAddCar
            // 
            this.mnuAddCar.Text = "Add Car";
            this.mnuAddCar.Click += new System.EventHandler(this.mnuAddCar_Click);
            // 
            // mnuEditCar
            // 
            this.mnuEditCar.Text = "Edit Car";
            this.mnuEditCar.Click += new System.EventHandler(this.mnuEditCar_Click);
            // 
            // mnuRemoveCar
            // 
            this.mnuRemoveCar.Text = "Remove Car";
            this.mnuRemoveCar.Click += new System.EventHandler(this.mnuRemoveCar_Click);
            // 
            // mnuManageSightings
            // 
            this.mnuManageSightings.Text = "Manage Sightings";
            this.mnuManageSightings.Click += new System.EventHandler(this.mnuManageSightings_Click);
            // 
            // mnuLogoDetail
            // 
            this.mnuLogoDetail.Text = "View Logo Detail";
            this.mnuLogoDetail.Click += new System.EventHandler(this.mnuLogoDetail_Click);
            // 
            // mnuClearSightings
            // 
            this.mnuClearSightings.Text = "Clear All Sightings";
            this.mnuClearSightings.Click += new System.EventHandler(this.mnuClearSightings_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.mnuBackup);
            this.menuItem2.MenuItems.Add(this.mnuBackupDB);
            this.menuItem2.MenuItems.Add(this.mnuBackupExcel);
            this.menuItem2.Text = "Backup and Export";
            // 
            // mnuBackup
            // 
            this.mnuBackup.Text = "Backup Sightings";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // mnuBackupDB
            // 
            this.mnuBackupDB.Text = "Export Sightings to DB";
            this.mnuBackupDB.Click += new System.EventHandler(this.mnuBackupDB_Click);
            // 
            // mnuBackupExcel
            // 
            this.mnuBackupExcel.Text = "Export Sightings to Excel";
            this.mnuBackupExcel.Click += new System.EventHandler(this.mnuBackupExcel_Click);
            // 
            // mnuListTypeToggle
            // 
            this.mnuListTypeToggle.Text = "Toggle Logo View";
            this.mnuListTypeToggle.Click += new System.EventHandler(this.mnuListTypeToggle_Click);
            // 
            // lstSightings
            // 
            this.lstSightings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSightings.FullRowSelect = true;
            this.lstSightings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSightings.Location = new System.Drawing.Point(0, 0);
            this.lstSightings.Name = "lstSightings";
            this.lstSightings.Size = new System.Drawing.Size(240, 268);
            this.lstSightings.TabIndex = 1;
            this.lstSightings.ItemActivate += new System.EventHandler(this.mnuAddSighting_Click);
            // 
            // pctThumbsUp
            // 
            this.pctThumbsUp.BackColor = System.Drawing.Color.White;
            this.pctThumbsUp.Image = ((System.Drawing.Image)(resources.GetObject("pctThumbsUp.Image")));
            this.pctThumbsUp.Location = new System.Drawing.Point(48, 58);
            this.pctThumbsUp.Name = "pctThumbsUp";
            this.pctThumbsUp.Size = new System.Drawing.Size(150, 150);
            this.pctThumbsUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctThumbsUp.Visible = false;
            this.pctThumbsUp.Click += new System.EventHandler(this.pctThumbsUp_Click);
            // 
            // mnuRemoveLast
            // 
            this.mnuRemoveLast.Text = "Remove Last Sighting";
            this.mnuRemoveLast.Click += new System.EventHandler(this.mnuRemoveLast_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pctThumbsUp);
            this.Controls.Add(this.lstSightings);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "Car Tracker!";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuAddSighting;
        private System.Windows.Forms.MenuItem mnuMenu;
        private System.Windows.Forms.MenuItem mnuAddCar;
        private System.Windows.Forms.ListView lstSightings;
        private System.Windows.Forms.MenuItem mnuManageSightings;
        private System.Windows.Forms.MenuItem mnuEditCar;
        private System.Windows.Forms.MenuItem mnuRemoveCar;
        private System.Windows.Forms.MenuItem mnuBackupDB;
        private System.Windows.Forms.MenuItem mnuClearSightings;
        private System.Windows.Forms.MenuItem mnuBackup;
        private System.Windows.Forms.MenuItem mnuBackupExcel;
        private System.Windows.Forms.MenuItem mnuLogoDetail;
        private System.Windows.Forms.MenuItem mnuListTypeToggle;
        private System.Windows.Forms.PictureBox pctThumbsUp;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuRemoveLast;
    }
}

