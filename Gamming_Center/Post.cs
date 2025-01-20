using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gamming_Center.Models;

namespace Gamming_Center
{
    public partial class Post : Form
    {
        PostModel model;
        private string id = null;
        private string idd = null;
        private int typeId;
        private string typeName;
        private int categoryId;
        private string categoryName;
        public Post()
        {
            InitializeComponent();
            model = new PostModel();
            model.LoadPostsToDataGridView(listPost);
            model.LoadTypesToDataGridView(listType);

        }

        private void Post_Load(object sender, EventArgs e)
        {
            LoadTypesIntoComboBox();
            LoadCategoriesIntoComboBox();
        }

        private void LoadTypesIntoComboBox()
        {
            var types = model.GetAvailableTypes();
            comboBoxTypes.DataSource = types;
            comboBoxTypes.DisplayMember = "Name";
            comboBoxTypes.ValueMember = "ID";
        }
        private void LoadCategoriesIntoComboBox()
        {
            var categories = model.GetAvailableCategories();
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "ID";
        }


        private void listPost_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

            if (listPost.SelectedRows.Count > 0) // Ensure a row is selected
            {
                var selectedRow = listPost.SelectedRows[0];
                id = selectedRow.Cells["ID"].Value.ToString();
                txtPostName.Text = selectedRow.Cells["Name"].Value.ToString();
                comboBoxTypes.Text = selectedRow.Cells["Type"].Value.ToString();

            }
        }

