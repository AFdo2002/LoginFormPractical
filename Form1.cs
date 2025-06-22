using System;
using System.Windows.Forms;

namespace LoginFormPractical
{
    public partial class Form1 : Form
    {
        private readonly DB database;

        public Form1()
        {
            InitializeComponent();
            database = new DB();
            lnkToRegister.LinkClicked += lnkToRegister_LinkClicked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool isValidUser = database.ValidateUser(username, password);

                if (isValidUser)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            this.Hide(); // Hide login form
            regForm.ShowDialog(); // Show registration as modal
            this.Show(); // Show login form again when registration closes
        }

    }
}
