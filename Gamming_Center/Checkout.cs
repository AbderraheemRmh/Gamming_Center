using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center
{
    
    public partial class Checkout : Form
    {
        private List<int> preCheckoutProducts = new List<int>();
        private string post;
        private int id;
        private double time;
        private int issuer;
        private double totalPrice = 0;
        private double postPrice = 0;
        private int numberPlayer;
        private Dictionary<int, CheckoutItem> checkoutItems = new Dictionary<int, CheckoutItem>();
        public Checkout(int id, string post, double time, int issuer, int numberPlayer, List<int> preCheckoutProducts)
        {
            InitializeComponent();
            this.preCheckoutProducts = preCheckoutProducts;
            this.post = post;
            this.id = id;
            lblPost.Text = this.post;
            this.time = time;
            this.numberPlayer = numberPlayer;
            this.issuer = issuer;
            postPrice = CalculateTotalPrice(this.id, this.time, this.numberPlayer);
            lblPostTotal.Text = string.Format("{0:0.0}", postPrice) + " DA";
            totalPrice += postPrice;
            lblTotal.Text = string.Format("{0:0.0}", (totalPrice)) + " DA";
            LoadProducts();
            addPreCheckoutItems();



        }



        private void addPreCheckoutItems()
        {
            foreach (int id in preCheckoutProducts)
            {
                int productId = id;
                string ProductNameDB = "";
                int ProductPriceDB = 0;
                int BasePriceDB = 0;

                if (checkoutItems.ContainsKey(productId))
                {
                    // If the product already exists in the checkout, increment its quantity
                    checkoutItems[productId].Quantity++;
                }
                else
                {
                    string connectionString = "Data Source=GammingCenter.db;Version=3;";
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand("SELECT  Name, Price, Original_Price FROM Product WHERE ID = @ProductID", connection))
                        {
                            command.Parameters.AddWithValue("@ProductID", productId);
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    ProductNameDB = reader.GetString(0);
                                    ProductPriceDB = reader.GetInt32(1);
                                    BasePriceDB = reader.GetInt32(2);
                                }
                            }
                        }
                    }
                    // Add a new product to the checkout
                    var checkoutItem = new CheckoutItem
                    {
                        ProductId = productId,
                        ProductName = ProductNameDB,
                        ProductPrice = ProductPriceDB,
                        Quantity = 1,
                        BasePrice = BasePriceDB
                    };
                    checkoutItems.Add(productId, checkoutItem);
                }
            }

            UpdateCheckoutPanel(); // Refresh the checkout list
        }
        private double CalculateTotalPrice(int postId, double timeUsed, int playerCount)
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                SELECT CASE @PlayerCount 
                       WHEN 2 THEN Price2P
                       WHEN 4 THEN Price4P
                       ELSE 0 END AS PricePerHour
                FROM Type
                WHERE ID = (SELECT Type FROM Post WHERE ID = @PostId)";
                    command.Parameters.AddWithValue("@PlayerCount", playerCount);
                    command.Parameters.AddWithValue("@PostId", postId);

                    var result = command.ExecuteScalar();
                    if (result != null && double.TryParse(result.ToString(), out var pricePerHour))
                    {
                        lblPricePH.Text = pricePerHour.ToString();
                        return pricePerHour * timeUsed;
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve price. Please check the post and type data.");
                    }
                }
            }
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
            totalPrice = postPrice;
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
                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            try
            {
                int postId = id; // Replace with the ID passed to this form
                double timeUsed = time; // Replace with the time used passed to this form
                int playerCount = numberPlayer; // Replace with the player count (2 or 4)
                int issuerId = issuer; // Replace with your variable storing issuer ID



                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"
                    INSERT INTO Post_Cashier (Issuer, Date, Price, Post)
                    VALUES (@Issuer, @Date, @Price, @Post)";
                        command.Parameters.AddWithValue("@Issuer", issuerId);
                        command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss"));
                        command.Parameters.AddWithValue("@Price", postPrice);
                        command.Parameters.AddWithValue("@Post", postId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Checkout completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Clear checkout list and refresh UI
                checkoutItems.Clear();
                UpdateCheckoutPanel();
                this.Close(); // Close the form after successful checkout
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during checkout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkouttxt_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void boughtProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPost_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblPostTotal_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPricePH_Click(object sender, EventArgs e)
        {

        }
    }
    public class CheckoutItem
    {
        public int ProductId { get; set; }      // Unique identifier for the product
        public string ProductName { get; set; } // Name of the product
        public decimal ProductPrice { get; set; } // Price of the product
        public int Quantity { get; set; }       // Quantity of the product in the checkout

        public int BasePrice;
    }
}
