using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuDuckAPP
{
    public partial class MainForm : Form
    {
        private int userId;
        private string username;
        private string firstName;
        private string lastName;
        private string connectionString;
        private string role;
        private string studentUsername;

        public MainForm(int userId, string username, string firstName, string lastName, string connectionString, string role)
        {
            InitializeComponent();
            this.CenterToScreen();
           
            this.userId = userId;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.connectionString = connectionString;
            this.role = role;
            if (role == "teacher")
            {
                ToGrades.Text = "Выставить оценки";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ToProfileForm_Click(object sender, EventArgs e)
        {

            ProfileForm profileForm = new ProfileForm(userId, username, firstName, lastName, connectionString, role);
            profileForm.Show();
            this.Hide();
        }

        private void ToGrades_Click(object sender, EventArgs e)
        {
            //int usId = int.Parse(userId);
            if (role == "teacher")
            {
                GiveGrades giveGradesForm = new GiveGrades(userId, username, firstName, lastName, connectionString, role);
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

        private void ToRaspisanie_Click(object sender, EventArgs e)
        {
            string usId = userId.ToString();
            ScheduleForm scheduleForm = new ScheduleForm(connectionString, studentUsername, role, usId, username, firstName, lastName);
            scheduleForm.Show();
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
            //Application.Exit();
            ExitApplication();
        }
    }
}
