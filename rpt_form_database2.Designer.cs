namespace rns
{
    partial class rpt_form_database2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpt_form_database2));
            this.database2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rnsDataSet = new rns.rnsDataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox29 = new System.Windows.Forms.PictureBox();
            this.btnclient = new System.Windows.Forms.Button();
            this.txtsearchvalue = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.radlikeonly = new System.Windows.Forms.RadioButton();
            this.radrecrnoonly = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmblikeselection = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.radall = new System.Windows.Forms.RadioButton();
            this.database2TableAdapter = new rns.rnsDataSetTableAdapters.database2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.database2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // database2BindingSource
            // 
            this.database2BindingSource.DataMember = "database2";
            this.database2BindingSource.DataSource = this.rnsDataSet;
            // 
            // rnsDataSet
            // 
            this.rnsDataSet.DataSetName = "rnsDataSet";
            this.rnsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::rns.Properties.Resources.arrow_red;
            this.pictureBox1.Location = new System.Drawing.Point(5, 79);
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
            // btnclient
            // 
            this.btnclient.Image = global::rns.Properties.Resources.search;
            this.btnclient.Location = new System.Drawing.Point(279, 219);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(26, 25);
            this.btnclient.TabIndex = 51;
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // txtsearchvalue
            // 
            this.txtsearchvalue.Location = new System.Drawing.Point(38, 220);
            this.txtsearchvalue.Name = "txtsearchvalue";
            this.txtsearchvalue.Size = new System.Drawing.Size(240, 23);
            this.txtsearchvalue.TabIndex = 50;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rpt_database2_dataset";
            reportDataSource1.Value = this.database2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "rns.rptdatabase2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(475, 435);
            this.reportViewer1.TabIndex = 0;
            // 
            // radlikeonly
            // 
            this.radlikeonly.AutoSize = true;
            this.radlikeonly.Location = new System.Drawing.Point(28, 74);
            this.radlikeonly.Name = "radlikeonly";
            this.radlikeonly.Size = new System.Drawing.Size(108, 21);
            this.radlikeonly.TabIndex = 1;
            this.radlikeonly.Text = "By LIKE Only";
            this.radlikeonly.UseVisualStyleBackColor = true;
            this.radlikeonly.CheckedChanged += new System.EventHandler(this.radlikeonly_CheckedChanged);
            // 
            // radrecrnoonly
            // 
            this.radrecrnoonly.AutoSize = true;
            this.radrecrnoonly.Checked = true;
            this.radrecrnoonly.Location = new System.Drawing.Point(28, 24);
            this.radrecrnoonly.Name = "radrecrnoonly";
            this.radrecrnoonly.Size = new System.Drawing.Size(143, 21);
            this.radrecrnoonly.TabIndex = 0;
            this.radrecrnoonly.TabStop = true;
            this.radrecrnoonly.Text = "By Candidate Only";
            this.radrecrnoonly.UseVisualStyleBackColor = true;
            this.radrecrnoonly.CheckedChanged += new System.EventHandler(this.radrecrnoonly_CheckedChanged);
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
            this.splitContainer1.Size = new System.Drawing.Size(856, 435);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackgroundImage = global::rns.Properties.Resources.bg2;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnclient);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtsearchvalue);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 391);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Request Report Query Definition";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::rns.Properties.Resources.drafts_image;
            this.button2.Image = global::rns.Properties.Resources.wizard;
            this.button2.Location = new System.Drawing.Point(9, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 60);
            this.button2.TabIndex = 87;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 83;
            this.label1.Text = "Search String";
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
            this.groupBox2.Controls.Add(this.cmblikeselection);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.radall);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.pictureBox29);
            this.groupBox2.Controls.Add(this.radlikeonly);
            this.groupBox2.Controls.Add(this.radrecrnoonly);
            this.groupBox2.Location = new System.Drawing.Point(57, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 143);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query Parameters";
            // 
            // cmblikeselection
            // 
            this.cmblikeselection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblikeselection.FormattingEnabled = true;
            this.cmblikeselection.Items.AddRange(new object[] {
            "Recrno",
            "Surname",
            "Firstname",
            "Middlename"});
            this.cmblikeselection.Location = new System.Drawing.Point(140, 73);
            this.cmblikeselection.Name = "cmblikeselection";
            this.cmblikeselection.Size = new System.Drawing.Size(136, 24);
            this.cmblikeselection.TabIndex = 170;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::rns.Properties.Resources.arrow_red;
            this.pictureBox3.Location = new System.Drawing.Point(6, 55);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(13, 14);
            this.pictureBox3.TabIndex = 169;
            this.pictureBox3.TabStop = false;
            // 
            // radall
            // 
            this.radall.AutoSize = true;
            this.radall.Location = new System.Drawing.Point(30, 51);
            this.radall.Name = "radall";
            this.radall.Size = new System.Drawing.Size(41, 21);
            this.radall.TabIndex = 168;
            this.radall.Text = "All";
            this.radall.UseVisualStyleBackColor = true;
            this.radall.CheckedChanged += new System.EventHandler(this.radall_CheckedChanged);
            // 
            // database2TableAdapter
            // 
            this.database2TableAdapter.ClearBeforeFill = true;
            // 
            // rpt_form_database2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 435);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rpt_form_database2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database 2 Reporting Wizard";
            this.Load += new System.EventHandler(this.rpt_form_database2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox29)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox29;
        private System.Windows.Forms.Button btnclient;
        private System.Windows.Forms.TextBox txtsearchvalue;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.RadioButton radlikeonly;
        private System.Windows.Forms.RadioButton radrecrnoonly;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton radall;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource database2BindingSource;
        private rnsDataSet rnsDataSet;
        private rnsDataSetTableAdapters.database2TableAdapter database2TableAdapter;
        private System.Windows.Forms.ComboBox cmblikeselection;
    }
}