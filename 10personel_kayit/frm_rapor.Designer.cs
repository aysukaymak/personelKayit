
namespace _10personel_kayit
{
    partial class frm_rapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PersonelVeriTabaniDataSet2 = new _10personel_kayit.PersonelVeriTabaniDataSet2();
            this.Tbl_PersonelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tbl_PersonelTableAdapter = new _10personel_kayit.PersonelVeriTabaniDataSet2TableAdapters.Tbl_PersonelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PersonelVeriTabaniDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_PersonelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Tbl_PersonelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_10personel_kayit.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1100, 647);
            this.reportViewer1.TabIndex = 0;
            // 
            // PersonelVeriTabaniDataSet2
            // 
            this.PersonelVeriTabaniDataSet2.DataSetName = "PersonelVeriTabaniDataSet2";
            this.PersonelVeriTabaniDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Tbl_PersonelBindingSource
            // 
            this.Tbl_PersonelBindingSource.DataMember = "Tbl_Personel";
            this.Tbl_PersonelBindingSource.DataSource = this.PersonelVeriTabaniDataSet2;
            // 
            // Tbl_PersonelTableAdapter
            // 
            this.Tbl_PersonelTableAdapter.ClearBeforeFill = true;
            // 
            // frm_rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_rapor";
            this.Text = "frm_rapor";
            this.Load += new System.EventHandler(this.frm_rapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PersonelVeriTabaniDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_PersonelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Tbl_PersonelBindingSource;
        private PersonelVeriTabaniDataSet2 PersonelVeriTabaniDataSet2;
        private PersonelVeriTabaniDataSet2TableAdapters.Tbl_PersonelTableAdapter Tbl_PersonelTableAdapter;
    }
}