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
    public partial class frm_istatistik : Form
    {
        public frm_istatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-9D4ELC7; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void frm_istatistik_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL
            baglanti.Open();

            SqlCommand komutPersonel= new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);

            SqlDataReader dr_Personel = komutPersonel.ExecuteReader(); //sqldatareader veri okuyucu demek bu sınıftan ürettiğimiz nesneyi komut1 ile ilişkilendiriyoruz
                                                                //executereader okuyucuyu çalıştır komutudur ve executereader select için çalıştırma komutuddur

            while(dr_Personel.Read()) //datareader1  komutu okuma işlemi yaptığı müddetçe tablo bitene kadar/null değer ile karşılaşana kadar
            {
                lblPersonel.Text = dr_Personel[0].ToString(); //datareader1 den gelen sıfırınccı indeksteki değeri labela yazdır
            }

            baglanti.Close();

            //EVLİ PERSONEL
            baglanti.Open();
            SqlCommand komutEvli = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=1", baglanti);
            SqlDataReader dr_Evli = komutEvli.ExecuteReader();
            while (dr_Evli.Read())
            {
                lblEvli.Text = dr_Evli[0].ToString();
            }
            baglanti.Close();

            //BEKAR PERSONEL
            baglanti.Open();
            SqlCommand komutBekar = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=0", baglanti);
            SqlDataReader dr_Bekar = komutBekar.ExecuteReader();
            while (dr_Bekar.Read())
            {
                lblBekar.Text = dr_Bekar[0].ToString();
            }
            baglanti.Close();

            //ŞEHİR
            baglanti.Open();
            SqlCommand komutSehir = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr_Sehir = komutSehir.ExecuteReader();
            while (dr_Sehir.Read())
            {
                lblSehir.Text = dr_Sehir[0].ToString();
            }
            baglanti.Close();

            //TOPLAM MAAŞ
            baglanti.Open();
            SqlCommand komutMaas = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr_Maas= komutMaas.ExecuteReader();
            while (dr_Maas.Read())
            {
                lblMaas.Text = dr_Maas[0].ToString();
            }
            baglanti.Close();

            //ORTALAMA MAAŞ
            baglanti.Open();
            SqlCommand komutOrt_Maas = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr_OrtMaas = komutOrt_Maas.ExecuteReader();
            while (dr_OrtMaas.Read())
            {
                lblOrtMaas.Text = dr_OrtMaas[0].ToString();
            }
            baglanti.Close();
        }
    }
}
