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
        // constructor del formulario
        public FormRegister()
        {
            InitializeComponent();
        }

        // Registra un usuario nuevo en la base de datos si los datos son correctos
        // y el nombre de usuario no existe todavía.
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
                    GestionUsuarios db = new GestionUsuarios(); //creem objecte

                    if (db.Iniciar())  //connexió amb base de datos
                    {
                        if (db.ExisteUsuario(username))     // comprobar si usuari existeix
                        {
                            MessageBox.Show("Username already exists.");
                            db.Cerrar();
                        }
                        else
                        {
                            db.RegistrarUsuario(username, password);
                            db.Cerrar();
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
                    // Por ejemplo, si users.db está dañado o no tiene la tabla users
                    MessageBox.Show("Error reading the user database (users.db).");
                }
            }
        }
    }
}