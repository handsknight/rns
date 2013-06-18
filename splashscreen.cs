using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomShapedFormTemplate1;



namespace rns
{
    public partial class splashscreen : Form
    {
        private int tims_elpased = 0;
        public splashscreen()
        {
            InitializeComponent();


            

            timer1.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();                              // Start the timer


        }

        void timer_Tick(object sender, EventArgs e)
        {

            if (tims_elpased == 1500)
            {
              
                timer1.Stop();
                timer1.Dispose();
                tims_elpased = 0;
                frmlogin frm_login = new frmlogin();
                frm_login.FormClosed += new FormClosedEventHandler(frm_splash_FormClosed);
                frm_login.Show();
                this.Hide();
            }
            else  tims_elpased += 500;
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {

        }

        private void frm_splash_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