        private void btnEditPost_Click(object sender, EventArgs e)
        {
            if (listPost.SelectedRows.Count > 0) // Ensure a row is selected
            {
                if (test1() && id != null)
                {
                    int ident = int.Parse(id); // Get the ID from the label
                    string name = txtPostName.Text;
                    string type = typeId.ToString();
                    string category = categoryId.ToString();
                    model.UpdatePost(ident, name, type, category);

                    // Optionally, refresh the DataGridView to show updated data
                    model.LoadPostsToDataGridView(listPost);
                    clearForm1();

                    MessageBox.Show("Worker details updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please select a worker to edit.", "Edit Worker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void clearForm1()
        {
            txtPostName.Text = "";
            comboBoxTypes.Text = "";
            id = null;
            lblPostName.Visible = false;
            lblType.Visible = false;

        }
        private bool test1()
        {
            if (txtPostName.Text == "")
            {
                MessageBox.Show("Please enter the name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPostName.Visible = true;
                lblType.Visible = false;
                return false;
            }
            else if (comboBoxTypes.Text == "")
            {
                MessageBox.Show("Please enter the type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPostName.Visible = false;
                lblType.Visible = true;
                return false;
            }
            else if (comboBoxCategory.Text == "")
            {
                MessageBox.Show("Please enter the category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPostName.Visible = false;
                lblType.Visible = true;
                return false;
            }
            else
            {
                lblPostName.Visible = false;
                lblType.Visible = false;
                return true;
            }



        }

        private void btnSavePost_Click(object sender, EventArgs e)
        {
            if (test1() && id == null)
            {
                string name = txtPostName.Text;
                string type = typeId.ToString();
                string category = categoryId.ToString();

                // Call the method to add the new worker
                model.AddPost(name, type,category);

                // Optionally, refresh the DataGridView to show updated data
                model.LoadPostsToDataGridView(listPost);
                // Optionally, clear the form fields after adding
                clearForm1();

                MessageBox.Show("New post added successfully!", "Add Post", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (id != null)
            {
                MessageBox.Show("Your in edit mode!", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (listPost.SelectedRows.Count > 0)
            {

                int ident = Int32.Parse(id);

                // Ask for confirmation
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this post?",
                                                            "Delete Post",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                // If the user clicks 'Yes', delete the worker
                if (dialogResult == DialogResult.Yes)
                {
                    model.DeletePost(ident); // Call the method to delete the worker

                    // Refresh the DataGridView to show the updated list
                    model.LoadPostsToDataGridView(listPost);
                    clearForm1();
                    MessageBox.Show("Post deleted successfully!", "Delete Post", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please select a post to delete.", "Delete Post", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem != null)
            {
                var selectedType = (TypeItem)comboBoxTypes.SelectedItem;
                typeId = selectedType.ID;
                typeName = selectedType.Name;

            }
        }

        private void listType_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (listType.SelectedRows.Count > 0) // Ensure a row is selected
            {
                var selectedRow = listType.SelectedRows[0];
                idd = selectedRow.Cells["ID"].Value.ToString();
                txtTypeName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtAmount.Text = selectedRow.Cells["Amount"].Value.ToString();
                txtPrice2P.Text = selectedRow.Cells["Price2P"].Value.ToString();
                txtPrice4P.Text = selectedRow.Cells["Price4P"].Value.ToString();

            }
        }

        private void btnSaveType_Click(object sender, EventArgs e)
        {
            if (test2() && idd == null)
            {
                string name = txtTypeName.Text;
                string amount = txtAmount.Text;
                int price2p = int.Parse(txtPrice2P.Text);
                int price4p = int.Parse(txtPrice4P.Text);

                // Call the method to add the new worker
                model.AddType(name, amount, price2p, price4p);

                // Optionally, refresh the DataGridView to show updated data
                model.LoadTypesToDataGridView(listType);
                // Optionally, clear the form fields after adding
                clearForm2();

                MessageBox.Show("New worker added successfully!", "Add Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTypesIntoComboBox();
            }
            else if (idd != null)
            {
                MessageBox.Show("Your in edit mode!", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool test2()
        {
            if (txtTypeName.Text == "")
            {
                MessageBox.Show("Please enter the name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = false;
                lblTypeName.Visible = true;
                lblPrice2P.Visible = false;
                lblPrice4P.Visible = false;
                return false;
            }
            else if (txtAmount.Text == "")
            {
                MessageBox.Show("Please enter the amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = true;
                lblTypeName.Visible = false;
                lblPrice2P.Visible = false;
                lblPrice4P.Visible = false;
                return false;
            }
            else if (txtPrice2P.Text == "")
            {
                MessageBox.Show("Please enter the price for 2P", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = false;
                lblTypeName.Visible = false;
                lblPrice2P.Visible = true;
                lblPrice4P.Visible = false;
                return false;
            }
            else if (txtPrice4P.Text == "")
            {
                MessageBox.Show("Please enter the price for 4P", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAmount.Visible = false;
                lblTypeName.Visible = false;
                lblPrice2P.Visible = false;
                lblPrice4P.Visible = true;
                return false;
            }
            else
            {
                lblAmount.Visible = false;
                lblTypeName.Visible = false;
                lblPrice2P.Visible = false;
                lblPrice4P.Visible = false;
                return true;
            }



        }
        private void clearForm2()
        {
            txtTypeName.Text = "";
            txtAmount.Text = "";
            txtPrice2P.Text = "";
            txtPrice4P.Text = "";
            idd = null;
            lblAmount.Visible = false;
            lblTypeName.Visible = false;
            lblPrice2P.Visible = false;
            lblPrice4P.Visible = false;

        }

        private void btnResetType_Click(object sender, EventArgs e)
        {
            clearForm2();
        }

        private void btnEditType_Click(object sender, EventArgs e)
        {
            if (listType.SelectedRows.Count > 0) // Ensure a row is selected
            {
                if (test2() && idd != null)
                {
                    int ident = int.Parse(idd); // Get the ID from the label
                    string name = txtTypeName.Text;
                    string amount = txtAmount.Text;
                    int price2p = int.Parse(txtPrice2P.Text);
                    int price4p = int.Parse(txtPrice4P.Text);

                    model.UpdateType(ident, name, amount, price2p, price4p);

                    // Optionally, refresh the DataGridView to show updated data
                    model.LoadTypesToDataGridView(listType);
                    clearForm2();

                    MessageBox.Show("Type details updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTypesIntoComboBox();

                }
            }
            else
            {
                MessageBox.Show("Please select a type to edit.", "Edit Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (listType.SelectedRows.Count > 0)
            {

                int ident = Int32.Parse(idd);

                // Ask for confirmation
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Type?",
                                                            "Delete Type",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                // If the user clicks 'Yes', delete the worker
                if (dialogResult == DialogResult.Yes)
                {
                    model.DeleteType(ident); // Call the method to delete the worker

                    // Refresh the DataGridView to show the updated list
                    model.LoadTypesToDataGridView(listType);
                    clearForm2();
                    MessageBox.Show("Type deleted successfully!", "Delete Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTypesIntoComboBox();

                }
            }
            else
            {
                MessageBox.Show("Please select a Type to delete.", "Delete Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem != null)
            {
                var selectedCategory = (TypeItem)comboBoxCategory.SelectedItem;
                categoryId = selectedCategory.ID;
                categoryName = selectedCategory.Name;

            }
        }
    }
}
