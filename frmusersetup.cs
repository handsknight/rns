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
    public partial class frmusersetup : Form
    {
        private Boolean newRecords = true;

        public frmusersetup()
        {
            InitializeComponent();
        }

        private void frmusersetup_Load(object sender, EventArgs e)
        {
            clearScreen();
        }

       
       
        private void clearScreen()
        {
            txtid.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtconfirm.Text = "";
            txtusername.Text = "";
            chkclientrequest.Checked = false;
            chkclients.Checked = false;
            chkdatabase1.Checked = false;
            chkdatabase2.Checked = false;
            chkdownload.Checked = false;
            chksetups.Checked = false;
            chksuspended.Checked = false;
            chkusers.Checked = false;
            txtid.Enabled = true;
            txtid.Focus();
            newRecords = true;

        }
        private void saveRecords()
        {
           
 
            if (txtid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID can't be empty!","Missing ID");
                return;
            }
            if (txtusername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Username can't be empty!", "Missing Username");
                return;
            }
            if (txtpassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password can't be empty!", "Missing Password");
                return;
            }
           if (newRecords == true )
           {
                
                if (txtconfirm.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Confirm Password pls.", "Missing Password");
                    return;
                }
                if (txtpassword.Text.Trim() != txtconfirm.Text.Trim())
                {
                    MessageBox.Show("Password and Confirm Password are not the same!", "Missing Password");
                    return;
                }
           }

            string strid = "'" + txtid.Text.Trim() + "'";
            string strusername = "'" + txtusername.Text + "'";
            string strpassword = "'" + txtpassword.Text + "'";
            string boolSuspend = "'" + chksuspended.Checked + "'";
            string booldatabase1 = "'" + chkdatabase1.Checked + "'";
            string booldatabase2 = "'" + chkdatabase2.Checked + "'";
            string boolclientsetup = "'" + chkclients.Checked + "'";
            string booldownload = "'" + chkdownload.Checked + "'";
            string boolusersetup = "'" + chkusers.Checked + "'";
            string boolcrequest = "'" + chkclientrequest.Checked + "'";
            string boolothersetup = "'" + chksetups.Checked + "'";
            string boolreports = "'" + chkreports.Checked + "'";

            //
           
            // save new  records
           if (newRecords == true)
           {
               
               datamethods2 dthm = new datamethods2();
               string sqlInsert = string.Empty;
               sqlInsert = @" insert into useracct (userid,pwd,names,suspend,database1,database2, 
                clientsetup,download,usersetup,crequest,othersetup,reports) 
                values (" + strid + "," + strpassword + "," + strusername + "," + boolSuspend + ","
                + booldatabase1 + "," + booldatabase2 + "," + boolclientsetup + "," + booldownload + ","
                + boolusersetup + "," + boolcrequest + "," + boolothersetup + "," + boolreports + ")";

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
               sqlInsert = @" update useracct set  pwd = " + strpassword + "," + " names= "
                + strusername + "," + " suspend = "  + boolSuspend+ "," + " database1 = " 
                + booldatabase1 + "," + " database2 = " + booldatabase2 + "," 
                + " clientsetup = " + boolclientsetup + "," + " download= "+ booldownload + "," 
                + " usersetup= " + boolusersetup + ","
                + " crequest= " + boolcrequest + "," + " othersetup= " + boolothersetup + ","
                + " reports= " + boolreports + "  where userid = " + strid ;

               int returnVal = dthm._update_Insert_NoParameter(sqlInsert);

               if (dthm.sqlUserError.Trim() != string.Empty) MessageBox.Show(dthm.sqlUserError);
               else
               {
                   MessageBox.Show("Update was successful Saved.", "RnS Notification");
                   clearScreen();
               }
           }

        }

        private void populateScreen()
        {
            string strid = txtid.Text;
            txtusername.Text = "";
            txtpassword.Text = "";
            txtconfirm.Text = "";
            txtusername.Text = "";
            chkclientrequest.Checked = false;
            chkclients.Checked = false;
            chkdatabase1.Checked = false;
            chkdatabase2.Checked = false;
            chkdownload.Checked = false;
            chksetups.Checked = false;
            chksuspended.Checked = false;
            chkusers.Checked = false;
           
            string queryString = string.Empty;
            queryString= "select distinct * from useracct where userid = " + "'" +strid+ "'";
            datamethods2 dthm = new datamethods2();
            SqlDataReader drRecords = dthm._dataReader_NoParameter(queryString);
            drRecords.Read();
            if (drRecords.HasRows)
            {
                
                newRecords = false;
                
                txtusername.Text = drRecords["names"].ToString();
                txtpassword.Text = drRecords["pwd"].ToString(); 
                txtconfirm.Text = drRecords["pwd"].ToString(); 
                chkclientrequest.Checked = Convert.ToBoolean( drRecords["crequest"]);
                chkclients.Checked = Convert.ToBoolean(drRecords["clientsetup"]);
                chkdatabase1.Checked = Convert.ToBoolean(drRecords["database1"]);
                chkdatabase2.Checked = Convert.ToBoolean(drRecords["database2"]);
                chkdownload.Checked = Convert.ToBoolean(drRecords["download"]);
                chksetups.Checked = Convert.ToBoolean(drRecords["othersetup"]);
                chksuspended.Checked = Convert.ToBoolean(drRecords["suspend"]);
                chkusers.Checked = Convert.ToBoolean(drRecords["usersetup"]);
                chkreports.Checked = Convert.ToBoolean(drRecords["reports"]); 
                 
            }
            drRecords.Dispose();
            pictureBox6.Focus();
            txtid.Enabled = false;
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

       

        private void txtid_Leave(object sender, EventArgs e)
        {
            populateScreen();
        }

        private void audittray()
        {
            

            datamethods2 dthm = new datamethods2();
            dthm.audittray("Setup/Modify User " + txtusername.Text.Trim());     
       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveRecords();
            audittray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program._searchedValue = ""; 
            frmsearch frmSch = new frmsearch();
            frmSch.FormClosed += new FormClosedEventHandler(frmSch_FormClosed);
            frmSch._returnCellIndex = 0;
            frmSch.strHeader1 = "Userid";
            frmSch.strHeader2 = "Names";
            string strQuery = string.Empty;
            strQuery = "select userid as UserId, names as Names from useracct";
            frmSch._getData(strQuery);
            frmSch.ShowDialog();
        }

        private void frmSch_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtid.Text = Program._searchedValue;
            if (txtid.Text != string.Empty)     populateScreen();
           
        }


    }
}
