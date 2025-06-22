using MySql.Data.MySqlClient;

namespace LoginFormPractical
{
    public class DB
    {
        private readonly string connectionString = "server=localhost;user=root;password=;database=userdb;";

        public bool ValidateUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username=@username AND password=@password", connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                connection.Open();
                return (long)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
