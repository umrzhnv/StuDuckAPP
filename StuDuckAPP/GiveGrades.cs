using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StuDuckAPP
{
    public partial class GiveGrades : Form
    {

        private int userId;
        private string username;
        private string firstName;
        private string lastName;
        private string connectionString;
        private int _currentTeacherID;
        private string role;
        private string studentUsername;
        public GiveGrades(int userId, string username, string firstName, string lastName, string connectionString, string role)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.userId = userId;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.connectionString = connectionString;
            this._currentTeacherID = userId;
            this.role=role;
        }

        private void GiveGrades_Load(object sender, EventArgs e)
        {
            loadGrupes();
            DisplayTeacherSubject(userId);

        }

        public class StudentGradeInfo
        {
            public string FullName { get; set; }
            public string Grades { get; set; }
        }

        private string GetGradesForStudent(int studentId)
        {
            List<decimal> grades = new List<decimal>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT GradeValue FROM Grades WHERE StudentID = @StudentID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            grades.Add(reader.GetDecimal(0));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении оценок: " + ex.Message);
            }
            return string.Join(", ", grades); // Форматируем оценки в строку, разделенную запятыми
        }

        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            // Другие свойства User
            public int? GroupID { get; set; } // Позволяет иметь null GroupID
            public string FullName => $"{FirstName} {LastName}"; // Свойство для отображения ФИО в ComboBox
        }

        // Класс Group (перенесен из предыдущего ответа)
        public class Group
        {
            public int GroupID { get; set; }
            public string GroupName { get; set; }
            // Другие свойства Group
            public override string ToString()
            {
                return GroupName;  // Важно для отображения в ComboBox
            }
        }

        private void loadGrupes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT GroupID, GroupName FROM Groups"; // Предполагаем, что у вас есть таблица Groups
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        List<Group> groups = new List<Group>();
                        while (reader.Read())
                        {
                            groups.Add(new Group
                            {
                                GroupID = reader.GetInt32(0),
                                GroupName = reader.GetString(1)
                            });
                        }
                        reader.Close();
                        groupComboBox.DataSource = groups; // Заполняем comboBoxGroups
                        groupComboBox.DisplayMember = "GroupName"; // Отображаем GroupName
                        groupComboBox.ValueMember = "GroupID"; // Используем GroupID как значение
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке групп: " + ex.Message);
            }
        }

        private void LoadStudentsForGroup(int? groupId)  // Принимаем int? чтобы обрабатывать null
        {
            
            gradesDataGridView.Columns.Clear();

            try
            {
                // 1. Получаем студентов для выбранной группы
                List<User> students = new List<User>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT u.UserID, u.Username, u.FirstName, u.LastName, u.GroupID
                                     FROM Users u
                                     INNER JOIN Students s ON u.UserID = s.StudentID
                                     WHERE u.GroupID = @GroupID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroupID", groupId ?? (object)DBNull.Value);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            students.Add(new User
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                GroupID = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                            });
                        }
                        reader.Close();
                    }
                }

                // 2. Получаем оценки для каждого студента
                List<StudentGradeInfo> studentGradeInfos = new List<StudentGradeInfo>();
                foreach (User student in students)
                {
                    string grades = GetGradesForStudent(student.UserID); // Получаем оценки для студента
                    studentGradeInfos.Add(new StudentGradeInfo
                    {
                        FullName = student.FullName,
                        Grades = grades
                    });
                }
                studentComboBox.DataSource = students;
                studentComboBox.DisplayMember = "FullName"; // Отображаем ФИО (из свойства FullName)
                studentComboBox.ValueMember = "UserID";   // Значением будет UserID
                // 3. Заполняем DataGridView
                gradesDataGridView.DataSource = studentGradeInfos;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке студентов и оценок: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные с формы
                if (studentComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите студента.");
                    return;
                }

                if (!decimal.TryParse(gradeTextBox.Text, out decimal gradeValue))
                {
                    MessageBox.Show("Пожалуйста, введите корректную оценку.");
                    return;
                }

                int studentId = ((User)studentComboBox.SelectedItem).UserID;
                DateTime dateGiven = gradeDatePicker.Value;

                // 1. Получаем SubjectID для преподавателя из БД
                int subjectId;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT SubjectID FROM Teachers WHERE TeacherID = @TeacherID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TeacherID", _currentTeacherID);
                            object result = command.ExecuteScalar(); // Используем ExecuteScalar, чтобы получить одно значение

                            if (result == null || result == DBNull.Value)
                            {
                                MessageBox.Show("Не удалось получить SubjectID для преподавателя.");
                                return;
                            }

                            subjectId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении SubjectID: " + ex.Message);
                    return;
                }

                // 2. Сохраняем оценку в БД
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Grades (StudentID, SubjectID, TeacherID, GradeValue, DateGiven)
                             VALUES (@StudentID, @SubjectID, @TeacherID, @GradeValue, @DateGiven)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId);
                        command.Parameters.AddWithValue("@SubjectID", subjectId);
                        command.Parameters.AddWithValue("@TeacherID", _currentTeacherID); // Используем _currentTeacherID
                        command.Parameters.AddWithValue("@GradeValue", gradeValue);
                        command.Parameters.AddWithValue("@DateGiven", dateGiven);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Оценка успешно сохранена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении оценки: " + ex.Message);
            }
        }



        private void groupComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //LoadStudentsForSelectedGroup();
            if (groupComboBox.SelectedItem is Group selectedGroup)
            {
                LoadStudentsForGroup(selectedGroup.GroupID);
            }
            else
            {
                groupComboBox.DataSource = null; // Очищаем, если группа не выбрана или выбрано некорректное значение
            }
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

        private void DisplayTeacherSubject(int teacherID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
SELECT
    S.SubjectName
FROM
    Teachers T
JOIN
    Subjects S ON T.SubjectID = S.SubjectID
WHERE
    T.TeacherID = @TeacherID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeacherID", teacherID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string subjectName = reader["SubjectName"].ToString();
                                subjectLabel.Text = subjectName; // Устанавливаем текст в Label
                            }
                            else
                            {
                                subjectLabel.Text = "Предмет не найден"; // Если предмет не найден
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении предмета: " + ex.Message);
                subjectLabel.Text = "Ошибка"; // Если произошла ошибка
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ToProfileForm_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(userId, username, firstName, lastName, connectionString, role);
            profileForm.Show();
            this.Hide();
        }

        private void ToMainForm_Click(object sender, EventArgs e)
        {
            
            if (role == "teacher")
            {
                TeacherForm teacherForm = new TeacherForm(userId, username, firstName, lastName, connectionString, role);
                teacherForm.Show();
                this.Hide();
            }
            else
            {

                MainForm mainForm = new MainForm(userId, username, firstName, lastName, connectionString, role);
                mainForm.Show();
                this.Hide();
            }
        }

        private void ToRaspisanie_Click(object sender, EventArgs e)
        {
            string usId = userId.ToString();
            ScheduleForm scheduleForm = new ScheduleForm(connectionString, studentUsername, role, usId, username, firstName, lastName);
            scheduleForm.Show();
            this.Hide();
        }
    } 
}