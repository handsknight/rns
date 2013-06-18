using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace rns
{
    public partial class rpt_form_database2 : Form
    {
        private string prv_recrno = string.Empty;

        public rpt_form_database2()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnclient_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_client);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "recrno";
            frmSch.strHeader2 = "names";
            frmSch.strHeader3 = "";
            frmSch.strHeader4 = "";
            string strQuery = string.Empty;
            strQuery = "select recrno, rtrim([surname])+' '+rtrim([firstname])+' '+rtrim([middlename]) as names from database2";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_client(object sender, FormClosedEventArgs e)
        {


            txtsearchvalue.Text = Program._searchedValue2.Trim();
            prv_recrno = Program._searchedValue.Trim();
            MessageBox.Show(prv_recrno);

        }

        private void rpt_form_database2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rnsDataSet.database2' table. You can move, or remove it, as needed.
            this.database2TableAdapter.Fill(this.rnsDataSet.database2);
            clearscreen();
        }
        private void clearscreen()
        {
            txtsearchvalue.Text = "";
            txtsearchvalue.Enabled = false;
           
        }

        private void radrecrnoonly_CheckedChanged(object sender, EventArgs e)
        {
            clearscreen();
        }

        private void radlikeonly_CheckedChanged(object sender, EventArgs e)
        {
            clearscreen();
            txtsearchvalue.Enabled = true;
        }

        private void radall_CheckedChanged(object sender, EventArgs e)
        {
            clearscreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            datamethods2 dmth = new datamethods2();
            if (radrecrnoonly.Checked == true && txtsearchvalue.Text.Trim() != string.Empty)
            {

                database2BindingSource.DataSource = database2TableAdapter.GetDataByRecrnoOnly(prv_recrno.Trim());
                this.reportViewer1.RefreshReport();

            }
            

    

            // for like
            if (radlikeonly.Checked == true && txtsearchvalue.Text.Trim() != string.Empty)
            {

                try
                {
                    string selValue = cmblikeselection.SelectedItem.ToString();
             

                    String sqlSelect = @"select distinct * from database2 " 
                        + " where ltrim(rtrim(" + selValue.Trim() + "))  LIKE '"
                        +  txtsearchvalue.Text.Trim() + "%'";

                


                    DataTable dt = new DataTable();
                    dt = dmth._dataTable_NoParameter(sqlSelect, ConfigurationManager.ConnectionStrings["rnsConString"].ConnectionString);

                    if (dmth.sqlUserError.Trim() == string.Empty)
                    {

                        // bind the datasource to the selected query datatable
                        if (dt.Rows.Count > 0)
                        {
                            database2BindingSource.DataSource = dt;
                            this.reportViewer1.RefreshReport();
                        }
                        else MessageBox.Show("Records records not found!", "RnS Notification");

                    }
                    else
                    {
                        MessageBox.Show(dmth.sqlUserError.Trim());
                        MessageBox.Show("Error occured, pls, try again(1)!", "RnS Notification");
                        dt.Dispose();
                    }
                }
                catch
                {
                    dmth.sqlUserError.Trim();
                    MessageBox.Show("Error occured, pls, try again(2)!", "RnS Notification");
                }
            }

          

            if (radall.Checked == true )
            {
                database2BindingSource.DataSource = database2TableAdapter.GetData();
                this.reportViewer1.RefreshReport();
            }
         

        }
    }
}
