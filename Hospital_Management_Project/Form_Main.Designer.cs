namespace Hospital_Management_Project
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.buttonPatientEnter = new System.Windows.Forms.Button();
            this.buttonDoctorEnter = new System.Windows.Forms.Button();
            this.buttonSecretaryEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPatientEnter
            // 
            this.buttonPatientEnter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPatientEnter.BackgroundImage")));
            this.buttonPatientEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPatientEnter.Location = new System.Drawing.Point(44, 158);
            this.buttonPatientEnter.Name = "buttonPatientEnter";
            this.buttonPatientEnter.Size = new System.Drawing.Size(194, 94);
            this.buttonPatientEnter.TabIndex = 0;
            this.buttonPatientEnter.UseVisualStyleBackColor = true;
            this.buttonPatientEnter.Click += new System.EventHandler(this.buttonPatientEnter_Click);
            // 
            // buttonDoctorEnter
            // 
            this.buttonDoctorEnter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDoctorEnter.BackgroundImage")));
            this.buttonDoctorEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDoctorEnter.Location = new System.Drawing.Point(282, 158);
            this.buttonDoctorEnter.Name = "buttonDoctorEnter";
            this.buttonDoctorEnter.Size = new System.Drawing.Size(194, 94);
            this.buttonDoctorEnter.TabIndex = 1;
            this.buttonDoctorEnter.UseVisualStyleBackColor = true;
            this.buttonDoctorEnter.Click += new System.EventHandler(this.buttonDoctorEnter_Click);
            // 
            // buttonSecretaryEnter
            // 
            this.buttonSecretaryEnter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSecretaryEnter.BackgroundImage")));
            this.buttonSecretaryEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSecretaryEnter.Location = new System.Drawing.Point(512, 158);
            this.buttonSecretaryEnter.Name = "buttonSecretaryEnter";
            this.buttonSecretaryEnter.Size = new System.Drawing.Size(194, 94);
            this.buttonSecretaryEnter.TabIndex = 2;
            this.buttonSecretaryEnter.UseVisualStyleBackColor = true;
            this.buttonSecretaryEnter.Click += new System.EventHandler(this.buttonSecretaryEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(101, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(351, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Doctor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(567, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secretary";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(557, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "BABOCHKA HOSPİTAL";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(747, 317);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSecretaryEnter);
            this.Controls.Add(this.buttonDoctorEnter);
            this.Controls.Add(this.buttonPatientEnter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Text = "Babochka Hospital";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPatientEnter;
        private System.Windows.Forms.Button buttonDoctorEnter;
        private System.Windows.Forms.Button buttonSecretaryEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}

