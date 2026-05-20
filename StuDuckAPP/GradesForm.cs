using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StuDuckAPP.GiveGrades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StuDuckAPP
{
    public partial class GradesForm : Form
    {

        private string connectionString;
        private string studentUsername;
        private string role;
        private string userId;
        private string username;
        private string firstName;
        private string lastName;
        public GradesForm(string connectionString, string studentUsername, string role, string userId, string username, string firstName, string lastName)
        {
            InitializeComponent();

            this.CenterToScreen();
            this.connectionString = connectionString;
            this.studentUsername = studentUsername;
            this.role = role;
            this.userId = userId; // Очень важно правильно инициализировать userId
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            if (role == "teacher")
            {
                int usId = int.Parse(userId);
                // Здесь нужно передать значения в правильном порядке
                GiveGrades giveGradesForm = new GiveGrades(usId, username, firstName, lastName, connectionString, role);
                giveGradesForm.Show();
                this.Hide();
            }
        }

        private void GradesForm_Load(object sender, EventArgs e)
        {

            LoadStudentInfo();
            LoadGrades();
        }

        private void LoadGrades()
        {
            dataGridViewGrades.Rows.Clear();
            dataGridViewGrades.Columns.Clear();

            // Добавляем столбцы
            dataGridViewGrades.Columns.Add("SubjectName", "Предмет");
            dataGridViewGrades.Columns.Add("GradeValue", "Оценки");
            dataGridViewGrades.Columns.Add("AverageGrade", "Средний бал");
            dataGridViewGrades.Columns.Add("TeacherName", "Преподаватель");

            // Списки для хранения данных графика
            List<string> subjectNames = new List<string>();
            List<double> averageGrades = new List<double>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
    Subjects.SubjectName,
    STRING_AGG(CAST(Grades.GradeValue AS VARCHAR(10)), ',    ') AS AllGrades,
    AVG(Grades.GradeValue) AS AverageGrade,
    TeacherInfo.TeacherName
FROM
    Grades
JOIN
    Subjects ON Grades.SubjectID = Subjects.SubjectID
JOIN
    Students ON Grades.StudentID = Students.StudentID
JOIN
    Users ON Students.StudentID = Users.UserID
OUTER APPLY (
    SELECT TOP 1 Users.FirstName + ' ' + Users.LastName AS TeacherName
    FROM Grades AS g
    JOIN Teachers ON g.TeacherID = Teachers.TeacherID
    JOIN Users ON Teachers.TeacherID = Users.UserID
    WHERE g.SubjectID = Subjects.SubjectID
    ORDER BY g.DateGiven DESC
) AS TeacherInfo
WHERE
    Users.Username = @Username
GROUP BY
    Subjects.SubjectName,
    TeacherInfo.TeacherName  -- Включаем TeacherInfo.TeacherName в GROUP BY
ORDER BY
    Subjects.SubjectName;
";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", studentUsername);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string subjectName = reader["SubjectName"].ToString();
                                string allGrades = reader["AllGrades"].ToString();
                                double averageGrade = Convert.ToDouble(reader["AverageGrade"]);
                                string teacherName = reader["TeacherName"].ToString();

                                dataGridViewGrades.Rows.Add(subjectName, allGrades, averageGrade, teacherName);


                                subjectNames.Add(subjectName);
                                averageGrades.Add(averageGrade);
                            }
                        }
                    }
                }
                CreateChartFromDataGridView(subjectNames, averageGrades);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке оценок: " + ex.Message);
            }
        }

        private void CreateChartFromDataGridView(List<string> subjectNames, List<double> averageGrades)
        {
            // Очищаем старые данные графика
            gradesChart.Series.Clear();
            gradesChart.AxisX.Clear();
            gradesChart.AxisY.Clear();

            ColumnSeries series = new ColumnSeries
            {
                Title = "Средний балл",
                Values = new ChartValues<double>(averageGrades),
                DataLabels = true,
                LabelPoint = point => point.Y.ToString("N2") // Форматируем до 2 знаков после запятой
            };

            // Добавляем серию на график
            gradesChart.Series.Add(series);

            // Настраиваем ось X
            gradesChart.AxisX.Add(new Axis
            {
                Title = "Предметы",
                Labels = subjectNames
            });

            // Настраиваем ось Y
            gradesChart.AxisY.Add(new Axis
            {
                Title = "Средний балл",
                MinValue = 0,
                MaxValue = 5
            });
        }


        private void LoadStudentInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT FirstName, LastName FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", studentUsername);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader.GetString(0);
                                string lastName = reader.GetString(1);
                                labelStudentName.Text = $"Оценки: {firstName} {lastName}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке имени студента: " + ex.Message);
            }
        }

        private void ToRaspisanie_Click(object sender, EventArgs e)
        {

            ScheduleForm scheduleForm = new ScheduleForm(connectionString, studentUsername, role, userId, username,  firstName,  lastName);
            scheduleForm.Show();
            this.Hide();
        }

        private void ToProfileForm_Click(object sender, EventArgs e)
        {
            int usId = int.Parse(userId);
            

            ProfileForm profileForm = new ProfileForm(usId, username, firstName, lastName, connectionString, role);
            profileForm.Show();
            this.Hide();
        }

        protected void ExitApplication()
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (!(form is Avtorization))
                {
                    form.Close();
                }
            }
            Avtorization avtorizationForm = new Avtorization();
            avtorizationForm.Show();

            this.Hide();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ToMainForm_Click(object sender, EventArgs e)
        {
            int usId = int.Parse(userId);
            MainForm mainForm = new MainForm(usId, username, firstName, lastName, connectionString, role);
            mainForm.Show();
            this.Hide();
        }
    }
}
