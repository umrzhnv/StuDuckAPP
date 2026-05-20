namespace StuDuckAPP
{
    partial class ProfileForm
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ToMainForm = new System.Windows.Forms.Button();
            this.ToProfileForm = new System.Windows.Forms.Button();
            this.ToGrades = new System.Windows.Forms.Button();
            this.ToRaspisanie = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.panel_slide = new System.Windows.Forms.Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddressValue = new System.Windows.Forms.Label();
            this.labelEmailValue = new System.Windows.Forms.Label();
            this.labelGenderValue = new System.Windows.Forms.Label();
            this.labelDateOfBirthValue = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            this.panel_slide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Sitka Display", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.Location = new System.Drawing.Point(271, 12);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(65, 33);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.guna2PictureBox4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Indigo;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 55);
            this.panel1.TabIndex = 0;
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.Image = global::StuDuckAPP.Properties.Resources.logo;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(48, -3);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(59, 55);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox4.TabIndex = 2;
            this.guna2PictureBox4.TabStop = false;
            this.guna2PictureBox4.UseTransparentBackground = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gabriola", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Beige;
            this.label3.Location = new System.Drawing.Point(84, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 51);
            this.label3.TabIndex = 3;
            this.label3.Text = "tuDuck";
            // 
            // ToMainForm
            // 
            this.ToMainForm.BackColor = System.Drawing.Color.Indigo;
            this.ToMainForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToMainForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToMainForm.FlatAppearance.BorderSize = 0;
            this.ToMainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToMainForm.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToMainForm.ForeColor = System.Drawing.Color.Lavender;
            this.ToMainForm.Location = new System.Drawing.Point(0, 55);
            this.ToMainForm.Name = "ToMainForm";
            this.ToMainForm.Size = new System.Drawing.Size(225, 45);
            this.ToMainForm.TabIndex = 1;
            this.ToMainForm.Text = "Главная";
            this.ToMainForm.UseVisualStyleBackColor = false;
            this.ToMainForm.Click += new System.EventHandler(this.ToMainForm_Click);
            // 
            // ToProfileForm
            // 
            this.ToProfileForm.BackColor = System.Drawing.Color.Indigo;
            this.ToProfileForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToProfileForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToProfileForm.FlatAppearance.BorderSize = 0;
            this.ToProfileForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToProfileForm.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic);
            this.ToProfileForm.ForeColor = System.Drawing.Color.Lavender;
            this.ToProfileForm.Location = new System.Drawing.Point(0, 100);
            this.ToProfileForm.Name = "ToProfileForm";
            this.ToProfileForm.Size = new System.Drawing.Size(225, 45);
            this.ToProfileForm.TabIndex = 2;
            this.ToProfileForm.Text = "Профиль";
            this.ToProfileForm.UseVisualStyleBackColor = false;
            // 
            // ToGrades
            // 
            this.ToGrades.BackColor = System.Drawing.Color.Indigo;
            this.ToGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToGrades.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToGrades.FlatAppearance.BorderSize = 0;
            this.ToGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToGrades.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic);
            this.ToGrades.ForeColor = System.Drawing.Color.Lavender;
            this.ToGrades.Location = new System.Drawing.Point(0, 145);
            this.ToGrades.Name = "ToGrades";
            this.ToGrades.Size = new System.Drawing.Size(225, 45);
            this.ToGrades.TabIndex = 3;
            this.ToGrades.Text = "Успеваемость";
            this.ToGrades.UseVisualStyleBackColor = false;
            this.ToGrades.Click += new System.EventHandler(this.ToGrades_Click);
            // 
            // ToRaspisanie
            // 
            this.ToRaspisanie.BackColor = System.Drawing.Color.Indigo;
            this.ToRaspisanie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToRaspisanie.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToRaspisanie.FlatAppearance.BorderSize = 0;
            this.ToRaspisanie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToRaspisanie.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic);
            this.ToRaspisanie.ForeColor = System.Drawing.Color.Lavender;
            this.ToRaspisanie.Location = new System.Drawing.Point(0, 190);
            this.ToRaspisanie.Name = "ToRaspisanie";
            this.ToRaspisanie.Size = new System.Drawing.Size(225, 45);
            this.ToRaspisanie.TabIndex = 4;
            this.ToRaspisanie.Text = "Расписание";
            this.ToRaspisanie.UseVisualStyleBackColor = false;
            this.ToRaspisanie.Click += new System.EventHandler(this.ToRaspisanie_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Indigo;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic);
            this.Exit.ForeColor = System.Drawing.Color.Lavender;
            this.Exit.Location = new System.Drawing.Point(0, 235);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(225, 45);
            this.Exit.TabIndex = 5;
            this.Exit.Text = "Выйти";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel_slide
            // 
            this.panel_slide.BackColor = System.Drawing.Color.Indigo;
            this.panel_slide.Controls.Add(this.Exit);
            this.panel_slide.Controls.Add(this.ToRaspisanie);
            this.panel_slide.Controls.Add(this.ToGrades);
            this.panel_slide.Controls.Add(this.ToProfileForm);
            this.panel_slide.Controls.Add(this.ToMainForm);
            this.panel_slide.Controls.Add(this.panel1);
            this.panel_slide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_slide.Location = new System.Drawing.Point(0, 0);
            this.panel_slide.Name = "panel_slide";
            this.panel_slide.Size = new System.Drawing.Size(225, 688);
            this.panel_slide.TabIndex = 2;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::StuDuckAPP.Properties.Resources.Vacancy;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(73, 14);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(189, 189);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 6;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Indigo;
            this.guna2Panel1.BorderRadius = 230;
            this.guna2Panel1.Controls.Add(this.labelDateOfBirthValue);
            this.guna2Panel1.Controls.Add(this.labelGenderValue);
            this.guna2Panel1.Controls.Add(this.labelEmailValue);
            this.guna2Panel1.Controls.Add(this.labelAddressValue);
            this.guna2Panel1.Controls.Add(this.labelName);
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel1.ForeColor = System.Drawing.Color.Indigo;
            this.guna2Panel1.Location = new System.Drawing.Point(246, 55);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(884, 254);
            this.guna2Panel1.TabIndex = 16;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Beige;
            this.labelName.Location = new System.Drawing.Point(370, 16);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(56, 29);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "label1";
            // 
            // labelAddressValue
            // 
            this.labelAddressValue.AutoSize = true;
            this.labelAddressValue.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAddressValue.ForeColor = System.Drawing.Color.Beige;
            this.labelAddressValue.Location = new System.Drawing.Point(370, 61);
            this.labelAddressValue.Name = "labelAddressValue";
            this.labelAddressValue.Size = new System.Drawing.Size(56, 29);
            this.labelAddressValue.TabIndex = 8;
            this.labelAddressValue.Text = "label1";
            // 
            // labelEmailValue
            // 
            this.labelEmailValue.AutoSize = true;
            this.labelEmailValue.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmailValue.ForeColor = System.Drawing.Color.Beige;
            this.labelEmailValue.Location = new System.Drawing.Point(370, 106);
            this.labelEmailValue.Name = "labelEmailValue";
            this.labelEmailValue.Size = new System.Drawing.Size(56, 29);
            this.labelEmailValue.TabIndex = 9;
            this.labelEmailValue.Text = "label1";
            // 
            // labelGenderValue
            // 
            this.labelGenderValue.AutoSize = true;
            this.labelGenderValue.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenderValue.ForeColor = System.Drawing.Color.Beige;
            this.labelGenderValue.Location = new System.Drawing.Point(370, 151);
            this.labelGenderValue.Name = "labelGenderValue";
            this.labelGenderValue.Size = new System.Drawing.Size(56, 29);
            this.labelGenderValue.TabIndex = 10;
            this.labelGenderValue.Text = "label1";
            // 
            // labelDateOfBirthValue
            // 
            this.labelDateOfBirthValue.AutoSize = true;
            this.labelDateOfBirthValue.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateOfBirthValue.ForeColor = System.Drawing.Color.Beige;
            this.labelDateOfBirthValue.Location = new System.Drawing.Point(370, 196);
            this.labelDateOfBirthValue.Name = "labelDateOfBirthValue";
            this.labelDateOfBirthValue.Size = new System.Drawing.Size(56, 29);
            this.labelDateOfBirthValue.TabIndex = 11;
            this.labelDateOfBirthValue.Text = "label1";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1142, 688);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.panel_slide);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            this.panel_slide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ToMainForm;
        private System.Windows.Forms.Button ToProfileForm;
        private System.Windows.Forms.Button ToGrades;
        private System.Windows.Forms.Button ToRaspisanie;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Panel panel_slide;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label labelDateOfBirthValue;
        private System.Windows.Forms.Label labelGenderValue;
        private System.Windows.Forms.Label labelEmailValue;
        private System.Windows.Forms.Label labelAddressValue;
        private System.Windows.Forms.Label labelName;
    }
}