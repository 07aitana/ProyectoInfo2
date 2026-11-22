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

        // Opens the user database and returns true, or returns false if the file is missing.
        public bool OpenConnection()
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

        // Closes the database connection.
        public void CloseConnection()
        {
            cnx.Close();
        }

        // Returns true if username is already in the database.
        public bool UserExists(string username)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM users WHERE username = '" + username + "'";

            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        // Saves username and password and returns true if the account was added.
        public bool RegisterUser(string username, string password)
        {
            string sql = "INSERT INTO users (username, password) VALUES ('" + username + "', '" + password + "')";

            SQLiteCommand command = new SQLiteCommand(sql, cnx);
            int result = command.ExecuteNonQuery();

            if (result > 0)
                return true;
            else
                return false;
        }

        // Returns true if username and password match an account.
        public bool ValidateLogin(string username, string password)
        {
            DataTable dt = new DataTable();

            string sql = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";

            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);

            adp.Fill(dt);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
