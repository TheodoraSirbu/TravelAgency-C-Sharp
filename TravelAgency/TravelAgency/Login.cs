using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TravelAgency
{
    public partial class Login : Form
    {
        private MySqlConnection connection;

        public Login()
        {
            InitializeComponent();
            string serverName = "localhost";
            string username = "root";
            string password = "";
            string dbName = "turism";

            string connectionString = $"Server={serverName};Database={dbName};Uid={username};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Black;
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {

            string username = usernametxt.Text;
            string password = passwordtxt.Text;

            try
            {
                connection.Open();

                string sql = "SELECT * FROM login WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        // Autentificare reușită
                        // Deschide Meniu sau alt formular
                        Meniu meniu = new Meniu();
                        meniu.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Autentificare eșuată
                        MessageBox.Show("Utilizator sau parolă incorecte!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem executing the query: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
