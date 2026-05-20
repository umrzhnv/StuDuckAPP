namespace StuDuckAPP
{
    partial class ScheduleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_slide = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.ToRaspisanie = new System.Windows.Forms.Button();
            this.ToGrades = new System.Windows.Forms.Button();
            this.ToProfileForm = new System.Windows.Forms.Button();
            this.ToMainForm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel_slide.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.panel_slide.TabIndex = 3;
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
            this.ToProfileForm.Click += new System.EventHandler(this.ToProfileForm_Click);
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
            // guna2DataGridView1
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.guna2DataGridView1.ColumnHeadersHeight = 55;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(242, 55);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 55;
            this.guna2DataGridView1.Size = new System.Drawing.Size(888, 598);
            this.guna2DataGridView1.TabIndex = 4;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 55;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 55;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1142, 688);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.panel_slide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.panel_slide.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_slide;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button ToRaspisanie;
        private System.Windows.Forms.Button ToGrades;
        private System.Windows.Forms.Button ToProfileForm;
        private System.Windows.Forms.Button ToMainForm;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private System.Windows.Forms.Label label3;
    }
}