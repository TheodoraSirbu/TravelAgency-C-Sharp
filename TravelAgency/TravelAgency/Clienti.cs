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
    public partial class Clienti : Form
    {
        private MySqlConnection connection;
        public Clienti()
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
                textBox1.Text = selectedRow.Cells["cod_client"].Value.ToString();
                textBox2.Text = selectedRow.Cells["nume"].Value.ToString();
                textBox3.Text = selectedRow.Cells["prenume"].Value.ToString();
                textBox4.Text = selectedRow.Cells["CNP"].Value.ToString();
                textBox5.Text = selectedRow.Cells["nr_tel"].Value.ToString();
                textBox6.Text = selectedRow.Cells["adresa"].Value.ToString();
                textBox7.Text = selectedRow.Cells["localitate"].Value.ToString();
                textBox8.Text = selectedRow.Cells["cod_rezervare"].Value.ToString();
            }
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "SELECT * FROM client";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "DELETE FROM client WHERE cod_client=@cod_client";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod_client", textBox1.Text);

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
                string query = "UPDATE angajat SET nume=@nume, prenume=@prenume, CNP=@CNP, nr_tel=@nr_tel, adresa=@adresa, localitate=@localitate, cod_rezervare=@cod_rezervare WHERE cod_client=@cod_client";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                cmd.Parameters.AddWithValue("@prenume", textBox3.Text);
                cmd.Parameters.AddWithValue("@CNP", textBox4.Text);
                cmd.Parameters.AddWithValue("@nr_tel", textBox5.Text);
                cmd.Parameters.AddWithValue("@adresa", textBox6.Text);
                cmd.Parameters.AddWithValue("@localitate", textBox7.Text);
                cmd.Parameters.AddWithValue("@cod_rezervare", textBox8.Text);

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
                string query = "INSERT INTO client (nume, prenume, CNP, nr_tel, adresa, localitate, cod_rezercare) VALUES (@nume, @prenume, @CNP, @nr_tel, @adresa, @localitate, @cod_rezervare)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nume", textBox2.Text);
                cmd.Parameters.AddWithValue("@prenume", textBox3.Text);
                cmd.Parameters.AddWithValue("@CNP", textBox4.Text);
                cmd.Parameters.AddWithValue("@nr_tel", textBox5.Text);
                cmd.Parameters.AddWithValue("@adresa", textBox6.Text);
                cmd.Parameters.AddWithValue("@localitate", textBox7.Text);
                cmd.Parameters.AddWithValue("@cod_rezervare", textBox8.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Meniu inapoi = new Meniu();
            inapoi.Show();
            this.Hide();
        }

        private void searchbar_text(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("nume LIKE '%{0}%' OR prenume LIKE '%{0}%'", searchbar.Text);
        }
    }
}
