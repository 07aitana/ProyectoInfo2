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
        // constructor del formulario
        public FormLogin()
        {
            InitializeComponent();
        }

        // Comprueba el usuario y la contraseña en la base de datos.
        // Si son correctos, oculta el login y abre el menú principal.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool loginCorrecto = false;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (username.Contains("'") || password.Contains("'"))
            {
                // La comilla simple rompería la consulta SQL
                MessageBox.Show("The username and the password cannot contain the character '");
            }
            else
            {
                try
                {
                    GestionUsuarios db = new GestionUsuarios(); //nou objecte

                    if (db.Iniciar()) //connexio base de dades
                    {
                        loginCorrecto = db.ComprobarLogin(username, password);
                        db.Cerrar();

                        if (!loginCorrecto)
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
                    // Por ejemplo, si users.db está dañado o no tiene la tabla users
                    MessageBox.Show("Error reading the user database (users.db).");
                }
            }

            if (loginCorrecto)
            {
                MessageBox.Show("Login successful.");

                // Mientras el menú está abierto, el login queda oculto.
                // Al cerrar el menú se cierra también el login y el programa termina.
                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
                this.Close();
            }
        }
        
        // abre el formulario para registrar un usuario nuevo
        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.ShowDialog();
        }

    }
}
