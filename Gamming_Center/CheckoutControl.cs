using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center
{
    public partial class CheckoutControl : UserControl
    {
        public int ProductId { get; set; } // To identify the product
        public string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }
        public decimal ProductPrice
        {
            get => decimal.Parse(lblProductPrice.Text);
            set => lblProductPrice.Text = value.ToString() + " DA"; 
        }
        public int Quantity
        {
            get => int.Parse(lblQuantity.Text);
            set => lblQuantity.Text = value.ToString();
        }

        public int BasePrice; // The original price of the product

        // Event triggered when the Remove button is clicked
        public event EventHandler RemoveClicked;

        public CheckoutControl()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveClicked?.Invoke(this, EventArgs.Empty); // Notify listeners
        }
    }
}
