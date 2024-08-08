using System.Formats.Asn1;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
//using Microsoft.Data.SqlClient;
namespace Deneme1
{
    public class CourseOperationException : Exception
    {
        public CourseOperationException(string message) : base(message)
        {
            MessageBox.Show(message);
        }
    }
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCoursesGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
                string courseCode = txtCourseCode.Text.Trim();
                string courseName = txtCourseName.Text.Trim();
                int classNumber = Convert.ToInt32(txtClass.Text);
                string teacherName = txtTeacherName.Text.Trim();
                string teacherSurname = txtTeacherSurname.Text.Trim();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Courses (CourseCode, CourseName, Class,TeacherName, TeacherSurname) VALUES (@Code, @Name, @Class, @Tname, @Tsurname);";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", courseCode);
                        command.Parameters.AddWithValue("@Name", courseName);
                        command.Parameters.AddWithValue("@Class", classNumber);
                        command.Parameters.AddWithValue("@Tname", teacherName);
                        command.Parameters.AddWithValue("@Tsurname", teacherSurname);
                        if (classNumber > 99)
                        {
                            throw new CourseOperationException("Xətalı sinif nömrəsi");
                        }
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dərs uğurla qeydiyyatdan keçdi!");
                            PopulateCoursesGrid();
                            // Clear the text boxes for the next entry
                            txtCourseCode.Text = "";
                            txtCourseName.Text = "";
                            txtClass.Text = "";
                            txtTeacherName.Text = "";
                            txtTeacherSurname.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Qeydiyyat zamanı xəta baş verdi.");
                        }
                    }
                }
            }
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) {; }
        }
        private void PopulateCoursesGrid()
        {
            string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CourseCode, CourseName, Class,TeacherName,TeacherSurname FROM Courses";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvCourses.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void txtCourseCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCourses_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow.Index != -1)
            {
                txtCourseCode.Text = dgvCourses.CurrentRow.Cells[0].Value.ToString();
                txtCourseName.Text = dgvCourses.CurrentRow.Cells[1].Value.ToString(); ;
                txtClass.Text = dgvCourses.CurrentRow.Cells[2].Value.ToString(); ;
                txtTeacherName.Text = dgvCourses.CurrentRow.Cells[3].Value.ToString(); ;
                txtTeacherSurname.Text = dgvCourses.CurrentRow.Cells[4].Value.ToString(); ;

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
                string courseCode = txtCourseCode.Text.Trim();
                string courseName = txtCourseName.Text.Trim();
                int classNumber = Convert.ToInt32(txtClass.Text);
                string teacherName = txtTeacherName.Text.Trim();
                string teacherSurname = txtTeacherSurname.Text.Trim();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "UPDATE Courses SET CourseCode=@Code, CourseName=@Name, Class=@Class, TeacherName=@TName, TeacherSurname=@TSurname WHERE CourseCode=@Code";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", courseCode);
                        command.Parameters.AddWithValue("@Name", courseName);
                        command.Parameters.AddWithValue("@Class", classNumber);
                        command.Parameters.AddWithValue("@Tname", teacherName);
                        command.Parameters.AddWithValue("@Tsurname", teacherSurname);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dərs uğurla yeniləndi!");
                            PopulateCoursesGrid();
                            // Clear the text boxes for the next entry
                            txtCourseCode.Clear();
                            txtCourseName.Clear();
                            txtClass.Clear();
                            txtTeacherName.Clear();
                            txtTeacherSurname.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
                string courseCode = txtCourseCode.Text.Trim();
                string courseName = txtCourseName.Text.Trim();
                int classNumber = Convert.ToInt32(txtClass.Text);
                string teacherName = txtTeacherName.Text.Trim();
                string teacherSurname = txtTeacherSurname.Text.Trim();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "DELETE Courses WHERE CourseCode=@Code";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", courseCode);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dərs uğurla silindi");
                            PopulateCoursesGrid();
                            // Clear the text boxes for the next entry
                            txtCourseCode.Text = "";
                            txtCourseName.Text = "";
                            txtClass.Text = "";
                            txtTeacherName.Text = "";
                            txtTeacherSurname.Text = "";
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

        // OPTIMIZATION COMBOBOXES !!!!!!!!!!!!!!!!!!

    }
}

