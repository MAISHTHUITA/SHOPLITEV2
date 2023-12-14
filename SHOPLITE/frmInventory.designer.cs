
namespace SHOPLITE
{
    partial class frmInventory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnManageReceipts = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnMiscIssue = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGrn = new System.Windows.Forms.Button();
            this.mainpnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.testpanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.btnManageReceipts);
            this.panel1.Controls.Add(this.btnInvoices);
            this.panel1.Controls.Add(this.btnReceipt);
            this.panel1.Controls.Add(this.btnMiscIssue);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnGrn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 58);
            this.panel1.TabIndex = 0;
            // 
            // btn1
            // 
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(793, 37);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 10);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            // 
            // btnManageReceipts
            // 
            this.btnManageReceipts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnManageReceipts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnManageReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageReceipts.ForeColor = System.Drawing.Color.White;
            this.btnManageReceipts.Location = new System.Drawing.Point(509, 0);
            this.btnManageReceipts.Name = "btnManageReceipts";
            this.btnManageReceipts.Size = new System.Drawing.Size(101, 52);
            this.btnManageReceipts.TabIndex = 0;
            this.btnManageReceipts.Text = "MANAGE RECEIPTS";
            this.btnManageReceipts.UseVisualStyleBackColor = false;
            this.btnManageReceipts.Click += new System.EventHandler(this.btnManageReceipts_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnInvoices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoices.ForeColor = System.Drawing.Color.White;
            this.btnInvoices.Location = new System.Drawing.Point(406, 1);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(101, 52);
            this.btnInvoices.TabIndex = 0;
            this.btnInvoices.Text = "MANAGE INVOICES";
            this.btnInvoices.UseVisualStyleBackColor = false;
            this.btnInvoices.Click += new System.EventHandler(this.btnManageInvoices_Click);
            // 
            // btnReceipt
            // 
            this.btnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnReceipt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.ForeColor = System.Drawing.Color.White;
            this.btnReceipt.Location = new System.Drawing.Point(305, 1);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(101, 52);
            this.btnReceipt.TabIndex = 0;
            this.btnReceipt.Text = "Miscellenous Receipt";
            this.btnReceipt.UseVisualStyleBackColor = false;
            this.btnReceipt.Click += new System.EventHandler(this.btnMiscReceipt_Click);
            // 
            // btnMiscIssue
            // 
            this.btnMiscIssue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnMiscIssue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnMiscIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiscIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiscIssue.ForeColor = System.Drawing.Color.White;
            this.btnMiscIssue.Location = new System.Drawing.Point(204, 1);
            this.btnMiscIssue.Name = "btnMiscIssue";
            this.btnMiscIssue.Size = new System.Drawing.Size(101, 52);
            this.btnMiscIssue.TabIndex = 0;
            this.btnMiscIssue.Text = "Miscellenous Issue";
            this.btnMiscIssue.UseVisualStyleBackColor = false;
            this.btnMiscIssue.Click += new System.EventHandler(this.btnMiscIssue_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(103, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Invoice";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnGrn
            // 
            this.btnGrn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnGrn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnGrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrn.ForeColor = System.Drawing.Color.White;
            this.btnGrn.Location = new System.Drawing.Point(2, 1);
            this.btnGrn.Name = "btnGrn";
            this.btnGrn.Size = new System.Drawing.Size(101, 52);
            this.btnGrn.TabIndex = 0;
            this.btnGrn.Text = "Good Receive";
            this.btnGrn.UseVisualStyleBackColor = false;
            this.btnGrn.Click += new System.EventHandler(this.btnGrn_Click);
            // 
            // mainpnl
            // 
            this.mainpnl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainpnl.BackColor = System.Drawing.Color.White;
            this.mainpnl.Location = new System.Drawing.Point(46, 69);
            this.mainpnl.Name = "mainpnl";
            this.mainpnl.Size = new System.Drawing.Size(749, 16);
            this.mainpnl.TabIndex = 1;
            this.mainpnl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.mainpnl_ControlRemoved);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 10);
            this.panel2.TabIndex = 0;
            // 
            // testpanel
            // 
            this.testpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testpanel.Location = new System.Drawing.Point(0, 58);
            this.testpanel.Name = "testpanel";
            this.testpanel.Size = new System.Drawing.Size(880, 519);
            this.testpanel.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(613, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "DEPOSITS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 577);
            this.Controls.Add(this.testpanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mainpnl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmInventory";
            this.ShowInTaskbar = false;
            this.Text = "frmInventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGrn;
        private System.Windows.Forms.Panel mainpnl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMiscIssue;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnManageReceipts;
        private System.Windows.Forms.Panel testpanel;
        private System.Windows.Forms.Button button2;
    }
}