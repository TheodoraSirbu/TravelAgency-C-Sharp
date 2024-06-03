using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TravelAgency
{
    public partial class Angajati : Form
    {
        private MySqlConnection connection;

        public Angajati()
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

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "SELECT * FROM angajat";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "INSERT INTO angajat (nume, prenume, CNP, data_nasterii, salariu, cod_functie) VALUES (@nume, @prenume, @CNP, @data_nasterii, @salariu, @cod_functie)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                cmd.Parameters.AddWithValue("@prenume", textBox3.Text);
                cmd.Parameters.AddWithValue("@CNP", textBox4.Text);
                cmd.Parameters.AddWithValue("@data_nasterii", textBox5.Text);
                cmd.Parameters.AddWithValue("@salariu", textBox6.Text);
                cmd.Parameters.AddWithValue("@cod_functie", textBox7.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "UPDATE angajat SET nume=@nume, prenume=@prenume, CNP=@CNP, data_nasterii=@data_nasterii, salariu=@salariu, cod_functie=@cod_functie WHERE cod_angajat=@cod_angajat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod_angajat", textBox1.Text);
                cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                cmd.Parameters.AddWithValue("@prenume", textBox3.Text);
                cmd.Parameters.AddWithValue("@CNP", textBox4.Text);
                cmd.Parameters.AddWithValue("@data_nasterii", textBox5.Text);
                cmd.Parameters.AddWithValue("@salariu", textBox6.Text);
                cmd.Parameters.AddWithValue("@cod_functie", textBox7.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "DELETE FROM angajat WHERE cod_angajat=@cod_angajat";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod_angajat", textBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("nume LIKE '%{0}%' OR prenume LIKE '%{0}%'", textBox8.Text);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["cod_angajat"].Value.ToString();
                textBox2.Text = selectedRow.Cells["nume"].Value.ToString();
                textBox3.Text = selectedRow.Cells["prenume"].Value.ToString();
                textBox4.Text = selectedRow.Cells["CNP"].Value.ToString();
                textBox5.Text = selectedRow.Cells["data_nasterii"].Value.ToString();
                textBox6.Text = selectedRow.Cells["salariu"].Value.ToString();
                textBox7.Text = selectedRow.Cells["cod_functie"].Value.ToString();
            }
        }

        private void inapoibtn(object sender, EventArgs e)
        {
            Meniu inapoi = new Meniu();
            inapoi.Show();
            this.Hide();
        }
    }
}
