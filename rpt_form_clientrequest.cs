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
    public partial class rpt_form_clientrequest : Form
    {
        private string prv_client = string.Empty;
        private string prv_poscode = string.Empty;

        public rpt_form_clientrequest()
        {
            InitializeComponent();
        }

        private void Sample_report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rnsDataSet.clientrequest' table. You can move, or remove it, as needed.
            this.clientrequestTableAdapter.Fill(this.rnsDataSet.clientrequest);
            // TODO: This line of code loads data into the 'rnsDataSet.clientrequest' table. You can move, or remove it, as needed.


            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = ConfigurationManager.ConnectionStrings["rnsConString"].ConnectionString;
            //if (conn.State == ConnectionState.Closed) conn.Open();

            //SqlCommand comm = new SqlCommand("select * from clientrequest where clientid = ''", conn);
            //rnsDataSet dr = new rnsDataSet();



            // TODO: This line of code loads data into the 'rnsDataSet.clientrequest' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'sampledataset.clientrequest' table. You can move, or remove it, as needed.

            datamethods2 dmth = new datamethods2();


            //rnsDataSet dsrns = new rnsDataSet();
            //MessageBox.Show(dsrns.Tables.Count.ToString());
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.Fill(dsrns);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnposcode_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_position);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Code";
            frmSch.strHeader2 = "Description";
            frmSch.strHeader3 = " ";
            frmSch.useRIMSConnString = true;
            string strQuery = string.Empty;
            strQuery = "select code as Code, desc1  as Description from codestab where option1 = 'POSIT'";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_position(object sender, FormClosedEventArgs e)
        {


            txtposition.Text = Program._searchedValue2.Trim();
            prv_poscode = Program._searchedValue.Trim();

        }

        private void btnclient_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_client);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "ClientID";
            frmSch.strHeader2 = "Clientname";
            frmSch.strHeader3 = " ";
            frmSch.useRIMSConnString = true;
            string strQuery = string.Empty;
            strQuery = "select customerid as ClientID, companyname  as Clientname from customers";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_client(object sender, FormClosedEventArgs e)
        {


            txtclient.Text = Program._searchedValue2.Trim();
            prv_client = Program._searchedValue.Trim();

        }

        private void button1_Click(object sender, EventArgs e)
        {




            if (radclientonly.Checked == true && txtclient.Text.Trim() != string.Empty)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = clientrequestTableAdapter.GetDataByClient(prv_client.Trim());
                clientrequestBindingSource.DataSource = clientrequestTableAdapter.GetDataByClient(prv_client.Trim());
                this.reportViewer1.RefreshReport();
            }
            if (radpositiononly.Checked == true && txtposition.Text.Trim() != string.Empty)
            {
               
                clientrequestBindingSource.DataSource = clientrequestTableAdapter.GetDataByPoscode(prv_poscode.Trim());
                this.reportViewer1.RefreshReport();
            }

            if (radclientpositiononly.Checked == true && txtposition.Text.Trim() != string.Empty && txtclient.Text.Trim() != string.Empty)
            {
                clientrequestBindingSource.DataSource = clientrequestTableAdapter.GetDataByClientPoscode(prv_client.Trim(),prv_poscode.Trim());
                this.reportViewer1.RefreshReport();
            }

            if (radall.Checked == true)
            {
                clientrequestBindingSource.DataSource = clientrequestTableAdapter.GetData();
                this.reportViewer1.RefreshReport();
            }

        }
    }
}
