using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Gamming_Center.Models;

namespace Gamming_Center
{
    public partial class Worker : Form
    {
        private WorkerModel model;
        private string id = null;
        public Worker()
        {
            InitializeComponent();
            model = new WorkerModel();
            model.LoadWorkersToDataGridView(listWorker);
        }

        private void listWorker_SelectionChanged(object sender, EventArgs e)
        {
            if (listWorker.SelectedRows.Count > 0) // Ensure a row is selected
            {
                var selectedRow = listWorker.SelectedRows[0];
                id = selectedRow.Cells["ID"].Value.ToString();
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
                txtMail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtPassword.Text = selectedRow.Cells["Password"].Value.ToString();
                string level = selectedRow.Cells["Level"].Value.ToString();
                if (level == "Admin")
                {
                    rdAdmin.Checked = true;

                }
                else if (level == "Worker")
                {
                    rdWorker.Checked = true;

                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listWorker.SelectedRows.Count > 0) // Ensure a row is selected
            {
                if (test() && id != null)
                {
                    int ident = int.Parse(id); // Get the ID from the label
                    string name = txtName.Text;
                    string phone = txtPhone.Text;
                    string email = txtMail.Text;
                    string lvl = "Worker";
                    if (rdAdmin.Checked)
                    {
                        lvl = "Admin";
                    }
                    else if (rdWorker.Checked)
                    {
                        lvl = "Worker";
                    }
                    string password = txtPassword.Text;

                    model.UpdateWorker(ident, name, phone, email, lvl, password);

                    // Optionally, refresh the DataGridView to show updated data
                    model.LoadWorkersToDataGridView(listWorker);
                    clearForm();

                    MessageBox.Show("Worker details updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Please select a worker to edit.", "Edit Worker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        private void clearForm()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtMail.Text = "";
            txtPassword.Text = "";
            rdAdmin.Checked = false;
            rdWorker.Checked = false;
            id = null;
            errRole.Visible = false;
            errName.Visible = false;
            errPassword.Visible = false;
            errPhone.Visible = false;
            errMail.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (test() && id == null)
            {
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string email = txtMail.Text;

                // Check which radio button is selected for the 'Level' property
                string level = rdAdmin.Checked ? "Admin" : "Worker";

                string password = txtPassword.Text;

                // Call the method to add the new worker
                model.AddWorker(name, phone, email, level, password);

                // Optionally, refresh the DataGridView to show updated data
                model.LoadWorkersToDataGridView(listWorker);
                // Optionally, clear the form fields after adding
                clearForm();

                MessageBox.Show("New worker added successfully!", "Add Worker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (id != null)
            {
                MessageBox.Show("Your in edit mode!", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            


        }
        private bool test()
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("Please enter the name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errName.Visible = true;
                errRole.Visible = false;
                errPassword.Visible = false;
                errPhone.Visible = false;
                errMail.Visible = false;
                return false;
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Please enter the phone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errPhone.Visible = true;
                errRole.Visible = false;
                errPassword.Visible = false;
                errName.Visible = false;
                errMail.Visible = false;
                return false;
            }
            else if (txtMail.Text == "")
            {
                MessageBox.Show("Please enter the email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errMail.Visible = true;
                errRole.Visible = false;
                errPassword.Visible = false;
                errPhone.Visible = false;
                errName.Visible = false;
                return false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter the password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errPassword.Visible = true;
                errRole.Visible = false;
                errName.Visible = false;
                errPhone.Visible = false;
                errMail.Visible = false;
                return false;
            }
            else if (rdAdmin.Checked == false && rdWorker.Checked == false)
            {
                MessageBox.Show("Please select the level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errRole.Visible = true;
                errName.Visible = false;
                errPassword.Visible = false;
                errPhone.Visible = false;
                errMail.Visible = false;
                return false;
            }
            else
            {
                errRole.Visible = false;
                errName.Visible = false;
                errPassword.Visible = false;
                errPhone.Visible = false;
                errMail.Visible = false;
                return true;
            }

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (listWorker.SelectedRows.Count > 0)
            {
                
                int ident = Int32.Parse(id);

                // Ask for confirmation
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this worker?",
                                                            "Delete Worker",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                // If the user clicks 'Yes', delete the worker
                if (dialogResult == DialogResult.Yes)
                {
                    model.DeleteWorker(ident); // Call the method to delete the worker

                    // Refresh the DataGridView to show the updated list
                    model.LoadWorkersToDataGridView(listWorker);
                    clearForm();
                    MessageBox.Show("Worker deleted successfully!", "Delete Worker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            else
            {
                MessageBox.Show("Please select a worker to delete.", "Delete Worker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Worker_Load(object sender, EventArgs e)
        {

        }
    }
    
}
