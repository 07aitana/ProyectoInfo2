using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDatabase
{
    public class GestionUsuarios
    {
        SQLiteConnection cnx;
        // abre la conexion con users.db. devuelve false si el fichero no existe
        public bool Iniciar()
        {
            string ruta = "..\\..\\..\\basedatos\\users.db";

            if (File.Exists(ruta))
            {
                string dataSource = "Data Source=" + ruta + ";Version=3;";
                cnx = new SQLiteConnection(dataSource);
                cnx.Open();
                return true;
            }
            else
            {
                return false;
            }


        }
        // cierra la conexion con la base de datos
        public void Cerrar()
        {
            cnx.Close();
        }
        // devuelve true si ya hay un usuario con ese nombre
        public bool ExisteUsuario(string username)
        {

            DataTable dt = new DataTable(); //on guardarem els resultats

            string sql = "SELECT * FROM users WHERE username = '" + username + "'"; //la consulta que volem fer

            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        // Añade un usuario nuevo a la tabla users.
        // Devuelve true si se ha insertado y false en caso contrario.
        public bool RegistrarUsuario(string username, string password)
        {
            string sql = "INSERT INTO users (username, password) VALUES ('" + username + "', '" + password + "')";

            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int result = command.ExecuteNonQuery();

            if (result > 0)
                return true;
            else
                return false;
        }

        // devuelve true si el usuario y la contraseña son correctos
        public bool ComprobarLogin(string username, string password)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'"; //comprova nom usuari i contrasenya

            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
