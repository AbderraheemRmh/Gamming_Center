namespace Gamming_Center
{
    partial class soloTimer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMasked = new System.Windows.Forms.MaskedTextBox();
            this.lblPost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReset = new FontAwesome.Sharp.IconButton();
            this.btnStart = new FontAwesome.Sharp.IconButton();
            this.lblPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMasked
            // 
            this.txtMasked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(240)))));
            this.txtMasked.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMasked.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.txtMasked.Location = new System.Drawing.Point(89, 148);
            this.txtMasked.Mask = "00:00:00";
            this.txtMasked.Name = "txtMasked";
            this.txtMasked.Size = new System.Drawing.Size(117, 31);
            this.txtMasked.TabIndex = 30;
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.BackColor = System.Drawing.Color.Transparent;
            this.lblPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblPost.Location = new System.Drawing.Point(117, 0);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(86, 29);
            this.lblPost.TabIndex = 29;
            this.lblPost.Text = "Post 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "End Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Elapced Time:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblEnd.Location = new System.Drawing.Point(207, 119);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(90, 25);
            this.lblEnd.TabIndex = 24;
            this.lblEnd.Text = "00:00:00";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblStart.Location = new System.Drawing.Point(207, 59);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(90, 25);
            this.lblStart.TabIndex = 23;
            this.lblStart.Text = "00:00:00";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStop.Location = new System.Drawing.Point(210, 148);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 30);
            this.btnStop.TabIndex = 22;
            this.btnStop.Text = "Done";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblTimer.Location = new System.Drawing.Point(207, 88);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(90, 25);
            this.lblTimer.TabIndex = 19;
            this.lblTimer.Text = "00:00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gamming_Center.Properties.Resources.b8;
            this.pictureBox1.Location = new System.Drawing.Point(121, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.btnReset.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReset.IconSize = 30;
            this.btnReset.Location = new System.Drawing.Point(262, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(35, 35);
            this.btnReset.TabIndex = 25;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStart.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStart.IconSize = 30;
            this.btnStart.Location = new System.Drawing.Point(11, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(35, 35);
            this.btnStart.TabIndex = 20;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblPrice.Location = new System.Drawing.Point(6, 156);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(23, 25);
            this.lblPrice.TabIndex = 33;
            this.lblPrice.Text = "0";
            // 
            // soloTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtMasked);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "soloTimer";
            this.Size = new System.Drawing.Size(300, 185);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox txtMasked;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnReset;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnStop;
        private FontAwesome.Sharp.IconButton btnStart;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPrice;
    }
}
