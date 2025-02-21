namespace Gamming_Center
{
    partial class ps4Timer
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
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStop2 = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.txtMasked = new System.Windows.Forms.MaskedTextBox();
            this.btnReset = new FontAwesome.Sharp.IconButton();
            this.btnStart = new FontAwesome.Sharp.IconButton();
            this.consolType = new System.Windows.Forms.PictureBox();
            this.lblPrice4 = new System.Windows.Forms.Label();
            this.lblPrice2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.consolType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblTimer.Location = new System.Drawing.Point(204, 80);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(90, 25);
            this.lblTimer.TabIndex = 3;
            this.lblTimer.Text = "00:00:00";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStop.Location = new System.Drawing.Point(3, 145);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 30);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "2P";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStop2
            // 
            this.btnStop2.BackColor = System.Drawing.Color.Transparent;
            this.btnStop2.Enabled = false;
            this.btnStop2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStop2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnStop2.Location = new System.Drawing.Point(234, 145);
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Size = new System.Drawing.Size(60, 30);
            this.btnStop2.TabIndex = 6;
            this.btnStop2.Text = "4P";
            this.btnStop2.UseVisualStyleBackColor = false;
            this.btnStop2.Click += new System.EventHandler(this.btnStop2_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblStart.Location = new System.Drawing.Point(204, 48);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(90, 25);
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "00:00:00";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblEnd.Location = new System.Drawing.Point(204, 112);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(90, 25);
            this.lblEnd.TabIndex = 8;
            this.lblEnd.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(4, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "End Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label3.Location = new System.Drawing.Point(4, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Elapced Time:";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.BackColor = System.Drawing.Color.Transparent;
            this.lblPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblPost.Location = new System.Drawing.Point(115, 0);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(86, 29);
            this.lblPost.TabIndex = 13;
            this.lblPost.Text = "Post 1";
            // 
            // txtMasked
            // 
            this.txtMasked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(240)))));
            this.txtMasked.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMasked.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.txtMasked.Location = new System.Drawing.Point(91, 142);
            this.txtMasked.Mask = "00:00:00";
            this.txtMasked.Name = "txtMasked";
            this.txtMasked.Size = new System.Drawing.Size(122, 31);
            this.txtMasked.TabIndex = 17;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.btnReset.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReset.IconSize = 35;
            this.btnReset.Location = new System.Drawing.Point(259, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(35, 35);
            this.btnReset.TabIndex = 9;
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
            this.btnStart.IconSize = 35;
            this.btnStart.Location = new System.Drawing.Point(9, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(35, 35);
            this.btnStart.TabIndex = 4;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // consolType
            // 
            this.consolType.Location = new System.Drawing.Point(114, 31);
            this.consolType.Name = "consolType";
            this.consolType.Size = new System.Drawing.Size(89, 47);
            this.consolType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.consolType.TabIndex = 19;
            this.consolType.TabStop = false;
            // 
            // lblPrice4
            // 
            this.lblPrice4.AutoSize = true;
            this.lblPrice4.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblPrice4.Location = new System.Drawing.Point(226, 176);
            this.lblPrice4.Name = "lblPrice4";
            this.lblPrice4.Size = new System.Drawing.Size(23, 25);
            this.lblPrice4.TabIndex = 20;
            this.lblPrice4.Text = "0";
            // 
            // lblPrice2
            // 
            this.lblPrice2.AutoSize = true;
            this.lblPrice2.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblPrice2.Location = new System.Drawing.Point(-1, 176);
            this.lblPrice2.Name = "lblPrice2";
            this.lblPrice2.Size = new System.Drawing.Size(23, 25);
            this.lblPrice2.TabIndex = 21;
            this.lblPrice2.Text = "0";
            // 
            // ps4Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(240)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblPrice2);
            this.Controls.Add(this.lblPrice4);
            this.Controls.Add(this.txtMasked);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.btnStop2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.consolType);
            this.DoubleBuffered = true;
            this.Name = "ps4Timer";
            this.Size = new System.Drawing.Size(300, 200);
            ((System.ComponentModel.ISupportInitialize)(this.consolType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnStart;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStop2;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private FontAwesome.Sharp.IconButton btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.MaskedTextBox txtMasked;
        private System.Windows.Forms.PictureBox consolType;
        private System.Windows.Forms.Label lblPrice4;
        private System.Windows.Forms.Label lblPrice2;
    }
}
