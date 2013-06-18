using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;

namespace rns
{
    public partial class frmdload : Form
    {

        private int _newAddedRowIndex = 0;
        private int _newAddedRowIndexSource = 0;
        private Boolean _coladded = false;
        private Boolean _coladded_des = false;
        private int _doubleClickSelRowIndex;
        private int _doubleClickSelColIndex;

        public frmdload()
        {
            InitializeComponent();
            clearScreen();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearScreen()
        {
            _coladded = false;
            _coladded_des = false;
            dgvDestination.Rows.Clear();
            dgvSource.Rows.Clear();
            _createDestinationColumns();
            _createSourceColumns();
            _newAddedRowIndexSource = 0;
            _newAddedRowIndex = 0;
            lblprocessing.Visible = false;

        }
        private void _createDestinationColumns()
        {
            // destination columns
            dgvDestination.Columns.Clear();
            

            DataGridViewTextBoxColumn recrno = new DataGridViewTextBoxColumn();
            recrno.HeaderText = "Candidate ID";
            recrno.Name = "recrno";
            recrno.ToolTipText = "Candidate ID";
            recrno.DefaultCellStyle.NullValue = " ";
            dgvDestination.Columns.Add(recrno);


            DataGridViewTextBoxColumn surname = new DataGridViewTextBoxColumn();
            surname.HeaderText = "Surname";
            surname.Name = "surname";
            surname.ToolTipText = "surname";
            surname.DefaultCellStyle.NullValue = " ";
            dgvDestination.Columns.Add(surname);

            DataGridViewTextBoxColumn othernames = new DataGridViewTextBoxColumn();
            othernames.HeaderText = "Otherames";
            othernames.Name = "othernames";
            othernames.ToolTipText = "Othernames";
            othernames.DefaultCellStyle.NullValue = " ";
            dgvDestination.Columns.Add(othernames);

            DataGridViewTextBoxColumn initials = new DataGridViewTextBoxColumn();
            initials.HeaderText = "Initials";
            initials.Name = "initials";
            initials.ToolTipText = "initials";
            initials.DefaultCellStyle.NullValue = " ";
            dgvDestination.Columns.Add(initials);

            DataGridViewCheckBoxColumn downloaded = new DataGridViewCheckBoxColumn();
            downloaded.HeaderText = "Downloaded";
            downloaded.Name = "downloaded";
            downloaded.ToolTipText = "downloaded";
            downloaded.DefaultCellStyle.NullValue = false;
            downloaded.ReadOnly = true;
            dgvDestination.Columns.Add(downloaded);

            //-------------------------

            
           

        }
        private void _createSourceColumns()
        {
     
            // source
            dgvSource.Columns.Clear();
            DataGridViewTextBoxColumn recrno = new DataGridViewTextBoxColumn();
            recrno.HeaderText = "Candidate ID";
            recrno.Name = "recrno";
            recrno.ToolTipText = "Candidate ID";
            recrno.DefaultCellStyle.NullValue = " ";
            dgvSource.Columns.Add(recrno);


            DataGridViewTextBoxColumn surname = new DataGridViewTextBoxColumn();
            surname.HeaderText = "Surname";
            surname.Name = "surname";
            surname.ToolTipText = "surname";
            surname.DefaultCellStyle.NullValue = " ";
            dgvSource.Columns.Add(surname);

            DataGridViewTextBoxColumn othernames = new DataGridViewTextBoxColumn();
            othernames.HeaderText = "Otherames";
            othernames.Name = "othernames";
            othernames.ToolTipText = "Othernames";
            othernames.DefaultCellStyle.NullValue = " ";
            dgvSource.Columns.Add(othernames);

            DataGridViewTextBoxColumn initials = new DataGridViewTextBoxColumn();
            initials.HeaderText = "Initials";
            initials.Name = "initials";
            initials.ToolTipText = "initials";
            initials.DefaultCellStyle.NullValue = " ";
            dgvSource.Columns.Add(initials);


        }

        private void dgvSource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _doubleClickSelColIndex = e.ColumnIndex;
            _doubleClickSelRowIndex = e.RowIndex;

            // get the cells values of the current row
            
            string _Cell1Value = dgvSource.Rows[_doubleClickSelRowIndex].Cells[0].Value.ToString().Trim();
            string _Cell2Value = dgvSource.Rows[_doubleClickSelRowIndex].Cells[1].Value.ToString().Trim();
            string _Cell3Value = dgvSource.Rows[_doubleClickSelRowIndex].Cells[2].Value.ToString().Trim();
            string _Cell4Value = dgvSource.Rows[_doubleClickSelRowIndex].Cells[3].Value.ToString().Trim();

            dgvDestination.Select();
            if (dgvDestination.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select row to copy to in the right destination table!","RnS Notification");
                return; 
            }
            int n = dgvDestination.Rows.Add();
            dgvDestination.Rows[n].Cells[0].Value = _Cell1Value;
            dgvDestination.Rows[n].Cells[1].Value = _Cell2Value;
            dgvDestination.Rows[n].Cells[2].Value = _Cell3Value;
            dgvDestination.Rows[n].Cells[3].Value = _Cell4Value;
            dgvDestination.Rows[n].Cells[4].Value = false;
            dgvDestination.CurrentRow.DataGridView.EndEdit();
            
            dgvDestination.CommitEdit(DataGridViewDataErrorContexts.Commit);
          
            dgvDestination.RefreshEdit();
            dgvDestination.EndEdit();
            

            //dgvDestination.CurrentRow.Cells[0].Value = _Cell1Value;
            //dgvDestination.CurrentRow.Cells[1].Value = _Cell2Value;
            //dgvDestination.CurrentRow.Cells[2].Value = _Cell3Value;
            //dgvDestination.CurrentRow.Cells[3].Value = _Cell4Value;
        }
         
