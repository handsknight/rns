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
using System.Configuration;
namespace rns
{
#pragma warning disable

    public partial class frmdatabase2 : Form
    {
        private Boolean newRecords = true;
        private int _newAddedRowIndex = 0;
        private Boolean _coladded = false;
        private int _doubleClickSelRowIndex;
        private int _doubleClickSelColIndex;
        private string prv_location = string.Empty;
        private string prv_grade = string.Empty;
        private string prv_qual = string.Empty;
        private string prv_posit = string.Empty;
        private string prv_client = string.Empty;
        private string prv_intlocation = string.Empty;
        private string prv_requestcode = string.Empty;
        private DataTable dt_callup = new DataTable();
        private string mydateformat =string.Empty;
        private string strReqId = string.Empty;


        public frmdatabase2()
        {
            InitializeComponent();
        }

        private void frmdatabase2_Load(object sender, EventArgs e)
        {
            clearScreen();
            _createColumns();
        }

        private void txtid_Leave(object sender, EventArgs e)
        {
            populateScreen();
            populateGrid();

        }
        private void populateScreen()
        {
            
            
            string strid = txtid.Text;
            clearScreen();
            txtid.Text = strid;
             

            string queryString = string.Empty;

            queryString = "select distinct * from database2 where recrno = " + "'" + strid + "'";
            datamethods2 dthm = new datamethods2();
            SqlDataReader drRecords = dthm._dataReader_NoParameter(queryString);
            drRecords.Read();
            if (drRecords.HasRows)
            {
                
                newRecords = false;


                txtsurname.Text = drRecords["surname"].ToString();
                txtfirstname.Text = drRecords["firstname"].ToString();
                txtmiddlename.Text = drRecords["middlename"].ToString();
         
                chkaptested.Checked = Convert.ToBoolean(drRecords["aptest"]);

                chkdocumented.Checked = Convert.ToBoolean(drRecords["documented"]);
                chkactive.Checked = Convert.ToBoolean(drRecords["active"]);
                chkmedical.Checked = Convert.ToBoolean(drRecords["medical"]);

                txtinitials.Text = drRecords["initials"].ToString();
                cmbtitle.Text = drRecords["title"].ToString();
                txtaddress.Text = drRecords["address"].ToString();
                cmbgender.Text = drRecords["sex"].ToString();
                dtpdob.Value = Convert.ToDateTime(drRecords["birthdate"]);
                
                // -- calacualte the age
                DateTime dtime = Convert.ToDateTime(drRecords["birthdate"]);
                Int32 int_year = dtime.Year;
                Int32 int_month = dtime.Month;
                Int32 int_Day = dtime.Day;
                Int32 int_yearDiff =  DateTime.Now.Date.Year-dtime.Year;

                
                if (int_yearDiff > 0)
                {
                    if (DateTime.Now.Date.Month >= int_month)
                    {
                       
                        if(DateTime.Now.Day >= int_Day )
                        {
                            
                            mskage.Text = (int_yearDiff).ToString();
                        }
                        else mskage.Text = (int_yearDiff-1).ToString();
                    }
                    else mskage.Text = (int_yearDiff - 1).ToString();
                }
                else mskage.Text ="0";

                
                // ------------------ 
                
                
               
                txtemail.Text = drRecords["email"].ToString();
                mskphone.Text = drRecords["phone"].ToString();

                txtlocation.Text = drRecords["lgadescr"].ToString();
                prv_location = drRecords["lgacode"].ToString();

                txtqualification.Text = drRecords["qualdescr"].ToString();
                prv_qual = drRecords["qualcode"].ToString();

                txtgrade.Text = drRecords["gradedescr"].ToString();
                prv_grade = drRecords["gradecode"].ToString();


                chkicslinterview.Checked = Convert.ToBoolean(drRecords["interviewed"]);
                cmdtinterviewresult.Text = drRecords["intersult"].ToString();
                cmbtestresult.Text = drRecords["testsult"].ToString();
                cmbmedicalresult.Text = drRecords["medsult"].ToString();
                txtmedissue.Text = drRecords["medissue"].ToString();
                chkessay.Checked = Convert.ToBoolean(drRecords["essay"]);
                cmbessayresult.Text = drRecords["essaysult"].ToString();
                chkshl.Checked = Convert.ToBoolean(drRecords["shl"]);
                chkinduction.Checked = Convert.ToBoolean(drRecords["induction"]);
                cmbinductionresult.Text = drRecords["inductsult"].ToString();
                txtmanager.Text = drRecords["manager"].ToString();
                mskrecordmanagerdate.Text = drRecords["entrydate"].ToString();
                mskmodifieddate.Text = drRecords["modifydate"].ToString();
                txtmodifiedby.Text = drRecords["modifiedby"].ToString();

                if (chkactive.Checked == true) chkactive.Enabled = false;
                drRecords.Dispose();
                //populateCandidateCallups();
               
            }
            else
            {
                drRecords.Close();
                drRecords.Dispose();


                queryString = "select distinct * from database1 where recrno = " + "'" + strid + "'";
                drRecords = dthm._dataReader_NoParameter(queryString);
                drRecords.Read();
                if (drRecords.HasRows)
                {
                    newRecords = true;
                    txtsurname.Text = drRecords["surname"].ToString();
                    txtfirstname.Text = drRecords["firstname"].ToString();
                    txtmiddlename.Text = drRecords["middlename"].ToString();
                    
                    chkaptested.Checked = Convert.ToBoolean(drRecords["aptest"]);

                    txtinitials.Text = drRecords["initials"].ToString();
                    cmbtitle.Text = drRecords["title"].ToString();
                    txtaddress.Text = drRecords["address"].ToString();
                    cmbgender.Text = drRecords["sex"].ToString();
                    dtpdob.Text = drRecords["birthdate"].ToString();
                    mskage.Text = drRecords["age"].ToString();
                    txtemail.Text = drRecords["email"].ToString();
                    mskphone.Text = drRecords["phone"].ToString();

                    cmbtestresult.Text = drRecords["testresult"].ToString();

                    txtlocation.Text = drRecords["lgadescr"].ToString();
                    prv_location = drRecords["lgacode"].ToString();

                    txtqualification.Text = drRecords["qualdescr"].ToString();
                    prv_qual = drRecords["qualcode"].ToString();

                    txtgrade.Text = drRecords["gradedescr"].ToString();
                    prv_grade = drRecords["gradecode"].ToString();

                }
                drRecords.Dispose();
            }

            
           
            txtid.Enabled = false;
            populateGrid();
        }

        
        private void clearScreen()
        {

            strReqId = string.Empty;


            newRecords = true;
            _coladded = false;

            string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            txtid.Text = "ICSL/RNS/" + strTime.Trim();
           
            txtsurname.Text = "";
            txtfirstname.Text = "";
            txtmiddlename.Text = "";
            txtinitials.Text = "";

            chkaptested.Checked = false;

            chkcinduction.Checked = false;
            chkdocumented.Checked = false;
            chkactive.Checked = false;
            chkmedical.Checked = false;
            cmbtitle.SelectedIndex = 0;
            txtaddress.Text = "";
            cmbgender.SelectedIndex = 0;
            dtpdob.Text = "01/01/1900";
            mskage.Text = "";
            txtemail.Text = "";
            mskphone.Text = "";
            txtlocation.Text = "";
            txtqualification.Text = "";
            txtgrade.Text = "";
            newRecords = true;
            chkicslinterview.Checked = false;
            chkactive.Enabled = true;
            
            dgvcallups.Rows.Clear();
            //_createColumns();

            chkicslinterview.Checked = false;
            chkdocumented.Checked = false;

            chkmedical.Checked = false;

            chkessay.Checked = false;
            chkshl.Checked = false;
            chkinduction.Checked = false;

          
            cmbemploymenttype.SelectedIndex = 0;
            cmbtestresult.SelectedIndex = 0;
            cmdtinterviewresult.SelectedIndex = 0;
            cmbgender.SelectedIndex = 0;
 
            cmbmedicalresult.SelectedIndex = 0;
            cmbessayresult.SelectedIndex = 0;
            cmbinductionresult.SelectedIndex = 0;
            txtmanager.Text = "";
           

            dtpclientinterviewdate.Text = "";
            chkclientinterview.Checked = false;
            cmbintassessment.SelectedIndex = 0;
            txtposition.Text = "";
            txtclient.Text = "";
            txtremarks.Text = "";

            interiewlocation.Text = "";

            prv_location = string.Empty;
            prv_grade = string.Empty;
            prv_qual = string.Empty;
            prv_posit = string.Empty;
            prv_client = string.Empty;
            prv_intlocation = string.Empty;
            prv_requestcode = string.Empty;

            dtpresumptiondate.Text = "01/01/1900";
            dtpclientinterviewdate.Text = "01/01/1900";

            txtrequest.Text = "";
            txtmanager.Text = Program.pbUserName;
            txtmodifiedby.Text = "";

            mskmodifieddate.Text = "";
            mskrecordmanagerdate.Text = DateTime.Now.ToString();
            txtsurname.Focus();

    
        
        }

