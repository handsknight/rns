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

using rns;

namespace rns
{
//#pragma warning disable

    public partial class candidateselection : Form
    {
        private int _newAddedRowIndex = 0;
        private Boolean _coladded = false;
        private datamethods2 dmth = new datamethods2();
        private DataTable dt_shortlisted = new DataTable();

        private Boolean _coladded_des = false;
        private string prv_location = string.Empty;
        private string prv_grade = string.Empty;
        private string prv_qual = string.Empty;
        private string prv_Poscode = string.Empty;

        public candidateselection()
        {
            InitializeComponent();
        }

        private void btnclient_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_FormClosed);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "ClientID";
            frmSch.strHeader2 = "Clientname";
            frmSch.strHeader3 = "";
            string strQuery = string.Empty;
            frmSch.useRIMSConnString = true;
            strQuery = "select customerid as ClientID, companyname  as Clientname from customers";
            frmSch._getData_RIMS(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (Program._searchedValue != string.Empty)
            {
                
                populateScreen();
                txtclientid.Text = Program._searchedValue;
            } 

        }

        private void btnrequest_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            string strClientId = "'" + txtclientid.Text + "'";

            if (txtclientid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Select Client", "RnS Notification");
                return;
            }
            Program._searchedValue2 = string.Empty;
            Program._searchedValue = string.Empty;

            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_FormClosed2);
            frmSch.strHeader1 = "RequestId";
            frmSch.strHeader2 = "Position";
            frmSch.strHeader3 = "PositionId";
            frmSch.strHeader4 = "Title";
            string strQuery = string.Empty;
            strQuery = "select distinct requestid as RequestId, position  as Position, poscode as PositionId,title as Title from clientrequest where status = 'false' and clientid = " + strClientId;
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed2(object sender, FormClosedEventArgs e)
        {
            
            grdCandidate.Rows.Clear();

            if (Program._searchedValue != string.Empty)
            {

                txtrequestid.Text = Program._searchedValue;
                lblposition.Text = Program._searchedValue2;
                prv_Poscode = Program._searchedValue3;
                lblrequestdescr.Text = Program._searchedValue4;
                populateGrid();
            }
         

        }

        private void populateGrid()
        {

            if (txtclientid.Text == string.Empty || txtrequestid.Text == string.Empty)
            {
                MessageBox.Show("Both Client and Request must be specified","RnS Notification");
                return;
            }


            grdCandidate.Rows.Clear();
            dt_shortlisted.Rows.Clear();

            string strClientId = "'" + txtclientid.Text + "'";
            string strRequestId = "'" + Program._searchedValue.Trim() + "'";
            int _totalSaved = 0;
            _totalSaved = 0;

            List<string> lstRecrno = new List<string>();
            string strParam = string.Empty;
            string strWhereCaluse = string.Empty;



            if (cmbgender.SelectedItem.ToString().Trim() != string.Empty) strParam = strParam + " and a.sex = '" + cmbgender.SelectedItem.ToString().Trim() + "'";
            if (txtlocation.Text.Trim() != string.Empty) strParam = strParam + " and a.lgacode = '" + prv_location.Trim() + "'";
            if (txtqualification.Text.Trim() != string.Empty) strParam = strParam + " and a.qualcode = '" + prv_qual.Trim() + "'";
            if (txtgrade.Text.Trim() != string.Empty) strParam = strParam + " and a.gradecode = '" + prv_grade.Trim() + "'";
            
            if (chkaptested.Checked == true)
            {
                if (cmbtestresult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify Test Result", "RnS Notification");
                    return;
                }
                
                if (cmbtestresult.Text.Trim() != string.Empty)
                {
                    strParam = strParam + " and a.aptest = 'true' and a.testsult = '" + cmbtestresult.Text.Trim() + "'"; 
                }
                
                

            }

            if (mskage.Text != string.Empty && mskage2.Text != string.Empty)
            {
                
                if ( Convert.ToInt32(mskage.Text) < Convert.ToInt32(mskage2.Text))
                {
                    strParam = strParam + " and a.age between " + mskage.Text + " and  " + mskage2.Text;

                }
                if (Convert.ToInt32(mskage.Text) > Convert.ToInt32(mskage2.Text))
                {

                    strParam = strParam + " and a.age between " + mskage2.Text + " and  " + mskage.Text;
                }

                if (Convert.ToInt32(mskage.Text) == Convert.ToInt32(mskage2.Text))
                {
                    strParam = strParam + " and a.age between " + mskage2.Text + " and  " + mskage.Text;
                }
            }

     
            //if (!= string.Empty) txtrequestid.Text = Program._searchedValue;

            // ----- selection from database 1
            if ( raddatabase1.Checked == true )
            {
                String sqlSelect = @"select distinct a.* from database1 a
                    where a.recrno not in (select recrno from database2)" + strParam;

//                String sqlSelect = @"select distinct * from database1
//                    where active = 'false' and recrno not in (select recrno from database2)" + strParam;


                DataTable dt = new DataTable();
                datamethods2 dtmth = new datamethods2();
                dt = dtmth._dataTable_NoParameter(sqlSelect);

                if (dtmth.sqlUserError == string.Empty)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dt_shortlisted = dt;
                        _addColumns(dt);

                    }
                    else MessageBox.Show("Requested records not found!", "RnS Notification");        

                }
                else
                {
                    MessageBox.Show(dtmth.sqlUserError, "RnS Notification");
                }
            }



            // ----- selection from database 2

            //interview 
            if (chkicslinterview.Checked == true)
            {
                if (cmdtinterviewresult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify ICSL Interview Result", "RnS Notification");
                    return;
                }

                if (cmdtinterviewresult.Text.Trim() != string.Empty)
                {
                    strParam = strParam + " and a.interviewed = 'true' and a.intersult = '" + cmdtinterviewresult.Text.Trim() + "'";
                }
                
            }

            
            //medical 
            if (chkmedical.Checked == true)
            {
                if (cmbmedicalresult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify Medical Result", "RnS Notification");
                    return;
                }

                if (cmbmedicalresult.Text.Trim() != string.Empty)
                {
                    strParam = strParam + " and a.medical = 'true' and a.medsult = '" + cmbmedicalresult.Text.Trim() + "'";
                }
                
            }

            


            //essay 
            if (chkessay.Checked == true)
            {

                if (cmbessayresult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify Essay Result", "RnS Notification");
                    return;
                }

                if (cmbessayresult.Text.Trim() != string.Empty)
                {
                    strParam = strParam + " and a.essay = 'true' and a.essaysult = '" + cmbessayresult.Text.Trim() + "'";
                }
                
            }

            

            //induction 
            if (chkinduction.Checked == true)
            {
                if (cmbinductionresult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify ICSL Induction assessment", "RnS Notification");
                    return;
                   
                }
                
                if (cmbinductionresult.Text.Trim() != string.Empty)
                {
                    strParam = strParam + " and a.induction = 'true' and a.inductsult = '" + cmbinductionresult.Text.Trim() + "'";
                }
                
            }


           
            //documented
            if (chkdocumented.Checked == true) strParam = strParam + " and a.documented = 'true' ";
         
           

            //chkshl
            if (chkshl.Checked == true) strParam = strParam + " and a.shl = 'true' ";


            //client induction 
            if (chkcinduction.Checked == true)
            {

                if (cmbcindsult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify client Induction assessment", "RnS Notification");
                    return;
                }
                

                if (cmbcindsult.Text.Trim() != string.Empty)
                {
                    strParam = strParam + " and b.cinduction = 'true' and b.cindsult = '" + cmbcindsult.Text.Trim() + "'";
                }
               
            }

            //client interview 
            if (chkcinterview.Checked == true)
            {

                if (chkcintsult.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify client interview assessment", "RnS Notification");
                    return;
                }
                
                strParam = strParam + " and b.cinterview = 'true' and b.cintersult = '" + chkcintsult.Text.Trim() + "'";
                
            }

            //emp type 
            if (cmbemploymenttype.Text.Trim() != string.Empty)
            {
                strParam = strParam + " and b.emptype = '" + cmbemploymenttype.Text.Trim() + "'";
            }


            if (raddatabase2.Checked == true)
            {
                String sqlSelect = @"select distinct a.* from database2 a, candidatecallup b 
                where a.recrno = b.recrno and  (a.active = 'false' or a.active = 'true' )" + strParam;
                
                //MessageBox.Show(sqlSelect);
                //return;
                DataTable dt = new DataTable();
                datamethods2 dtmth = new datamethods2();
                dt = dtmth._dataTable_NoParameter(sqlSelect);

                if (dtmth.sqlUserError == string.Empty)
                {
                    if (dt.Rows.Count > 0)
                    {
                        dt_shortlisted = dt;
                        _addColumns(dt);
                       

                    }
                    else MessageBox.Show("Requested records not found!", "RnS Notification");

                }
                else
                {
                    MessageBox.Show(dtmth.sqlUserError, "RnS Notification");
                }
            }
            grdCandidate.Focus();
            raddatabase1.Enabled = false;
            raddatabase2.Enabled = false;
        }

        private void populateScreen()
        {

            clearScreen();

        }

        private void _addColumns(DataTable dt)
        {
            grdCandidate.Rows.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                int n = grdCandidate.Rows.Add();
                grdCandidate.Rows[n].Cells[0].Value = dt.Rows[x]["recrno"].ToString();
                grdCandidate.Rows[n].Cells[1].Value = dt.Rows[x]["surname"].ToString();
                grdCandidate.Rows[n].Cells[2].Value = dt.Rows[x]["firstname"].ToString();
                grdCandidate.Rows[n].Cells[3].Value = dt.Rows[x]["middlename"].ToString();
                grdCandidate.Rows[n].Cells[4].Value = dt.Rows[x]["address"].ToString();
                grdCandidate.Rows[n].Cells[5].Value = dt.Rows[x]["phone"].ToString();
                grdCandidate.Rows[n].Cells[6].Value = dt.Rows[x]["email"].ToString();
                grdCandidate.Rows[n].Cells[7].Value = false;
                grdCandidate.Rows[n].Cells[8].Value = false;
                
           }

        }

        private void _createColumns()
        {

            // source
            grdCandidate.Columns.Clear();

            DataGridViewTextBoxColumn recrno = new DataGridViewTextBoxColumn();
            recrno.HeaderText = "Candidate ID";
            recrno.Name = "recrno";
            recrno.ToolTipText = "Candidate ID";
            recrno.DefaultCellStyle.NullValue = " ";
            recrno.ReadOnly = true;
            grdCandidate.Columns.Add(recrno);


            DataGridViewTextBoxColumn surname = new DataGridViewTextBoxColumn();
            surname.HeaderText = "Surname";
            surname.Name = "surname";
            surname.ToolTipText = "surname";
            surname.ReadOnly = true;
            surname.DefaultCellStyle.NullValue = " ";

            grdCandidate.Columns.Add(surname);

            DataGridViewTextBoxColumn firstname = new DataGridViewTextBoxColumn();
            firstname.HeaderText = "Firstname";
            firstname.Name = "firstname";
            firstname.ToolTipText = "firstname";
            firstname.DefaultCellStyle.NullValue = " ";
            firstname.ReadOnly = true;
            grdCandidate.Columns.Add(firstname);

            DataGridViewTextBoxColumn middlename = new DataGridViewTextBoxColumn();
            middlename.HeaderText = "Middlename";
            middlename.Name = "middlename";
            middlename.ToolTipText = "middlename";
            middlename.DefaultCellStyle.NullValue = " ";
            middlename.ReadOnly = true;
            grdCandidate.Columns.Add(middlename);

            DataGridViewTextBoxColumn address = new DataGridViewTextBoxColumn();
            address.HeaderText = "address";
            address.Name = "address";
            address.ToolTipText = "address";
            address.DefaultCellStyle.NullValue = " ";
            address.ReadOnly = true;
            grdCandidate.Columns.Add(address);

            DataGridViewTextBoxColumn phone = new DataGridViewTextBoxColumn();
            phone.HeaderText = "Phone";
            phone.Name = "phone";
            phone.ToolTipText = "Phone";
            phone.DefaultCellStyle.NullValue = " ";
            phone.ReadOnly = true;
            grdCandidate.Columns.Add(phone);

            DataGridViewTextBoxColumn email = new DataGridViewTextBoxColumn();
            email.HeaderText = "Email";
            email.Name = "email";
            email.ToolTipText = "email";
            email.DefaultCellStyle.NullValue = " ";
            email.ReadOnly = true;
            grdCandidate.Columns.Add(email);

            DataGridViewCheckBoxColumn include = new DataGridViewCheckBoxColumn();
            include.HeaderText = "Include";
            include.Name = "include";
            include.ToolTipText = "include";
            include.DefaultCellStyle.NullValue = false;
            include.ReadOnly = false;
            grdCandidate.Columns.Add(include);

            DataGridViewCheckBoxColumn saved = new DataGridViewCheckBoxColumn();
            saved.HeaderText = "Saved Status";
            saved.Name = "saved";
            saved.ToolTipText = "saved";
            saved.DefaultCellStyle.NullValue = false;
            saved.ReadOnly = true;
            grdCandidate.Columns.Add(saved);

        }

        private void clearScreen()
        {
            dt_shortlisted.Rows.Clear();

            lblrequestdescr.Text = "";
            txtclientid.Text = ""; 
            txtrequestid.Text = ""; 
            _coladded = false;
            _coladded_des = false;
            grdCandidate.Rows.Clear();
            _newAddedRowIndex = 0;
            lblposition.Text = string.Empty;
            //raddatabase1.Checked = true;
            raddatabase1.Enabled = true;
            raddatabase2.Enabled = true;

            chkaptested.Checked = false;
            chkicslinterview.Checked = false;
            chkdocumented.Checked = false;

            chkmedical.Checked = false;
            chkessay.Checked = false;
            chkshl.Checked = false;
            chkinduction.Checked = false;
          

            txtlocation.SelectedText = "";
            txtqualification.Text = "";
            txtgrade.Text = "";
            cmbemploymenttype.SelectedIndex = 0;
            cmbtestresult.SelectedIndex = 0;
            cmdtinterviewresult.SelectedIndex = 0;
            cmbgender.SelectedIndex = 0;
            mskage.Text="";
            cmbmedicalresult.SelectedIndex = 0;
            cmbessayresult.SelectedIndex = 0;
            cmbinductionresult.SelectedIndex = 0;



            chkcinduction.Checked = false;
            cmbcindsult.SelectedIndex = 0;

        }

        private void candidateselection_Load(object sender, EventArgs e)
        {
            clearScreen();
            _createColumns();

            
            
        }

        private void grdCandidate_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Index == 8)
            {
                _coladded_des = true;

                grdCandidate.Rows[_newAddedRowIndex].Cells[0].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[1].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[2].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[3].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[4].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[5].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[6].Value = " ";
                grdCandidate.Rows[_newAddedRowIndex].Cells[7].Value = false;
                grdCandidate.Rows[_newAddedRowIndex].Cells[8].Value = false;
                grdCandidate.RefreshEdit();
                grdCandidate.Refresh();
                grdCandidate.EndEdit();


            }
        }

        private void grdCandidate_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _newAddedRowIndex = e.RowIndex;
            if (_coladded_des == true)
            {

                grdCandidate.Rows[e.RowIndex].Cells[0].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[1].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[2].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[3].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[4].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[5].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[6].Value = " ";
                grdCandidate.Rows[e.RowIndex].Cells[7].Value = false;
                grdCandidate.Rows[e.RowIndex].Cells[8].Value = false;
                grdCandidate.RefreshEdit();
                grdCandidate.Refresh();



            }
        }

        private void saveRecords()
        {


            if (grdCandidate.Rows.Count == 0)
            {
                MessageBox.Show("Specify candidate records", "RnS Notification");
                return;
            }

            if (raddatabase1.Checked == true)  saveRecords_database1();
            if (raddatabase2.Checked == true)  saveRecords_database2();

            


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            saveRecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void clearGrid()
        {
            _coladded = false;
            _coladded_des = false;
            grdCandidate.Rows.Clear();
            _newAddedRowIndex = 0;
            raddatabase2.Enabled = true;
            raddatabase1.Enabled = true;
            txtrequestid.Text = "";
            lblposition.Text = "";

            
        }

        private void saveRecords_database1()
        {
            string strRecrno = String.Empty;

            string sqlInsertwhere = string.Empty;
            List<string> lstRecrno = new List<string>();



            int _totalSaved = 0;



            // get all the recrno
            for (int x = 0; x < grdCandidate.Rows.Count; x++)
            {
                if (grdCandidate.Rows[x].Cells[0].Value.ToString() != null && grdCandidate.Rows[x].Cells[0].Value.ToString().Trim() != string.Empty)
                {
                    if (Convert.ToBoolean(grdCandidate.Rows[x].Cells[4].Value) == true) lstRecrno.Add(grdCandidate.Rows[x].Cells[0].Value.ToString().Trim());
                }

            }

            if (lstRecrno.Count > 0)
            {
                sqlInsertwhere = " where recrno = '" + lstRecrno[0] + "'";
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
                MessageBox.Show("Select not made", "RnS Notification");
                return;
            }

            // save the records
            datamethods2 dthm = new datamethods2();
            DataTable dt = new DataTable();
            string sqlQueury = "Select distinct * from database1 ";
            sqlQueury += sqlInsertwhere;

            MessageBox.Show(sqlQueury);

            dt = dthm._dataTable_NoParameter(sqlQueury);
            if (dthm.sqlUserError == string.Empty)
            {
                if (dt.Rows.Count > 0)
                {
                    _totalSaved = 0;

                    for (int x = 0; x < dt.Rows.Count; x++)
                    {

                        // insert into database 2                    
                        string sqlInsert = string.Empty;
                        sqlInsert = @" Insert into database2 "
                            + "(recrno,surname,firstname,middlename,initials,address, "
                            + " title,sex,age,phone,email,lgacode,lgadescr,birthdate,gradecode,gradedescr,screened,aptest,active,"
                            + " qualdescr,qualcode,manager,testsult,modifiedby,"
                            + " inview,documented,medical,interviewed,shl,induction)"
                            + " values ('" + dt.Rows[x]["recrno"].ToString() + "',"
                            + "'" + dt.Rows[x]["surname"].ToString() + "',"
                            + "'" + dt.Rows[x]["firstname"].ToString() + "',"
                            + "'" + dt.Rows[x]["middlename"].ToString() + "',"
                            + "'" + dt.Rows[x]["initials"].ToString() + "',"
                            + "'" + dt.Rows[x]["address"].ToString() + "',"
                            + "'" + dt.Rows[x]["title"].ToString() + "',"
                            + "'" + dt.Rows[x]["sex"].ToString() + "',"
                            + "'" + (DateTime.Now.Year - Convert.ToDateTime(dt.Rows[x]["birthdate"]).Year).ToString() + "',"
                            + "'" + dt.Rows[x]["phone"].ToString() + "',"
                            + "'" + dt.Rows[x]["email"].ToString() + "',"
                            + "'" + dt.Rows[x]["lgacode"].ToString() + "',"
                            + "'" + dt.Rows[x]["lgadescr"].ToString() + "',"
                            + "'" + dt.Rows[x]["birthdate"].ToString() + "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + Program.pbUserName.Trim()+ "',"
                            + "'" + " " + "',"
                            + "'" + " " + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + false + "',"
                            + "'" + false 
                            + ")";

                        MessageBox.Show(sqlInsert);
                        dthm._update_Insert_NoParameter(sqlInsert);

                        if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError, "RnS Notification");
                        else
                        {

                            string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + x.ToString();

                            // insert into candidtaerequest 2                    
                            sqlInsert = string.Empty;

                            //sqlInsert = @" Insert into candidatecallup "
                            //    + "(recrno,reqid,position,requestid,clientid,datesent, "
                            //    + " interview,ippased,employed,remarks)"
                            //    + " values ('" + dt.Rows[x]["recrno"].ToString() + "',"
                            //    + "'" + strTime + "',"
                            //    + "'" + lblposition.Text + "',"
                            //    + "'" + txtrequestid.Text + "',"
                            //    + "'" + txtclientid.Text + "',"
                            //    + "'" + "01/01/1900" + "',"
                            //    + "'" + false + "',"
                            //    + "'" + false + "',"
                            //    + "'" + false + "',"
                            //    + "'" + " " + "'"
                            //    + ")";

                            sqlInsert = @" Insert into candidatecallup "
                               + "(recrno,reqid,posdescr,requestid,clientid, position,,reqdescr)"
                               + " values ('" + dt.Rows[x]["recrno"].ToString() + "',"
                               + "'" + strTime + "',"
                               + "'" + lblposition.Text + "',"
                               + "'" + txtrequestid.Text + "',"
                               + "'" + txtclientid.Text + "',"
                               + "'" + prv_Poscode.Trim() + "'"
                               + "'" + lblrequestdescr.Text.Trim() + "'"
                               + ")";
                            dthm._update_Insert_NoParameter(sqlInsert);


                            // update into database1                    
                            sqlInsert = string.Empty;
                            sqlInsert = @" update database1 set active = 'true' where recrno = '" + dt.Rows[x]["recrno"].ToString() + "'";

                            dthm._update_Insert_NoParameter(sqlInsert);

                            _totalSaved += 1;


                            try
                            {
                                grdCandidate.Rows[x].Cells[8].Value = true;
                            }
                            catch
                            {
                            }


                        }
                    }
                }
                else MessageBox.Show("There are no records to processed", "RnS Notification");
            }

            else MessageBox.Show(dthm.sqlUserError, "RnS Notification");


            if (_totalSaved > 0) MessageBox.Show(_totalSaved.ToString() + " records was committed Successfully", "RnS Notification");

        }
        private void saveRecords_database2()
        {
            string strRecrno = String.Empty;

            string sqlInsertwhere = string.Empty;
            List<string> lstRecrno = new List<string>();



            int _totalSaved = 0;

            datamethods2 dthm = new datamethods2();

            // get all the recrno
            for (int x = 0; x < grdCandidate.Rows.Count; x++)
            {
                try
                {
                    if (Convert.ToBoolean(grdCandidate.Rows[x].Cells[7].Value)== true  && grdCandidate.Rows[x].Cells[0].Value.ToString().Trim() != string.Empty)
                    {
                        string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + x.ToString();


                        MessageBox.Show(DateTime.Now.Date.ToString("yyyy/MM/dd"));

                        // insert into candidtaerequest 2                    
                        string sqlInsert = string.Empty;
                        sqlInsert = @" Insert into candidatecallup "
                            + "(recrno,reqid,posdescr,request,clientid,position,reqdescr,dcallup)"
                            + " values ('" + grdCandidate.Rows[x].Cells[0].Value.ToString() + "',"
                            + "'" + strTime + "',"
                            + "'" + lblposition.Text + "',"
                            + "'" + txtrequestid.Text + "',"
                            + "'" + txtclientid.Text + "',"
                            + "'" + prv_Poscode.Trim() + "',"
                            + "'" + lblrequestdescr.Text.Trim() + "',"
                            + "'" + DateTime.Now.Date.ToString("yyyy/MM/dd") + "'"
                            + ")";

                        dthm._update_Insert_NoParameter(sqlInsert);

                        if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError, "RnS Notification");
                        else
                        {

                            _totalSaved += 1;


                        }

                        // update the status of the grid 
                        try
                        {
                            grdCandidate.Rows[x].Cells[8].Value = true;
                        }
                        catch
                        {
                        }

                        
                    }
                }
                catch
                {
                }

            }
            if (_totalSaved > 0) MessageBox.Show(_totalSaved.ToString() + " records was committed Successfully", "RnS Notification");
     
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            btnquery.FlatStyle = FlatStyle.Standard;
            lblquery.ForeColor = System.Drawing.Color.DarkBlue; ;
            lblquery.BorderStyle = BorderStyle.None;
            lblquery.Font = new Font(lblquery.Font.FontFamily.Name, 8);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            btnquery.FlatStyle = FlatStyle.Popup;
            lblquery.ForeColor = System.Drawing.Color.DarkRed;
            lblquery.BorderStyle = BorderStyle.FixedSingle;
            lblquery.Font = new Font(lblquery.Font.FontFamily.Name, 9);

        }

        private void raddatabase1_Click(object sender, EventArgs e)
        {
           
            clearScreen();
           
        }

        private void raddatabase2_Click(object sender, EventArgs e)
        {
          
            clearScreen();

        }

        private void raddatabase2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_location);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Code";
            frmSch.strHeader2 = "Description";
            frmSch.strHeader3 = " ";
            frmSch.useRIMSConnString = true;
            string strQuery = string.Empty;
            strQuery = "select code as Code, desc1  as Description from codestab where option1 = 'LOCAT'";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_location(object sender, FormClosedEventArgs e)
        {


            txtlocation.Text = Program._searchedValue2.Trim();
            prv_location = Program._searchedValue.Trim();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_qualification);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Code";
            frmSch.strHeader2 = "Description";
            frmSch.strHeader3 = " ";
            frmSch.useRIMSConnString = true;
            string strQuery = string.Empty;
            strQuery = "select code as Code, desc1  as Description from codestab where option1 = 'QUALIF'";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_qualification(object sender, FormClosedEventArgs e)
        {


            txtqualification.Text = Program._searchedValue2.Trim();
            prv_qual = Program._searchedValue.Trim();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_grade);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Code";
            frmSch.strHeader2 = "Description";
            frmSch.strHeader3 = " ";
            frmSch.useRIMSConnString = true;
            string strQuery = string.Empty;
            strQuery = "select code as Code, desc1  as Description from codestab where option1 = 'P51'";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_grade(object sender, FormClosedEventArgs e)
        {


            txtgrade.Text = Program._searchedValue2.Trim();
            prv_grade = Program._searchedValue.Trim();

        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (txtclientid.Text == string.Empty || txtrequestid.Text == string.Empty)
            {
                MessageBox.Show("Both Client and Request must be specified", "RnS Notification");
                return;
            }
            
            
            //if (dt_shortlisted.Rows.Count == 0)
            //{
            //    MessageBox.Show("Shortlisted Records is empty", "RnS Notification");
            //    return;
            //}

            DialogResult dialogResult = MessageBox.Show("Continue with reporting", "RnS Notification", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                

            

                try
                {

                    
                    String sqlSelect = @"select distinct a.*,b.posdescr, b.clientid from database2 a, candidatecallup b 
                         where a.recrno = b.recrno "
                       + " and b.dcallup = " + "'" + DateTime.Now.Date.ToString("yyy/MM/dd") + "'"
                       + " and b.clientid = " + "'" + txtclientid.Text + "'"
                       + " and b.request = " + "'" + txtrequestid.Text + "'"
                       + " and position = " + "'" + prv_Poscode + "'";


                    DataTable dt = new DataTable();
                    dt = dmth._dataTable_NoParameter(sqlSelect, ConfigurationManager.ConnectionStrings["rnsConString"].ConnectionString);

                    if (dmth.sqlUserError.Trim() == string.Empty)
                    {
                      

                        if (dt.Rows.Count > 0)
                        {
                            rpt_form_candidateselection rptcansel = new rpt_form_candidateselection();
                            rptcansel.bindSource_selection(dt);
                            rptcansel.ShowDialog();
                        }
                        else MessageBox.Show("Records for last shorlisted records not found!", "RnS Notification");

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
                    MessageBox.Show("Error occured, pls, try again(2)!","RnS Notification");
                }
            }
        }

      


       
    }
}
