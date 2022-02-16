using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //sgl komutlarını kullanabilmemiz için gereken kütüphane

namespace _10personel_kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-9D4ELC7; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLİst_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet2.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet2.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //işin bellek boyutunda ilk olarak oluşturduğumuz baglanti nesnesini open komutu ile açmamız gerekiyor

            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Personel (PerAd, PerSoyAd, PerSehir, PerMaas, PerDurum, PerMeslek) values (@ad, @soyad, @sehir, @maas, @durum, @meslek)", baglanti); //bir komut nesnesi türetiyoruz ve çift tırnak içerisine direkt sql komutunu yazacağız
                                                                                                                                                                //values içerisinde kullanılan p1 ve p2 birer köprü görevi görürler. Sql sorgusu ve textboxlar arası geçişi sağlayacak
            komutkaydet.Parameters.AddWithValue("@ad", txtAD.Text); //komut nesnesinden gelen parametreleri değer olarak ekle yani txtADdan gelen değeri p1 e atadım
            komutkaydet.Parameters.AddWithValue("@soyad", txtSOYAD.Text);
            komutkaydet.Parameters.AddWithValue("@sehir", cmbSEHIR.Text);
            komutkaydet.Parameters.AddWithValue("@maas", msktxtMAAS.Text);
            komutkaydet.Parameters.AddWithValue("@durum", label8.Text); //Sql üzerinde değerleri true-false veya 0-1 olarak girebildiğimiz için öncelikle label kullanarak butonlara true ve false değerlerini atadık, daha sonra labelı parametreye atadık
            komutkaydet.Parameters.AddWithValue("@meslek", txtMESLEK.Text);

            komutkaydet.ExecuteNonQuery(); //sorguyu çalıştır ExecuteNonQuery insertte, update ve delete sorgulamalarında kullanılır

            baglanti.Close(); //baglantiyi bellekte kapat

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet2.Tbl_Personel); //listele butonuna tekrar basmadan kaydedilen personeli otomstik listelesin diye buraya kopyaladım

            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Form1_TextChanged metodunda da labelın değerlerini değiştirdiğimiz için haa almamak adına bunları da ıf bloğu içine yazdık 
            //radiobutton1 seçiliyse(checked true ise) labela true yazacak
            //radiobutton2 seçiliyse(checked true ise) labela false yazacak
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btnTem_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtAD.Text = "";
            txtSOYAD.Text = "";
            txtMESLEK.Text = "";
            cmbSEHIR.Text = "";
            msktxtMAAS.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAD.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int secilen = dataGridView1.SelectedCells[0].RowIndex; //herhangi bir hücreye çift tıkladığımda datagridden seçilen hücrenin 0.sütununun satır değerini secilen değişkenine ataış olacak
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); //datagridin satırlarından secilen satırın(int secilen) hücreleri içerisinde sıfırncı hücrenin değerini(value) txtID ye yazdır
            txtAD.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSOYAD.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSEHIR.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktxtMAAS.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString(); //yine olaylar kısmından textchange kısmına çift tıklıyoruz
            txtMESLEK.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            //datagridden okunup labela atanan değer true ise radiabutton1 seçili olacak
            //datagridden okunup labela atanan değer false ise radiabutton2 seçili olacak
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where PerId=@id", baglanti);

            komutsil.Parameters.AddWithValue("@id", txtID.Text); //PerIdyi silince tüm satırı yani tüm personel bilgilerini silmiş olacak

            komutsil.ExecuteNonQuery();

            baglanti.Close();

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet2.Tbl_Personel); //listele butonuna tekrar basmadan kaydedilen personeli otomstik listelesin diye buraya kopyaladım

            MessageBox.Show("Kayıt Silindi.");
        }

        private void btnGncll_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@ad, PerSoyAd=@soyad, PerSehir=@sehir, PerMaas=@maas, PerDurum=@durum, PerMeslek=@meslek Where PerId=@id", baglanti);

            komutguncelle.Parameters.AddWithValue("@ad", txtAD.Text);
            komutguncelle.Parameters.AddWithValue("@soyad", txtSOYAD.Text);
            komutguncelle.Parameters.AddWithValue("@sehir", cmbSEHIR.Text);
            komutguncelle.Parameters.AddWithValue("@maas", msktxtMAAS.Text);
            komutguncelle.Parameters.AddWithValue("@durum", label8.Text);
            komutguncelle.Parameters.AddWithValue("@meslek", txtMESLEK.Text);
            komutguncelle.Parameters.AddWithValue("@id", txtID.Text); //zaten sql id değerini otomatik atıyor ama bunu şart olarak eklemezsek sadece yukarıdaki komutlarla güncelleme sonunda veritabanındaki tüm kayıtları aynı yapar
                                                                      //bu şart yazılınca sadece alınan id ye sahip personelin kaydını güncellemiş olur

            komutguncelle.ExecuteNonQuery();

            baglanti.Close();

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet2.Tbl_Personel); //listele butonuna tekrar basmadan kaydedilen personeli otomstik listelesin diye buraya kopyaladım

            MessageBox.Show("Kayıt Güncellendi.");
        }

        private void btnIst_Click(object sender, EventArgs e)
        {
            frm_istatistik frm = new frm_istatistik();
            frm.Show();
        }

        private void btnGraf_Click(object sender, EventArgs e)
        {
            frm_grafik frm = new frm_grafik();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_rapor frm = new frm_rapor();
            frm.Show();
        }
    }
}
