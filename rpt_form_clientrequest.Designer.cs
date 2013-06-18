namespace rns
{
    partial class rpt_form_clientrequest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpt_form_clientrequest));
            this.clientrequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rnsDataSet = new rns.rnsDataSet();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnclient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtclient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtposition = new System.Windows.Forms.TextBox();
            this.btnposition = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.radall = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox29 = new System.Windows.Forms.PictureBox();
            this.radclientpositiononly = new System.Windows.Forms.RadioButton();
            this.radpositiononly = new System.Windows.Forms.RadioButton();
            this.radclientonly = new System.Windows.Forms.RadioButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.clientrequestTableAdapter = new rns.rnsDataSetTableAdapters.clientrequestTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.clientrequestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).BeginInit();
            this.SuspendLayout();
            // 
            // clientrequestBindingSource
            // 
            this.clientrequestBindingSource.DataMember = "clientrequest";
            this.clientrequestBindingSource.DataSource = this.rnsDataSet;
            // 
            // rnsDataSet
            // 
            this.rnsDataSet.DataSetName = "rnsDataSet";
            this.rnsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::rns.Properties.Resources.drafts_image;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(849, 372);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackgroundImage = global::rns.Properties.Resources.bg2;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.btnclient);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtclient);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtposition);
            this.groupBox1.Controls.Add(this.btnposition);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Request Report Query Definition";
            // 
            // btnclient
            // 
            this.btnclient.Image = global::rns.Properties.Resources.search;
            this.btnclient.Location = new System.Drawing.Point(283, 192);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(26, 25);
            this.btnclient.TabIndex = 51;
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 83;
            this.label1.Text = "Client";
            // 
            // txtclient
            // 
            this.txtclient.Location = new System.Drawing.Point(42, 193);
            this.txtclient.Name = "txtclient";
            this.txtclient.ReadOnly = true;
            this.txtclient.Size = new System.Drawing.Size(240, 23);
            this.txtclient.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 86;
            this.label2.Text = "Position";
            // 
            // txtposition
            // 
            this.txtposition.Location = new System.Drawing.Point(42, 246);
            this.txtposition.Name = "txtposition";
            this.txtposition.ReadOnly = true;
            this.txtposition.Size = new System.Drawing.Size(240, 23);
            this.txtposition.TabIndex = 84;
            // 
            // btnposition
            // 
            this.btnposition.Image = global::rns.Properties.Resources.search;
            this.btnposition.Location = new System.Drawing.Point(283, 244);
            this.btnposition.Name = "btnposition";
            this.btnposition.Size = new System.Drawing.Size(26, 25);
            this.btnposition.TabIndex = 85;
            this.btnposition.UseVisualStyleBackColor = true;
            this.btnposition.Click += new System.EventHandler(this.btnposcode_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::rns.Properties.Resources.drafts_image;
            this.button4.Image = global::rns.Properties.Resources.report2;
            this.button4.Location = new System.Drawing.Point(209, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.TabIndex = 79;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(232, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackgroundImage = global::rns.Properties.Resources.drafts_image;
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.radall);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.pictureBox29);
            this.groupBox2.Controls.Add(this.radclientpositiononly);
            this.groupBox2.Controls.Add(this.radpositiononly);
            this.groupBox2.Controls.Add(this.radclientonly);
            this.groupBox2.Location = new System.Drawing.Point(39, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 131);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query Parameters";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::rns.Properties.Resources.arrow_red;
            this.pictureBox3.Location = new System.Drawing.Point(4, 112);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(13, 14);
            this.pictureBox3.TabIndex = 169;
            this.pictureBox3.TabStop = false;
            // 
            // radall
            // 
            this.radall.AutoSize = true;
            this.radall.Location = new System.Drawing.Point(28, 108);
            this.radall.Name = "radall";
            this.radall.Size = new System.Drawing.Size(41, 21);
            this.radall.TabIndex = 168;
            this.radall.Text = "All";
            this.radall.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::rns.Properties.Resources.arrow_red;
            this.pictureBox2.Location = new System.Drawing.Point(5, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 14);
            this.pictureBox2.TabIndex = 167;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::rns.Properties.Resources.arrow_red;
            this.pictureBox1.Location = new System.Drawing.Point(5, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 14);
            this.pictureBox1.TabIndex = 166;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox29
            // 
            this.pictureBox29.Image = global::rns.Properties.Resources.arrow_red;
            this.pictureBox29.Location = new System.Drawing.Point(5, 29);
            this.pictureBox29.Name = "pictureBox29";
            this.pictureBox29.Size = new System.Drawing.Size(13, 14);
            this.pictureBox29.TabIndex = 165;
            this.pictureBox29.TabStop = false;
            // 
            // radclientpositiononly
            // 
            this.radclientpositiononly.AutoSize = true;
            this.radclientpositiononly.Location = new System.Drawing.Point(28, 81);
            this.radclientpositiononly.Name = "radclientpositiononly";
            this.radclientpositiononly.Size = new System.Drawing.Size(196, 21);
            this.radclientpositiononly.TabIndex = 2;
            this.radclientpositiononly.Text = "By Client and Position Only";
            this.radclientpositiononly.UseVisualStyleBackColor = true;
            // 
            // radpositiononly
            // 
            this.radpositiononly.AutoSize = true;
            this.radpositiononly.Location = new System.Drawing.Point(28, 51);
            this.radpositiononly.Name = "radpositiononly";
            this.radpositiononly.Size = new System.Drawing.Size(129, 21);
            this.radpositiononly.TabIndex = 1;
            this.radpositiononly.Text = "By Position Only";
            this.radpositiononly.UseVisualStyleBackColor = true;
            // 
            // radclientonly
            // 
            this.radclientonly.AutoSize = true;
            this.radclientonly.Checked = true;
            this.radclientonly.Location = new System.Drawing.Point(28, 24);
            this.radclientonly.Name = "radclientonly";
            this.radclientonly.Size = new System.Drawing.Size(114, 21);
            this.radclientonly.TabIndex = 0;
            this.radclientonly.TabStop = true;
            this.radclientonly.Text = "By Client Only";
            this.radclientonly.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rpt_clientreq_dataset";
            reportDataSource1.Value = this.clientrequestBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "rns.rptclientrequest.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(471, 372);
            this.reportViewer1.TabIndex = 0;
            // 
            // clientrequestTableAdapter
            // 
            this.clientrequestTableAdapter.ClearBeforeFill = true;
            // 
            // rpt_form_clientrequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 372);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rpt_form_clientrequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports: Client Requests";
            this.Load += new System.EventHandler(this.Sample_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientrequestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnsDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnclient;
        private System.Windows.Forms.TextBox txtclient;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radclientpositiononly;
        private System.Windows.Forms.RadioButton radpositiononly;
        private System.Windows.Forms.RadioButton radclientonly;
        private System.Windows.Forms.PictureBox pictureBox29;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnposition;
        private System.Windows.Forms.TextBox txtposition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton radall;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource clientrequestBindingSource;
        private rnsDataSet rnsDataSet;
        private rnsDataSetTableAdapters.clientrequestTableAdapter clientrequestTableAdapter;
    }
}