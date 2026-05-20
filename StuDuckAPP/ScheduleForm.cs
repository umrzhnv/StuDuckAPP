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
using System.Windows.Forms;
using static StuDuckAPP.GiveGrades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StuDuckAPP
{
    public partial class ScheduleForm : Form
    {
        private string studentUsername;
        private string role;
        private string userId;
        private string username;
        private string firstName;
        private string lastName;

        private string connectionString;
        public ScheduleForm(string connectionString, string studentUsername, string role, string userId, string username, string firstName, string lastName)
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
            if (role=="teacher")
            {
                ToGrades.Text = "Выставить оценки";
            }
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {

            loadSchedule();
        }

        private void loadSchedule()
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Columns.Clear();

            guna2DataGridView1.Columns.Add("DayOfWeek", "День недели");
            guna2DataGridView1.Columns.Add("GroupName", "Группа");
            guna2DataGridView1.Columns.Add("Time", "Время");
            guna2DataGridView1.Columns.Add("Room", "Аудитория");
            guna2DataGridView1.Columns.Add("SubjectName", "Предмет");

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
SELECT
    S.DayOfWeek,
    G.GroupName,
    S.Time,
    S.Room,
    Sub.SubjectName AS SubjectName
FROM
    Schedule S
JOIN
    Groups G ON S.GroupID = G.GroupID
JOIN
    Subjects Sub ON S.SubjectID = Sub.SubjectID
ORDER BY
    S.DayOfWeek, S.Time;

";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string day = reader["DayOfWeek"].ToString();
                                string group = reader["GroupName"].ToString();
                                string time = reader["Time"].ToString();
                                string room = reader["Room"].ToString();
                                string subjectName = reader["SubjectName"].ToString(); // Получаем название предмета

                                guna2DataGridView1.Rows.Add(day, group, time, room, subjectName);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке расписания: " + ex.Message);
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

        private void ToMainForm_Click(object sender, EventArgs e)
        {   int usId = int.Parse(userId);
            if (role == "teacher")
            {
                TeacherForm teacherForm = new TeacherForm(usId, username, firstName, lastName, connectionString, role);
                teacherForm.Show();
                this.Hide();
            }
            else
            {
               
                MainForm mainForm = new MainForm(usId, username, firstName, lastName, connectionString, role);
                mainForm.Show();
                this.Hide();
            }

        }

        private void ToProfileForm_Click(object sender, EventArgs e)
        {
            int usId = int.Parse(userId);


            ProfileForm profileForm = new ProfileForm(usId, username, firstName, lastName, connectionString, role);
            profileForm.Show();
            this.Hide();
        }

        private void ToGrades_Click(object sender, EventArgs e)
        {
            //GradesForm gradesForm = new GradesForm(connectionString, username, role, userId.ToString(), username, firstName, lastName);
            //gradesForm.Show();
            //this.Hide();
            int usId=int.Parse(userId);
            if (role == "teacher")
            {
                GiveGrades giveGradesForm = new GiveGrades(usId, username, firstName, lastName, connectionString, role);
                giveGradesForm.Show();
                this.Hide();
            }
            else
            {
                GradesForm gradesForm = new GradesForm(connectionString, username, role, userId.ToString(), username, firstName, lastName);
                gradesForm.Show();
                this.Hide();
            }

        }
    }
}
