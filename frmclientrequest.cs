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
    public partial class frmclientrequest : Form
    {
        private int _doubleClickSelRowIndex ;
        private int _doubleClickSelColIndex;
        private int _newAddedRowIndex = 0;
        private Boolean _coladded = false;


        public frmclientrequest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void frmclientrequest_Load(object sender, EventArgs e)
        {
            clearScreen();

            
        }

        private void creategridcolumn()
        {

            // create column headers
            grdClientRequest.Rows.Clear();
            grdClientRequest.ColumnCount = 0;
            grdClientRequest.ColumnCount = 14;
            grdClientRequest.Columns[0].Name = "Position";

            grdClientRequest.Columns[1].Name = "Qual1";
            grdClientRequest.Columns[2].Name = "Qual2";
            grdClientRequest.Columns[3].Name = "Qual3";
            grdClientRequest.Columns[4].Name = "Qual4";
            grdClientRequest.Columns[5].Name = "RequestNo";
            grdClientRequest.Columns[6].Name = "Datefrom";
            grdClientRequest.Columns[7].Name = "DateTo";
            grdClientRequest.Columns[8].Name = "Location";
            grdClientRequest.Columns[9].Name = "EmployedNo";
            grdClientRequest.Columns[10].Name = "InterviewNo";
            grdClientRequest.Columns[11].Name = "SupplyNo";
            grdClientRequest.Columns[12].Name = "Remarks";

        }

        private void saveRecords()
        {

            if (chkactive.Enabled == false)
            {
                MessageBox.Show("This request is closed", "RnS Notification");
                return;
            }

            if (txtclientid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Client can't be empty!", "Missing Client ID");
                return;
            }
            if (txtrequestid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Request ID can't be empty!", "Missing Request ID");
                return;
            }
            //if (dtpdeadline.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show("Request Date can't be empty!", "Missing Request Date");
            //    return;
            //}

            if (txttitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Request Title can't be empty!", "Missing Request Title");
                return;
            }

            string strClientID = txtclientid.Text.Trim() ;
            string strrequestid = txtrequestid.Text ;
            string strrequestdate = dtprequesteddate.Value.ToShortDateString();
            string strDeadeline = dtpdeadline.Value.ToShortDateString();
            string strTitle= txttitle.Text;
            if (strrequestdate == string.Empty) strrequestdate = DateTime.Now.ToString();
            string strActive = chkactive.Checked.ToString();

            int _totalSaved = 0;
           
            datamethods2 dthm = new datamethods2();

            for (int x = 0; x < grdClientRequest.Rows.Count; x++)
            {
                if (grdClientRequest.Rows[x].Cells[1].Value.ToString() != null && grdClientRequest.Rows[x].Cells[1].Value.ToString().Trim() != string.Empty)
                {    
                    
                    string reqid = grdClientRequest.Rows[x].Cells[0].Value.ToString();
                    string sPosition = grdClientRequest.Rows[x].Cells[1].Value.ToString();
                    string qual1 = grdClientRequest.Rows[x].Cells[2].Value.ToString();
                    string qual2 = grdClientRequest.Rows[x].Cells[3].Value.ToString();
                    string qual3 = grdClientRequest.Rows[x].Cells[4].Value.ToString();
                    string qual4 = grdClientRequest.Rows[x].Cells[5].Value.ToString();
                    string RequestNo = grdClientRequest.Rows[x].Cells[6].Value.ToString();
                    string Location = grdClientRequest.Rows[x].Cells[7].Value.ToString();
                    string SupplyNo = grdClientRequest.Rows[x].Cells[8].Value.ToString();
                    string InterviewNo = grdClientRequest.Rows[x].Cells[9].Value.ToString();
                    string EmployedNo = grdClientRequest.Rows[x].Cells[10].Value.ToString();
                    string Remarks = grdClientRequest.Rows[x].Cells[11].Value.ToString();
                    Boolean newkeyid = Convert.ToBoolean(grdClientRequest.Rows[x].Cells[12].Value);
                    string strposcode = grdClientRequest.Rows[x].Cells[13].Value.ToString();
                    string strlgacode = grdClientRequest.Rows[x].Cells[14].Value.ToString();
                

                    if (newkeyid == false) //existing: do Update
                    {
                        
                        string sqlUpdate = string.Empty;
                        sqlUpdate = @" update clientrequest set  position = '" + sPosition + "',"
                            + " qual1= '" + qual1 + "',"
                            + " qual2 = '" + qual2 + "',"
                            + " qual3 = '" + qual3 + "',"
                            + " qual4 = '" + qual4 + "',"
                            + " RequestNo = '" + RequestNo + "',"
                            + " Location= '" + Location + "',"
                            + " EmployedNo= '" + EmployedNo + "',"
                            + " InterviewNo= '" + InterviewNo + "',"
                            + " SupplyNo= '" + SupplyNo + "',"
                            + " status= '" + strActive + "',"
                            + " drequest= '" + dtpdeadline.Value.ToString("yyyy/MM/dd") + "',"
                            + " reqdate= '" + dtprequesteddate.Value.ToString("yyyy/MM/dd") + "',"
                            + " title= '" + strTitle + "',"
                            + " poscode= '" + strposcode.Trim() + "',"
                            + " lgacode = '" + strlgacode + "',"
                            + " Remarks= '" + Remarks + "'"
                            + " where clientid = '" + strClientID + "'"
                            + " and requestid= '" + strrequestid + "'"
                            + " and reqid= '" + reqid + "'";

                        dthm._update_Insert_NoParameter(sqlUpdate);

                        if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError,"RnS Notification");
                        else
                        {
                            _totalSaved += 1;
                        }
                    }
                    else // new: do insert
                    {
                        
                       

                        string sqlInsert = string.Empty;
                        sqlInsert = @" Insert into clientrequest "
                            + "(position,qual1,qual2,qual3,qual4,RequestNo, "
                            + " poscode,lgacode,Location,EmployedNo,InterviewNo,SupplyNo,Remarks,status,drequest,reqdate,clientid,requestid,reqid,title)"
                            + " values ('" + sPosition + "',"
                            + "'" + qual1 + "',"
                            + "'" + qual2 + "',"
                            + "'" + qual3 + "',"
                            + "'" + qual4 + "',"
                            + "'" + RequestNo + "',"
                            + "'" + strposcode.Trim() + "',"
                            + "'" + strlgacode.Trim() + "',"
                            + "'" + Location + "',"
                            + "'" + EmployedNo + "',"
                            + "'" + InterviewNo + "',"
                            + "'" + SupplyNo + "',"
                            + "'" + Remarks + "',"
                            + "'" + strActive + "',"
                            + "'" + dtpdeadline.Value.ToString("yyyy/MM/dd") + "',"
                            + "'" + dtprequesteddate.Value.ToString("yyyy/MM/dd") + "',"
                            + "'" + strClientID + "',"
                            + "'" + strrequestid + "',"
                            + "'" + reqid + "',"
                            + "'" + strTitle + "'"
                            + ")";

                        dthm._update_Insert_NoParameter(sqlInsert);

                        if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError, "RnS Notification");
                        else
                        {
                            _totalSaved += 1;
                        }
                    }
                }

                    
            }


            if (_totalSaved > 0)
            {
                MessageBox.Show(_totalSaved.ToString() + " records was committed Successfully", "RnS Notification");
                clearScreen();
            }
            else MessageBox.Show(_totalSaved.ToString() + " records was committed Successfully", "RnS Notification");

        }

        private void clearScreen()
        {
            _coladded = false;
            txtclientid.Text = "";
            txtrequestid.Text = "";
            txttitle.Text = "";
            txtclientid.Enabled = false;
            txtrequestid.Enabled = false;
            grdClientRequest.Rows.Clear();
            chkactive.Checked = false;
            chkactive.Enabled = true;
            dtpdeadline.Value = DateTime.Now;
            dtprequesteddate.Value = DateTime.Now;

            //creategridcolumn();
            _createColumns();
        }

        

        private void populateScreen()
        {
            txtclientid.Enabled = false;
            txtrequestid.Text = "";
            dtpdeadline.Text = "";
            grdClientRequest.Rows.Clear();
            chkactive.Checked = false;
            chkactive.Enabled = true;
            txttitle.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program._searchedValue = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_FormClosed);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "ClientID";
            frmSch.strHeader2 = "Clientname";
            frmSch.strHeader3 = "";
            string strQuery = string.Empty;
            strQuery = "select customerid as ClientID, companyname  as Clientname from customers";
            frmSch._getData_RIMS(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtclientid.Text = Program._searchedValue;
            if (txtclientid.Text != string.Empty) populateScreen();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program._searchedValue = string.Empty;
            string strClientId = "'" + txtclientid.Text + "'";

            if (txtclientid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Select Client","RnS Notification");
                return;
            } 
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_FormClosed2);
            frmSch.strHeader1 = "RequestId";
            frmSch.strHeader2 = "Title";
            string strQuery = string.Empty;
            strQuery = "select distinct requestid as RequestId, Title from clientrequest where clientid = " + strClientId;
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed2(object sender, FormClosedEventArgs e)
        {

            populateGrid();

        }

        private void populateGrid()
        {
            string strClientId = "'" + txtclientid.Text +"'";
            string strRequestId = "'" + Program._searchedValue.Trim() + "'";
          
            //if (!= string.Empty) txtrequestid.Text = Program._searchedValue;


            String sqlSelect = @"select * from clientrequest where clientid = " + strClientId +
            " and requestid = " + strRequestId;
            DataTable dt = new DataTable();
            datamethods2 dtmth = new datamethods2();
            dt = dtmth._dataTable_NoParameter(sqlSelect);
            if (dtmth.sqlUserError == string.Empty)
            {
                if (dt.Rows.Count > 0)
                {
                    txtrequestid.Text = Program._searchedValue.Trim();
                    dtpdeadline.Value = Convert.ToDateTime(dt.Rows[0]["drequest"]);
                    dtprequesteddate.Value = Convert.ToDateTime(dt.Rows[0]["reqdate"]);
                    txttitle.Text = Program._searchedValue2;

                    if (Convert.ToBoolean(dt.Rows[0]["status"]) == true)
                    {
                        chkactive.Checked = true;
                        chkactive.Enabled = false;
                        dtpdeadline.Enabled = false;
                    } 

                     _addColumns(dt);

                }
                else
                {

                
                    // create a new request id
                    string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    string strdate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                    string newRequestId = txtclientid.Text.Trim().ToUpper() + "/" + strdate + "/" + strTime;
                    txtrequestid.Text = newRequestId;
                    dtpdeadline.Text = DateTime.Now.Date.ToString();
                    txttitle.Text = "";

                }
               
                _formatCells();

            }
            else
            {
                MessageBox.Show(dtmth.sqlUserError,"RnS Notification");
            }
            txtrequestid.Enabled = false;
            //mskrequestdate.Focus();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            saveRecords();
        }

        private void txtclientid_Leave(object sender, EventArgs e)
        {
            populateScreen();
        }

        private void txtrequestid_Leave(object sender, EventArgs e)
        {
            
        }

             

        private void grdClientRequest_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            // Don't throw an exception when we're done.
            //e.ThrowException = false;

            // Display an error message.
            string txt = "Error with " + grdClientRequest.Columns[e.ColumnIndex].HeaderText + "\n\n" + e.Exception.Message;
            MessageBox.Show(txt, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

            // If this is true, then the user is trapped in this cell.
           // e.Cancel = false;

            
        }

        private void _formatCells()
        {
            
           // this.grdClientRequest.Columns["Datefrom"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //this.grdClientRequest.Columns["Dateto"].DefaultCellStyle.Format = "d";
            //this.grdClientRequest.Columns["Datefrom"].DefaultCellStyle.Format = "d";

        }

        private void _createColumns()
        {

            grdClientRequest.Columns.Clear();


            DataGridViewTextBoxColumn reqid = new DataGridViewTextBoxColumn();
            reqid.Name = "reqid";
            reqid.ToolTipText = "reqid";
            reqid.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(reqid);
            reqid.Visible = false;

            DataGridViewTextBoxColumn tbPosition = new DataGridViewTextBoxColumn();
            tbPosition.HeaderText = "Position";
            tbPosition.Name = "position";
            tbPosition.ToolTipText = "Position";
            tbPosition.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(tbPosition);

            DataGridViewTextBoxColumn tbQual1 = new DataGridViewTextBoxColumn();
            tbQual1.HeaderText = "Qual 1";
            tbQual1.Name = "Qual1";
            tbQual1.ToolTipText = "Qualification 1";
            tbQual1.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(tbQual1);

            DataGridViewTextBoxColumn tbQual2 = new DataGridViewTextBoxColumn();
            tbQual2.HeaderText = "Qual 2";
            tbQual2.Name = "Qual2";
            tbQual2.ToolTipText = "Qualification 2";
            tbQual2.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(tbQual2);


            DataGridViewTextBoxColumn tbQual3 = new DataGridViewTextBoxColumn();
            tbQual3.HeaderText = "Qual 3";
            tbQual3.Name = "Qual3";
            tbQual3.ToolTipText = "Qualification 3";
            tbQual3.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(tbQual3);

            DataGridViewTextBoxColumn tbQual4 = new DataGridViewTextBoxColumn();
            tbQual4.HeaderText = "Qual4";
            tbQual4.Name = "Qual4";
            tbQual4.ToolTipText = "Qualification 4";
            tbQual4.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(tbQual4);


            DataGridViewTextBoxColumn RequestNo = new DataGridViewTextBoxColumn();
            RequestNo.HeaderText = "Request#";
            RequestNo.Name = "requestNo";
            RequestNo.ToolTipText = "Total Requested";
            RequestNo.DefaultCellStyle.NullValue = "0";
            grdClientRequest.Columns.Add(RequestNo);


            DataGridViewTextBoxColumn Location = new DataGridViewTextBoxColumn();
            Location.HeaderText = "Location";
            Location.Name = "Location";
            Location.ToolTipText = "Location";
            Location.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(Location);

            DataGridViewTextBoxColumn SupplyNo = new DataGridViewTextBoxColumn();
            SupplyNo.HeaderText = "Sent#";
            SupplyNo.Name = "SupplyNo";
            SupplyNo.ToolTipText = "Total Sent";
            SupplyNo.DefaultCellStyle.NullValue = "0";
            grdClientRequest.Columns.Add(SupplyNo);
           

            DataGridViewTextBoxColumn InterviewNo = new DataGridViewTextBoxColumn();
            InterviewNo.HeaderText = "Interviewed#";
            InterviewNo.Name = "InterviewNo";
            InterviewNo.ToolTipText = "Total Interviewd";
            InterviewNo.DefaultCellStyle.NullValue = "0";
            grdClientRequest.Columns.Add(InterviewNo);


            DataGridViewTextBoxColumn EmployedNo = new DataGridViewTextBoxColumn();
            EmployedNo.HeaderText = "Employed#";
            EmployedNo.Name = "EmployedNo";
            EmployedNo.ToolTipText = "Total Employed";
            EmployedNo.DefaultCellStyle.NullValue = "0";
            grdClientRequest.Columns.Add(EmployedNo);

            DataGridViewTextBoxColumn Remarks = new DataGridViewTextBoxColumn();
            Remarks.HeaderText = "Remarks";
            Remarks.Name = "Remarks";
            Remarks.ToolTipText = "Remarks";
            Remarks.DefaultCellStyle.NullValue = "";
            grdClientRequest.Columns.Add(Remarks);


            DataGridViewCheckBoxColumn newkeyid = new DataGridViewCheckBoxColumn();
            newkeyid.HeaderText = "newkeyid";
            newkeyid.Name = "newkeyid";
            newkeyid.ToolTipText = "newkeyid";
            newkeyid.DefaultCellStyle.NullValue = true;
            grdClientRequest.Columns.Add(newkeyid);
            newkeyid.Visible = false;

            DataGridViewTextBoxColumn poscode = new DataGridViewTextBoxColumn();
            poscode.HeaderText = "poscode";
            poscode.Name = "poscode";
            poscode.ToolTipText = "poscode";
            poscode.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(poscode);
            poscode.Visible = false;

            DataGridViewTextBoxColumn lgacode = new DataGridViewTextBoxColumn();
            lgacode.HeaderText = "lgacode";
            lgacode.Name = "lgacode";
            lgacode.ToolTipText = "lgacode";
            lgacode.DefaultCellStyle.NullValue = " ";
            grdClientRequest.Columns.Add(lgacode);
            lgacode.Visible = false;
            
        }

        private void open_grid_forSearch(object sender, FormClosedEventArgs e)
        {
           // MessageBox.Show(Program._searchedValue);
            grdClientRequest.BeginEdit(true);

            grdClientRequest.Rows[_doubleClickSelRowIndex].Cells[_doubleClickSelColIndex].Value = Program._searchedValue2.Trim();

           //lgacode
            if (_doubleClickSelColIndex == 7) grdClientRequest.Rows[_doubleClickSelRowIndex].Cells[14].Value = Program._searchedValue.Trim();

            //poscode
            if (_doubleClickSelColIndex == 1) grdClientRequest.Rows[_doubleClickSelRowIndex].Cells[13].Value = Program._searchedValue.Trim();
           


            grdClientRequest.RefreshEdit();
            grdClientRequest.Refresh();
            grdClientRequest.EndEdit();
            grdClientRequest.AutoResizeColumns();
            grdClientRequest.AutoResizeRows();
            grdClientRequest.Focus();
            


            

        }

        private void grdClientRequest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "CellContentDoubleClick Event");

            _doubleClickSelColIndex = e.ColumnIndex;
            _doubleClickSelRowIndex = e.RowIndex;
            
            string strQuery = string.Empty;

            if (e.ColumnIndex == 1) // position
            {
                strQuery = "select code, desc1  as description from codestab where option1 = 'POSIT' ";

            }

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5) // qual1
            {
                strQuery = "select code, desc1  as description from codestab where option1 = 'QUALIF' ";
            }

            if (e.ColumnIndex == 7) // location
            {
                strQuery = "select code, desc1  as description from codestab where option1 = 'LGACODE' ";
            }

            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 7)
            {
                Program._searchedValue = string.Empty;

                frmsearch frmSch = new frmsearch();
                frmSch.FormClosed += new FormClosedEventHandler(open_grid_forSearch);
                frmSch.strHeader1 = "Code";
                frmSch.strHeader2 = "Description";
                frmSch.strHeader3 = "";
                frmSch.useRIMSConnString = true;
                frmSch._getData(strQuery);
                frmSch.ShowDialog();
            }
        }

        private void grdClientRequest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            grdClientRequest.Rows[e.RowIndex].Cells[0].Value = strTime;
            _newAddedRowIndex = e.RowIndex;
            //MessageBox.Show("row");
            if (_coladded == true)
            {
                             
                grdClientRequest.Rows[_newAddedRowIndex].Cells[1].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[2].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[3].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[4].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[5].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[6].Value = "0";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[7].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[8].Value = "0";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[9].Value = "0";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[10].Value = "0";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[11].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[12].Value = true;
                grdClientRequest.Rows[_newAddedRowIndex].Cells[13].Value = " ";
                grdClientRequest.Rows[_newAddedRowIndex].Cells[14].Value = " ";

                grdClientRequest.RefreshEdit();
                grdClientRequest.Refresh();
               
            }
        }

        private void _addColumns( DataTable dt)
        {
            grdClientRequest.Rows.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                int n = grdClientRequest.Rows.Add();
                grdClientRequest.Rows[n].Cells[0].Value = dt.Rows[x]["reqid"].ToString();
                grdClientRequest.Rows[n].Cells[1].Value = dt.Rows[x]["position"].ToString();
                grdClientRequest.Rows[n].Cells[2].Value = dt.Rows[x]["qual1"].ToString();
                grdClientRequest.Rows[n].Cells[3].Value = dt.Rows[x]["qual2"].ToString();
                grdClientRequest.Rows[n].Cells[4].Value = dt.Rows[x]["qual3"].ToString();
                grdClientRequest.Rows[n].Cells[5].Value = dt.Rows[x]["qual4"].ToString();
                grdClientRequest.Rows[n].Cells[6].Value = dt.Rows[x]["RequestNo"].ToString();
                grdClientRequest.Rows[n].Cells[7].Value = dt.Rows[x]["Location"].ToString();
                grdClientRequest.Rows[n].Cells[8].Value = dt.Rows[x]["SupplyNo"].ToString();
                grdClientRequest.Rows[n].Cells[9].Value = dt.Rows[x]["InterviewNo"].ToString();
                grdClientRequest.Rows[n].Cells[10].Value = dt.Rows[x]["EmployedNo"].ToString();
                grdClientRequest.Rows[n].Cells[11].Value = dt.Rows[x]["Remarks"].ToString();
                grdClientRequest.Rows[n].Cells[12].Value = false;
                grdClientRequest.Rows[n].Cells[13].Value = dt.Rows[x]["poscode"].ToString();
                grdClientRequest.Rows[n].Cells[14].Value = dt.Rows[x]["lgacode"].ToString();
              

                
                              
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (txtclientid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Specify Client","RnS Notification");
                return;
            }

            // create a new request id
            string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string strdate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            string newRequestId = txtclientid.Text.Trim().ToUpper() + "/" + strdate + "/" + strTime;
            txtrequestid.Text = newRequestId;
            dtpdeadline.Text = DateTime.Now.Date.ToString();
            chkactive.Checked = false;
            chkactive.Enabled = true;
            grdClientRequest.Rows.Clear();
        }

        private void grdClientRequest_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            
           if (e.Column.Index == 14)
           {
               _coladded = true;

               grdClientRequest.Rows[_newAddedRowIndex].Cells[1].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[2].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[3].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[4].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[5].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[6].Value = "0";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[7].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[8].Value = "0";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[9].Value = "0";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[10].Value = "0";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[11].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[12].Value = true;
               grdClientRequest.Rows[_newAddedRowIndex].Cells[13].Value = " ";
               grdClientRequest.Rows[_newAddedRowIndex].Cells[14].Value = " ";

               grdClientRequest.RefreshEdit();
               grdClientRequest.Refresh();
               

           }
        }

        private void grdClientRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            rpt_form_clientrequest rptfrm = new rpt_form_clientrequest();
            rptfrm.ShowDialog();

            //rpt_frm_clientRequests rptfrm = new rpt_frm_clientRequests();
            //rptfrm.ShowDialog();
        }

       
       

      
    }
}