        private void saveRecords()
        {


            if (txtid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID can't be empty!", "Missing ID");
                return;
            }
            if (txtsurname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Username can't be empty!", "Missing Username");
                return;
            }
            if (txtfirstname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Username can't be empty!", "Missing Username");
                return;
            }


            if (txtclient.Text.Trim() != string.Empty)
            {
                if (txtrequest.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Specify the client request!", "Missing request");
                    return;
                }

            }

           

            if (txtclient.Text.Trim() != string.Empty && txtrequest.Text.Trim() != string.Empty)
            {
                // if position is not selected
                if (txtposition.Text == String.Empty)
                {
                    MessageBox.Show("Specified Position", "RnS Notification");
                    return;
                }
                
                // checked employment infos
                if (chkclientinterview.Checked == true)
                {
                    // if emplyment type si not selected
                    if (cmbemploymenttype.SelectedIndex == 0)
                    {
                        MessageBox.Show("Specified Employment Type", "RnS Notification");
                        return;
                    }

                    // if position is not selected
                    if (txtposition.Text  == String.Empty)
                    {
                        MessageBox.Show("Specified Position", "RnS Notification");
                        return;
                    }

                    // if int location is not selected
                    if (interiewlocation.Text == String.Empty)
                    {
                        MessageBox.Show("Specified Interview Location", "RnS Notification");
                        return;
                    }

                    // if int location is not selected
                    if (cmbintassessment.SelectedIndex==0)
                    {
                        MessageBox.Show("Specified Interview Assessment", "RnS Notification");
                        return;
                    }

                   
                }
                
              
              
                   // if int location is not selected
                if (chkcinduction.Checked==true && cmbcindsult.SelectedIndex == 0 )
                {
                    
                        MessageBox.Show("Specified Induction Result", "RnS Notification");
                        return;
               

                }

            }




          

             string strentrydate = string.Empty;
             if (mskrecordmanagerdate.MaskFull == false) strentrydate = "'" + DateTime.Now.ToString("yyyy/MM/dd") + "'";
             else strentrydate = "'" + Convert.ToDateTime(mskrecordmanagerdate.Text).ToString("yyyy/MM/dd") + "'";


            string strid = "'" + txtid.Text.Trim() + "'";
            string strsurname = "'" + txtsurname.Text + "'";
            string strfirstname = "'" + txtfirstname.Text + "'";
            string strtxtmiddlename = "'" + txtmiddlename.Text + "'";
            string strinitials = "'" + txtinitials.Text + "'";
            string strtitle = "'" + cmbtitle.Text + "'";
            string straddress = "'" + txtaddress.Text + "'";
            string strgender = "'" + cmbgender.Text + "'";
            string strdob = "'" + dtpdob.Value.ToString("yyyy/MM/dd") + "'";
            string strage = "'" + mskage.Text + "'";
            string stremail = "'" + txtemail.Text + "'";
            string strphone = "'" + mskphone.Text + "'";
            string strlocation = "'" + txtlocation.Text + "'";
            string strqualification = "'" + txtqualification.Text + "'";
            string strgrade = "'" + txtgrade.Text + "'";
            string straptested = "'" + chkaptested.Checked + "'";

            string stremployed = "'" + chkcinduction.Checked + "'";
            string strdocumented = "'" + chkdocumented.Checked + "'";
            string stractive = "'" + chkactive.Checked + "'";
            string strmedical = "'" + chkmedical.Checked + "'";
            string stricslinterviewd = "'" + chkicslinterview.Checked + "'";


           

            string strdtpclientinterviewdate = dtpclientinterviewdate.Text;
            string strmskresumptiondate = dtpresumptiondate.Text;

            string strRequestdescr = "'" + txtrequest.Text + "'";
            string strModifiedBy = "'" + Program.pbUserName + "'";
            //


           
           

            // save new  records
            if (newRecords == true)
            {
                strModifiedBy = "'" + string.Empty + "'"; 

                datamethods2 dthm = new datamethods2();
                string sqlInsert = string.Empty;
                sqlInsert = @" insert into database2 (recrno,surname,firstname,middlename,initials,address, 
                title,sex,birthdate,age,phone,email,lgadescr,qualdescr,gradedescr,aptest,
                documented,active,interviewed, medical,
                intersult,
                medsult,
                medissue,
                essay,
                essaysult,
                induction,
                inductsult,
                shl,
                manager,
                lgacode,
                gradecode,
                qualcode,
                testsult,
                entrydate,
                modifydate,
                modifiedby
                )  values ("
                 + strid + "," + strsurname + "," + strfirstname + "," + strtxtmiddlename + ","
                 + strinitials + "," + straddress + "," + strtitle + "," + strgender + ","
                 + strdob + "," + strage + "," + strphone + "," + stremail + "," + strlocation + "," + strqualification
                 + "," + strgrade + "," + straptested + "," + strdocumented + "," + stractive + ","
                 + stricslinterviewd + "," + strmedical + ","
                 + "'" + cmdtinterviewresult.SelectedItem.ToString().Trim() + "'" + ","
                 + "'" + cmbmedicalresult.SelectedItem.ToString().Trim() + "'" + ","
                 + "'" + txtmedissue.Text.Trim() + "'" + ","
                 + "'" + chkessay.Checked + "'" + ","
                 + "'" + cmbessayresult.SelectedItem.ToString().Trim() + "'" + ","
                 + "'" + chkinduction.Checked + "'" + ","
                 + "'" + cmbinductionresult.SelectedItem.ToString().Trim() + "'" + ","
                 + "'" + chkshl.Checked + "'" + ","
                 + "'" + txtmanager.Text.Trim() + "'" + ","
                 + "'" + prv_location + "'" + ","
                 + "'" + prv_grade + "'" + ","
                 + "'" + prv_qual + "'" + ","
                 + "'" + cmbtestresult.SelectedItem.ToString().Trim() + "'" + ","
                 + strentrydate + ","
                 + "'" + "" + "'" + ","
                 + strModifiedBy 
                 + ")";



               int returnVal = dthm._update_Insert_NoParameter(sqlInsert);

                if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
                else
                {
                    saveToClientRequest();
                    MessageBox.Show("Records Saved.", "RnS Notification");
                    clearScreen();
                }

            }
            else // do update
            {
                

                datamethods2 dthm = new datamethods2();
                string sqlInsert = string.Empty;
                sqlInsert = @" update database2 set  surname = " + strsurname + "," + " firstname= "
                 + strfirstname + ",  middlename = " + strtxtmiddlename + ", initials = "
                 + strinitials + "," + " address = " + straddress + ","
                 + " title = " + strtitle + "," + " sex= " + strgender + ","
                 + " birthdate= " + strdob + ","
                 + " age= " + strage + "," + " phone= " + strphone + ","
                 + " email= " + stremail + "," + " lgadescr= " + strlocation + "," + " qualdescr= " + strqualification + ","
                 + " gradedescr= " + strgrade + "," + " aptest= " + straptested + ","
                 + " documented= " + strdocumented + "," + " active= " + stractive + "," + " medical= " + strmedical
                 + "," + " interviewed = " + stricslinterviewd 
                 + "," + "intersult= " + "'" + cmdtinterviewresult.SelectedItem.ToString().Trim() + "'" 
                 + "," + "medsult= " + "'" + cmbmedicalresult.SelectedItem.ToString().Trim() + "'" 
                 + "," + "medissue= " + "'" + txtmedissue.Text.Trim() + "'" 
                 + "," + "essay= " + "'" + chkessay.Checked + "'" 
                 + "," + "essaysult= " + "'" + cmbessayresult.SelectedItem.ToString().Trim() + "'" 
                 + "," + "induction= " + "'" + chkinduction.Checked + "'"  
                 + "," + "inductsult= " + "'" + cmbinductionresult.SelectedItem.ToString().Trim() + "'"  
                 + "," + "shl= " + "'" + chkshl.Checked + "'"  
                 + "," + "manager= " + "'" + txtmanager.Text.Trim() + "'"  
                 + "," + "lgacode= " +  "'" + prv_location.Trim() + "'"  
                 + "," + "gradecode= " + "'" + prv_grade.Trim() + "'" 
                 + "," + "qualcode= " + "'" + prv_qual.Trim() + "'" 
                 + "," + "testsult= " + "'" + cmbtestresult.SelectedItem.ToString().Trim() + "'" 
                 + "," + "entrydate= " + strentrydate 
                 + "," + "modifydate= " + "'" + DateTime.Now.ToString("yyyy/MM/dd") + "'"
                 + "," + "modifiedby= " + "'" + Program.pbUserName + "'" 
                 + "  where recrno = " + strid;

                int returnVal = dthm._update_Insert_NoParameter(sqlInsert);

                if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
                else
                {
                 
                    saveToClientRequest();
                 
                    updateDatabase1_active();
                    
                    MessageBox.Show("Done.", "RnS Notification");
                    clearScreen();
                }
            }
         
            

        }

