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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravelAgency
{
    public partial class Rezervari : Form
    {
        private MySqlConnection connection;
        public Rezervari()
        {
            InitializeComponent();
            string serverName = "localhost";
            string username = "root";
            string password = "";
            string dbName = "turism";

            string connectionString = $"Server={serverName};Database={dbName};Uid={username};Pwd={password};";
            connection = new MySqlConnection(connectionString);

            LoadData();


            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["cod_rezervare"].Value.ToString();
                textBox2.Text = selectedRow.Cells["data_rezervare"].Value.ToString();
                textBox3.Text = selectedRow.Cells["pret"].Value.ToString();
                textBox4.Text = selectedRow.Cells["avans"].Value.ToString();
                textBox5.Text = selectedRow.Cells["cod_contract"].Value.ToString();
            }
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "SELECT * FROM rezervari";
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "DELETE FROM rezervari WHERE cod_rezervare=@cod_rezervare";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod_rezervare", textBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void modifybtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "UPDATE rezervari SET data_rezervare=@data_rezervare, pret=@pret, avans=@avans, cod_contract=@cod_contract WHERE cod_rezervare=@cod_rezervare";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data_rezervare", textBox2.Text);
                cmd.Parameters.AddWithValue("@pret", textBox3.Text);
                cmd.Parameters.AddWithValue("@avans", textBox4.Text);
                cmd.Parameters.AddWithValue("@cod_contract", textBox5.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "INSERT INTO rezervari (data_rezervare, pret, avans, cod_contract) VALUES (@data_rezervare, @pret, @avans, @cod_contract)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@data_rezervare", textBox2.Text);
                cmd.Parameters.AddWithValue("@pret", textBox3.Text);
                cmd.Parameters.AddWithValue("@avans", textBox4.Text);
                cmd.Parameters.AddWithValue("@cod_contract", textBox5.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }
    }
}
