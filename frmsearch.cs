using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace rns
{
    public partial class frmsearch : Form
    {
        public DataTable dt;
        public DataTable dtCache;
        public DataView dv;
        public int filterOption = 1;
        public string strfilter = string.Empty;
        public string strHeader1 = string.Empty;
        public string strHeader2 = string.Empty;
        public string strHeader3 = string.Empty;
        public string strHeader4 = string.Empty;
        public Boolean useRIMSConnString = false;
        public int _returnCellIndex;


        public frmsearch()
        {
            InitializeComponent();
        }

        private void frmsearch_Load(object sender, EventArgs e)
        {
           
        }
        public void _getData( string queryString )
        {
            radHeader1.Checked = true;

            dt = new DataTable();
            dtCache = new DataTable();
            datamethods2 dtmth = new datamethods2();

            if (useRIMSConnString == true) dt = dtmth._dataTable_NoParameter_RIMS(queryString); // use RIMS connstring
            else   dt = dtmth._dataTable_NoParameter(queryString); // use RnS connString 

            if (dtmth.sqlUserError == string.Empty)
            {
                dv = new DataView();
                dv = dt.DefaultView;
                grdSearch.DataSource = dv;
                dtCache = dt;
                
            }

            if (strHeader1.Trim() == string.Empty)
            {
                radHeader1.Text = "ID";
            }
            else
            {
                radHeader1.Text = strHeader1;
            }


            if (strHeader2.Trim() == string.Empty)
            {
                radHeader2.Text = "Description";
                radHeader2.Visible = false;

            }
            else
            {
                radHeader2.Text = strHeader2;
            }

            if (strHeader3.Trim() == string.Empty)
            {
                radHeader3.Text = "Description 2";
                radHeader3.Visible = false;
            }
            else
            {
                radHeader3.Text = strHeader3;
            }


            if (strHeader4.Trim() == string.Empty)
            {
                radHeader4.Text = "Description 3";
                radHeader4.Visible = false;
            }
            else
            {
                radHeader4.Text = strHeader4;
            }
           
           
        }

        public void _getData_RIMS(string queryString)
        {
            radHeader1.Checked = true;

            dt = new DataTable();
            dtCache = new DataTable();
            datamethods2 dtmth = new datamethods2();
            dt = dtmth._dataTable_NoParameter_RIMS(queryString);

            if (dtmth.sqlUserError == string.Empty)
            {
                dv = new DataView();
                dv = dt.DefaultView;
                grdSearch.DataSource = dv;
                dtCache = dt;

            }

            if (strHeader1.Trim() == string.Empty)
            {
                radHeader1.Text = "ID";
            }
            else
            {
                radHeader1.Text = strHeader1;
            }


            if (strHeader2.Trim() == string.Empty)
            {
                radHeader2.Text = "Description";
                radHeader2.Visible = false;

            }
            else
            {
                radHeader2.Text = strHeader2;
            }

            if (strHeader3.Trim() == string.Empty)
            {
                radHeader3.Text = "Description 2";
                radHeader3.Visible = false;
            }
            else
            {
                radHeader3.Text = strHeader3;
            }

            if (strHeader4.Trim() == string.Empty)
            {
                radHeader4.Text = "Description 3";
                radHeader4.Visible = false;
            }
            else
            {
                radHeader4.Text = strHeader4;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            _getSearchText();
            if (txtsearch.Text.Trim() == string.Empty)
            {
                dv.RowFilter = "";
                grdSearch.DataSource = dt;
                
            }
            else    _filterRecords();
           
        }


        private void _getSearchText()
        {
            if (radHeader1.Checked == true)
            {

              
                strfilter = strHeader1 + " like '" + txtsearch.Text.Trim() + "%'";
            }

            if (radHeader2.Visible==true && radHeader2.Checked == true)
            {
                strfilter = strHeader2 + " like '" + txtsearch.Text.Trim() + "%'";
            }
            if (radHeader3.Visible == true &&  radHeader3.Checked == true)
            {
                strfilter = strHeader3 + " like '" + txtsearch.Text.Trim() + "%'";
            }

            if (radHeader4.Visible == true && radHeader4.Checked == true)
            {
                strfilter = strHeader4 + " like '" + txtsearch.Text.Trim() + "%'";
            }
        }

        private void _filterRecords()
        {
            dt.DefaultView.RowFilter = strfilter;
            grdSearch.DataSource = dt.DefaultView;
           
        }

       

        private void grdSearch_SelectionChanged(object sender, EventArgs e)
        {

            _getSelectedValue();
          
        }

        private void _getSelectedValue()
        {
            if (grdSearch.Rows.Count > 0)
            {
                int oldRowIndex = grdSearch.CurrentRow.Index;
                Program._searchedValue = grdSearch.Rows[oldRowIndex].Cells[0].Value.ToString(); 
                
                //// return array object 
                //string index_value1 =  (string)grdSearch.Rows[oldRowIndex].Cells[0].Value; 
                //string index_value2 =  (string)grdSearch.Rows[oldRowIndex].Cells[1].Value;
                //string[] arryReturnValue = new string[] { index_value1, index_value2 };
                //Program._returnArray = arryReturnValue;



                if (radHeader2.Visible == true)
                {
                    Program._searchedValue2 = grdSearch.Rows[oldRowIndex].Cells[1].Value.ToString(); 
                }

                if (radHeader3.Visible == true)
                {
                    Program._searchedValue3 = grdSearch.Rows[oldRowIndex].Cells[2].Value.ToString();
                }

                if (radHeader4.Visible == true)
                {
                    Program._searchedValue4 = grdSearch.Rows[oldRowIndex].Cells[3].Value.ToString();
                }
            }
              
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          
            _getSelectedValue();
            this.Close();

        }

        private void grdSearch_DoubleClick(object sender, EventArgs e)
        {
            _getSelectedValue();
            this.Close();
        }
        
    }
}
