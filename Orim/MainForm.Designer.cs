namespace Orim
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.runInSystemTrayCheck = new System.Windows.Forms.CheckBox();
            this.useHotkeyCheck = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runOnStartupCheck = new System.Windows.Forms.CheckBox();
            this.mainMenuStrip.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.notifyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(264, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.StartCapture);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.runOnStartupCheck);
            this.optionsGroupBox.Controls.Add(this.runInSystemTrayCheck);
            this.optionsGroupBox.Controls.Add(this.useHotkeyCheck);
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(240, 94);
            this.optionsGroupBox.TabIndex = 1;
            this.optionsGroupBox.TabStop = false;
            // 
            // runInSystemTrayCheck
            // 
            this.runInSystemTrayCheck.AutoSize = true;
            this.runInSystemTrayCheck.Location = new System.Drawing.Point(6, 42);
            this.runInSystemTrayCheck.Name = "runInSystemTrayCheck";
            this.runInSystemTrayCheck.Size = new System.Drawing.Size(130, 17);
            this.runInSystemTrayCheck.TabIndex = 2;
            this.runInSystemTrayCheck.Text = "Run in the system tray";
            this.runInSystemTrayCheck.UseVisualStyleBackColor = true;
            this.runInSystemTrayCheck.CheckedChanged += new System.EventHandler(this.runInSystemTrayCheck_CheckedChanged);
            // 
            // useHotkeyCheck
            // 
            this.useHotkeyCheck.AutoSize = true;
            this.useHotkeyCheck.Location = new System.Drawing.Point(6, 65);
            this.useHotkeyCheck.Name = "useHotkeyCheck";
            this.useHotkeyCheck.Size = new System.Drawing.Size(221, 17);
            this.useHotkeyCheck.TabIndex = 3;
            this.useHotkeyCheck.Text = "Use hotkey to start caputre (Ctrl + Alt + Z)";
            this.useHotkeyCheck.UseVisualStyleBackColor = true;
            this.useHotkeyCheck.CheckedChanged += new System.EventHandler(this.useHotkeyCheck_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
            this.notifyIcon.Icon = global::Orim.Properties.Resources.AppIcon;
            this.notifyIcon.Text = global::Orim.Properties.Resources.AppName;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.captureToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(117, 76);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.captureToolStripMenuItem.Text = "Capture";
            this.captureToolStripMenuItem.Click += new System.EventHandler(this.StartCapture);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // runOnStartupCheck
            // 
            this.runOnStartupCheck.Location = new System.Drawing.Point(6, 19);
            this.runOnStartupCheck.Name = "runOnStartupCheck";
            this.runOnStartupCheck.Size = new System.Drawing.Size(103, 17);
            this.runOnStartupCheck.TabIndex = 0;
            this.runOnStartupCheck.Text = "Run on Startup";
            this.runOnStartupCheck.UseVisualStyleBackColor = true;
            this.runOnStartupCheck.CheckedChanged += new System.EventHandler(this.runOnStartupCheck_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 131);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Orim.Properties.Resources.AppIcon;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Orim";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox runInSystemTrayCheck;
        private System.Windows.Forms.CheckBox useHotkeyCheck;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox runOnStartupCheck;
    }
}

