using System;
using System.Drawing;
using System.Windows.Forms;

namespace Orim
{
    public partial class SnippedForm : Form
    {
        private bool isMoving = false;
        private Point startPoint;
        private bool isOnTop = true;

        public SnippedForm()
        {
            InitializeComponent();
        }

        public void CaptureScreen(Rectangle rect)
        {
            // Add width and height for board line of PictureBox
            this.SetBounds(rect.X + 5, rect.Y + 5, rect.Width + 2, rect.Height + 2);
            pictureBox.SetBounds(0, 0, rect.Width + 2, rect.Height + 2);

            Bitmap bmp = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, new Size(rect.Width, rect.Height));
            }
            pictureBox.Image = bmp;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMoving = true;
                startPoint = e.Location;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving && e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startPoint.X;
                this.Top += e.Y - startPoint.Y;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isOnTop = !isOnTop;
            this.TopMost = isOnTop;
            this.ShowInTaskbar = !isOnTop;
            alwaysOnTopToolStripMenuItem.Checked = isOnTop;
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy the image to clipboard to paste in other programs
            Clipboard.SetImage(pictureBox.Image);

            // Display popup message
            new ToolTip().Show(
                "Copied",
                this, this.Width / 2 - 30,
                this.Height - 50,
                1000);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save the image to a file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.FileName = this.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                pictureBox.Image.Save(fileName);
            }
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void SnippedForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                CloseForm();
            }
        }
    }
}
