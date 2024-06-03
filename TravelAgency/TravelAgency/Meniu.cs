using System.Windows.Forms;
using System;

namespace TravelAgency
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
        }

        private void clientibtn_Click(object sender, EventArgs e)
        {
            Clienti clienti = new Clienti();
            clienti.Show();
            this.Hide();
           
        }

        private void rezervaribtn_Click(object sender, EventArgs e)
        {
            Rezervari rezervari = new Rezervari();
            rezervari.Show();
            this.Hide();
        }

        private void contractebtn_Click(object sender, EventArgs e)
        {
            Contracte contracte = new Contracte();
            contracte.Show();
            this.Hide();
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.Show();
            this.Hide();
        }

        private void angajatibtn_Click(object sender, EventArgs e)
        {
            Angajati angajati = new Angajati();
            angajati.Show();
            this.Hide();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
