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
using System.Globalization;
using static System.Formats.Asn1.AsnWriter;
using System.Collections;
using System.Linq.Expressions;
using Microsoft.VisualBasic.Devices;

namespace Deneme1
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
        public Form3()
        {
            InitializeComponent();
        }

        private void UpdateExam(string courseCode, decimal studentID, DateTime examDate, int score)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE  Exams SET CourseCode=@CourseCode, StudentNumber=@StudentNumber, ExamDate=@ExamDate, Score=@Score WHERE CourseCode=@CourseCode"
                                   ;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseCode", courseCode);
                        command.Parameters.AddWithValue("@StudentNumber", studentID);
                        command.Parameters.AddWithValue("@ExamDate", examDate);
                        command.Parameters.AddWithValue("@Score", score);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gözlənilməz xəta baş verdi");
            }
        }
        private void DeleteExam(string courseCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE TOP(1) from Exams WHERE CourseCode=@Code";
                    ;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", courseCode);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gözlənilməz xəta baş verdi");
            }
        }
        private void RegisterExam(string courseCode, decimal studentID, DateTime examDate, int score)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Exams (CourseCode, StudentNumber, ExamDate, Score) " +
                                   "VALUES (@CourseCode, @StudentNumber, @ExamDate, @Score)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseCode", courseCode);
                        command.Parameters.AddWithValue("@StudentNumber", studentID);
                        command.Parameters.AddWithValue("@ExamDate", examDate);
                        command.Parameters.AddWithValue("@Score", score);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gözlənilməz xəta baş verdi");
            }
        }
        private void DeleteExamsWithClassMismatch()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Exams WHERE NOT EXISTS " +
                                    "(SELECT 1 FROM Students WHERE Exams.StudentNumber = Students.StudentNum " +
                                    "AND Students.StudentClass = (SELECT Class FROM Courses WHERE Exams.CourseCode = Courses.CourseCode))";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection)) 
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    
                }
            }
        }
        private bool IsCourseCodeAndStudentNumberValid(string courseCode, decimal studentNumber) // sinif eyni olamlidir.
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Step 1: Check if the course code exists
                string courseQuery = "SELECT COUNT(*) FROM Courses WHERE CourseCode = @CourseCode";
                using (SqlCommand courseCommand = new SqlCommand(courseQuery, connection))
                {
                    courseCommand.Parameters.AddWithValue("@CourseCode", courseCode);
                    int courseCount = (int)courseCommand.ExecuteScalar();

                    if (courseCount == 0)
                    {
                        // Course code is not valid, return false
                        return false;
                    }
                }
                string studentQuery = "SELECT COUNT(*) FROM Students WHERE StudentNum = @StudentNumbe";
                using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection))
                {
                    studentCommand.Parameters.AddWithValue("@StudentNumbe", studentNumber);
                    int studentCount = (int)studentCommand.ExecuteScalar();

                    if (studentCount == 0)
                    {
                        // Student number is not valid, return false
                        return false;
                    }

                }
                decimal studentClass;
                string classQuery1 = "SELECT StudentClass FROM Students WHERE StudentNum = @StudentNumber";
                using (SqlCommand stdclassCommand = new SqlCommand(classQuery1, connection))
                {
                    stdclassCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    studentClass = (decimal)stdclassCommand.ExecuteScalar();

                }

                string classQuery = "SELECT Class FROM Courses WHERE CourseCode = @CourseCode";
                using (SqlCommand classCommand = new SqlCommand(classQuery, connection))
                {
                    classCommand.Parameters.AddWithValue("@CourseCode", courseCode);
                    decimal courseClass = (decimal)classCommand.ExecuteScalar();

                    if (courseClass != studentClass)
                    {
                        // Course code and student number belong to different classes, return false
                        return false;
                    }
                }

                // Both course code and student number are valid, return true
                return true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //string selectedCourseCode = cmbCourses.SelectedValue?.ToString();

            //// Perform any validation or other checks here before confirming the registration
            //if (string.IsNullOrEmpty(selectedCourseCode))
            //{
            //    MessageBox.Show("Please select a course to register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            string courseCode = cmbCourses.Text.Trim();
            decimal studentID = Convert.ToDecimal(cmbStudents.Text); //check string as well 

            int score;

            if (string.IsNullOrEmpty(courseCode))
            {
                MessageBox.Show("Dərs kodu Daxil edin", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(txtClass.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime examDate))
            {
                MessageBox.Show("Xətalı Tarix. Tarixi 'YYYY-MM-DD' formasında daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsCourseCodeAndStudentNumberValid(courseCode, studentID))
            {
                MessageBox.Show("Xətalı dərs kodu, şagird nömrəsi və ya sinif uyğunsuzluğu", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtTeacherName.Text, out score))
            {
                MessageBox.Show("Keçərli qiymət daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RegisterExam(courseCode, studentID, examDate, score);
            PopulateCoursesGrid();
            MessageBox.Show("İmtahan uğurla qeydiyyatdan keçdi!", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void PopulateCoursesGrid()
        {
            string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CourseCode, StudentNumber, ExamDate, Score FROM Exams";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dgvExams.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dgvExams.CurrentRow.Index != -1)
            {
                cmbCourses.Text = dgvExams.CurrentRow.Cells[0].Value.ToString();
                cmbStudents.Text = dgvExams.CurrentRow.Cells[1].Value.ToString(); ;

                txtClass.Text = dgvExams.CurrentRow.Cells[2].Value.ToString();
                txtTeacherName.Text = dgvExams.CurrentRow.Cells[3].Value.ToString(); ;


            }
        }
        private List<Course> coursesList;
        private void Form3_Load(object sender, EventArgs e)
        {
            DeleteExamsWithClassMismatch();
            PopulateCoursesGrid();


            coursesList = GetAllCourses1();

            // Set the coursesDataTable as the data source for the cmbCourses combobox
            cmbCourses.DataSource = coursesList;

            // Set the display and value members to the corresponding columns of the DataTable
            cmbCourses.DisplayMember = "CourseName"; // Display course name in the combobox
            cmbCourses.ValueMember = "CourseCode";
        }
        public class Course
        {
            public string CourseCode { get; set; }
            public string CourseName { get; set; }
            public int Class { get; set; }
            public string TeacherName { get; set; }
            public string TeacherSurname { get; set; }
        }
        private List<Course> GetAllCourses1()
        {
            List<Course> coursesList = new List<Course>();
            try
            {
                DataTable coursesDataTable = new DataTable();
                string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT CourseCode, CourseName FROM Courses";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(coursesDataTable);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions if needed
                    MessageBox.Show("Error fetchin cour: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                foreach (DataRow row in coursesDataTable.Rows)
                {
                    Course course = new Course
                    {
                        CourseCode = row["CourseCode"].ToString(),
                        CourseName = row["CourseName"].ToString(),
                    };
                    coursesList.Add(course);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error fetching coursesss: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return coursesList;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string courseCode = cmbCourses.Text.Trim();
            decimal studentID = Convert.ToDecimal(cmbStudents.Text); //check string as well 

            int score;

            if (string.IsNullOrEmpty(courseCode))
            {
                MessageBox.Show("Dərs kodu Daxil edin", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(txtClass.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime examDate))
            {
                MessageBox.Show("Xətalı Tarix. Tarixi 'YYYY-MM-DD' formasında daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsCourseCodeAndStudentNumberValid(courseCode, studentID))
            {
                MessageBox.Show("Xətalı dərs kodu, şagird nömrəsi və ya sinif uyğunsuzluğu", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtTeacherName.Text, out score))
            {
                MessageBox.Show("Keçərli qiymət daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateExam(courseCode, studentID, examDate, score);
            PopulateCoursesGrid();
            MessageBox.Show("İmtahan uğurla yeniləndi!", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                string courseCode = cmbCourses.Text.Trim();
                decimal studentID = Convert.ToDecimal(cmbStudents.Text); //check string as well 

                int score;

                if (string.IsNullOrEmpty(courseCode))
                {
                    MessageBox.Show("Dərs kodu Daxil edin", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsCourseCodeAndStudentNumberValid(courseCode, studentID))
                {
                    MessageBox.Show("Xətalı dərs kodu, şagird nömrəsi və ya sinif uyğunsuzluğu", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DeleteExam(courseCode);
                PopulateCoursesGrid();
                MessageBox.Show("İmtahan uğurla silindi!", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Gözlənilməz xəta baş verdi" + ex.Message); }
        }
        private DataTable GetAllStudents(string varb)
        {
            DataTable studentsDataTable = new DataTable();
            string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //string varb = cmbCourses.Text.Trim();
                    string query = "SELECT StudentNum FROM Students WHERE StudentClass = (SELECT Class from Courses WHERE CourseName=@CourseCode)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseCode", varb);
                        //command.ExecuteNonQuery();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(studentsDataTable);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                MessageBox.Show("Error fetchin students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return studentsDataTable;
        }
        private DataTable GetAllCourses()
        {
            DataTable coursesDataTable = new DataTable();
            string connectionString = "Data Source=LAPTOP-QJF9QCRR\\SQLEXPRESS;Initial Catalog=EXAMPROGRAM;Integrated Security=True;";
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CourseCode FROM Courses";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(coursesDataTable);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                MessageBox.Show("Error fetchin courses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return coursesDataTable;
        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStudents.DataSource = GetAllStudents(cmbCourses.Text.Trim());
            if (true)
            {
                cmbStudents.DisplayMember = "";
            }
            cmbStudents.DisplayMember = "StudentNum";//StudentNumber? tolka eta linya
            cmbStudents.ValueMember = "StudentNum";
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}


