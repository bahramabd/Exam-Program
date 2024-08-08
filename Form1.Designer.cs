namespace Deneme1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCourseCode = new TextBox();
            txtCourseName = new TextBox();
            txtClass = new TextBox();
            txtTeacherName = new TextBox();
            txtTeacherSurname = new TextBox();
            button2 = new Button();
            dgvCourses = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 64);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 0;
            label1.Text = "Dərsin Kodu:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 111);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 1;
            label2.Text = "Dərsin Adı:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 156);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Sinifi:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 203);
            label4.Name = "label4";
            label4.Size = new Size(184, 20);
            label4.TabIndex = 3;
            label4.Text = "Dərsi Verən Müəllimin Adı:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(92, 253);
            label5.Name = "label5";
            label5.Size = new Size(206, 20);
            label5.TabIndex = 4;
            label5.Text = "Dərsi Verən Müəllimin Soyadı:";
            label5.Click += label5_Click;
            // 
            // txtCourseCode
            // 
            txtCourseCode.Location = new Point(300, 64);
            txtCourseCode.Name = "txtCourseCode";
            txtCourseCode.Size = new Size(231, 27);
            txtCourseCode.TabIndex = 5;
            txtCourseCode.TextChanged += txtCourseCode_TextChanged;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(300, 108);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(231, 27);
            txtCourseName.TabIndex = 6;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(298, 156);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(233, 27);
            txtClass.TabIndex = 7;
            // 
            // txtTeacherName
            // 
            txtTeacherName.Location = new Point(299, 203);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(232, 27);
            txtTeacherName.TabIndex = 8;
            // 
            // txtTeacherSurname
            // 
            txtTeacherSurname.Location = new Point(299, 250);
            txtTeacherSurname.Name = "txtTeacherSurname";
            txtTeacherSurname.Size = new Size(232, 27);
            txtTeacherSurname.TabIndex = 9;
            txtTeacherSurname.TextChanged += textBox5_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientInactiveCaption;
            button2.Location = new Point(428, 304);
            button2.Name = "button2";
            button2.Size = new Size(103, 43);
            button2.TabIndex = 12;
            button2.Text = "Qeydə Alın";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dgvCourses
            // 
            dgvCourses.BackgroundColor = SystemColors.ButtonHighlight;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(554, 36);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.RowTemplate.Height = 29;
            dgvCourses.Size = new Size(458, 348);
            dgvCourses.TabIndex = 13;
            dgvCourses.CellContentClick += dataGridView1_CellContentClick;
            dgvCourses.DoubleClick += dgvCourses_DoubleClick;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.Location = new Point(321, 304);
            button1.Name = "button1";
            button1.Size = new Size(101, 43);
            button1.TabIndex = 38;
            button1.Text = "Yenilə";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GradientInactiveCaption;
            button3.Location = new Point(214, 304);
            button3.Name = "button3";
            button3.Size = new Size(101, 43);
            button3.TabIndex = 39;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dgvCourses);
            Controls.Add(button2);
            Controls.Add(txtTeacherSurname);
            Controls.Add(txtTeacherName);
            Controls.Add(txtClass);
            Controls.Add(txtCourseName);
            Controls.Add(txtCourseCode);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "İmtahan Proqramı";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCourseCode;
        private TextBox txtCourseName;
        private TextBox txtClass;
        private TextBox txtTeacherName;
        private TextBox txtTeacherSurname;
        private Button button2;
        private DataGridView dgvCourses;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button button1;
        private Button button3;
    }
}