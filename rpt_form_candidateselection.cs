using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;






namespace rns
{
    public partial class rpt_form_candidateselection : Form
    {

        public rpt_form_candidateselection()
        {
            InitializeComponent();
        }

        private void rpt_form_candidateselection_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rnsDataSet.database2' table. You can move, or remove it, as needed.
            this.database2TableAdapter.Fill(this.rnsDataSet.database2);


            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void bindSource_selection( DataTable dt)
        {
            
            database2BindingSource.DataSource = dt;
            this.reportViewer1.RefreshReport();
        }
        
        
    }
}
