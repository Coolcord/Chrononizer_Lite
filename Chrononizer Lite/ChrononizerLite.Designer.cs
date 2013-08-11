namespace Chrononizer_Lite
{
    partial class ChrononizerLite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChrononizerLite));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.InfoTab = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.flpLibraryInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLibraryBytes = new System.Windows.Forms.Label();
            this.lblFileBreakdown = new System.Windows.Forms.Label();
            this.lblFLACFiles = new System.Windows.Forms.Label();
            this.lblMP3Files = new System.Windows.Forms.Label();
            this.lblM4AFiles = new System.Windows.Forms.Label();
            this.lblWMAFiles = new System.Windows.Forms.Label();
            this.lblOGGFiles = new System.Windows.Forms.Label();
            this.lblWAVFiles = new System.Windows.Forms.Label();
            this.lblXMFiles = new System.Windows.Forms.Label();
            this.lblMODFiles = new System.Windows.Forms.Label();
            this.lblNSFFiles = new System.Windows.Forms.Label();
            this.lblSongCount = new System.Windows.Forms.Label();
            this.lblLibraryFiles = new System.Windows.Forms.Label();
            this.lblChiptunesFiles = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.btnSyncDesktop = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.PreferencesTab = new System.Windows.Forms.TabPage();
            this.btnAbout = new System.Windows.Forms.Button();
            this.cbAutoExit = new System.Windows.Forms.CheckBox();
            this.btnDesktopLibraryLocation = new System.Windows.Forms.Button();
            this.cbOverrideDesktopPath = new System.Windows.Forms.CheckBox();
            this.tbDesktopLibraryLocation = new System.Windows.Forms.TextBox();
            this.lblDesktopLibraryLocation = new System.Windows.Forms.Label();
            this.tbDesktopUsername = new System.Windows.Forms.TextBox();
            this.lblDesktopUsername = new System.Windows.Forms.Label();
            this.tbDesktopHostname = new System.Windows.Forms.TextBox();
            this.lblDesktopHostname = new System.Windows.Forms.Label();
            this.cbAskSync = new System.Windows.Forms.CheckBox();
            this.btnLibraryLocation = new System.Windows.Forms.Button();
            this.lblLibraryLocation = new System.Windows.Forms.Label();
            this.tbLibraryLocation = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ScanBW = new System.ComponentModel.BackgroundWorker();
            this.DesktopSyncBW = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.InfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.flpLibraryInfo.SuspendLayout();
            this.PreferencesTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.InfoTab);
            this.tabControl.Controls.Add(this.PreferencesTab);
            this.tabControl.Location = new System.Drawing.Point(-1, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(785, 556);
            this.tabControl.TabIndex = 8;
            // 
            // InfoTab
            // 
            this.InfoTab.Controls.Add(this.splitContainer);
            this.InfoTab.Controls.Add(this.btnScan);
            this.InfoTab.Location = new System.Drawing.Point(4, 25);
            this.InfoTab.Name = "InfoTab";
            this.InfoTab.Size = new System.Drawing.Size(777, 527);
            this.InfoTab.TabIndex = 2;
            this.InfoTab.Text = "Library Info";
            this.InfoTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new System.Drawing.Point(12, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.flpLibraryInfo);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnSyncDesktop);
            this.splitContainer.Size = new System.Drawing.Size(757, 391);
            this.splitContainer.SplitterDistance = 340;
            this.splitContainer.TabIndex = 4;
            // 
            // flpLibraryInfo
            // 
            this.flpLibraryInfo.Controls.Add(this.lblLibraryBytes);
            this.flpLibraryInfo.Controls.Add(this.lblFileBreakdown);
            this.flpLibraryInfo.Controls.Add(this.lblFLACFiles);
            this.flpLibraryInfo.Controls.Add(this.lblMP3Files);
            this.flpLibraryInfo.Controls.Add(this.lblM4AFiles);
            this.flpLibraryInfo.Controls.Add(this.lblWMAFiles);
            this.flpLibraryInfo.Controls.Add(this.lblOGGFiles);
            this.flpLibraryInfo.Controls.Add(this.lblWAVFiles);
            this.flpLibraryInfo.Controls.Add(this.lblXMFiles);
            this.flpLibraryInfo.Controls.Add(this.lblMODFiles);
            this.flpLibraryInfo.Controls.Add(this.lblNSFFiles);
            this.flpLibraryInfo.Controls.Add(this.lblSongCount);
            this.flpLibraryInfo.Controls.Add(this.lblLibraryFiles);
            this.flpLibraryInfo.Controls.Add(this.lblChiptunesFiles);
            this.flpLibraryInfo.Controls.Add(this.lblTotalFiles);
            this.flpLibraryInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLibraryInfo.Location = new System.Drawing.Point(3, 31);
            this.flpLibraryInfo.Name = "flpLibraryInfo";
            this.flpLibraryInfo.Size = new System.Drawing.Size(334, 357);
            this.flpLibraryInfo.TabIndex = 4;
            // 
            // lblLibraryBytes
            // 
            this.lblLibraryBytes.AutoSize = true;
            this.lblLibraryBytes.Location = new System.Drawing.Point(3, 0);
            this.lblLibraryBytes.Name = "lblLibraryBytes";
            this.lblLibraryBytes.Size = new System.Drawing.Size(137, 17);
            this.lblLibraryBytes.TabIndex = 0;
            this.lblLibraryBytes.Text = "Library Size: 0 bytes";
            // 
            // lblFileBreakdown
            // 
            this.lblFileBreakdown.AutoSize = true;
            this.lblFileBreakdown.Location = new System.Drawing.Point(3, 37);
            this.lblFileBreakdown.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.lblFileBreakdown.Name = "lblFileBreakdown";
            this.lblFileBreakdown.Size = new System.Drawing.Size(108, 17);
            this.lblFileBreakdown.TabIndex = 22;
            this.lblFileBreakdown.Text = "File Breakdown:";
            // 
            // lblFLACFiles
            // 
            this.lblFLACFiles.AutoSize = true;
            this.lblFLACFiles.Location = new System.Drawing.Point(3, 54);
            this.lblFLACFiles.Name = "lblFLACFiles";
            this.lblFLACFiles.Size = new System.Drawing.Size(87, 17);
            this.lblFLACFiles.TabIndex = 4;
            this.lblFLACFiles.Text = "FLAC: 0 files";
            // 
            // lblMP3Files
            // 
            this.lblMP3Files.AutoSize = true;
            this.lblMP3Files.Location = new System.Drawing.Point(3, 71);
            this.lblMP3Files.Name = "lblMP3Files";
            this.lblMP3Files.Size = new System.Drawing.Size(81, 17);
            this.lblMP3Files.TabIndex = 5;
            this.lblMP3Files.Text = "MP3: 0 files";
            // 
            // lblM4AFiles
            // 
            this.lblM4AFiles.AutoSize = true;
            this.lblM4AFiles.Location = new System.Drawing.Point(3, 88);
            this.lblM4AFiles.Name = "lblM4AFiles";
            this.lblM4AFiles.Size = new System.Drawing.Size(81, 17);
            this.lblM4AFiles.TabIndex = 7;
            this.lblM4AFiles.Text = "M4A: 0 files";
            // 
            // lblWMAFiles
            // 
            this.lblWMAFiles.AutoSize = true;
            this.lblWMAFiles.Location = new System.Drawing.Point(3, 105);
            this.lblWMAFiles.Name = "lblWMAFiles";
            this.lblWMAFiles.Size = new System.Drawing.Size(86, 17);
            this.lblWMAFiles.TabIndex = 6;
            this.lblWMAFiles.Text = "WMA: 0 files";
            // 
            // lblOGGFiles
            // 
            this.lblOGGFiles.AutoSize = true;
            this.lblOGGFiles.Location = new System.Drawing.Point(3, 122);
            this.lblOGGFiles.Name = "lblOGGFiles";
            this.lblOGGFiles.Size = new System.Drawing.Size(86, 17);
            this.lblOGGFiles.TabIndex = 8;
            this.lblOGGFiles.Text = "OGG: 0 files";
            // 
            // lblWAVFiles
            // 
            this.lblWAVFiles.AutoSize = true;
            this.lblWAVFiles.Location = new System.Drawing.Point(3, 139);
            this.lblWAVFiles.Name = "lblWAVFiles";
            this.lblWAVFiles.Size = new System.Drawing.Size(84, 17);
            this.lblWAVFiles.TabIndex = 9;
            this.lblWAVFiles.Text = "WAV: 0 files";
            // 
            // lblXMFiles
            // 
            this.lblXMFiles.AutoSize = true;
            this.lblXMFiles.Location = new System.Drawing.Point(3, 156);
            this.lblXMFiles.Name = "lblXMFiles";
            this.lblXMFiles.Size = new System.Drawing.Size(73, 17);
            this.lblXMFiles.TabIndex = 10;
            this.lblXMFiles.Text = "XM: 0 files";
            // 
            // lblMODFiles
            // 
            this.lblMODFiles.AutoSize = true;
            this.lblMODFiles.Location = new System.Drawing.Point(3, 173);
            this.lblMODFiles.Name = "lblMODFiles";
            this.lblMODFiles.Size = new System.Drawing.Size(85, 17);
            this.lblMODFiles.TabIndex = 11;
            this.lblMODFiles.Text = "MOD: 0 files";
            // 
            // lblNSFFiles
            // 
            this.lblNSFFiles.AutoSize = true;
            this.lblNSFFiles.Location = new System.Drawing.Point(3, 190);
            this.lblNSFFiles.Name = "lblNSFFiles";
            this.lblNSFFiles.Size = new System.Drawing.Size(80, 17);
            this.lblNSFFiles.TabIndex = 12;
            this.lblNSFFiles.Text = "NSF: 0 files";
            // 
            // lblSongCount
            // 
            this.lblSongCount.AutoSize = true;
            this.lblSongCount.Location = new System.Drawing.Point(3, 227);
            this.lblSongCount.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.lblSongCount.Name = "lblSongCount";
            this.lblSongCount.Size = new System.Drawing.Size(86, 17);
            this.lblSongCount.TabIndex = 23;
            this.lblSongCount.Text = "Song Count:";
            // 
            // lblLibraryFiles
            // 
            this.lblLibraryFiles.AutoSize = true;
            this.lblLibraryFiles.Location = new System.Drawing.Point(3, 244);
            this.lblLibraryFiles.Name = "lblLibraryFiles";
            this.lblLibraryFiles.Size = new System.Drawing.Size(110, 17);
            this.lblLibraryFiles.TabIndex = 13;
            this.lblLibraryFiles.Text = "Library: 0 songs";
            // 
            // lblChiptunesFiles
            // 
            this.lblChiptunesFiles.AutoSize = true;
            this.lblChiptunesFiles.Location = new System.Drawing.Point(3, 261);
            this.lblChiptunesFiles.Name = "lblChiptunesFiles";
            this.lblChiptunesFiles.Size = new System.Drawing.Size(129, 17);
            this.lblChiptunesFiles.TabIndex = 14;
            this.lblChiptunesFiles.Text = "Chiptunes: 0 songs";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(3, 278);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(98, 17);
            this.lblTotalFiles.TabIndex = 15;
            this.lblTotalFiles.Text = "Total: 0 songs";
            // 
            // btnSyncDesktop
            // 
            this.btnSyncDesktop.Location = new System.Drawing.Point(3, 120);
            this.btnSyncDesktop.Name = "btnSyncDesktop";
            this.btnSyncDesktop.Size = new System.Drawing.Size(407, 151);
            this.btnSyncDesktop.TabIndex = 3;
            this.btnSyncDesktop.Text = "Upload new files to Desktop";
            this.btnSyncDesktop.UseVisualStyleBackColor = true;
            this.btnSyncDesktop.Click += new System.EventHandler(this.btnSyncDesktop_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(11, 401);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(758, 118);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Scan Library";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // PreferencesTab
            // 
            this.PreferencesTab.Controls.Add(this.btnAbout);
            this.PreferencesTab.Controls.Add(this.cbAutoExit);
            this.PreferencesTab.Controls.Add(this.btnDesktopLibraryLocation);
            this.PreferencesTab.Controls.Add(this.cbOverrideDesktopPath);
            this.PreferencesTab.Controls.Add(this.tbDesktopLibraryLocation);
            this.PreferencesTab.Controls.Add(this.lblDesktopLibraryLocation);
            this.PreferencesTab.Controls.Add(this.tbDesktopUsername);
            this.PreferencesTab.Controls.Add(this.lblDesktopUsername);
            this.PreferencesTab.Controls.Add(this.tbDesktopHostname);
            this.PreferencesTab.Controls.Add(this.lblDesktopHostname);
            this.PreferencesTab.Controls.Add(this.cbAskSync);
            this.PreferencesTab.Controls.Add(this.btnLibraryLocation);
            this.PreferencesTab.Controls.Add(this.lblLibraryLocation);
            this.PreferencesTab.Controls.Add(this.tbLibraryLocation);
            this.PreferencesTab.Location = new System.Drawing.Point(4, 25);
            this.PreferencesTab.Name = "PreferencesTab";
            this.PreferencesTab.Size = new System.Drawing.Size(777, 527);
            this.PreferencesTab.TabIndex = 3;
            this.PreferencesTab.Text = "Preferences";
            this.PreferencesTab.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(360, 119);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(407, 151);
            this.btnAbout.TabIndex = 38;
            this.btnAbout.Text = "About Chrononizer Lite";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // cbAutoExit
            // 
            this.cbAutoExit.AutoSize = true;
            this.cbAutoExit.Location = new System.Drawing.Point(12, 337);
            this.cbAutoExit.Name = "cbAutoExit";
            this.cbAutoExit.Size = new System.Drawing.Size(428, 21);
            this.cbAutoExit.TabIndex = 36;
            this.cbAutoExit.Text = "Automatically exit Chrononizer upon successful synchronization";
            this.cbAutoExit.UseVisualStyleBackColor = true;
            this.cbAutoExit.CheckedChanged += new System.EventHandler(this.cbAutoExit_CheckedChanged);
            // 
            // btnDesktopLibraryLocation
            // 
            this.btnDesktopLibraryLocation.Enabled = false;
            this.btnDesktopLibraryLocation.Location = new System.Drawing.Point(302, 282);
            this.btnDesktopLibraryLocation.Name = "btnDesktopLibraryLocation";
            this.btnDesktopLibraryLocation.Size = new System.Drawing.Size(31, 23);
            this.btnDesktopLibraryLocation.TabIndex = 34;
            this.btnDesktopLibraryLocation.Text = "...";
            this.btnDesktopLibraryLocation.UseVisualStyleBackColor = true;
            this.btnDesktopLibraryLocation.Click += new System.EventHandler(this.btnDesktopLibraryLocation_Click);
            // 
            // cbOverrideDesktopPath
            // 
            this.cbOverrideDesktopPath.AutoSize = true;
            this.cbOverrideDesktopPath.Location = new System.Drawing.Point(12, 238);
            this.cbOverrideDesktopPath.Name = "cbOverrideDesktopPath";
            this.cbOverrideDesktopPath.Size = new System.Drawing.Size(174, 21);
            this.cbOverrideDesktopPath.TabIndex = 32;
            this.cbOverrideDesktopPath.Text = "Override Desktop Path";
            this.cbOverrideDesktopPath.UseVisualStyleBackColor = true;
            this.cbOverrideDesktopPath.CheckedChanged += new System.EventHandler(this.cbOverrideDesktopPath_CheckedChanged);
            // 
            // tbDesktopLibraryLocation
            // 
            this.tbDesktopLibraryLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDesktopLibraryLocation.Enabled = false;
            this.tbDesktopLibraryLocation.Location = new System.Drawing.Point(12, 282);
            this.tbDesktopLibraryLocation.Name = "tbDesktopLibraryLocation";
            this.tbDesktopLibraryLocation.ReadOnly = true;
            this.tbDesktopLibraryLocation.Size = new System.Drawing.Size(284, 22);
            this.tbDesktopLibraryLocation.TabIndex = 28;
            this.tbDesktopLibraryLocation.Click += new System.EventHandler(this.tbDesktopLibraryLocation_Click);
            this.tbDesktopLibraryLocation.TextChanged += new System.EventHandler(this.tbDesktopLibraryLocation_TextChanged);
            // 
            // lblDesktopLibraryLocation
            // 
            this.lblDesktopLibraryLocation.AutoSize = true;
            this.lblDesktopLibraryLocation.Enabled = false;
            this.lblDesktopLibraryLocation.Location = new System.Drawing.Point(9, 262);
            this.lblDesktopLibraryLocation.Name = "lblDesktopLibraryLocation";
            this.lblDesktopLibraryLocation.Size = new System.Drawing.Size(122, 17);
            this.lblDesktopLibraryLocation.TabIndex = 27;
            this.lblDesktopLibraryLocation.Text = "Desktop Location:";
            // 
            // tbDesktopUsername
            // 
            this.tbDesktopUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDesktopUsername.Location = new System.Drawing.Point(12, 210);
            this.tbDesktopUsername.Name = "tbDesktopUsername";
            this.tbDesktopUsername.Size = new System.Drawing.Size(284, 22);
            this.tbDesktopUsername.TabIndex = 22;
            this.tbDesktopUsername.TextChanged += new System.EventHandler(this.tbDesktopUsername_TextChanged);
            // 
            // lblDesktopUsername
            // 
            this.lblDesktopUsername.AutoSize = true;
            this.lblDesktopUsername.Location = new System.Drawing.Point(9, 190);
            this.lblDesktopUsername.Name = "lblDesktopUsername";
            this.lblDesktopUsername.Size = new System.Drawing.Size(133, 17);
            this.lblDesktopUsername.TabIndex = 21;
            this.lblDesktopUsername.Text = "Desktop Username:";
            // 
            // tbDesktopHostname
            // 
            this.tbDesktopHostname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDesktopHostname.Location = new System.Drawing.Point(12, 165);
            this.tbDesktopHostname.Name = "tbDesktopHostname";
            this.tbDesktopHostname.Size = new System.Drawing.Size(284, 22);
            this.tbDesktopHostname.TabIndex = 20;
            this.tbDesktopHostname.TextChanged += new System.EventHandler(this.tbDesktopHostname_TextChanged);
            // 
            // lblDesktopHostname
            // 
            this.lblDesktopHostname.AutoSize = true;
            this.lblDesktopHostname.Location = new System.Drawing.Point(9, 145);
            this.lblDesktopHostname.Name = "lblDesktopHostname";
            this.lblDesktopHostname.Size = new System.Drawing.Size(132, 17);
            this.lblDesktopHostname.TabIndex = 19;
            this.lblDesktopHostname.Text = "Desktop Hostname:";
            // 
            // cbAskSync
            // 
            this.cbAskSync.AutoSize = true;
            this.cbAskSync.Location = new System.Drawing.Point(12, 310);
            this.cbAskSync.Name = "cbAskSync";
            this.cbAskSync.Size = new System.Drawing.Size(235, 21);
            this.cbAskSync.TabIndex = 17;
            this.cbAskSync.Text = "Always ask before synchronizing";
            this.cbAskSync.UseVisualStyleBackColor = true;
            this.cbAskSync.CheckedChanged += new System.EventHandler(this.cbAskSync_CheckedChanged);
            // 
            // btnLibraryLocation
            // 
            this.btnLibraryLocation.Location = new System.Drawing.Point(302, 119);
            this.btnLibraryLocation.Name = "btnLibraryLocation";
            this.btnLibraryLocation.Size = new System.Drawing.Size(31, 23);
            this.btnLibraryLocation.TabIndex = 2;
            this.btnLibraryLocation.Text = "...";
            this.btnLibraryLocation.UseVisualStyleBackColor = true;
            this.btnLibraryLocation.Click += new System.EventHandler(this.btnLibraryLocation_Click);
            // 
            // lblLibraryLocation
            // 
            this.lblLibraryLocation.AutoSize = true;
            this.lblLibraryLocation.Location = new System.Drawing.Point(9, 100);
            this.lblLibraryLocation.Name = "lblLibraryLocation";
            this.lblLibraryLocation.Size = new System.Drawing.Size(154, 17);
            this.lblLibraryLocation.TabIndex = 1;
            this.lblLibraryLocation.Text = "Music Library Location:";
            // 
            // tbLibraryLocation
            // 
            this.tbLibraryLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLibraryLocation.Location = new System.Drawing.Point(12, 120);
            this.tbLibraryLocation.Name = "tbLibraryLocation";
            this.tbLibraryLocation.ReadOnly = true;
            this.tbLibraryLocation.Size = new System.Drawing.Size(284, 22);
            this.tbLibraryLocation.TabIndex = 0;
            this.tbLibraryLocation.Click += new System.EventHandler(this.tbLibraryLocation_Click);
            this.tbLibraryLocation.TextChanged += new System.EventHandler(this.tbLibraryLocation_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 556);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(7, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(771, 537);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // ScanBW
            // 
            this.ScanBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ScanBW_DoWork);
            // 
            // DesktopSyncBW
            // 
            this.DesktopSyncBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DesktopSyncBW_DoWork);
            // 
            // ChrononizerLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(782, 555);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChrononizerLite";
            this.Text = "Chrononizer Lite";
            this.Load += new System.EventHandler(this.Chrononizer_Lite_Load);
            this.tabControl.ResumeLayout(false);
            this.InfoTab.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.flpLibraryInfo.ResumeLayout(false);
            this.flpLibraryInfo.PerformLayout();
            this.PreferencesTab.ResumeLayout(false);
            this.PreferencesTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage InfoTab;
        private System.Windows.Forms.TabPage PreferencesTab;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.FlowLayoutPanel flpLibraryInfo;
        private System.Windows.Forms.Label lblLibraryBytes;
        private System.Windows.Forms.Label lblFileBreakdown;
        private System.Windows.Forms.Label lblFLACFiles;
        private System.Windows.Forms.Label lblMP3Files;
        private System.Windows.Forms.Label lblWMAFiles;
        private System.Windows.Forms.Label lblM4AFiles;
        private System.Windows.Forms.Label lblOGGFiles;
        private System.Windows.Forms.Label lblWAVFiles;
        private System.Windows.Forms.Label lblXMFiles;
        private System.Windows.Forms.Label lblMODFiles;
        private System.Windows.Forms.Label lblNSFFiles;
        private System.Windows.Forms.Label lblSongCount;
        private System.Windows.Forms.Label lblLibraryFiles;
        private System.Windows.Forms.Label lblChiptunesFiles;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Button btnLibraryLocation;
        private System.Windows.Forms.Label lblLibraryLocation;
        private System.Windows.Forms.TextBox tbLibraryLocation;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker DesktopSyncBW;
        public System.ComponentModel.BackgroundWorker ScanBW;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox tbDesktopLibraryLocation;
        private System.Windows.Forms.Label lblDesktopLibraryLocation;
        private System.Windows.Forms.TextBox tbDesktopUsername;
        private System.Windows.Forms.Label lblDesktopUsername;
        private System.Windows.Forms.TextBox tbDesktopHostname;
        private System.Windows.Forms.Label lblDesktopHostname;
        private System.Windows.Forms.CheckBox cbAskSync;
        private System.Windows.Forms.CheckBox cbOverrideDesktopPath;
        private System.Windows.Forms.Button btnDesktopLibraryLocation;
        private System.Windows.Forms.CheckBox cbAutoExit;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSyncDesktop;
    }
}

