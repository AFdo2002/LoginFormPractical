using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginFormPractical
{
    public partial class RegistrationForm : Form
    {
        private readonly DB database = new DB();

        public RegistrationForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add these lines to wire up event handlers
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;

            // Add password masking
            textBox2.PasswordChar = '•';
            textBox3.PasswordChar = '•';
        }

        private void button1_Click(object sender, EventArgs e) // Register button
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password");
                return;
            }

            try
            {
                if (database.CheckUsernameExists(username))
                {
                    MessageBox.Show("Username already exists");
                    return;
                }

                if (database.RegisterUser(username, password))
                {
                    MessageBox.Show("Registration successful!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Cancel button
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
