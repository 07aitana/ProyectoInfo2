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
    public partial class FormRegister : Form
    {
        // Sets up the sign-up form.
        public FormRegister()
        {
            InitializeComponent();
        }

        // Checks the form and creates an account if the username is free (sender and e are unused).
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (username.Contains("'") || password.Contains("'"))
            {
                MessageBox.Show("The username and the password cannot contain the character '");
            }
            else if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
            }
            else
            {
                try
                {
                    GestionUsuarios db = new GestionUsuarios();

                    if (db.OpenConnection())
                    {
                        if (db.UserExists(username))
                        {
                            MessageBox.Show("Username already exists.");
                            db.CloseConnection();
                        }
                        else
                        {
                            db.RegisterUser(username, password);
                            db.CloseConnection();
                            MessageBox.Show("Account created successfully.");
                            this.Close();
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
        }
    }
}
