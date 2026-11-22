using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserDatabase;

namespace AirTrafficSimForms
{
    public partial class FormLogin : Form
    {
        // Sets up the login form.
        public FormLogin()
        {
            InitializeComponent();
        }

        // Checks the username and password and opens the main menu if they match (sender and e are unused).
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool loginSucceeded = false;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (username.Contains("'") || password.Contains("'"))
            {
                // A single quote would break the quoted SQL value.
                MessageBox.Show("The username and the password cannot contain the character '");
            }
            else
            {
                try
                {
                    GestionUsuarios db = new GestionUsuarios();

                    if (db.OpenConnection())
                    {
                        loginSucceeded = db.ValidateLogin(username, password);
                        db.CloseConnection();

                        if (!loginSucceeded)
                        {
                            MessageBox.Show("Incorrect username or password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database file not found (users.db).");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading the user database (users.db).");
                }
            }

            if (loginSucceeded)
            {
                MessageBox.Show("Login successful.");

                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
                this.Close();
            }
        }

        // Opens the sign-up form (sender and e are unused).
        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.ShowDialog();
        }
    }
}
