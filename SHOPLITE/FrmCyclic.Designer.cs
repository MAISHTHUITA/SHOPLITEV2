namespace SHOPLITE
{
    partial class FrmCyclic
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnPayments = new SHOPLITE.RJButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.btnCustStmt = new SHOPLITE.RJButton();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 5);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Fuchsia;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 3);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumPurple;
            this.panel3.Controls.Add(this.pnlNav);
            this.panel3.Controls.Add(this.btnCustStmt);
            this.panel3.Controls.Add(this.btnPayments);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 58);
            this.panel3.TabIndex = 2;
            // 
            // pnlNav
            // 
            this.pnlNav.Location = new System.Drawing.Point(11, 3);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(126, 10);
            this.pnlNav.TabIndex = 0;
            this.pnlNav.Visible = false;
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPayments.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPayments.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPayments.BorderRadius = 0;
            this.btnPayments.BorderSize = 0;
            this.btnPayments.FlatAppearance.BorderSize = 0;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(11, 9);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(126, 49);
            this.btnPayments.TabIndex = 0;
            this.btnPayments.Text = "PAYMENTS";
            this.btnPayments.TextColor = System.Drawing.Color.White;
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(976, 4);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 582);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(976, 46);
            this.panel5.TabIndex = 4;
            // 
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(0, 70);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(976, 512);
            this.mainpanel.TabIndex = 5;
            // 
            // btnCustStmt
            // 
            this.btnCustStmt.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCustStmt.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCustStmt.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCustStmt.BorderRadius = 0;
            this.btnCustStmt.BorderSize = 0;
            this.btnCustStmt.FlatAppearance.BorderSize = 0;
            this.btnCustStmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustStmt.ForeColor = System.Drawing.Color.White;
            this.btnCustStmt.Location = new System.Drawing.Point(143, 9);
            this.btnCustStmt.Name = "btnCustStmt";
            this.btnCustStmt.Size = new System.Drawing.Size(126, 49);
            this.btnCustStmt.TabIndex = 0;
            this.btnCustStmt.Text = "CUSTOMER STATEMENTS";
            this.btnCustStmt.TextColor = System.Drawing.Color.White;
            this.btnCustStmt.UseVisualStyleBackColor = false;
            this.btnCustStmt.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // FrmCyclic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 628);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCyclic";
            this.ShowInTaskbar = false;
            this.Text = "FrmCyclic";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private RJButton btnPayments;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Panel pnlNav;
        private RJButton btnCustStmt;
    }
}