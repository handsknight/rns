namespace rns
{
    partial class rpt_form_candidateselection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpt_form_candidateselection));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rnsDataSet = new rns.rnsDataSet();
            this.database2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database2TableAdapter = new rns.rnsDataSetTableAdapters.database2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rnsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rpt_database1_sel__dataset";
            reportDataSource1.Value = this.database2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "rns.rptshortlisted.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(676, 443);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // rnsDataSet
            // 
            this.rnsDataSet.DataSetName = "rnsDataSet";
            this.rnsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // database2BindingSource
            // 
            this.database2BindingSource.DataMember = "database2";
            this.database2BindingSource.DataSource = this.rnsDataSet;
            // 
            // database2TableAdapter
            // 
            this.database2TableAdapter.ClearBeforeFill = true;
            // 
            // rpt_form_candidateselection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 443);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rpt_form_candidateselection";
            this.Text = "Candidate Selection Report";
            this.Load += new System.EventHandler(this.rpt_form_candidateselection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rnsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource database2BindingSource;
        private rnsDataSet rnsDataSet;
        private rnsDataSetTableAdapters.database2TableAdapter database2TableAdapter;

    }
}