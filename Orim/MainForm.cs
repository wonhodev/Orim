using Microsoft.Win32;
using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace Orim
{
    public partial class MainForm : Form
    {
        private HotKeyRegister hotkey;
        private ScreenPanelForm screenPanel;

        public MainForm()
        {
            InitializeComponent();

            runOnStartupCheck.Checked = Properties.Settings.Default.RunOnStartup;
            runInSystemTrayCheck.Checked = Properties.Settings.Default.RunInSystemTray;
            useHotkeyCheck.Checked = Properties.Settings.Default.UseHotkey;
            if (useHotkeyCheck.Checked)
            {
                InitializeHotKey();
            }
        }

        /// <summary>
        /// Set a global hotkey for screen capture
        /// </summary>
        private void InitializeHotKey()
        {
            // To register global hotkey (Ctrl + Alt + Z)
            hotkey = new HotKeyRegister(
                this.Handle,
                4001,
                HotKeyRegister.ModifierKeys.Control | HotKeyRegister.ModifierKeys.Shift,
                Keys.Z);

            hotkey.HotKeyPressed += new EventHandler(StartCapture);
        }
        
        public void MinimizeToSystemTray()
        {
            notifyIcon.Visible = true;
            this.Hide();
        }

        /// <summary>
        /// Display the form from system tray
        /// </summary>
        private void ShowFromTray()
        {
            notifyIcon.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                MinimizeToSystemTray();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotkey?.Dispose();
            Application.Exit();
        }

        public void ScreenPanelVisibleChanged(object sender, EventArgs e)
        {
            ScreenPanelForm screenPanel = sender as ScreenPanelForm;
            if (screenPanel != null && !screenPanel.Visible)
            {
                this.TopMost = false;
            }
        }

        /// <summary>
        /// An event for "New" menu, "Capture" button,
        /// "Capture" menu in the notify icon, and hotkey (Ctrl+Alt+Z)
        /// </summary>
        public void StartCapture(object sender, EventArgs e)
        {
            this.TopMost = true;

            if (screenPanel == null)
            {
                screenPanel = new ScreenPanelForm();
                screenPanel.VisibleChanged += new EventHandler(ScreenPanelVisibleChanged);
            }

            screenPanel.ShowFullScreenPanel();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowFromTray();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFromTray();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runOnStartupCheck_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            string appName = Properties.Resources.AppName;

            try
            {
                if (runOnStartupCheck.Checked)
                {
                    registryKey.SetValue(appName, Application.ExecutablePath);
                }
                else
                {
                    registryKey.DeleteValue(appName);                    
                }

                Properties.Settings.Default.RunOnStartup = runOnStartupCheck.Checked;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot access Registry");
                throw;
            }            
        }

        private void runInSystemTrayCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunInSystemTray = runInSystemTrayCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void useHotkeyCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseHotkey = useHotkeyCheck.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
