namespace Gamming_Center
{
    partial class checkoutProducts
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
            this.checkouttxt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.boughtProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnValid = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.productsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkouttxt
            // 
            this.checkouttxt.AutoSize = true;
            this.checkouttxt.BackColor = System.Drawing.Color.Transparent;
            this.checkouttxt.Font = new System.Drawing.Font("Forte", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkouttxt.ForeColor = System.Drawing.Color.White;
            this.checkouttxt.Location = new System.Drawing.Point(332, 0);
            this.checkouttxt.Name = "checkouttxt";
            this.checkouttxt.Size = new System.Drawing.Size(352, 87);
            this.checkouttxt.TabIndex = 14;
            this.checkouttxt.Text = "Checkout";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.checkouttxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 100);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.boughtProduct);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(814, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 650);
            this.panel2.TabIndex = 17;
            // 
            // boughtProduct
            // 
            this.boughtProduct.AutoScroll = true;
            this.boughtProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boughtProduct.Location = new System.Drawing.Point(0, 0);
            this.boughtProduct.Name = "boughtProduct";
            this.boughtProduct.Size = new System.Drawing.Size(286, 451);
            this.boughtProduct.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(286, 199);
            this.panel4.TabIndex = 17;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnValid);
            this.panel7.Controls.Add(this.btnCancel);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 129);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(286, 70);
            this.panel7.TabIndex = 17;
            // 
            // btnValid
            // 
            this.btnValid.BackColor = System.Drawing.Color.DarkGreen;
            this.btnValid.FlatAppearance.BorderSize = 0;
            this.btnValid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValid.ForeColor = System.Drawing.Color.Snow;
            this.btnValid.Location = new System.Drawing.Point(0, 29);
            this.btnValid.Name = "btnValid";
            this.btnValid.Size = new System.Drawing.Size(158, 41);
            this.btnValid.TabIndex = 2;
            this.btnValid.Text = "Checkout";
            this.btnValid.UseVisualStyleBackColor = false;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Snow;
            this.btnCancel.Location = new System.Drawing.Point(164, 29);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 41);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(3, 59);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(228, 67);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "000.0 DA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 38);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.productsPanel);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 650);
            this.panel3.TabIndex = 18;
            // 
            // productsPanel
            // 
            this.productsPanel.AutoScroll = true;
            this.productsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsPanel.Location = new System.Drawing.Point(0, 44);
            this.productsPanel.Name = "productsPanel";
            this.productsPanel.Size = new System.Drawing.Size(814, 606);
            this.productsPanel.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(814, 44);
            this.panel5.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(194, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 38);
            this.label4.TabIndex = 15;
            this.label4.Text = "Consommation";
            // 
            // checkoutProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "checkoutProducts";
            this.Text = "checkoutProducts";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label checkouttxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel boughtProduct;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnValid;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel productsPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
    }
}