using System;
using System.Drawing;
using System.Windows.Forms;

namespace Orim
{
    public partial class ScreenPanelForm : Form
    {
        // Mouse moving
        private bool isDrag = false;
        private Point startPoint;

        // Area line drawing
        private Rectangle drawingRectangle;
        private Graphics graphics;
        private Bitmap backgroundImage;
        private Font font;

        public ScreenPanelForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display panel on all screens in all monitors
        /// </summary>
        public void ShowFullScreenPanel()
        {
            // full-screen size in all monitors
            int x = SystemInformation.VirtualScreen.X;
            int y = SystemInformation.VirtualScreen.Y;
            int width = SystemInformation.VirtualScreen.Width;
            int height = SystemInformation.VirtualScreen.Height;
            this.SetBounds(x, y, width, height);

            InitializeGraphics(width, height);

            this.Show();
            this.Activate();
        }

        /// <summary>
        /// Graphics to draw area line
        /// </summary>
        /// <param name="width">image width</param>
        /// <param name="height">image height</param>
        private void InitializeGraphics(int width, int height)
        {
            backgroundImage = new Bitmap(width, height);
            graphics = Graphics.FromImage(backgroundImage);
            this.BackgroundImage = backgroundImage;
            font = new Font("Arial", 10);
        }

        private void ScreenPanelForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Hide();
            }
        }

        private void ScreenPanelForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                startPoint = e.Location;
            }
        }

        private void ScreenPanelForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag && graphics != null)
            {
                drawingRectangle = new Rectangle();
                drawingRectangle.X = startPoint.X < e.X ? startPoint.X : e.X;
                drawingRectangle.Y = startPoint.Y < e.Y ? startPoint.Y : e.Y;
                drawingRectangle.Width = Math.Abs(e.X - startPoint.X);
                drawingRectangle.Height = Math.Abs(e.Y - startPoint.Y);

                // Draw rectangle line for area to snip
                graphics.Clear(this.BackColor);
                graphics.DrawRectangle(Pens.Red, drawingRectangle);
                graphics.DrawString($"{drawingRectangle.Width},{drawingRectangle.Height}",
                    font, Brushes.Black, e.X + 15, e.Y + 15);

                this.Invalidate();
            }
        }

        private void ScreenPanelForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;

            if (drawingRectangle != null && drawingRectangle.Width > 0 && drawingRectangle.Height > 0)
            {
                // Clear and invalidate immediately to clear remained line
                graphics?.Clear(this.BackColor);
                this.Refresh();
                this.Hide();

                SnippedForm snipped = new SnippedForm();
                snipped.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
                snipped.CaptureScreen(RectangleToScreen(drawingRectangle));
                snipped.Show();
                snipped.Activate();
            }
        }

        private void ScreenPanelForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                font?.Dispose();
                graphics?.Dispose();
                backgroundImage?.Dispose();
            }
        }
    }
}
