
namespace SHOPLITE.ModalForms
{
    partial class frmManageInvoices
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromCustCode = new System.Windows.Forms.TextBox();
            this.btnViewInvoices = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToCustCd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(100)))), ((int)(((byte)(179)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 33);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "GENERATE CUSTOMER STATEMENTS";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "FROM CUST. CODE";
            // 
            // txtFromCustCode
            // 
            this.txtFromCustCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFromCustCode.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromCustCode.Location = new System.Drawing.Point(131, 34);
            this.txtFromCustCode.Name = "txtFromCustCode";
            this.txtFromCustCode.Size = new System.Drawing.Size(84, 22);
            this.txtFromCustCode.TabIndex = 2;
            this.txtFromCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFromCustCode_KeyDown);
            // 
            // btnViewInvoices
            // 
            this.btnViewInvoices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(117)))), ((int)(((byte)(223)))));
            this.btnViewInvoices.FlatAppearance.BorderSize = 0;
            this.btnViewInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewInvoices.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInvoices.ForeColor = System.Drawing.Color.White;
            this.btnViewInvoices.Location = new System.Drawing.Point(97, 211);
            this.btnViewInvoices.Name = "btnViewInvoices";
            this.btnViewInvoices.Size = new System.Drawing.Size(144, 54);
            this.btnViewInvoices.TabIndex = 0;
            this.btnViewInvoices.Text = "VIEW INVOICES";
            this.btnViewInvoices.UseVisualStyleBackColor = false;
            this.btnViewInvoices.Click += new System.EventHandler(this.btnViewInvoices_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(215, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "TO CUST. CODE";
            // 
            // txtToCustCd
            // 
            this.txtToCustCd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtToCustCd.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToCustCd.Location = new System.Drawing.Point(323, 32);
            this.txtToCustCd.Name = "txtToCustCd";
            this.txtToCustCd.Size = new System.Drawing.Size(90, 22);
            this.txtToCustCd.TabIndex = 2;
            this.txtToCustCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtToCustCd_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "FROM DATE";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(215, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "TO DATE";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(306, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(306, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(119, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = ":";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(119, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = ":";
            // 
            // DtpFrom
            // 
            this.DtpFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpFrom.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.DtpFrom.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFrom.Location = new System.Drawing.Point(131, 70);
            this.DtpFrom.Name = "DtpFrom";
            this.DtpFrom.Size = new System.Drawing.Size(84, 22);
            this.DtpFrom.TabIndex = 4;
            // 
            // DtpTo
            // 
            this.DtpTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpTo.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpTo.CustomFormat = "dd-MMM-yyyy";
            this.DtpTo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpTo.Location = new System.Drawing.Point(323, 68);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(90, 22);
            this.DtpTo.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DtpTo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.DtpFrom);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtToCustCd);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtFromCustCode);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(61, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(431, 131);
            this.panel3.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(309, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 54);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnViewInvoices_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 387);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(560, 28);
            this.panel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnViewInvoices);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 354);
            this.panel2.TabIndex = 6;
            // 
            // frmManageInvoices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(560, 415);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageInvoices";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmManageInvoices_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromCustCode;
        private System.Windows.Forms.Button btnViewInvoices;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToCustCd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DtpFrom;
        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}