using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center
{
    public partial class ProductCheckout : UserControl
    {
        private int cornerRadius = 20;
        public int ProductId { get; set; }
        public string ProductName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }
        public int ProductPrice
        {
            get => Int32.Parse(lblPrice.Text); 
            set => lblPrice.Text = value.ToString();
        }
        public int BasePrice;
        public Image ProductPhoto
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        // Event triggered when the Add button is clicked
        public event EventHandler AddClicked;

        public ProductCheckout()
        {
            InitializeComponent();
            btnAdd.Click += (s, e) => AddClicked?.Invoke(this, EventArgs.Empty); // Fire event
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Top-left corner
            path.AddArc(this.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Top-right corner
            path.AddArc(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
            path.AddArc(0, this.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Apply the rounded rectangle to the region of the control
            this.Region = new Region(path);

            // Optional: Draw a border
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.Transparent, 0))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }


    }
}
