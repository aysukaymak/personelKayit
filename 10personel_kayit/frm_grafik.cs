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
    public partial class frm_grafik : Form
    {
        public frm_grafik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-9D4ELC7; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void frm_grafik_Load(object sender, EventArgs e)
        {
            //ŞEHİRLER
            baglanti.Open();
            SqlCommand komutSehirler = new SqlCommand("Select PerSehir, Count(*) From Tbl_Personel Group By PerSehir", baglanti);
            SqlDataReader dr_sehirler = komutSehirler.ExecuteReader();
            while (dr_sehirler.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr_sehirler[0], dr_sehirler[1]); //chart1in serilerine x ve y noktaları olarak sehirleri ve sehirlerdeki personel sayısını ekle
            }
            baglanti.Close();

            //MAAŞLAR
            baglanti.Open();
            SqlCommand komutMaaslar = new SqlCommand("Select PerMeslek, Avg(PerMaas) From Tbl_Personel Group By PerMeslek", baglanti);
            SqlDataReader dr_maaslar = komutMaaslar.ExecuteReader();
            while (dr_maaslar.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr_maaslar[0], dr_maaslar[1]); //chart1in serilerine x ve y noktaları olarak sehirleri ve sehirlerdeki personel sayısını ekle
            }
            baglanti.Close();
        }
    }
}
