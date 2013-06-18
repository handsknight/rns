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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            panel1.MouseEnter += new EventHandler(panel1_MouseEnter);
            panel1.MouseLeave += new EventHandler(panel1_MouseLeave);

            panel3.MouseLeave += new EventHandler(panel3_MouseLeave);
            panel3.MouseEnter += new EventHandler(panel3_MouseEnter);

            panel2.MouseLeave += new EventHandler(panel2_MouseLeave);
            panel2.MouseEnter += new EventHandler(panel2_MouseEnter);

            panel6.MouseLeave += new EventHandler(panel6_MouseLeave);
            panel6.MouseEnter += new EventHandler(panel6_MouseEnter);

            panel4.MouseLeave += new EventHandler(panel4_MouseLeave);
            panel4.MouseEnter += new EventHandler(panel4_MouseEnter);

            panel8.MouseLeave += new EventHandler(panel8_MouseLeave);
            panel8.MouseEnter += new EventHandler(panel8_MouseEnter);

            panel10.MouseLeave += new EventHandler(panel10_MouseLeave);
            panel10.MouseEnter += new EventHandler(panel10_MouseEnter);

            panel12.MouseLeave += new EventHandler(panel12_MouseLeave);
            panel12.MouseEnter += new EventHandler(panel12_MouseEnter);

            panel13.MouseLeave += new EventHandler(panel13_MouseLeave);
            panel13.MouseEnter += new EventHandler(panel13_MouseEnter);

         


            imgdownload.MouseLeave += new EventHandler(imgdownload_MouseLeave);
            imgdownload.MouseEnter += new EventHandler(imgdownload_MouseEnter);

            imgdatabase1.MouseLeave += new EventHandler(imgdatabase1_MouseLeave);
            imgdatabase1.MouseEnter += new EventHandler(imgdatabase1_MouseEnter);

            imgdatabase2.MouseLeave += new EventHandler(imgdatabase2_MouseLeave);
            imgdatabase2.MouseEnter += new EventHandler(imgdatabase2_MouseEnter);

            imgclient.MouseLeave += new EventHandler(imgclient_MouseLeave);
            imgclient.MouseEnter += new EventHandler(imgclient_MouseEnter);

            imgusersetup.MouseLeave += new EventHandler(imgusersetup_MouseLeave);
            imgusersetup.MouseEnter += new EventHandler(imgusersetup_MouseEnter);

            panel1.Click += new EventHandler(panel1_click);
            panel2.Click += new EventHandler(panel2_click);
            panel3.Click += new EventHandler(panel3_click);
            panel6.Click += new EventHandler(panel6_click);
            panel4.Click += new EventHandler(panel4_click);
            panel8.Click += new EventHandler(panel8_click);
            panel10.Click += new EventHandler(panel10_click);
            panel12.Click += new EventHandler(panel12_click);
            panel13.Click += new EventHandler(panel13_click);


        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

             

        void panel1_MouseLeave(object sender, EventArgs e)
        {
           
            panel1.BorderStyle = BorderStyle.None;
            panel1.BackColor = Color.White;
        }


        void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.BackColor = Color.Wheat;
        }

        void panel3_MouseLeave(object sender, EventArgs e)
        {

            panel3.BorderStyle = BorderStyle.None;
            panel3.BackColor = Color.White;
        }


        void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.BackColor = Color.Wheat;
        }

        void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.None;
        }


        void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.BackColor = Color.Wheat;
        }

        // panel 6
        void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.White;
            panel6.BorderStyle = BorderStyle.None;
        }


        void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.BackColor = Color.LightPink;
        }
        
        // panel 4
        void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.None;
        }


        void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.BackColor = Color.Wheat;
        }

        // panel 8
        void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.None;
        }


        void panel8_MouseEnter(object sender, EventArgs e)
        {
            panel8.BorderStyle = BorderStyle.Fixed3D;
            panel8.BackColor = Color.Wheat;
        }

        // panel 10
        void panel10_MouseLeave(object sender, EventArgs e)
        {
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.None;
        }


        void panel10_MouseEnter(object sender, EventArgs e)
        {
            panel10.BorderStyle = BorderStyle.Fixed3D;
            panel10.BackColor = Color.Wheat;
        }

        // panel 12
        void panel12_MouseLeave(object sender, EventArgs e)
        {
            panel12.BackColor = Color.White;
            panel12.BorderStyle = BorderStyle.None;
        }


        void panel12_MouseEnter(object sender, EventArgs e)
        {
            panel12.BorderStyle = BorderStyle.Fixed3D;
            panel12.BackColor = Color.Wheat;
        }

        // panel 12
        void panel13_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.White;
            panel13.BorderStyle = BorderStyle.None;
        }


        void panel13_MouseEnter(object sender, EventArgs e)
        {
            panel13.BorderStyle = BorderStyle.Fixed3D;
            panel13.BackColor = Color.Wheat;
        }

      

        void panel1_click(object sender, EventArgs e)
        {
            _OpenDownloadform();
        }

        void panel2_click(object sender, EventArgs e)
        {


             _OpenClientRequest();
            
            
        }


        public void _OpenDatabase1()
        {
            frmcandidate frm_cand = new frmcandidate();
            frm_cand.ShowDialog();
        }

        void panel3_click(object sender, EventArgs e)
        {
            _OpenCandiateform();
        }

        void panel6_click(object sender, EventArgs e)
        {
            _OpenCandidateSelection();
        }

        public void _OpenCandidateSelection()
        {

            if (Program.pbDatabase2Access == false)
            {
                MessageBox.Show("Access denied", "RnS Notification");
                return;
            }

            candidateselection frm_candidateselection = new candidateselection();
            frm_candidateselection.ShowDialog();
        }

        void panel4_click(object sender, EventArgs e)
        {
            MessageBox.Show("hi4");
        }

        void panel8_click(object sender, EventArgs e)
        {
            MessageBox.Show("hi8");
        }
        void panel10_click(object sender, EventArgs e)
        {
            MessageBox.Show("hi10");
        }

        void panel12_click(object sender, EventArgs e)
        {
            _OpenCandiateform_db2();
        }

        void panel13_click(object sender, EventArgs e)
        {
            _OpenUserSetup();

        }

        public void  _OpenClientRequest()
        {

            if (Program.pbClientRequestAccess == false)
            {
                MessageBox.Show("Access denied", "RnS Notification");
                return;
            }
          
            
            frmclientrequest frm_clr = new frmclientrequest();
            frm_clr.ShowDialog();


           
        }

        public void _OpenCandiateform()
        {
            if (Program.pbDatabase1Access == false)
            {
                MessageBox.Show("Access denied", "RnS Notification");
                return;
            }
            frmcandidate frm_cand = new frmcandidate();
            frm_cand.ShowDialog();
        }

        public void _OpenCandiateform_db2()
        {
            if (Program.pbDatabase2Access == false)
            {
                MessageBox.Show("Access denied", "RnS Notification");
                return;
            }
            
            frmdatabase2 frm_db2 = new frmdatabase2();
            frm_db2.ShowDialog();
        }

        public void _OpenDownloadform()
        {
            if (Program.pbDownloadAcess == false)
            {
                MessageBox.Show("Access denied", "RnS Notification");
                return;
            }
            
            frmdload frm_download = new frmdload();
            frm_download.ShowDialog();
        }

        public void _OpenUserSetup()
        {

            if (Program.pbUserSetupAccess == false)
            {
                MessageBox.Show("Access denied", "RnS Notification");
                return;
            }
            
            frmusersetup frm_usrsetup = new frmusersetup();
            frm_usrsetup.ShowDialog();
        }

        public void _Close()
        {
              this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            _Close();
            
        }

        private void manageRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmclientrequest frm_clr = new frmclientrequest();
            frm_clr.ShowDialog();
        }

       

        private void webLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenDownloadform();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void database1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenCandiateform();
        }

        private void database2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenCandiateform_db2();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tssusername.Text = "Current User: " + Program.pbUserName.Trim() + " Login Date: " + DateTime.Now.ToString();
            picLogo.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _OpenDownloadform();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _OpenCandiateform();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _OpenCandiateform_db2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _OpenClientRequest();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            _OpenUserSetup();
        }

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Close();
        }

        private void webLocalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _OpenDownloadform();
        }

        private void clientRequestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _OpenClientRequest();
        }

        private void database2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _OpenCandiateform_db2();
            
        }

        private void database1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _OpenCandiateform();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _OpenUserSetup();
        }

        // ---- events for images ----
        void imgdownload_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.None;
        }


        void imgdownload_MouseEnter(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.BackColor = Color.Wheat;
        }

        void imgdatabase1_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.None;
        }


        void imgdatabase1_MouseEnter(object sender, EventArgs e)
        {
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.BackColor = Color.Wheat;
        }

        void imgdatabase2_MouseLeave(object sender, EventArgs e)
        {
            panel12.BackColor = Color.White;
            panel12.BorderStyle = BorderStyle.None;
        }


        void imgdatabase2_MouseEnter(object sender, EventArgs e)
        {
            panel12.BorderStyle = BorderStyle.Fixed3D;
            panel12.BackColor = Color.Wheat;
        }

        void imgclient_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.None;
        }


        void imgclient_MouseEnter(object sender, EventArgs e)
        {
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.BackColor = Color.Wheat;
        }

        void imgusersetup_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.White;
            panel13.BorderStyle = BorderStyle.None;
        }


        void imgusersetup_MouseEnter(object sender, EventArgs e)
        {
            panel13.BorderStyle = BorderStyle.Fixed3D;
            panel13.BackColor = Color.Wheat;
        }

        private void imgdownload_Click(object sender, EventArgs e)
        {
            _OpenDownloadform();
        }

        private void imgdatabase1_Click(object sender, EventArgs e)
        {
            _OpenCandiateform();
        }

        private void imgdatabase2_Click(object sender, EventArgs e)
        {
            _OpenCandiateform_db2();
        }

        private void imgclient_Click(object sender, EventArgs e)
        {
            _OpenClientRequest();
        }

        private void imgusersetup_Click(object sender, EventArgs e)
        {
            _OpenUserSetup();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _OpenCandidateSelection();
        }

        private void reportWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenReport();
        }

       private void _OpenReport()
       {
           if (Program.pbReportAccess == false)
           {
               MessageBox.Show("Access denied", "RnS Notification");
               return;
           }

           frmreport frmreport = new frmreport();
           frmreport.ShowDialog();
       }
       

    }
}