        private void saveToClientRequest()
        {

            if (txtclient.Text.Trim() == string.Empty || txtrequest.Text.Trim() == string.Empty) 
            {
                return;
            }


          

            string strid = "'" + txtid.Text.Trim() + "'";

            string strdocumented = "'" + chkdocumented.Checked + "'";
            string stricslinterviewd = "'" + chkicslinterview.Checked + "'";
            string strdtpclientinterviewdate = "'" +  dtpclientinterviewdate.Value.ToString("yyyy/MM/dd") + "'";

                       
            string strmskresumptiondate = "'" + dtpresumptiondate.Value.ToString("yyyy/MM/dd") + "'";

            string strRequestdescr = "'" + txtrequest.Text + "'";
            

            string queryString = @"select distinct * from candidatecallup where recrno = " +  strid 
              +   " and clientid = '"+  txtclient.Text.Trim() + "'"
              + " and request = '" + prv_requestcode.Trim() + "'"
              + " and position = '" + prv_posit.Trim() +"'"
              + " and reqid = '" + strReqId.Trim() + "'";


            datamethods2 dthm = new datamethods2();
            SqlDataReader drRecords = dthm._dataReader_NoParameter(queryString);


            drRecords.Read();
            if (!drRecords.HasRows)
            {
                drRecords.Close();
                drRecords.Dispose();
                
                    

                string sqlInsert = string.Empty;
                sqlInsert = @" insert into candidatecallup (
                reqid,
                recrno, 
                emptype,
                intlocdesr,
                intloccode,
                clientid,
                position,
                posdescr,
                cinterview,
                cintersult,
                remarks,
                intervdate,
                rdate,
                request,
                reqdescr,
                cinduction,
                cindsult) "
                + " values ("
                 + "'" + strReqId + "'" + ","
                 + strid + ","
                 + "'" + cmbemploymenttype.Text.Trim() + "'" + ","
                 + "'" + interiewlocation.Text + "'" + ","
                 + "'" + prv_intlocation + "'" + ","
                 + "'" + txtclient.Text + "'" + ","
                 + "'" + prv_posit + "'" + ","
                 + "'" + txtposition.Text + "'" + ","
                 + "'" + chkclientinterview.Checked + "'" + ","
                 + "'" + cmbintassessment.Text.Trim() + "'" + ","
                 + "'" + txtremarks.Text + "'" + ","
                 + strdtpclientinterviewdate + ","
                 + strmskresumptiondate + ","
                 + "'" + prv_requestcode + "'" + ","
                 + strRequestdescr + ","
                 + "'" + chkcinduction.Checked + "'" + ","
                 + "'" + cmbcindsult.Text.Trim() + "'" + ")" ;


               
                int returnVal = dthm._update_Insert_NoParameter(sqlInsert);


                if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
                
            }
            else // do update
            {

  

                drRecords.Close();
                drRecords.Dispose();

                string sqlUpdate = string.Empty;
                sqlUpdate = @" update candidatecallup set "
                 + "emptype= " + "'" + cmbemploymenttype.Text.Trim() + "'"
                 + "," + "intlocdesr= " + "'" + interiewlocation.Text + "'"
                 + "," + "intloccode= " + "'" + prv_intlocation + "'"
                 + "," + "clientid= " + "'" + txtclient.Text + "'"
                 + "," + "position= " + "'" + prv_posit + "'"
                 + "," + "posdescr= " + "'" + txtposition.Text + "'"
                 + "," + "cinterview= " + "'" + chkclientinterview.Checked + "'"
                 + "," + "cintersult= " + "'" + cmbintassessment.Text.Trim() + "'"
                 + "," + "remarks= " + "'" + txtremarks.Text + "'"
                 + "," + "intervdate= " + strdtpclientinterviewdate
                 + "," + "request= " + "'" + prv_requestcode + "'"
                 + "," + "reqdescr = " + "'" + txtrequest.Text + "'"
                 + "," + "rdate= " + strmskresumptiondate
                 + "," + "cinduction= " + "'" + chkcinduction.Checked + "'"
                 + "," + "cindsult= " + "'" + cmbcindsult.Text.Trim() + "'"
                 + "  where recrno = " + strid
                 + " and reqid = '" + strReqId + "'" ;

                //MessageBox.Show(Convert.ToDateTime(strmskdatesentout).ToString("yyyy/MM/dd"));

                int returnVal = dthm._update_Insert_NoParameter(sqlUpdate);

                if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
               
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveRecords();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program._searchedValue = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_FormClosed);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Id";
            frmSch.strHeader2 = "Surname";
            frmSch.strHeader3 = "Middlename";
            string strQuery = string.Empty;
            strQuery = "select recrno as Id, surname  as Surname, (firstname + middlename) as Middlename from database2";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtid.Text = Program._searchedValue;
            if (txtid.Text != string.Empty) populateScreen();

        }

