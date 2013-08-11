/* -========================- License and Distribution -========================-
 * 
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

/* -=========================- About Chrononizer Lite -=========================-
 *  
 *  Chrononizer Lite is based off of Chrononizer v1.0.2. The goal of this project 
 *  was to make an application that could be used on a computer which is using
 *  a secondary music library. In this case, that computer is my laptop. With
 *  Chrononizer Lite, the laptop can now send any new files it has in its library
 *  to the primary music library, which in this case is the desktop.
 *  
 *  Using this application, if I download a new song on my laptop, all I have to
 *  do is put the new song in my laptop's music library. Then, once I am able to 
 *  connect to my desktop over the network, I can use Chrononizer Lite to send
 *  these new songs to my desktop's music library. Unlike Chrononizer,
 *  Chrononizer Lite does not delete any old files -- it only copies new ones.
 *  
 *  Like Chrononizer, Chrononizer Lite is intended for my own personal use.
 *  However, I intend to keep it open source. If anyone else wants to build
 *  something similar, they'll have the option of using my source code as a base.
 * 
 *  If you wish to contact me about the application, or anything of the like,
 *  feel free to send me an email at coolcord24@gmail.com
 */

/* -================================- Credits -================================-
 *  
 *  The following files included with Chrononizer (though some modified)
 *  were not originally created by me. Credit shall be given where it is due!
 * 
 *  AaawYeah.wav:
 *      Original sound effect from My Little Pony: Friendship is Magic © Hasbro
 *      
 *  ChronoBoost.wav:
 *      Original sound effect from StarCraft II © Blizzard
 *      
 *  chrononizer.ico:
 *      Icon ripped from StarCraft II © Blizzard
 *      
 *  Luminescence.Xiph.dll:
 *      Library by Cyber_Sinh released under LGPL license
 * 
 *  OhNo.wav:
 *      Sound effect provided with IMGBurn
 *      
 *  ScannerSweep.wav:
 *      Original sound effect from StarCraft II © Blizzard
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;
using System.Media;

namespace Chrononizer_Lite
{
    public partial class ChrononizerLite : Form
    {
        #region Initialization and Startup
        private string DesktopHostname = " ";
        private string DesktopLibraryLocation = " ";
        private string DesktopUsername = " ";
        private string MusicLibrary = " ";

        Boolean AskSync = true;
        Boolean AutoExit = false;
        Boolean DesktopSyncSuccess = true;
        Boolean OverrideDesktopPath = false;

        Dictionary<string, Boolean> checkedFiles = new Dictionary<string, Boolean>();

        FlowLayoutPanel DTflow;
        Label lblDTStatus, lblDTProgress;
        ListBox lbDT;
        ProgressBar pbDT;

        public struct UpdateLocation
        {
            public string SourceFile;
            public string DestinationFile;
        }

        public ChrononizerLite()
        {
            InitializeComponent();
        }

        private void Chrononizer_Lite_Load(object sender, EventArgs e)
        {
            Form ChrononizerLite = this;
            ChrononizerLite.FormBorderStyle = FormBorderStyle.FixedDialog;

            if (!Properties.Settings.Default.FirstBoot)
            {
                //Load saved settings. Order is important!
                cbOverrideDesktopPath.Checked = Properties.Settings.Default.OverrideDesktopPath;
                tbLibraryLocation.Text = Properties.Settings.Default.MusicLibrary;
                tbDesktopHostname.Text = Properties.Settings.Default.DesktopHostname;
                tbDesktopUsername.Text = Properties.Settings.Default.DesktopUsername;
                tbDesktopLibraryLocation.Text = Properties.Settings.Default.DesktopLibraryLocation;
                cbAskSync.Checked = Properties.Settings.Default.AskSync;
                cbAutoExit.Checked = Properties.Settings.Default.AutoExit;
            }
            else
            {
                //first time launching application
                Properties.Settings.Default.FirstBoot = false;

                //attempt to find the music library
                string drive = Environment.GetFolderPath(Environment.SpecialFolder.System);
                drive = drive.Substring(0, 1); //get drive letter
                string username = WindowsIdentity.GetCurrent().Name.Split('\\')[1]; //get username from login

                //Load default settings. Order is important!
                cbOverrideDesktopPath.Checked = Properties.Settings.Default.OverrideDesktopPath;
                tbLibraryLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\";
                tbDesktopHostname.Text = "Desktop";
                tbDesktopUsername.Text = Environment.UserName; //assume that the Desktop's username is the same as the user running the app
                tbDesktopLibraryLocation.Text = "\\\\" + DesktopHostname + "\\Users\\" + DesktopUsername + "\\Music\\";
                cbAskSync.Checked = Properties.Settings.Default.AskSync;
                cbAutoExit.Checked = Properties.Settings.Default.AutoExit;

                Properties.Settings.Default.Save();

                DialogResult result = MessageBox.Show("It is highly recommended that you check and configure your preferences before you use Chrononizer Lite.\n\nWould you like to do so now?", "Welcome to Chrononizer Lite!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) tabControl.SelectedTab = PreferencesTab; //show the preferences tab
            }

            //store the values
            MusicLibrary = tbLibraryLocation.Text;
            DesktopLibraryLocation = tbDesktopLibraryLocation.Text;
            DesktopHostname = tbDesktopHostname.Text;
            DesktopUsername = tbDesktopUsername.Text;
            AskSync = cbAskSync.Checked;
            OverrideDesktopPath = cbOverrideDesktopPath.Checked;
            AutoExit = cbAutoExit.Checked;
        }


        #endregion

        #region Interface Event Handlers
        //===========================================================================
        //
        // Interface Event Handlers
        //
        //===========================================================================

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Form aboutForm = new Form() { FormBorderStyle = FormBorderStyle.FixedSingle, MinimizeBox = false, MaximizeBox = false };
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.Width = 400;
            aboutForm.Height = 200;
            aboutForm.Text = "About Chrononizer Lite";
            aboutForm.Icon = Properties.Resources.ChrononizerLite;

            //Get the version number
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            Label aboutText = new Label()
            {
                Width = 400,
                Height = 130,
                Location = new Point(0, 0),
                ImageAlign = ContentAlignment.MiddleCenter,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Chrononizer Lite v" + fileVersionInfo.ProductMajorPart + "." + fileVersionInfo.ProductMinorPart + "." + fileVersionInfo.ProductBuildPart +
                    "\nBased off of Chrononizer v1.0.2\n\n" +
                    "Upload Files to Your Primary Music Library\n\n" +
                    "Programmed and Designed by Coolcord"
            };
            Font aboutFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            aboutText.Font = aboutFont;
            Button btnOk = new Button() { Width = 100, Height = 30, Text = "OK", Location = new Point(150, 130), ImageAlign = ContentAlignment.MiddleCenter, TextAlign = ContentAlignment.MiddleCenter };
            btnOk.Click += (btnSender, btnE) => aboutForm.Close(); //click ok to close
            aboutForm.AcceptButton = btnOk;
            aboutForm.Controls.Add(aboutText);
            aboutForm.Controls.Add(btnOk);
            aboutForm.ShowDialog();
            aboutForm.Dispose();
            btnOk.Dispose();
            aboutText.Dispose();
            aboutFont.Dispose();
        }

        private void btnChiptunesLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(3);
        }

        private void btnDownscaledLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(2);
        }

        private void btnDesktopLibraryLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(5);
        }

        private void btnLibraryLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(1);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!AreBackgroundWorkersRunning())
            {
                if (!DoLibrariesExist()) return;
                btnScan.Text = "Scanning...";
                ScanBW.RunWorkerAsync();
            }
        }

        private void btnSyncDesktop_Click(object sender, EventArgs e)
        {
            if (!AreBackgroundWorkersRunning())
            {
                if (!DoLibrariesExist()) return;
                this.Invoke(new MethodInvoker(() => PreferencesTab.Enabled = false)); //disallow changes to preferences
                DesktopSyncBW.RunWorkerAsync();
                btnSyncDesktop.Text = "Running...";
            }
        }

        private void cbAskSync_CheckedChanged(object sender, EventArgs e)
        {
            AskSync = cbAskSync.Checked;
            Properties.Settings.Default.AskSync = cbAskSync.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbAutoExit_CheckedChanged(object sender, EventArgs e)
        {
            AutoExit = cbAutoExit.Checked;
            Properties.Settings.Default.AutoExit = cbAutoExit.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbOverrideDesktopPath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOverrideDesktopPath.Checked)
            {
                lblDesktopLibraryLocation.Enabled = true;
                tbDesktopLibraryLocation.Enabled = true;
                btnDesktopLibraryLocation.Enabled = true;
                lblDesktopHostname.Enabled = false;
                tbDesktopHostname.Enabled = false;
                lblDesktopUsername.Enabled = false;
                tbDesktopUsername.Enabled = false;
            }
            else
            {
                lblDesktopLibraryLocation.Enabled = false;
                tbDesktopLibraryLocation.Enabled = false;
                btnDesktopLibraryLocation.Enabled = false;
                tbDesktopLibraryLocation.Text = "\\\\" + DesktopHostname + "\\Users\\" + DesktopUsername + "\\Music\\";
                lblDesktopHostname.Enabled = true;
                tbDesktopHostname.Enabled = true;
                lblDesktopUsername.Enabled = true;
                tbDesktopUsername.Enabled = true;
            }
            OverrideDesktopPath = cbOverrideDesktopPath.Checked;
            Properties.Settings.Default.OverrideDesktopPath = cbOverrideDesktopPath.Checked;
            Properties.Settings.Default.Save();
        }

        private void tbChiptunesLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(3);
        }

        private void tbDownscaledLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(2);
        }

        private void tbDesktopHostname_TextChanged(object sender, EventArgs e)
        {
            DesktopHostname = tbDesktopHostname.Text;
            if (!OverrideDesktopPath)
                tbDesktopLibraryLocation.Text = "\\\\" + DesktopHostname + "\\Users\\" + DesktopUsername + "\\Music\\";
            Properties.Settings.Default.DesktopHostname = tbDesktopHostname.Text;
            Properties.Settings.Default.Save();
        }

        private void tbDesktopLibraryLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(5);
        }

        private void tbDesktopLibraryLocation_TextChanged(object sender, EventArgs e)
        {
            DesktopLibraryLocation = tbDesktopLibraryLocation.Text;
            Properties.Settings.Default.DesktopLibraryLocation = tbDesktopLibraryLocation.Text;
            Properties.Settings.Default.Save();
        }

        private void tbDesktopUsername_TextChanged(object sender, EventArgs e)
        {
            DesktopUsername = tbDesktopUsername.Text;
            if (!OverrideDesktopPath)
                tbDesktopLibraryLocation.Text = "\\\\" + DesktopHostname + "\\Users\\" + DesktopUsername + "\\Music\\";
            Properties.Settings.Default.DesktopUsername = tbDesktopUsername.Text;
            Properties.Settings.Default.Save();
        }

        private void tbLibraryLocation_Click(object sender, EventArgs e)
        {
            OpenFolderDialog(1);
        }

        private void tbLibraryLocation_TextChanged(object sender, EventArgs e)
        {
            MusicLibrary = tbLibraryLocation.Text;
            Properties.Settings.Default.MusicLibrary = tbLibraryLocation.Text;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Background Worker Handlers
        //===========================================================================
        //
        // Background Worker Handlers
        //
        //===========================================================================

        //
        // DesktopSyncBW_DoWork(object sender, DoWorkEventArgs e)
        // Background worker for synchronizing with only the Desktop
        //
        private void DesktopSyncBW_DoWork(object sender, DoWorkEventArgs e)
        {
            if (FindDesktop())
            {
                ShowSyncStatus(true);
                this.Invoke(new MethodInvoker(() => lblDTStatus.Text = "Scanning and preparing Desktop... DO NOT DISCONNECT THE DEVICE! This may take some time..."));
                DesktopSyncSuccess = PerformSyncDesktop();
                if (AutoExit && DesktopSyncSuccess)
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.AaawYeah);
                    sound.PlaySync();  //Plays the sound in sync with the current thread so that it isn't cut off when the program exits

                    System.Environment.Exit(0); //exit the program if auto exit is enabled
                }
                else if (DesktopSyncSuccess)
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.AaawYeah);
                    sound.Play();  //Plays the sound in a new thread

                    MessageBox.Show("Upload Complete!", "Chrononizer Lite", MessageBoxButtons.OK, MessageBoxIcon.Information); //show the success window if at least one operation completed
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.OhNo);
                    sound.Play();  //Plays the sound in a new thread

                    MessageBox.Show("Upload Failed!", "Chrononizer Lite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ShowSyncStatus(false);
            }
            this.Invoke(new MethodInvoker(() =>
            {
                btnSyncDesktop.Text = "Upload new files to Desktop";
                PreferencesTab.Enabled = true; //allow changes to preferences
            }));
        }

        //
        // ScanBW_DoWork(object sender, DoWorkEventArgs e)
        // Background worker for scanning the music library
        //
        private void ScanBW_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(() => PreferencesTab.Enabled = false)); //disallow changes to preferences

            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.ScannerSweep);
            sound.Play();  //Plays the sound in a new thread

            long flac, mp3, wma, m4a, ogg, wav, xm, mod, nsf, audioTotal, chiptunesTotal, total;
            flac = mp3 = wma = m4a = ogg = wav = xm = mod = nsf = audioTotal = chiptunesTotal = total = 0;
            double dSize, allSize, lSize;
            dSize = allSize = lSize = 0;

            lSize = GetDirectorySize(MusicLibrary, 0, ref flac, ref mp3, ref wma, ref m4a, ref ogg, ref wav, ref xm, ref mod, ref nsf);

            audioTotal = flac + mp3 + wma + m4a + ogg + wav;
            chiptunesTotal = xm + mod + nsf;
            total = audioTotal + chiptunesTotal;
            allSize = lSize + dSize;
            this.Invoke(new MethodInvoker(() =>
            {
                lblLibraryBytes.Text = "Library Size: " + BytesToSize(lSize); //display the size
                lblFLACFiles.Text = "FLAC: " + Plural(flac, "file"); //display the sizeber of flac songs
                lblMP3Files.Text = "MP3: " + Plural(mp3, "file"); //display the sizeber of mp3 songs
                lblWMAFiles.Text = "WMA: " + Plural(wma, "file"); //display the sizeber of wma songs
                lblM4AFiles.Text = "M4A: " + Plural(m4a, "file"); //display the sizeber of m4a songs
                lblOGGFiles.Text = "OGG: " + Plural(ogg, "file"); //display the sizeber of ogg songs
                lblWAVFiles.Text = "WAV: " + Plural(wav, "file"); //display the sizeber of wav songs
                lblXMFiles.Text = "XM: " + Plural(xm, "file"); //display the sizeber of xm songs
                lblMODFiles.Text = "MOD: " + Plural(mod, "file"); //display the sizeber of mod songs
                lblNSFFiles.Text = "NSF: " + Plural(nsf, "file"); //display the sizeber of nsf songs
                lblLibraryFiles.Text = "Library: " + Plural(audioTotal, "song");
                lblChiptunesFiles.Text = "Chiptunes: " + Plural(chiptunesTotal, "song");
                lblTotalFiles.Text = "Total: " + Plural(total, "song");
                btnScan.Text = "Rescan Library";
                checkedFiles.Clear();
            }));

            this.Invoke(new MethodInvoker(() => PreferencesTab.Enabled = true)); //allow changes to preferences
        }


        #endregion

        #region Synchronize Functions
        //===========================================================================
        //
        // Synchronize Functions
        //
        //===========================================================================

        //
        // FindDesktop()
        // Attempts to find the Desktop
        //
        public Boolean FindDesktop()
        {
            if (Directory.Exists(DesktopLibraryLocation))
            {
                DialogResult result = DialogResult.Yes;
                if (!OverrideDesktopPath && AskSync)
                    result = MessageBox.Show(DesktopHostname + " logged in as " + DesktopUsername + " is mounted.\nWould you like to upload to this device?", "Device Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else if (OverrideDesktopPath && AskSync)
                    result = MessageBox.Show("Desktop found at the following location:\n" + DesktopLibraryLocation + "\nWould you like to upload to this device?", "Device Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.ChronoBoost);
                    sound.Play();  //Plays the sound in a new thread

                    return true;
                }
                else //the user said no
                {
                    if (lblDTStatus != null)
                        this.Invoke(new MethodInvoker(() => lblDTStatus.Text = "Error: Upload to Desktop canceled! "));
                }
            }
            else //could not find device
            {
                if (lblDTStatus != null)
                    this.Invoke(new MethodInvoker(() => lblDTStatus.Text = "Error: Upload to Desktop failed! "));
                MessageBox.Show("Desktop is not connected! Make sure that it is mounted properly!", "Chrononizer Lite", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        //
        // PerformSyncDesktop()
        // Synchronizes the Desktop with the music library
        //
        public Boolean PerformSyncDesktop()
        {
            double CopySize = 0;
            Queue<UpdateLocation> UpdateFiles = new Queue<UpdateLocation>();

            CopySize = PrepareSyncDesktop(MusicLibrary, DesktopLibraryLocation, ref UpdateFiles);

            Queue<UpdateLocation> CopyFiles = new Queue<UpdateLocation>();

            //populate the listbox with files that need to be copied
            while (UpdateFiles.Count > 0)
            {
                UpdateLocation update = UpdateFiles.Dequeue();
                this.Invoke(new MethodInvoker(() => lbDT.Items.Add(update.DestinationFile)));
                CopyFiles.Enqueue(update);
            }

            //set up the progress bar
            int progress = 0;
            double percent = 0;
            this.Invoke(new MethodInvoker(() =>
            {
                lblDTStatus.Text = "Copying updated files to Desktop...";
                lblDTProgress.Text = "0%";
            }));

            //copy files to Desktop here
            while (CopyFiles.Count > 0)
            {
                UpdateLocation update = CopyFiles.Dequeue();
                string source = update.SourceFile;
                string destination = update.DestinationFile;

                DialogResult result = DialogResult.Retry;
                while (result == DialogResult.Retry) //be ready in case of an error
                {
                    if (File.Exists(source))
                    {
                        //read source file info
                        FileInfo info = new FileInfo(source);

                        //copy the file
                        try
                        {
                            File.Copy(source, destination, true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            if (!File.Exists(Path.GetFullPath(destination))) //check to see if the error was because of a lost connection
                                result = MessageBox.Show("Connection to the Desktop has been lost!", "Chrononizer Lite", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            else if (!File.Exists(source)) //the source file no longer exists
                                result = MessageBox.Show("The file " + Path.GetFileName(source) + " cannot be found in the music library!", "Chrononizer Lite", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                            else
                                return false; //unkown error, so stop the synchronization process

                            if (result == DialogResult.Abort || result == DialogResult.Cancel)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    pbDT.Value = 0;
                                    lblDTProgress.Text = " ";
                                    lblDTStatus.Text = "Error: Upload to Desktop failed! ";
                                }));
                                return false;
                            }
                            else if (result == DialogResult.Retry)
                                continue;
                        }

                        //calculate progress
                        progress += (int)(((info.Length / CopySize) * 100000));
                        percent = Math.Round((((double)progress) / 1000), 2);
                        break;
                    }
                    else
                    {
                        result = MessageBox.Show("The file " + Path.GetFileName(source) + " cannot be found in the music library!", "Chrononizer Lite", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (result == DialogResult.Abort)
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                pbDT.Value = 0;
                                lblDTProgress.Text = " ";
                                lblDTStatus.Text = "Error: Upload to Desktop failed! ";
                            }));
                            return false;
                        }
                        else if (result == DialogResult.Ignore)
                            break;
                    }
                }

                this.Invoke(new MethodInvoker(() =>
                {
                    pbDT.Value = progress; //get the file's size
                    lblDTProgress.Text = percent.ToString() + "%";
                    lbDT.Items.Remove(destination);
                }));
            }

            this.Invoke(new MethodInvoker(() =>
            {
                pbDT.Value = pbDT.Maximum;
                lblDTProgress.Text = "100%";
                lblDTStatus.Text = "Upload to Desktop complete! ";
            }));

            return true;
        }

        //
        // PrepareSyncDesktop(string sourcePath, string destinationPath, ref Queue<UpdateLocation> UpdateFiles)
        // Scans the Desktop, removes unnecessary files and folders, and determines what new files need to be copied
        //
        public double PrepareSyncDesktop(string sourcePath, string destinationPath, ref Queue<UpdateLocation> UpdateFiles)
        {
            double size = 0; //size of all files in this directory that will need to be copied
            bool dirExisted = DirExisted(destinationPath);
            if (!Directory.Exists(destinationPath))
                return size; //the directory could not be accessed

            //get the source files
            string[] sourceFiles = null;
            try
            {
                sourceFiles = Directory.GetFiles(sourcePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return size;
            }
            foreach (string sourceFile in sourceFiles)
            {
                FileInfo sourceInfo = new FileInfo(sourceFile);
                string destinationFile = Path.Combine(destinationPath, sourceInfo.Name);
                if (dirExisted && File.Exists(destinationFile))
                {
                    FileInfo destinationInfo = new FileInfo(destinationFile);
                    if (sourceInfo.LastWriteTime > destinationInfo.LastWriteTime)
                    {
                        //file is newer, so add it to the queue of files that need to be copied
                        UpdateLocation update = new UpdateLocation();
                        update.SourceFile = sourceFile;
                        update.DestinationFile = Path.Combine(destinationPath, sourceInfo.Name);
                        UpdateFiles.Enqueue(update);
                        FileInfo info = new FileInfo(sourceFile);
                        size += info.Length; //get the file's size
                    }
                }
                else
                {
                    //add it to the queue of files that need to be copied
                    UpdateLocation update = new UpdateLocation();
                    update.SourceFile = sourceFile;
                    update.DestinationFile = Path.Combine(destinationPath, sourceInfo.Name);
                    UpdateFiles.Enqueue(update);
                    FileInfo info = new FileInfo(sourceFile);
                    size += info.Length; //get the file's size
                }
            }

            //now process the directories if exist
            string[] dirs = null;
            try
            {
                dirs = Directory.GetDirectories(sourcePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return size;
            }
            foreach (string dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                //recursive do the directories
                size += PrepareSyncDesktop(dir, Path.Combine(destinationPath, dirInfo.Name), ref UpdateFiles);
            }
            return size;
        }

        #endregion

        #region Miscellaneous Functions
        //===========================================================================
        //
        // Miscellaneous Functions
        //
        //===========================================================================

        //
        // AreBackgroundWorkersRunning()
        // Returns true if there are any background workers running
        //
        private Boolean AreBackgroundWorkersRunning()
        {
            if (DesktopSyncBW.IsBusy || ScanBW.IsBusy)
                return true;
            else
                return false;
        }

        //
        // BytesToSize(double size)
        // Converts a number of bytes to a readable size measured in KB, MB, GB, TB, or PB
        //
        public static string BytesToSize(double size)
        {
            int type = 0;
            string s = " ";
            while (size > 1024)
            {
                size /= 1024;
                type++;
                if (type >= 5)
                {
                    break; //don't calculate beyond PB
                }
            }
            size = Math.Round(size, 2); //round to two decimal places
            s = size.ToString(); //put the sizeber in a string
            switch (type)
            {
                case 0:
                    if (size == 1) s += " byte";
                    else s += " bytes";
                    break;
                case 1:
                    s += " KB";
                    break;
                case 2:
                    s += " MB";
                    break;
                case 3:
                    s += " GB";
                    break;
                case 4:
                    s += " TB";
                    break;
                case 5:
                    s += " PB";
                    break;
                default:
                    break;
            }
            return s;
        }

        //
        // DirExisted(string path)
        // Return true if the directory exists. If the directory does not exist, create it and return false.
        //
        private bool DirExisted(string path)
        {
            Boolean exists = false;
            //create destination directory if not exist
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false; //directory creation failed
                }
                exists = false;
            }
            else
                exists = true;

            return exists;
        }

        //
        // DoLibrariesExist()
        // Makes sure that the library paths are valid. If they are not, an error will be thrown
        //
        private Boolean DoLibrariesExist()
        {
            if (!Directory.Exists(MusicLibrary))
            {
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.OhNo);
                sound.Play();  //Plays the sound in a new thread

                MessageBox.Show("The music library could not be found at the following specified directory: " + MusicLibrary, "Chrononizer Lite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //
        // Plural(long value, string units)
        // Make a string plural or singular depending upon the number of units
        //
        public static string Plural(long value, string units)
        {
            string plural = " ";
            if (value == 1)
                plural = value.ToString() + " " + units; //only one object
            else
                plural = value.ToString() + " " + units + "s"; //add an s if plural
            return plural;
        }

        //
        // OpenFolderDialog(int TextBox)
        // Opens the FolderBrowserDialog() for a specific text box
        //
        private void OpenFolderDialog(int TextBox)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.RootFolder = Environment.SpecialFolder.MyComputer;

            //set the starting path if relevant
            if (TextBox == 1) open.SelectedPath = MusicLibrary;

            if (open.ShowDialog() != DialogResult.OK)
            {
                open.Dispose();
                return;
            }

            //set the path accordingly
            if (TextBox == 1)
            {
                tbLibraryLocation.Text = open.SelectedPath + "\\";
            }
            else if (TextBox == 5)
            {
                if (MusicLibrary.Contains(open.SelectedPath) || open.SelectedPath.Contains(MusicLibrary))
                {
                    MessageBox.Show("The override path cannot be related to the any of the libraries!", "Chrononizer Lite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    tbDesktopLibraryLocation.Text = open.SelectedPath + "\\";
            }
            open.Dispose();
        }

        //
        // GetDirectorySize(string root, double size, ref long flac, ref long mp3, ref long wma, ref long m4a, ref long ogg, ref long wav, ref long xm, ref long mod, ref long nsf)
        // Calculates a directory size and counts the number of unique file types
        //
        private double GetDirectorySize(string root, double size, ref long flac, ref long mp3, ref long wma, ref long m4a, ref long ogg, ref long wav, ref long xm, ref long mod, ref long nsf)
        {
            if (!Directory.Exists(root)) return size; //path is invalid
            string[] files = null;
            string[] folders = null;
            try
            {
                files = Directory.GetFiles(root, "*.*"); //get array of all file names
                folders = Directory.GetDirectories(root); //get array of all folder names for this directory
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return size;
            }

            foreach (string name in files)
            {
                FileInfo info = new FileInfo(name); //read in the file
                String ext = Path.GetExtension(name).ToLowerInvariant(); //get the file's extension
                size += info.Length; //get the length
                //increment count based upon file type and extension type
                if (ext == ".flac")
                {
                    flac++;
                    try
                    {
                        checkedFiles.Add(name, true); //mark that it has been checked and is not proper
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else if (ext == ".mp3") mp3++;
                else if (ext == ".wma") wma++;
                else if (ext == ".m4a") m4a++;
                else if (ext == ".ogg") ogg++;
                else if (ext == ".wav") wav++;
                else if (ext == ".xm") xm++;
                else if (ext == ".mod") mod++;
                else if (ext == ".nsf") nsf++;
            }
            foreach (string name in folders)
            {
                size = GetDirectorySize(name, size, ref flac, ref mp3, ref wma, ref m4a, ref ogg, ref wav, ref xm, ref mod, ref nsf); //recurse through the folders
            }
            return size;
        }

        //
        // ShowSyncStatus(Boolean visible)
        // Shows or hides the synchronize status screen
        //
        public void ShowSyncStatus(Boolean visible)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (visible)
                {
                    panel1.Visible = true;
                    tabControl.Visible = false;

                    //Status text
                    DTflow = new FlowLayoutPanel();
                    DTflow.FlowDirection = FlowDirection.LeftToRight;
                    DTflow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    DTflow.AutoSize = true;
                    lblDTStatus = new Label();
                    lblDTStatus.Text = "Searching for Desktop...";
                    lblDTStatus.AutoSize = true;
                    DTflow.Controls.Add(lblDTStatus);
                    lblDTProgress = new Label();
                    lblDTProgress.Text = " ";
                    lblDTProgress.AutoSize = true;
                    DTflow.Controls.Add(lblDTProgress);

                    //Progressbar
                    pbDT = new ProgressBar();
                    pbDT.Maximum = 100000;
                    pbDT.Value = 0;
                    pbDT.Width = 765;
                    pbDT.Height = 38;
                    pbDT.Value = 0;

                    //Listbox
                    lbDT = new ListBox();
                    lbDT.Width = 765;
                    lbDT.Height = 450;

                    //Add the objects to the layout
                    flowLayoutPanel2.Controls.Add(DTflow);
                    flowLayoutPanel2.Controls.Add(pbDT);
                    flowLayoutPanel2.Controls.Add(lbDT);
                }
                else
                {
                    tabControl.Visible = true;
                    panel1.Visible = false;

                    //Status text
                    DTflow.Controls.Remove(lblDTStatus);
                    DTflow.Controls.Remove(lblDTProgress);
                    flowLayoutPanel2.Controls.Remove(lbDT);
                    flowLayoutPanel2.Controls.Remove(pbDT);
                    flowLayoutPanel2.Controls.Remove(DTflow);
                    lblDTStatus.Dispose();
                    lblDTProgress.Dispose();
                    DTflow.Dispose();
                    pbDT.Dispose();
                    lbDT.Dispose();
                    lblDTStatus = null;
                    lblDTProgress = null;
                    DTflow = null;
                    pbDT = null;
                    lbDT = null;
                }
            }));
        }

        #endregion
    }
}
