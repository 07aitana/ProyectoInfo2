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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                GestionUsuarios db = new GestionUsuarios(); //nou objecte

                if (db.Initialize()) //connexio base de dades
                {
                    if (db.LoginUser(username, password))
                    {
                        MessageBox.Show("Login successful.");

                        db.Close();

                        this.Hide();

                        MainForm main = new MainForm();
                        main.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password.");
                        db.Close();
                    }

                    
                }
                else
                {
                    MessageBox.Show("Database file not found.");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
