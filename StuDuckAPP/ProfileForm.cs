using StuDuckAPP;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StuDuckAPP
{
    public partial class ProfileForm : Form
    {
        private int userId;
        private string username;
        private string firstName;
        private string lastName;
        private string connectionString;
        private string role;
        private string studentUsername;
        

        public ProfileForm(int userId, string username, string firstName, string lastName, string connectionString, string role)
        {
            InitializeComponent();
            SetRoundedShape(guna2Panel1, 30);
            this.CenterToScreen();
            this.userId = userId;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.connectionString = connectionString;

            // Отображаем данные профиля
            labelUsername.Text = "Имя пользователя:   " + username;
            labelName.Text = "Имя:   " + firstName + " " + lastName;

            // Загружаем дополнительные данные (если нужно)
            LoadAdditionalProfileData();
            this.role = role;
            if (role == "teacher")
            {
                ToGrades.Text = "Выставить оценки";
            }
        }

        private void LoadAdditionalProfileData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT Address, Email, Gender, DateOfBirth
                             FROM Users
                             WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Получаем данные из базы данных
                                string address = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                string email = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                string gender = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                DateTime? dateOfBirth = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);

                                // Заполняем Label-ы
                                labelAddressValue.Text ="Адрес:   "+ address;
                                labelEmailValue.Text ="Почта:   "+ email;
                                labelGenderValue.Text = "Пол:   "+gender;
                                labelDateOfBirthValue.Text = $"Дата рождения:   {(dateOfBirth.HasValue ? dateOfBirth.Value.ToShortDateString() : "Не указана")}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке дополнительных данных профиля: " + ex.Message);
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {

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

        private void ToGrades_Click(object sender, EventArgs e)
        {
            if (role == "teacher")
            {
                GiveGrades giveGradesForm = new GiveGrades(userId, username, firstName, lastName, connectionString, role);
                giveGradesForm.Show();
                this.Hide();
            }
            else {
                GradesForm gradesForm = new GradesForm(connectionString, username, role, userId.ToString(), username, firstName, lastName);
                gradesForm.Show();
                this.Hide();
            }

        }

        private void ToRaspisanie_Click(object sender, EventArgs e)
        {
            string usId = userId.ToString();
            ScheduleForm scheduleForm = new ScheduleForm(connectionString, studentUsername, role, usId, username, firstName, lastName);
            scheduleForm.Show();
            this.Close();
        }

        private void ToMainForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm  =new MainForm(userId, username, firstName, lastName, connectionString, role);
            mainForm.Show();
            this.Hide();
        }

        static void SetRoundedShape(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }
    }
}