        private void _createColumns()
        {

            dgvcallups.Columns.Clear();



            DataGridViewTextBoxColumn posdescr = new DataGridViewTextBoxColumn();
            posdescr.HeaderText = "Position";
            posdescr.Name = "posdescr";
            posdescr.ToolTipText = "Position";
            posdescr.DefaultCellStyle.NullValue = " ";
            posdescr.ReadOnly = true;
            dgvcallups.Columns.Add(posdescr);


            DataGridViewTextBoxColumn clientid = new DataGridViewTextBoxColumn();
            clientid.HeaderText = "Client";
            clientid.Name = "clientid";
            clientid.ToolTipText = "Client";
            clientid.DefaultCellStyle.NullValue = " ";
            clientid.ReadOnly = true;
            dgvcallups.Columns.Add(clientid);

            DataGridViewTextBoxColumn reqdescr = new DataGridViewTextBoxColumn();
            reqdescr.HeaderText = "Request";
            reqdescr.Name = "reqdescr";
            reqdescr.ToolTipText = "Request";
            reqdescr.DefaultCellStyle.NullValue = " ";
            reqdescr.ReadOnly = true;
            dgvcallups.Columns.Add(reqdescr);


            DataGridViewCheckBoxColumn cinterview = new DataGridViewCheckBoxColumn();
            cinterview.HeaderText = "Interviewed";
            cinterview.Name = "cinterview";
            cinterview.ToolTipText = "interviewed";
            cinterview.DefaultCellStyle.NullValue = false;
            cinterview.ReadOnly = true;
            dgvcallups.Columns.Add(cinterview);

            DataGridViewTextBoxColumn cintersult = new DataGridViewTextBoxColumn();
            cintersult.HeaderText = "Interview Result";
            cintersult.Name = "cintersult";
            cintersult.ToolTipText = "Interview Result";
            cintersult.DefaultCellStyle.NullValue = "";
            cintersult.ReadOnly = true;
            dgvcallups.Columns.Add(cintersult);

           
            DataGridViewTextBoxColumn emptype = new DataGridViewTextBoxColumn();
            emptype.HeaderText = "Emploment Type";
            emptype.Name = "emptype";
            emptype.ToolTipText = "Emploment Type";
            emptype.DefaultCellStyle.NullValue = "";
            emptype.ReadOnly = true;
            dgvcallups.Columns.Add(emptype);

            DataGridViewTextBoxColumn request = new DataGridViewTextBoxColumn();
            request.HeaderText = "requestid";
            request.Name = "request";
            request.ToolTipText = "requestid";
            request.DefaultCellStyle.NullValue = "";
            request.Visible = false;
            dgvcallups.Columns.Add(request);

            DataGridViewTextBoxColumn position = new DataGridViewTextBoxColumn();
            position.HeaderText = "position";
            position.Name = "position";
            position.ToolTipText = "position";
            position.DefaultCellStyle.NullValue = "";
            position.Visible = false;
            dgvcallups.Columns.Add(position);

            DataGridViewTextBoxColumn col_reqid = new DataGridViewTextBoxColumn();
            col_reqid.HeaderText = "reqid";
            col_reqid.Name = "reqid";
            col_reqid.ToolTipText = "reqid";
            col_reqid.DefaultCellStyle.NullValue = "";
            col_reqid.Visible = false;
            dgvcallups.Columns.Add(col_reqid);
          
        }

