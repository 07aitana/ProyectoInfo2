using System;
using System.Collections.Generic;
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
        public bool Initialize()
        {
            string ruta = @"C:\UPC\2A\info2\PROYECTOINFO2\basedatos\users.db";

            if (File.Exists(ruta))
            {
                string dataSource = "Data Source=" + ruta;
                cnx = new SQLiteConnection(dataSource);
                cnx.Open();
                return true;
            }
            else
            {
                return false;
            }


        }
        public void Close()
        {
            cnx.Close();
        }
        public bool UserExists(string username)
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
        public bool RegisterUser(string username, string password)
        {
            string sql = "INSERT INTO users (username, password) VALUES (@username, @password)";

            SQLiteCommand command = new SQLiteCommand(sql, cnx);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            int result = command.ExecuteNonQuery();

            if (result > 0)
                return true;
            else
                return false;

        }
        public bool LoginUser(string username, string password)
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
