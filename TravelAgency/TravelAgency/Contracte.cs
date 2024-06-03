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
    public partial class Contracte : Form
    {
        private MySqlConnection connection;
        public Contracte()
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
                textBox1.Text = selectedRow.Cells["cod_contract"].Value.ToString();
                textBox2.Text = selectedRow.Cells["destinatie"].Value.ToString();
                textBox3.Text = selectedRow.Cells["data_inceput"].Value.ToString();
                textBox4.Text = selectedRow.Cells["data_sfarsit"].Value.ToString();
                textBox5.Text = selectedRow.Cells["denumire_hotel"].Value.ToString();
                textBox6.Text = selectedRow.Cells["transport"].Value.ToString();
                textBox7.Text = selectedRow.Cells["nr_pers"].Value.ToString();
                textBox8.Text = selectedRow.Cells["numar_nopti_cazare"].Value.ToString();
                textBox9.Text = selectedRow.Cells["pret_noapte"].Value.ToString();
                textBox10.Text = selectedRow.Cells["cod_angajat"].Value.ToString();
            }
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "SELECT * FROM contract";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void searchbar_text(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("destinatie LIKE '%{0}%' OR denumire_hotel LIKE '%{0}%'", searchbar.Text);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "INSERT INTO contract (destinatie, data_inceput, data_sfarsit, denumire_hotel, transport, nr_pers, numar_nopti_cazare, pret_noapte, cod_angajat) VALUES (@destinatie, @data_inceput, @data_sfarsit, @denumire_hotel, @transport, @nr_pers, @numar_nopti_cazare, @pret_noapte, @cod_angajat)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@destinatie", textBox2.Text);
                cmd.Parameters.AddWithValue("@data_inceput", textBox3.Text);
                cmd.Parameters.AddWithValue("@data_sfarsit", textBox4.Text);
                cmd.Parameters.AddWithValue("@denumire_hotel", textBox5.Text);
                cmd.Parameters.AddWithValue("@transport", textBox6.Text);
                cmd.Parameters.AddWithValue("@nr_pers", textBox7.Text);
                cmd.Parameters.AddWithValue("@numar_nopti_cazare", textBox8.Text);
                cmd.Parameters.AddWithValue("@pret_noapte", textBox9.Text);
                cmd.Parameters.AddWithValue("@cod_angajat", textBox10.Text);

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
                string query = "UPDATE angajat SET destinatie=@destinatie, data_inceput=@data_inceput, data_sfarsit=@data_sfarsit, denumire_hotel=@denumire_hotel, transport=@transport, nr_pers=@nr_pers, numar_nopti_cazare=@numar_nopti_cazare, pret_noapte=@pret_noapte, cod_angajat=@cod_angajat WHERE cod_contract=@cod_contract";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@destinatie", textBox2.Text);
                cmd.Parameters.AddWithValue("@data_inceput", textBox3.Text);
                cmd.Parameters.AddWithValue("@data_sfarsit", textBox4.Text);
                cmd.Parameters.AddWithValue("@denumire_hotel", textBox5.Text);
                cmd.Parameters.AddWithValue("@transport", textBox6.Text);
                cmd.Parameters.AddWithValue("@nr_pers", textBox7.Text);
                cmd.Parameters.AddWithValue("@numar_nopti_cazare", textBox8.Text);
                cmd.Parameters.AddWithValue("@pret_noapte", textBox9.Text);
                cmd.Parameters.AddWithValue("@cod_angajat", textBox10.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.ConnectionString))
            {
                string query = "DELETE FROM contract WHERE cod_contract=@cod_contract";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod_contract", textBox1.Text);

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
    }
}