        private void populateGrid()
        {
            string strid = "'" + txtid.Text + "'";


            String sqlSelect = @"select * from candidatecallup where recrno = " + strid;
           
            //DataTable dt = new DataTable();
            datamethods2 dtmth = new datamethods2();
            dt_callup.Rows.Clear();
            dt_callup = dtmth._dataTable_NoParameter(sqlSelect);

            if (dtmth.sqlUserError == string.Empty)
            {
                if (dt_callup.Rows.Count > 0)
                {

                    _addColumns(dt_callup);

                }
            }
            else
            {
                MessageBox.Show(dtmth.sqlUserError, "RnS Notification");
            }
         
        }

        private void _addColumns(DataTable dt)
        {
            dgvcallups.Rows.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {

                int n = dgvcallups.Rows.Add();
                dgvcallups.Rows[n].Cells[0].Value = dt.Rows[x]["posdescr"].ToString();
                dgvcallups.Rows[n].Cells[1].Value = dt.Rows[x]["clientid"].ToString();
                dgvcallups.Rows[n].Cells[2].Value = dt.Rows[x]["reqdescr"].ToString();
                dgvcallups.Rows[n].Cells[3].Value = dt.Rows[x]["cinterview"].ToString();
                dgvcallups.Rows[n].Cells[4].Value = dt.Rows[x]["cintersult"].ToString();
                dgvcallups.Rows[n].Cells[5].Value = dt.Rows[x]["emptype"].ToString();
                dgvcallups.Rows[n].Cells[6].Value = dt.Rows[x]["request"].ToString();
                dgvcallups.Rows[n].Cells[7].Value = dt.Rows[x]["position"].ToString();
                dgvcallups.Rows[n].Cells[8].Value = dt.Rows[x]["reqid"].ToString();
               
            }

        }

