using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center
{
    public partial class checkoutProducts : Form
    {
        private int issuer;
        private double totalPrice = 0;
        private Dictionary<int, CheckoutItem> checkoutItems = new Dictionary<int, CheckoutItem>();
        public checkoutProducts(int issuer)
        {
            InitializeComponent();
            this.issuer = issuer;
            lblTotal.Text = string.Format("{0:0.0}", (totalPrice)) + " DA";
            LoadProducts();
        }

        
        private void LoadProducts()
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT ID, Name, Price, Original_Price, Photo FROM Product", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productControl = new ProductCheckout
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                ProductPrice = reader.GetInt32(2),
                                BasePrice = reader.GetInt32(3),
                                ProductPhoto = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, reader.GetString(4)))
                            };

                            productControl.AddClicked += ProductControl_AddClicked; // Subscribe to Add button event
                            productsPanel.Controls.Add(productControl); // Add to the left panel
                        }
                    }
                }
            }
        }

        private void ProductControl_AddClicked(object sender, EventArgs e)
        {
            var productControl = sender as ProductCheckout;
            if (productControl == null) return;

            int productId = productControl.ProductId;

            if (checkoutItems.ContainsKey(productId))
            {
                // If the product already exists in the checkout, increment its quantity
                checkoutItems[productId].Quantity++;
            }
            else
            {
                // Add a new product to the checkout
                var checkoutItem = new CheckoutItem
                {
                    ProductId = productId,
                    ProductName = productControl.ProductName,
                    ProductPrice = productControl.ProductPrice,
                    Quantity = 1,
                    BasePrice = productControl.BasePrice
                };
                checkoutItems.Add(productId, checkoutItem);
            }

            UpdateCheckoutPanel(); // Refresh the checkout list
        }

        private void UpdateCheckoutPanel()
        {
            boughtProduct.Controls.Clear();
            totalPrice = 0;
            foreach (var item in checkoutItems.Values)
            {
                var checkoutControl = new CheckoutControl
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    Quantity = item.Quantity
                };

                checkoutControl.RemoveClicked += CheckoutControl_RemoveClicked; // Subscribe to Remove event
                boughtProduct.Controls.Add(checkoutControl); // Add to the right panel

                totalPrice += (double)(item.ProductPrice * item.Quantity);
            }
            lblTotal.Text = string.Format("{0:0.0}", (totalPrice)) + " DA";
        }
        private void CheckoutControl_RemoveClicked(object sender, EventArgs e)
        {
            var checkoutControl = sender as CheckoutControl;
            if (checkoutControl == null) return;

            int productId = checkoutControl.ProductId;

            // Remove the item from the checkout list
            if (checkoutItems.ContainsKey(productId))
            {
                var item = checkoutItems[productId];
                if (item.Quantity > 1)
                {
                    // Decrement the quantity
                    item.Quantity--;
                }
                else
                {
                    // Remove the item completely if the quantity is 1
                    checkoutItems.Remove(productId);
                }
            }

            // Refresh the checkout panel to reflect changes
            UpdateCheckoutPanel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel the checkout?",
                                 "Cancel Confirmation",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Close the form if user confirms
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in checkoutItems.Values)
                        {
                            // Insert into Product_Cachier table
                            var insertCommand = new SQLiteCommand(
                                @"INSERT INTO Product_Cashier (Issuer, Date, Price, Product, Amount, Base) 
                          VALUES (@Issuer, @Date, @Price, @Product, @Amount, @Base)",
                                connection,
                                transaction);

                            insertCommand.Parameters.AddWithValue("@Issuer", issuer);
                            insertCommand.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss"));
                            insertCommand.Parameters.AddWithValue("@Price", item.ProductPrice * item.Quantity);
                            insertCommand.Parameters.AddWithValue("@Product", item.ProductId);
                            insertCommand.Parameters.AddWithValue("@Amount", item.Quantity);
                            insertCommand.Parameters.AddWithValue("@Base", item.BasePrice * item.Quantity);

                            insertCommand.ExecuteNonQuery();

                            // Update Product table
                            var updateCommand = new SQLiteCommand(
                                @"UPDATE Product 
                          SET Amount = Amount - @SoldAmount 
                          WHERE ID = @ProductId",
                                connection,
                                transaction);

                            updateCommand.Parameters.AddWithValue("@SoldAmount", item.Quantity);
                            updateCommand.Parameters.AddWithValue("@ProductId", item.ProductId);

                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Checkout completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear checkout list and refresh UI
                        checkoutItems.Clear();
                        UpdateCheckoutPanel();
                        this.Close(); // Close the form after successful checkout

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
    }


}

