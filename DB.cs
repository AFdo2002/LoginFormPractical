using System.Data;
using MySql.Data.MySqlClient;

namespace LoginFormPractical
{
    public class DB
    {
        private readonly string connectionString = "server=localhost;user=root;password=;database=userdb;";

        public bool ValidateUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                return (long)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
