namespace SHOPLITE.ModalForms
{
    partial class FrmPaymentPosting
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelmain = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnCustStmnt = new SHOPLITE.RJButton();
            this.btnPayments = new SHOPLITE.RJButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 32);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(234, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUSTOMER POSTING MODULE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Fuchsia;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 6);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 559);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(751, 24);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Thistle;
            this.panel4.Controls.Add(this.btnCustStmnt);
            this.panel4.Controls.Add(this.btnPayments);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(751, 50);
            this.panel4.TabIndex = 4;
            // 
            // panelmain
            // 
            this.panelmain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelmain.Location = new System.Drawing.Point(82, 159);
            this.panelmain.Name = "panelmain";
            this.panelmain.Size = new System.Drawing.Size(524, 384);
            this.panelmain.TabIndex = 5;
            // 
            // pnlNav
            // 
            this.pnlNav.Location = new System.Drawing.Point(616, 132);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(71, 11);
            this.pnlNav.TabIndex = 1;
            this.pnlNav.Visible = false;
            // 
            // btnCustStmnt
            // 
            this.btnCustStmnt.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCustStmnt.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCustStmnt.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCustStmnt.BorderRadius = 0;
            this.btnCustStmnt.BorderSize = 0;
            this.btnCustStmnt.FlatAppearance.BorderSize = 0;
            this.btnCustStmnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustStmnt.ForeColor = System.Drawing.Color.White;
            this.btnCustStmnt.Location = new System.Drawing.Point(138, 6);
            this.btnCustStmnt.Name = "btnCustStmnt";
            this.btnCustStmnt.Size = new System.Drawing.Size(103, 40);
            this.btnCustStmnt.TabIndex = 0;
            this.btnCustStmnt.Text = "STATEMENT";
            this.btnCustStmnt.TextColor = System.Drawing.Color.White;
            this.btnCustStmnt.UseVisualStyleBackColor = false;
            this.btnCustStmnt.Click += new System.EventHandler(this.btnCustStmnt_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPayments.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPayments.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPayments.BorderRadius = 0;
            this.btnPayments.BorderSize = 0;
            this.btnPayments.FlatAppearance.BorderSize = 0;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(29, 6);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(103, 40);
            this.btnPayments.TabIndex = 0;
            this.btnPayments.Text = "PAYMENTS";
            this.btnPayments.TextColor = System.Drawing.Color.White;
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // FrmPaymentPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 583);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.panelmain);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPaymentPosting";
            this.ShowInTaskbar = false;
            this.Text = "FrmPaymentPosting";
            this.Load += new System.EventHandler(this.FrmPaymentPosting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private RJButton btnPayments;
        private System.Windows.Forms.Panel panelmain;
        private System.Windows.Forms.Panel pnlNav;
        private RJButton btnCustStmnt;
    }
}