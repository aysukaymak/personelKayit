using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _10personel_kayit
{
    public partial class frm_giris : Form
    {
        public frm_giris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-9D4ELC7; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutgiris = new SqlCommand("Select * From Tbl_Yonetici Where KullaniciAd=@ad and Sifre=@sifre", baglanti);
            komutgiris.Parameters.AddWithValue("@ad", textBox1.Text);
            komutgiris.Parameters.AddWithValue("@sifre", textBox2.Text);
            SqlDataReader dr_giris = komutgiris.ExecuteReader();
            if (dr_giris.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız.");
            }
            baglanti.Close();
        }
    }
}
