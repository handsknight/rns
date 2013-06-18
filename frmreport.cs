using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rns
{
    public partial class frmreport : Form
    {
        public frmreport()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void clearscreen()
        {
            radcandidateselection.Checked = false;
            radclientlists.Checked = false;
            radclientrequest.Checked = false;
            raddatabase1.Checked = false;
            raddatabase2.Checked = false;
            raddownload.Checked = false;
            radusersetups.Checked = false;

            mskdatefrom.Text = "";
            mskdateto.Text = "";


        }

        private void frmreport_Load(object sender, EventArgs e)
        {
            clearscreen();


        }

        private void raddownload_MouseEnter(object sender, EventArgs e)
        {
            
            raddownload.ForeColor = Color.Red;
        }

        private void raddownload_MouseLeave(object sender, EventArgs e)
        {
            raddownload.ForeColor = Color.Black;
        }

        private void radclientrequest_MouseEnter(object sender, EventArgs e)
        {
            radclientrequest.ForeColor = Color.Red;
        }

        private void radclientrequest_MouseLeave(object sender, EventArgs e)
        {
            radclientrequest.ForeColor = Color.Black;

        }

        private void raddatabase1_MouseEnter(object sender, EventArgs e)
        {
            raddatabase1.ForeColor = Color.Red;
        }

        private void raddatabase1_MouseLeave(object sender, EventArgs e)
        {
            raddatabase1.ForeColor = Color.Black;
        }

        private void raddatabase2_MouseEnter(object sender, EventArgs e)
        {
            raddatabase2.ForeColor = Color.Red;
        }

        private void raddatabase2_MouseLeave(object sender, EventArgs e)
        {
            raddatabase2.ForeColor = Color.Black;
        }

        private void radcandidateselection_MouseEnter(object sender, EventArgs e)
        {
            radcandidateselection.ForeColor = Color.Red;
        }

        private void radcandidateselection_MouseLeave(object sender, EventArgs e)
        {
            radcandidateselection.ForeColor = Color.Black;
        }

        private void radusersetups_MouseEnter(object sender, EventArgs e)
        {
            radusersetups.ForeColor = Color.Red;
        }

        private void radusersetups_MouseLeave(object sender, EventArgs e)
        {
            radusersetups.ForeColor = Color.Black;
        }

        private void radclientlists_MouseEnter(object sender, EventArgs e)
        {
            radclientlists.ForeColor = Color.Red;
        }

        private void radclientlists_MouseLeave(object sender, EventArgs e)
        {
            radclientlists.ForeColor = Color.Black;
        }

        private void btnsearch1_Click(object sender, EventArgs e)
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
            //txtclient.Text = txtclient.Text +  Program._searchedValue.Trim() + ";";
            txtclient.Text = Program._searchedValue.Trim() ;
            if (txtclient.Text != string.Empty)
            {

                
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }


       
    }
}
