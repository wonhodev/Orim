namespace Orim
{
    partial class ScreenPanelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenPanelForm));
            this.SuspendLayout();
            // 
            // ScreenPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = Properties.Resources.AppIcon;            
            this.Name = "ScreenPanelForm";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = Properties.Resources.AppName;
            this.VisibleChanged += new System.EventHandler(this.ScreenPanelForm_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenPanelForm_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenPanelForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenPanelForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenPanelForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}