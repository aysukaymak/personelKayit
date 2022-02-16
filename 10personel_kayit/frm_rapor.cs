using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10personel_kayit
{
    public partial class frm_rapor : Form
    {
        public frm_rapor()
        {
            InitializeComponent();
        }

        private void frm_rapor_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'PersonelVeriTabaniDataSet2.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.Tbl_PersonelTableAdapter.Fill(this.PersonelVeriTabaniDataSet2.Tbl_Personel);

            this.reportViewer1.RefreshReport();
        }
    }
}
