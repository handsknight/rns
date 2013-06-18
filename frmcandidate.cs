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
    public partial class frmcandidate : Form
    {
        private Boolean newRecords = true;
        private string prv_location = string.Empty;
        private string prv_grade = string.Empty;
        private string prv_qual = string.Empty;


        public frmcandidate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveRecords();
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
            strQuery = "select recrno as Id, surname  as Surname, (firstname + middlename) as Middlename from database1";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtid.Text = Program._searchedValue;
            if (txtid.Text != string.Empty) populateScreen();

        }
        private void txtid_Leave(object sender, EventArgs e)
        {
            populateScreen();
        }
        private void populateScreen()
        {
            string strid = txtid.Text;
            txtsurname.Text = "";
            txtfirstname.Text = "";
            txtmiddlename.Text = "";
            txtinitials.Text = "";
            chkdocscreened.Checked = false;
            chkaptested.Checked = false;
            cmbtitle.SelectedIndex = 0;
            txtaddress.Text = "";
            cmbgender.SelectedIndex = 0;
            mskdob.Text = "";
            mskage.Text = "";
            txtemail.Text = "";
            mskphone.Text = "";
            txtlocation.Text = "";
            txtqualification.Text = "";
            txtgrade.Text = "";
            txtid.Enabled = false;
            newRecords = true;
            chktransfered.Checked = false;

            string queryString = string.Empty;

            queryString = "select distinct * from database1 where recrno = " + "'" + strid + "'";
            datamethods2 dthm = new datamethods2();
            SqlDataReader drRecords = dthm._dataReader_NoParameter(queryString);
            drRecords.Read();
            if (drRecords.HasRows)
            {

                newRecords = false;
                             
                
                txtsurname.Text = drRecords["surname"].ToString();
                txtfirstname.Text = drRecords["firstname"].ToString();
                txtmiddlename.Text = drRecords["middlename"].ToString();
                chkdocscreened.Checked = Convert.ToBoolean(drRecords["screened"]);
                chkaptested.Checked = Convert.ToBoolean(drRecords["aptest"]);
                txtinitials.Text = drRecords["initials"].ToString();
                cmbtitle.Text = drRecords["title"].ToString();
                txtaddress.Text = drRecords["address"].ToString();
                cmbgender.Text = drRecords["sex"].ToString();
                mskdob.Text = drRecords["birthdate"].ToString();
                mskage.Text = drRecords["age"].ToString();
                txtemail.Text = drRecords["email"].ToString();
                mskphone.Text = drRecords["phone"].ToString();
                txtlocation.Text = drRecords["lgadescr"].ToString();
                txtqualification.Text = drRecords["qualdescr"].ToString();
                txtgrade.Text = drRecords["gradedescr"].ToString();
                chktransfered.Checked = Convert.ToBoolean(drRecords["active"]);
                cmbtestresult.Text = drRecords["testresult"].ToString();
                prv_grade = drRecords["gradecode"].ToString();
                prv_location = drRecords["lgacode"].ToString();
                prv_qual = drRecords["qualcode"].ToString();
                
            }
            drRecords.Dispose();
            pictureBox6.Focus();
            txtid.Enabled = false;
        }
        private void frmcandidate_Load(object sender, EventArgs e)
        {
            clearScreen();
            //float scaleX = ((float)Screen.PrimaryScreen.WorkingArea.Width / 1024);
            //float scaleY = ((float)Screen.PrimaryScreen.WorkingArea.Height / 768);
            //SizeF aSf = new SizeF(scaleX, scaleY);
            //this.Scale(aSf);

        }

        private void clearScreen()
        {
            txtid.Text = "";
            txtsurname.Text = "";
            txtfirstname.Text = "";
            txtmiddlename.Text = "";
            txtinitials.Text = "";
            chkdocscreened.Checked = false;
            chkaptested.Checked = false;
            cmbtitle.SelectedIndex = 0;
            txtaddress.Text = "";
            cmbgender.SelectedIndex = 0;
            mskdob.Text = "";
            mskage.Text = "";
            txtemail.Text = "";
            mskphone.Text = "";
            txtlocation.Text = "";
            txtqualification.Text = "";
            txtgrade.Text = "";
            txtid.Enabled = true;
            txtid.Focus();
            newRecords = true;
            chktransfered.Checked = false;
            prv_qual = "";
            prv_location = "";
            prv_grade = "";
            cmbtestresult.Text = "";

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearScreen();
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

                 

            string strid = "'" + txtid.Text.Trim() + "'";
            string strsurname = "'" + txtsurname.Text + "'";
            string strfirstname = "'" + txtfirstname.Text + "'";
            string strtxtmiddlename= "'" + txtmiddlename.Text + "'";
            string strinitials = "'" +  txtinitials.Text + "'";
            string strtitle = "'" + cmbtitle.SelectedItem.ToString().Trim() + "'";
            string straddress = "'" +  txtaddress.Text + "'";
            string strgender = "'" + cmbgender.SelectedItem.ToString().Trim() + "'";
            string strdob = "'" +  mskdob.Text + "'";
            string strage = "'" +  mskage.Text + "'";
            string stremail = "'" +  txtemail.Text + "'";
            string strphone = "'" +  mskphone.Text + "'";
            string strlocation = "'" + txtlocation.Text + "'";
            string strqualification = "'" + txtqualification.Text + "'";
            string strgrade = "'" + txtgrade.Text + "'";
            string strdocscreened = "'" + chkdocscreened.Checked + "'";
            string straptested = "'" + chkaptested.Checked + "'";
            string strtransfered = "'" + chktransfered.Checked + "'";
            string strTextResult = "'" + cmbtestresult.SelectedItem.ToString().Trim() + "'";
          
            //

            // save new  records
            if (newRecords == true)
            {

                datamethods2 dthm = new datamethods2();
                string sqlInsert = string.Empty;
                sqlInsert = @" insert into database1 (recrno,surname,firstname,middlename,initials,address, 
                title,sex,birthdate,age,phone,email,lgadescr,qualdescr,gradedescr,screened,aptest,
                active,testresult,lgacode,qualcode,gradecode) 
                values (" + strid + "," + strsurname + "," + strfirstname + "," + strtxtmiddlename + ","
                 + strinitials + "," + straddress + "," + strtitle + "," + strgender + ","
                 + strdob + "," + strage + "," + strphone + "," + stremail + "," + strlocation + "," + strqualification
                 + "," + strgrade + "," + strdocscreened + "," + straptested + ","
                 + strtransfered + ","
                 + strTextResult + ","
                 + "'" + prv_location + "'" + ","
                 + "'" + prv_qual + "'" + ","
                 + "'" + prv_grade + "'" + ","
                 + ")";

                int returnVal = dthm._update_Insert_NoParameter(sqlInsert);

                if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
                else
                {
                    MessageBox.Show("Records Saved.", "RnS Notification");
                    clearScreen();
                }

            }
            else
            {

                datamethods2 dthm = new datamethods2();
                string sqlInsert = string.Empty;
                sqlInsert = @" update database1 set  surname = " + strsurname + "," + " firstname= "
                 + strfirstname + "," + " middlename = " + strtxtmiddlename + "," + " initials = "
                 + strinitials + "," + " address = " + straddress + ","
                 + " title = " + strtitle + "," + " sex= " + strgender + ","
                 + " birthdate= " + strdob + ","
                 + " age= " + strage + "," + " phone= " + strphone + ","
                 + " email= " + stremail + "," + " lgadescr= " + strlocation + "," + " qualdescr= " + strqualification + ","
                 + " gradedescr= " + strgrade + "," + " screened= " + strdocscreened + "," + " aptest= " + straptested
                 + "," + " active= " + strtransfered
                 + "," + " testresult= " + strTextResult
                 + "," + " lgacode= " + "'" + prv_location + "'"
                 + "," + " qualcode= " + "'" + prv_qual + "'" 
                 + "," + " gradecode= " + "'" + prv_grade + "'" 
                 + "  where recrno = " + strid;

                int returnVal = dthm._update_Insert_NoParameter(sqlInsert);

                if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
                else
                {

                    MessageBox.Show("Update was successful Saved.", "RnS Notification");
                    clearScreen();
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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
    }
}