        private void dgvcallups_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {


            //if (e.Column.Index == 9)
            //{
            //    _coladded = true;

            //    dgvcallups.Rows[_newAddedRowIndex].Cells[1].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[2].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[3].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[4].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[5].Value = false;
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[6].Value = false;
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[7].Value = false;
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[8].Value = "";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[9].Value = true;

            //    dgvcallups.RefreshEdit();
            //    dgvcallups.Refresh();


            //}
        }

        private void dgvcallups_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            //dgvcallups.Rows[e.RowIndex].Cells[0].Value = strTime;
            //_newAddedRowIndex = e.RowIndex;

            //if (_coladded == true)
            //{

            //    dgvcallups.Rows[_newAddedRowIndex].Cells[1].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[2].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[3].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[4].Value = " ";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[5].Value = false;
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[6].Value = false;
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[7].Value = false;
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[8].Value = "";
            //    dgvcallups.Rows[_newAddedRowIndex].Cells[9].Value = true;

            //    dgvcallups.RefreshEdit();
            //    dgvcallups.Refresh();

            //}
        }

        private void dgvcallups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void open_grid_forSearch(object sender, FormClosedEventArgs e)
        {
            // MessageBox.Show(Program._searchedValue);
            dgvcallups.BeginEdit(true);

            dgvcallups.Rows[_doubleClickSelRowIndex].Cells[_doubleClickSelColIndex].Value = Program._searchedValue2.Trim();
            dgvcallups.RefreshEdit();
            dgvcallups.Refresh();
            dgvcallups.EndEdit();
            dgvcallups.AutoResizeColumns();
            dgvcallups.AutoResizeRows();
            dgvcallups.Focus();





        }

        
        private void updateDatabase1_active()
        {

            string strid = "'" + txtid.Text.Trim() + "'";

            datamethods2 dthm = new datamethods2();
            string sqlInsert = string.Empty;
            sqlInsert = @" update database1 set active = 'true' where recrno = " + strid;

            int returnVal = dthm._update_Insert_NoParameter(sqlInsert);

            if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
           
           


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
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
            prv_posit = Program._searchedValue.Trim();

        }

        private void button8_Click(object sender, EventArgs e)
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


            txtclient.Text = Program._searchedValue.Trim();

            txtrequest.Text = "";
            prv_requestcode = "";

           
            cmbemploymenttype.Text = "";
            chkcinduction.Checked = false;
           

            dtpclientinterviewdate.Text = "";
            chkclientinterview.Checked = false;
            cmbintassessment.Text = "";
            dtpresumptiondate.Text = "";
            txtposition.Text = "";
            prv_posit = "";



            txtremarks.Text = "";


            prv_intlocation = "";
            interiewlocation.Text = "";

           

            string strTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string strdate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            strReqId = txtclient.Text.Trim().ToUpper() + "/" + strdate + "/" + strTime;
    


        }

        private void button9_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_intlocation);
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

        private void frmSch_intlocation(object sender, FormClosedEventArgs e)
        {


            interiewlocation.Text = Program._searchedValue2.Trim();
            prv_intlocation = Program._searchedValue.Trim();

        }

        private void button11_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_Database1);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Id";
            frmSch.strHeader2 = "Surname";
            frmSch.strHeader3 = "Middlename";
            string strQuery = string.Empty;
            strQuery = @"select recrno as Id, surname  as Surname, 
                (firstname + middlename) as Middlename 
                from database1 where recrno not in (select distinct recrno from database2) ";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_Database1(object sender, FormClosedEventArgs e)
        {

            if (Program._searchedValue.Trim() != string.Empty)
            {
                txtid.Text = Program._searchedValue.Trim();
                populateScreen();
            } 

        }

        private void button12_Click(object sender, EventArgs e)
        {

            Program._searchedValue = string.Empty;
            Program._searchedValue2 = string.Empty;
            string strClientId = "'" + txtclient.Text.Trim() + "'";

            if (txtclient.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Select Client", "RnS Notification");
                return;
            }
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_request);
            frmSch.strHeader1 = "RequestId";
            frmSch.strHeader2 = "Title";
            frmSch.strHeader3 = "Position";
            string strQuery = string.Empty;
            strQuery = "select distinct requestid as RequestId, Title,position  from clientrequest where status=0 and clientid = " + strClientId;
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_request(object sender, FormClosedEventArgs e)
        {


            txtrequest.Text = Program._searchedValue2.Trim();
            prv_requestcode= Program._searchedValue.Trim();

        }

        private void dgvcallups_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string clientid = "'" + dgvcallups.Rows[e.RowIndex].Cells["clientid"].Value.ToString() + "'";
                string requestid = "'" + dgvcallups.Rows[e.RowIndex].Cells["request"].Value.ToString() + "'";
                string positionid = "'" + dgvcallups.Rows[e.RowIndex].Cells["position"].Value.ToString() + "'";
                string reqid =  dgvcallups.Rows[e.RowIndex].Cells["reqid"].Value.ToString() ;

                string strRecrno = "'" + txtid.Text.Trim() + "'";
                string strFilter = string.Empty;
                //strFilter = " clientid = " + clientid + " and request = " + requestid + " and position = " + positionid;
                

                
                strFilter = " reqid = '" + reqid + "'";


                DataRow[] rw;
                rw = dt_callup.Select(strFilter);
                
                if (rw.Length > 0)
                {
                    strReqId = reqid;

                    DataTable dt = new DataTable();
                    dt = rw.CopyToDataTable();
                    txtclient.Text = dt.Rows[0]["clientid"].ToString();
                    txtrequest.Text = dt.Rows[0]["reqdescr"].ToString();
                    prv_requestcode = dt.Rows[0]["request"].ToString();

                   
                    cmbemploymenttype.Text= dt.Rows[0]["emptype"].ToString();
                    chkcinduction.Checked = Convert.ToBoolean(dt.Rows[0]["cinduction"]);
                    cmbcindsult.Text = dt.Rows[0]["cindsult"].ToString();

                    dtpclientinterviewdate.Value = Convert.ToDateTime(dt.Rows[0]["intervdate"]);
                    chkclientinterview.Checked = Convert.ToBoolean(dt.Rows[0]["cinterview"]);
                    cmbintassessment.Text = dt.Rows[0]["cintersult"].ToString();
                    dtpresumptiondate.Value = Convert.ToDateTime(dt.Rows[0]["rdate"]);
                    txtposition.Text = dt.Rows[0]["posdescr"].ToString();
                    prv_posit = dt.Rows[0]["position"].ToString();



                    txtremarks.Text = dt.Rows[0]["remarks"].ToString();


                    prv_intlocation = dt.Rows[0]["intloccode"].ToString();
                    interiewlocation.Text = dt.Rows[0]["intlocdesr"].ToString();

                   

                    dt.Dispose();
               
                }
              
            }
            catch
            {
            }

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            rpt_form_database2 rptfrm = new rpt_form_database2();
            rptfrm.ShowDialog();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
