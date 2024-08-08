using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Deneme1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
            int studentNum = Convert.ToInt32(txtCourseCode.Text);
            string studentName = txtCourseName.Text.Trim();
            string studentSurname = txtClass.Text.Trim();
            int studentClass = Convert.ToInt32(txtTeacherName.Text);


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "INSERT INTO Students (StudentNum, StudentName, StudentSurname,StudentClass) VALUES (@Code, @Name, @Class, @Tname);";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Code", studentNum);
                    command.Parameters.AddWithValue("@Name", studentName);
                    command.Parameters.AddWithValue("@Class", studentSurname);
                    command.Parameters.AddWithValue("@Tname", studentClass);


                    int rowsAffected = command.ExecuteNonQuery();
                    PopulateCoursesGrid();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Şagird uğurla qeydiyyatdan keçdi!");
                        // Clear the text boxes for the next entry
                        txtCourseCode.Text = "";
                        txtCourseName.Text = "";
                        txtClass.Text = "";
                        txtTeacherName.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Qeydiyyat zamanı xəta baş verdi");
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PopulateCoursesGrid();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void PopulateCoursesGrid()
        {
            string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT StudentNum, StudentName, StudentSurname,StudentClass FROM Students";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvStudents.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
                int studentNum = Convert.ToInt32(txtCourseCode.Text);
                string studentName = txtCourseName.Text.Trim();
                string studentSurname = txtClass.Text.Trim();
                int studentClass = Convert.ToInt32(txtTeacherName.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "UPDATE Students SET StudentNum=@Code, StudentName=@Name, StudentSurname=@Class, StudentClass=@TName WHERE StudentNum=@Code";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", studentNum);
                        command.Parameters.AddWithValue("@Name", studentName);
                        command.Parameters.AddWithValue("@Class", studentSurname);
                        command.Parameters.AddWithValue("@Tname", studentClass);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dərs uğurla yeniləndi!");
                            PopulateCoursesGrid();
                            // Clear the text boxes for the next entry
                            txtCourseCode.Text = "";
                            txtCourseName.Text = "";
                            txtClass.Text = "";
                            txtTeacherName.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Qeydiyyat zamanı xəta baş verdi.");
                        }
                    }
                }
            }
            catch { MessageBox.Show("Qeydiyyat zamanı xəta baş verdi."); }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
                int studentNum = Convert.ToInt32(txtCourseCode.Text);
                string studentName = txtCourseName.Text.Trim();
                string studentSurname = txtClass.Text.Trim();
                int studentClass = Convert.ToInt32(txtTeacherName.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "DELETE Students WHERE StudentNum=@Code";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", studentNum);



                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dərs uğurla silindi!");
                            PopulateCoursesGrid();
                            // Clear the text boxes for the next entry
                            txtCourseCode.Text = "";
                            txtCourseName.Text = "";
                            txtClass.Text = "";
                            txtTeacherName.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Qeydiyyat zamanı xəta baş verdi.");
                        }
                    }
                }
            }
            catch { MessageBox.Show("Qeydiyyat zamanı xəta baş verdi."); }
        }

        private void dgvStudents_DoubleClick_1(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow.Index != -1)
            {
                txtCourseCode.Text = dgvStudents.CurrentRow.Cells[0].Value.ToString();
                txtCourseName.Text = dgvStudents.CurrentRow.Cells[1].Value.ToString(); ;
                txtClass.Text = dgvStudents.CurrentRow.Cells[2].Value.ToString(); ;
                txtTeacherName.Text = dgvStudents.CurrentRow.Cells[3].Value.ToString(); ;


            }
        }
    }
}

