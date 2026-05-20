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

namespace StuDuckAPP
{
    public partial class Avtorization : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\source\\repos\\StuDuckAPP\\StuDuckAPP\\StuduckDB.mdf;Integrated Security=True";
        public Avtorization()
        {
            InitializeComponent();
            this.CenterToScreen();
            guna2Panel1.BorderRadius = 23;
            SetRoundedShape(guna2Panel1, 30);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение StuDuck — это ваш надежный помощник в мире учебы, который поможет вам достичь успеха и наслаждаться студенческой жизнью!" +
               " StuDuck — это универсальное и удобное приложение, созданное специально для студентов, которые стремятся организовать свою учебную жизнь и максимально эффективно использовать свое время. Это приложение является надежным инструментом для повышения успеваемости и упрощения учебного процесса." +
               " Приложение предоставляет возможность следить за успеваемостью: студенты могут отслеживать свои оценки, анализировать результаты тестов и экзаменов." +
               " С помощью StuDuck студенты могут быть всегда в курсе последних новостей своего учебного заведения, включая изменения в расписании, анонсы мероприятий и важные объявления от преподавателей. Интуитивно понятный интерфейс позволяет легко находить необходимую информацию и не пропускать важные события.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = maskedTextBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Получаем данные пользователя (UserID, Username, Password, Role, FirstName, LastName)
                    string query = "SELECT UserID, Username, Password, Role, FirstName, LastName, IsAdmin FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string usernameFromDB = reader.GetString(1);
                                string passwordFromDB = reader.GetString(2);
                                string role = reader.GetString(3);
                                string firstName = reader.GetString(4);
                                string lastName = reader.GetString(5);
                                bool isAdmin=reader.GetBoolean(6);
                                // 2. Проверка пароля (без хэширования для учебного примера)
                                if (password == passwordFromDB)
                                {
                                    if (isAdmin)
                                    {
                                        AdminForm adminForm = new AdminForm();
                                        adminForm.Show();
                                        this.Hide();
                                        return;
                                    }
                                    // Авторизация успешна

                                    // 3. Открываем соответствующие формы
                                    if (role == "student")
                                    {
                                        // Создаем ProfileForm и передаем данные
                                        ProfileForm profileForm = new ProfileForm(userId, usernameFromDB, firstName, lastName, connectionString, role);
                                        // Создаем GradesForm и передаем данные
                                        GradesForm gradesForm = new GradesForm(connectionString, usernameFromDB, role, userId.ToString(), usernameFromDB, firstName, lastName);

                                        MainForm mainForm = new MainForm(userId, usernameFromDB, firstName, lastName, connectionString, role);
                                        mainForm.Show();
                                        this.Hide();
                                    }
                                    else if (role == "teacher")
                                    {
                                        TeacherForm teacherForm = new TeacherForm(userId, usernameFromDB, firstName, lastName, connectionString, role);
                                        teacherForm.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Неизвестная роль пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь с таким именем не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Avtorization_Load(object sender, EventArgs e)
        {

        }
    }
}
