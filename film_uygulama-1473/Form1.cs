using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace film_uygulama_1473
{

    public partial class Form1 : Form
    {
        string baglanti = "Server=localhost;Database=film_arsiv;Uid=root;Pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string klasorYolu = @"poster";
            if (Directory.Exists(klasorYolu))
            {
                Directory.CreateDirectory(klasorYolu);

            }
            CmdDoldur();
            DgwDoldur();
        }
        void DgwDoldur()
        {
            using (MySqlConnection baglan = new MySqlConnection(baglanti))
            {
                baglan.Open();
                string sorgu = "SELECT * FROM filmler;";

                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();




                da.Fill(dt);
                dgwFılmler.DataSource = dt;

             
                dgwFılmler.Columns["poster"].Visible= false;
                dgwFılmler.Columns["yonetmen"].Visible = false;
            }
        }

        private void dgwFılmler_SelectionChanged(object sender, EventArgs e)
        {
            if(dgwFılmler.SelectedRows.Count > 0)
            {
                txtFılmad.Text = dgwFılmler.SelectedRows[0].Cells["Film_ad"].Value.ToString();
                txtYonetmen.Text = dgwFılmler.SelectedRows[0].Cells["yonetmen"].Value.ToString();
                txtYıl.Text = dgwFılmler.SelectedRows[0].Cells["yil"].Value.ToString();
                cmbTur.Text = dgwFılmler.SelectedRows[0].Cells["tur"].Value.ToString();
                txtSure.Text = dgwFılmler.SelectedRows[0].Cells["sure"].Value.ToString();
                txtPuan.Text = dgwFılmler.SelectedRows[0].Cells["imdb_puan"].Value.ToString();
                txtPoster.Text = dgwFılmler.SelectedRows[0].Cells["poster"].Value.ToString();

          

                cbOdul.Checked = Convert.ToBoolean(dgwFılmler.SelectedRows[0].Cells["film_odul"].Value);
            }
        }

        private void pbResim_Click(object sender, EventArgs e)
        {

        }

        void CmdDoldur()
        {
            using (MySqlConnection baglan = new MySqlConnection(baglanti))
            {
                baglan.Open();
                string sorgu = "SELECT DISTINCT tur FROM filmler;";

                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();




                da.Fill(dt);
                cmbTur.DataSource = dt;

                cmbTur.DisplayMember = "tur";
                cmbTur.ValueMember = "tur";
            }
        }
    }
}
