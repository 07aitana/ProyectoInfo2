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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AirTrafficSimForms
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
            }
            else
            {
                GestionUsuarios db = new GestionUsuarios(); //creem objecte

                if (db.Initialize())  //connexió amb base de datos
                {
                    if (db.UserExists(username))     // comprobar si usuari existeix
                    {
                        MessageBox.Show("Username already exists.");
                    }
                    else
                    {
                        db.RegisterUser(username, password);
                        MessageBox.Show("Account created successfully.");
                        this.Close();
                    }

                    db.Close();
                }
                else
                {
                    MessageBox.Show("Database file not found.");
                }
            }
        }
    }
}