        private void dgvSource_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _newAddedRowIndexSource = e.RowIndex;
            if (_coladded == true)
            {
                dgvSource.Rows[e.RowIndex].Cells[0].Value = " ";
                dgvSource.Rows[e.RowIndex].Cells[1].Value = " ";
                dgvSource.Rows[e.RowIndex].Cells[2].Value = " ";
                dgvSource.Rows[e.RowIndex].Cells[3].Value = " ";

                dgvSource.RefreshEdit();
                dgvSource.Refresh();

            }
        }

        private void dgvSource_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

            if (e.Column.Index == 3)
            {
                _coladded = true;

                dgvSource.Rows[_newAddedRowIndexSource].Cells[0].Value = " ";
                dgvSource.Rows[_newAddedRowIndexSource].Cells[1].Value = " ";
                dgvSource.Rows[_newAddedRowIndexSource].Cells[2].Value = " ";
                dgvSource.Rows[_newAddedRowIndexSource].Cells[3].Value = " ";

                dgvSource.RefreshEdit();
                dgvSource.Refresh();


            }
        }

        private void dgvDestination_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _newAddedRowIndex = e.RowIndex;
            if (_coladded_des == true)
            {
                
                dgvDestination.Rows[e.RowIndex].Cells[0].Value = " ";
                dgvDestination.Rows[e.RowIndex].Cells[1].Value = " ";
                dgvDestination.Rows[e.RowIndex].Cells[2].Value = " ";
                dgvDestination.Rows[e.RowIndex].Cells[3].Value = " ";
                dgvDestination.Rows[e.RowIndex].Cells[4].Value = false;
                dgvDestination.RefreshEdit();
                dgvDestination.Refresh();

                

            }

           


        }

        private void dgvDestination_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index == 4)
            {
                _coladded_des = true;

                dgvDestination.Rows[_newAddedRowIndex].Cells[0].Value = " ";
                dgvDestination.Rows[_newAddedRowIndex].Cells[1].Value = " ";
                dgvDestination.Rows[_newAddedRowIndex].Cells[2].Value = " ";
                dgvDestination.Rows[_newAddedRowIndex].Cells[3].Value = " ";
                dgvDestination.Rows[_newAddedRowIndex].Cells[4].Value = false;
                dgvDestination.RefreshEdit();
                dgvDestination.Refresh();
                dgvDestination.EndEdit();


            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _clearSourceGrid();
        }

        private void _clearSourceGrid()
        {
            dgvSource.Rows.Clear();
            
           
        }

        private void _clearDestinationGrid()
        {
            dgvDestination.Rows.Clear();
            btnsave.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _clearDestinationGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {

                dgvDestination.Rows.Insert(dgvDestination.Rows.Count - 1);
            }
            catch
            {
                MessageBox.Show("Cannot cannot insert", "RnS Notification");
            }

        }

        private void dgvDestination_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                dgvDestination.Rows.RemoveAt(e.RowIndex);
            }
            catch
            {
                MessageBox.Show("Cannot commit deletion","RnS Notification");
            }


        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
           
            
            _getOnlineRecords();
        }

             

        private void _getOnlineRecords()
        {

            string strQuery = string.Empty;
            strQuery = "select recrno ,Surname, Othernames,Initials from recruittab where used = 'false'";
            datamethods2 dmth = new datamethods2();
            DataTable dt = new DataTable();
            dt = dmth._dataTable_NoParameter_webdb(strQuery);
            if (dmth.sqlUserError == String.Empty)
            {
                if (dt.Rows.Count > 0)
                {
                    dgvSource.Rows.Clear();
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        
                        int n = dgvSource.Rows.Add();
                        dgvSource.Rows[n].Cells[0].Value = dt.Rows[x]["recrno"].ToString().Trim();
                        dgvSource.Rows[n].Cells[1].Value = dt.Rows[x]["surname"].ToString().Trim();
                        dgvSource.Rows[n].Cells[2].Value = dt.Rows[x]["othernames"].ToString().Trim();
                        dgvSource.Rows[n].Cells[3].Value = dt.Rows[x]["initials"].ToString().Trim();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Records not available! ","RnS Notification");
                }
            }
            else
            {
                MessageBox.Show(dmth.sqlUserError,"RnS Notification");
            }

            

            
        }

        private void btnsearch2_Click(object sender, EventArgs e)
        {

                     
            _getDownloaded();
            btnsave.Enabled = false;
        }

        private void _getDownloaded()
        {
            
            
            
            
            string strQuery = string.Empty;
            strQuery = "select recrno,Surname, firstname, middlename, Initials from database1";
            datamethods2 dmth = new datamethods2();
            DataTable dt = new DataTable();
            dt = dmth._dataTable_NoParameter(strQuery);
            if (dmth.sqlUserError == String.Empty)
            {
                if (dt.Rows.Count > 0)
                {
                    dgvDestination.Rows.Clear();
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {

                        int n = dgvDestination.Rows.Add();
                        dgvDestination.Rows[n].Cells[0].Value = dt.Rows[x]["recrno"].ToString().Trim();
                        dgvDestination.Rows[n].Cells[1].Value = dt.Rows[x]["surname"].ToString();
                        dgvDestination.Rows[n].Cells[2].Value = dt.Rows[x]["firstname"].ToString().Trim() + " " + dt.Rows[x]["middlename"].ToString().Trim();
                        dgvDestination.Rows[n].Cells[3].Value = dt.Rows[x]["initials"].ToString().Trim();
                        dgvDestination.Rows[n].Cells[4].Value = true;
                    }
                }
                else
                {
                    MessageBox.Show("Records not available! ", "RnS Notification");
                }
            }
            else
            {
                MessageBox.Show(dmth.sqlUserError, "RnS Notification");
            }

            
        }

        private void saveRecords()
        {

           
            if (dgvDestination.Rows.Count == 0 )
            {
                MessageBox.Show("Move records into destination table", "RnS Notification");
                return;
            }


            lblprocessing.Text = "Processing pls wait...";


            string strRecrno = String.Empty;
            

            string sqlInsertwhere = string.Empty;
            List<string> lstRecrno = new List<string>();
            
            

            int _totalSaved = 0;

           

            // get all the recrno
            for (int x = 0; x < dgvDestination.Rows.Count; x++)
            {
                if (dgvDestination.Rows[x].Cells[0].Value.ToString() != null && dgvDestination.Rows[x].Cells[0].Value.ToString().Trim() != string.Empty)
                {
                  if (Convert.ToBoolean(dgvDestination.Rows[x].Cells[4].Value) == false) lstRecrno.Add(dgvDestination.Rows[x].Cells[0].Value.ToString().Trim());
                }

            }

            if (lstRecrno.Count > 0)
            {
                sqlInsertwhere = "where recrno = '" + lstRecrno[0] + "'";
                if (lstRecrno.Count - 1 > 0)
                {
                    for (int x = 1; x < lstRecrno.Count; x++)
                    {
                        sqlInsertwhere += " or recrno = '" + lstRecrno[x] + "'";
                    }
                }
            }

            if (sqlInsertwhere.Trim() == string.Empty) // do insert
            {
                MessageBox.Show("There are no new records to save", "RnS Notification");
                lblprocessing.Visible = false;
                return;
            }

            // save the records
            datamethods2 dthm = new datamethods2();
            DataTable dt = new DataTable();
            string sqlQueury = "Select * from recruittab ";
            sqlQueury += sqlInsertwhere;
            dt = dthm._dataTable_NoParameter_webdb(sqlQueury);
            if (dthm.sqlUserError == string.Empty)
            {
                if (dt.Rows.Count > 0)
                {
                    _totalSaved = 0;
                    string strLgaDescr = String.Empty;

                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        lblprocessing.Visible = true;
                        lblprocessing.Text = "Processing Record " + (x + 1).ToString() + " of " + dt.Rows.Count.ToString();

                        string strSex = "Male";

                        if (dt.Rows[x]["sex"].ToString() == "2")
                        {
                            strSex = "Female";
                        }

                        strLgaDescr = "";

                        if (dt.Rows[x]["lga"].ToString().Trim() != string.Empty )
                        {
                            string sqlgetDescr = string.Empty;
                            sqlgetDescr = "select desc1 from codestab where option1='LGACODE' and code = '" + dt.Rows[x]["lga"].ToString() + "'";
                            SqlDataReader dr = dthm._dataReader_NoParameter(sqlgetDescr, ConfigurationManager.ConnectionStrings["rnsConString_rims"].ConnectionString);
                            if (dthm.sqlUserError == string.Empty)
                            {
                                dr.Read();
                                if (dr.HasRows)    strLgaDescr = dr["desc1"].ToString();
                            }
                            dr.Dispose();
                            dr.Close();
                        }

                        string sqlInsert = string.Empty;
                        sqlInsert = @" Insert into database1 "
                            + "(recrno,surname,firstname,middlename,initials,address, "
                            + " title,sex,age,phone,email,lgacode,lgadescr,birthdate,gradecode,gradedescr,qualcode,qualdescr,testresult,screened,aptest,active)"
                            + " values ('" + dt.Rows[x]["recrno"].ToString() + "',"
                            + "'" + dt.Rows[x]["surname"].ToString() + "',"
                            + "'" + dt.Rows[x]["othernames"].ToString() + "',"
                            + "'" + dt.Rows[x]["initials"].ToString() + "',"
                            + "'" + " " + "',"
                            + "'" + dt.Rows[x]["address"].ToString() + "',"
                            + "'" + dt.Rows[x]["title"].ToString() + "',"
                            + "'" + strSex + "',"
                            + "'" + (DateTime.Now.Year - Convert.ToDateTime(dt.Rows[x]["birthdate"]).Year).ToString() + "',"
                            + "'" + dt.Rows[x]["phone"].ToString() + "',"
                            + "'" + dt.Rows[x]["email"].ToString() + "',"
                            + "'" + dt.Rows[x]["lga"].ToString() + "',"
                            + "'" + strLgaDescr + "',"
                            + "'" + dt.Rows[x]["birthdate"].ToString() + "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + false + "')";

                        
                        dthm._update_Insert_NoParameter(sqlInsert);

                        if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError, "RnS Notification");
                        else
                        {
                            _totalSaved += 1;

                            // update the webdb recruittaab
                            string sqlUpdate = string.Empty;
                            sqlUpdate = @" update recruittab set  used = 'true'"
                             + "  where recrno = '" + dt.Rows[x]["recrno"].ToString() + "'";
                            dthm._update_Insert_NoParameter(sqlUpdate, ConfigurationManager.ConnectionStrings["rnsConString_webdb"].ConnectionString);

                            try
                            {
                                dgvDestination.Rows[x].Cells[4].Value = true;
                            }
                            catch
                            {
                            }






                        }
                    }
                }
                else
                {

                    MessageBox.Show("There are no records to processed", "RnS Notification");
                    lblprocessing.Visible = false;
                }
               
            }

            else MessageBox.Show("dthm.sqlUserError","RnS Notification");

          
            if (_totalSaved > 0) MessageBox.Show(_totalSaved.ToString() + " records was committed Successfully", "RnS Notification");

            lblprocessing.Visible = false;

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            saveRecords();
        }
    }
}
