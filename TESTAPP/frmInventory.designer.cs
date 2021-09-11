
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
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnMiscIssue = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGrn = new System.Windows.Forms.Button();
            this.mainpnl = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
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
            // btnInvoices
            // 
            this.btnInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnInvoices.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInvoices.FlatAppearance.BorderSize = 3;
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoices.ForeColor = System.Drawing.Color.White;
            this.btnInvoices.Location = new System.Drawing.Point(494, 8);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(101, 43);
            this.btnInvoices.TabIndex = 0;
            this.btnInvoices.Text = "MANAGE INVOICES";
            this.btnInvoices.UseVisualStyleBackColor = false;
            this.btnInvoices.Click += new System.EventHandler(this.btnManageInvoices_Click);
            // 
            // btnReceipt
            // 
            this.btnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnReceipt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReceipt.FlatAppearance.BorderSize = 3;
            this.btnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.ForeColor = System.Drawing.Color.White;
            this.btnReceipt.Location = new System.Drawing.Point(367, 8);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(101, 43);
            this.btnReceipt.TabIndex = 0;
            this.btnReceipt.Text = "Miscellenous Receipt";
            this.btnReceipt.UseVisualStyleBackColor = false;
            this.btnReceipt.Click += new System.EventHandler(this.btnMiscReceipt_Click);
            // 
            // btnMiscIssue
            // 
            this.btnMiscIssue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnMiscIssue.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMiscIssue.FlatAppearance.BorderSize = 3;
            this.btnMiscIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiscIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiscIssue.ForeColor = System.Drawing.Color.White;
            this.btnMiscIssue.Location = new System.Drawing.Point(260, 8);
            this.btnMiscIssue.Name = "btnMiscIssue";
            this.btnMiscIssue.Size = new System.Drawing.Size(101, 43);
            this.btnMiscIssue.TabIndex = 0;
            this.btnMiscIssue.Text = "Miscellenous Issue";
            this.btnMiscIssue.UseVisualStyleBackColor = false;
            this.btnMiscIssue.Click += new System.EventHandler(this.btnMiscIssue_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(140, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Invoice";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnGrn
            // 
            this.btnGrn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(148)))), ((int)(((byte)(25)))));
            this.btnGrn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGrn.FlatAppearance.BorderSize = 3;
            this.btnGrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrn.ForeColor = System.Drawing.Color.White;
            this.btnGrn.Location = new System.Drawing.Point(19, 8);
            this.btnGrn.Name = "btnGrn";
            this.btnGrn.Size = new System.Drawing.Size(101, 43);
            this.btnGrn.TabIndex = 0;
            this.btnGrn.Text = "Good Receive";
            this.btnGrn.UseVisualStyleBackColor = false;
            this.btnGrn.Click += new System.EventHandler(this.btnGrn_Click);
            // 
            // mainpnl
            // 
            this.mainpnl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainpnl.BackColor = System.Drawing.Color.White;
            this.mainpnl.Location = new System.Drawing.Point(19, 79);
            this.mainpnl.Name = "mainpnl";
            this.mainpnl.Size = new System.Drawing.Size(823, 473);
            this.mainpnl.TabIndex = 1;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 577);
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
    }
}