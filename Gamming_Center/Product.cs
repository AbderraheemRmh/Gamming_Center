using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gamming_Center.Models;

namespace Gamming_Center
{
    public partial class Product : Form
    {
        private string id = null;
        private ProductModel model;
        private bool changed = false;
        private bool statrDetecting = false;
        public Product()
        {
            InitializeComponent();
            model = new ProductModel();
            model.LoadProductToDataGridView(listProduct);
            
        }
       
        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select a Product Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path
                    txtPhotoPath.Text = openFileDialog.FileName;

                    // Show the image in the PictureBox
                    pictureBoxPhoto.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private string CopyPhotoToSrc(string sourcePath)
        {
            string srcFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src");
            if (!Directory.Exists(srcFolder))
            {
                Directory.CreateDirectory(srcFolder);
            }

            // Generate a unique name for the file to avoid overwriting
            string fileName = Path.GetFileName(sourcePath);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // Format: YYYYMMDD_HHMMSS
            string uniqueFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{timestamp}{Path.GetExtension(fileName)}";
            string destinationPath = Path.Combine(srcFolder, uniqueFileName);

            // Copy the file to the `src` folder
            File.Copy(sourcePath, destinationPath, true);

            // Return the relative path for database storage
            return Path.Combine("src", uniqueFileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhotoPath.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Copy the selected photo to the `src` folder
            string relativePhotoPath = CopyPhotoToSrc(txtPhotoPath.Text);
            if (test() && id == null)
            {
                string name = txtName.Text;
                int amount = int.Parse(txtAmount.Text);
                int price = int.Parse(txtPrice.Text);
                int priceOut = int.Parse(txtPriceOut.Text);

                // Call the method to add the new worker
                model.AddProduct(name, relativePhotoPath, priceOut, price, amount);

                // Optionally, refresh the DataGridView to show updated data
                model.LoadProductToDataGridView(listProduct);
                // Optionally, clear the form fields after adding
                clearForm();

                MessageBox.Show("New product added successfully!", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (id != null)
            {
                MessageBox.Show("Your in edit mode!", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private bool test()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter the name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = false;
                lblName.Visible = true;
                lblPrice.Visible = false;
                return false;
            }
            else if (txtAmount.Text == "")
            {
                MessageBox.Show("Please enter the amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = true;
                lblName.Visible = false;
                lblPrice.Visible = false;
                return false;
            }
            else if (txtPrice.Text == "")
            {
                MessageBox.Show("Please enter the price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = false;
                lblName.Visible = false;
                lblPrice.Visible = true;
                return false;
            }
            else if (txtPriceOut.Text == "")
            {
                MessageBox.Show("Please enter the price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = false;
                lblName.Visible = false;
                lblPriceOut.Visible = true;
                return false;
            }
            else
            {
                lblAmount.Visible = false;
                lblName.Visible = false;
                lblPrice.Visible = false;
                return true;
            }



        }
        private void clearForm()
        {
            txtName.Text = "";
            txtAmount.Text = "";
            txtPrice.Text = "";
            txtPriceOut.Text = "";
            txtPhotoPath.Text = "";
            pictureBoxPhoto.Image = null;
            id = null;
            lblAmount.Visible = false;
            lblName.Visible = false;
            lblPrice.Visible = false;
            lblPriceOut.Visible = false;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void listProduct_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (listProduct.SelectedRows.Count > 0) // Ensure a row is selected
            {
                var selectedRow = listProduct.SelectedRows[0];
                id = selectedRow.Cells["ID"].Value.ToString();
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtAmount.Text = selectedRow.Cells["Amount"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["Original_Price"].Value.ToString();
                txtPriceOut.Text = selectedRow.Cells["Price"].Value.ToString();
                txtPhotoPath.Text = selectedRow.Cells["Photo"].Value.ToString();
                pictureBoxPhoto.Image = Image.FromFile(selectedRow.Cells["Photo"].Value.ToString());
                statrDetecting = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtPhotoPath.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string relativePhotoPath;
            if (changed)
            {
                // Copy the selected photo to the `src` folder
                 relativePhotoPath = CopyPhotoToSrc(txtPhotoPath.Text);
            }
            else
            {
                 relativePhotoPath = txtPhotoPath.Text;
            }
                if (test() && id != null)
            {
                int ident = int.Parse(id);
                string name = txtName.Text;
                int amount = int.Parse(txtAmount.Text);
                int price = int.Parse(txtPrice.Text);
                int priceOut = int.Parse(txtPriceOut.Text);
                // Call the method to add the new worker
                model.UpdateProduct(ident, name, relativePhotoPath, priceOut, price, amount);

                // Optionally, refresh the DataGridView to show updated data
                model.LoadProductToDataGridView(listProduct);
                // Optionally, clear the form fields after adding
                clearForm();

                MessageBox.Show("New product Edited successfully!", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            statrDetecting = false;
            changed = false;
        }

        private void txtPhotoPath_TextChanged(object sender, EventArgs e)
        {
            if (statrDetecting)
            {
                changed = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            // Check if a row is selected
            if (listProduct.SelectedRows.Count > 0)
            {

                int ident = Int32.Parse(id);
                if (pictureBoxPhoto.Image != null)
                {
                    pictureBoxPhoto.Image.Dispose();
                    pictureBoxPhoto.Image = null;
                }
                
                // Ask for confirmation
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this post?",
                                                            "Delete Post",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                // If the user clicks 'Yes', delete the worker
                if (dialogResult == DialogResult.Yes)
                {
                    
                    model.DeleteProduct(ident); // Call the method to delete the worker
                    clearForm();
                    // Refresh the DataGridView to show the updated list
                    model.LoadProductToDataGridView(listProduct);
                    
                    MessageBox.Show("Post deleted successfully!", "Delete Post", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please select a post to delete.", "Delete Post", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editSize()
        {
            panel1.Width = this.Width / 2;
            panel2.Width = this.Width / 2;
            listProduct.Height = panel2.Height * 4 / 5;
        }

        private void Product_Load(object sender, EventArgs e)
        {
            editSize();
        }
    }
}
