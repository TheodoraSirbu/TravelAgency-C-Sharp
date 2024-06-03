using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency
{
    public partial class Log : Form
    {
        private MySqlConnection connection;
        public Log()
        {
            InitializeComponent();
            string serverName = "localhost";
            string username = "root";
            string password = "";
            string dbName = "turism";

            string connectionString = $"Server={serverName};Database={dbName};Uid={username};Pwd={password};";
            connection = new MySqlConnection(connectionString);

            LoadData();
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "SELECT * FROM logutilizare";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Meniu inapoi = new Meniu();
            inapoi.Show();
            this.Hide();
        }
    }
}
