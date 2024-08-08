namespace Deneme1
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCourseCode = new TextBox();
            txtCourseName = new TextBox();
            txtClass = new TextBox();
            txtTeacherName = new TextBox();
            button2 = new Button();
            dgvStudents = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 83);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 13;
            label1.Text = "Şagirdin Nömrəsi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 130);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 14;
            label2.Text = "Şagirdin Adı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 175);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 15;
            label3.Text = "Şagirdin Soyadı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 222);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 16;
            label4.Text = "Şagirdin Sinifi:";
            // 
            // txtCourseCode
            // 
            txtCourseCode.Location = new Point(296, 83);
            txtCourseCode.Name = "txtCourseCode";
            txtCourseCode.Size = new Size(231, 27);
            txtCourseCode.TabIndex = 18;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(296, 127);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(231, 27);
            txtCourseName.TabIndex = 19;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(294, 175);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(233, 27);
            txtClass.TabIndex = 20;
            // 
            // txtTeacherName
            // 
            txtTeacherName.Location = new Point(295, 222);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(232, 27);
            txtTeacherName.TabIndex = 21;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientInactiveCaption;
            button2.Location = new Point(424, 285);
            button2.Name = "button2";
            button2.Size = new Size(103, 43);
            button2.TabIndex = 24;
            button2.Text = "Qeydə Alın";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.BackgroundColor = SystemColors.ButtonHighlight;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(559, 43);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 29;
            dgvStudents.Size = new Size(425, 348);
            dgvStudents.TabIndex = 25;
            dgvStudents.DoubleClick += dgvStudents_DoubleClick_1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Location = new Point(206, 285);
            button1.Name = "button1";
            button1.Size = new Size(103, 43);
            button1.TabIndex = 26;
            button1.Text = "Sil";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GradientInactiveCaption;
            button3.Location = new Point(315, 285);
            button3.Name = "button3";
            button3.Size = new Size(103, 43);
            button3.TabIndex = 27;
            button3.Text = "Yenilə";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dgvStudents);
            Controls.Add(button2);
            Controls.Add(txtTeacherName);
            Controls.Add(txtClass);
            Controls.Add(txtCourseName);
            Controls.Add(txtCourseCode);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            Text = "Şagirdlərin Registrasiyası";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCourseCode;
        private TextBox txtCourseName;
        private TextBox txtClass;
        private TextBox txtTeacherName;
        private Button button2;
        private DataGridView dgvStudents;
        private Button button1;
        private Button button3;
    }
}