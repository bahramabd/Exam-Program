namespace Deneme1
{
    partial class Form3
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
            button2 = new Button();
            txtTeacherName = new TextBox();
            txtClass = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvExams = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            cmbCourses = new ComboBox();
            cmbStudents = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvExams).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientInactiveCaption;
            button2.Location = new Point(428, 274);
            button2.Name = "button2";
            button2.Size = new Size(101, 43);
            button2.TabIndex = 34;
            button2.Text = "Qeydə Alın";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtTeacherName
            // 
            txtTeacherName.Location = new Point(297, 211);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(232, 27);
            txtTeacherName.TabIndex = 32;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(296, 164);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(233, 27);
            txtClass.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 211);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 28;
            label4.Text = "Qiyməti:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 164);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 27;
            label3.Text = "İmtahan tarixi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 119);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 26;
            label2.Text = "Şagirdin Nömrəsi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 72);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 25;
            label1.Text = "Dərsin Kodu:";
            // 
            // dgvExams
            // 
            dgvExams.BackgroundColor = SystemColors.ButtonHighlight;
            dgvExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExams.Location = new Point(560, 37);
            dgvExams.Name = "dgvExams";
            dgvExams.RowHeadersWidth = 51;
            dgvExams.RowTemplate.Height = 29;
            dgvExams.Size = new Size(411, 348);
            dgvExams.TabIndex = 35;
            dgvExams.DoubleClick += dataGridView1_DoubleClick;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Location = new Point(321, 274);
            button1.Name = "button1";
            button1.Size = new Size(101, 43);
            button1.TabIndex = 36;
            button1.Text = "Yenilə";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GradientInactiveCaption;
            button3.Location = new Point(214, 274);
            button3.Name = "button3";
            button3.Size = new Size(101, 43);
            button3.TabIndex = 37;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // cmbCourses
            // 
            cmbCourses.FormattingEnabled = true;
            cmbCourses.Location = new Point(298, 69);
            cmbCourses.Name = "cmbCourses";
            cmbCourses.Size = new Size(231, 28);
            cmbCourses.TabIndex = 38;
            cmbCourses.SelectedIndexChanged += cmbCourses_SelectedIndexChanged;
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(296, 116);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(231, 28);
            cmbStudents.TabIndex = 39;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 450);
            Controls.Add(cmbStudents);
            Controls.Add(cmbCourses);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dgvExams);
            Controls.Add(button2);
            Controls.Add(txtTeacherName);
            Controls.Add(txtClass);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private TextBox txtTeacherName;
        private TextBox txtClass;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvExams;
        private Button button1;
        private Button button3;
        private ComboBox cmbCourses;
        private ComboBox cmbStudents;
    }
}