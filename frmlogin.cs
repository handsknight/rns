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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
            button1.MouseEnter += new EventHandler(button1_MouseEnter);
            button1.MouseLeave += new EventHandler(button1_MouseLeave);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Popup;
        }


        void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Standard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
           

        }

        private void login()
        {
            if (txtuserid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID can't be empty!", "Missing ID");
                return;
            }
           
            if (txtpassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password can't be empty!", "Missing Password");
                return;
            }

            txtuserid.Enabled = false;
            txtpassword.Enabled = false;

            string strid = "'" + txtuserid.Text.Trim() + "'";
            string strpassword = "'" + txtpassword.Text + "'";

            string queryString = string.Empty;
            queryString = @"select distinct * from useracct where userid = " + strid 
                + " and pwd = " +  strpassword ;

            datamethods2 dthm = new datamethods2();
            SqlDataReader drRecords;
            drRecords = dthm._dataReader_NoParameter(queryString);
            if (dthm.sqlUserError != String.Empty)
            {
                MessageBox.Show(dthm.sqlUserError);
                drRecords.Close();
                drRecords.Dispose();
                return;
            }
           

            drRecords.Read();
            if (drRecords.HasRows)
            {
                // get the access right vaiables
                if (Convert.ToBoolean(drRecords["suspend"]) == true)
                {
                    MessageBox.Show("Users Suspended!", "RnS Notification");
                    txtuserid.Enabled = true;
                    txtpassword.Enabled = true;
                    return;
                }


                Program.pbClientRequestAccess = Convert.ToBoolean(drRecords["crequest"]);
                Program.pbClientSetupAccess = Convert.ToBoolean(drRecords["clientsetup"]);
                Program.pbDatabase1Access = Convert.ToBoolean(drRecords["database1"]);
                Program.pbDatabase2Access = Convert.ToBoolean(drRecords["database2"]);
                Program.pbDownloadAcess = Convert.ToBoolean(drRecords["download"]);
                Program.pbSetupAccess = Convert.ToBoolean(drRecords["othersetup"]);
                Program.pbUserSetupAccess = Convert.ToBoolean(drRecords["usersetup"]);
                Program.pbReportAccess = Convert.ToBoolean(drRecords["reports"]);
                Program.pbUserName = drRecords["names"].ToString().Trim();
                Program.pbUserID = drRecords["userid"].ToString().Trim();

                MessageBox.Show("Welcome User: " + Program.pbUserName,"RnS Notification");

                // open the main form
                Form1 frm_fm1 = new Form1();
                frm_fm1.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
                frm_fm1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Users...", "RnS Notification");
                txtuserid.Enabled = true;
                txtpassword.Enabled = true;
            }
            drRecords.Close();
            drRecords.Dispose();
        }
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }
    }
}
