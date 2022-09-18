
namespace SHOPLITE.ModalForms
{
    partial class frmSalesReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txttounit = new System.Windows.Forms.TextBox();
            this.TxtToUser = new System.Windows.Forms.TextBox();
            this.txtvatto = new System.Windows.Forms.TextBox();
            this.txtDeptTo = new System.Windows.Forms.TextBox();
            this.txtSuppTo = new System.Windows.Forms.TextBox();
            this.txtfromunit = new System.Windows.Forms.TextBox();
            this.txtFromUser = new System.Windows.Forms.TextBox();
            this.txtvatfrom = new System.Windows.Forms.TextBox();
            this.txtProdTo = new System.Windows.Forms.TextBox();
            this.txtDeptFrom = new System.Windows.Forms.TextBox();
            this.txtSuppFrom = new System.Windows.Forms.TextBox();
            this.txtProdFrom = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(3)))), ((int)(((byte)(109)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 47);
            this.panel2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sales Report";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(321, 19);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(69, 17);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dtTo);
            this.panel1.Controls.Add(this.dtFrom);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txttounit);
            this.panel1.Controls.Add(this.TxtToUser);
            this.panel1.Controls.Add(this.txtvatto);
            this.panel1.Controls.Add(this.txtDeptTo);
            this.panel1.Controls.Add(this.txtSuppTo);
            this.panel1.Controls.Add(this.txtfromunit);
            this.panel1.Controls.Add(this.txtFromUser);
            this.panel1.Controls.Add(this.txtvatfrom);
            this.panel1.Controls.Add(this.txtProdTo);
            this.panel1.Controls.Add(this.txtDeptFrom);
            this.panel1.Controls.Add(this.txtSuppFrom);
            this.panel1.Controls.Add(this.txtProdFrom);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(12, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 250);
            this.panel1.TabIndex = 10;
            // 
            // dtTo
            // 
            this.dtTo.CalendarFont = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.CustomFormat = "dd-MMM-yyyy";
            this.dtTo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(240, 16);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(112, 20);
            this.dtTo.TabIndex = 44;
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarFont = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtFrom.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(92, 16);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(115, 20);
            this.dtFrom.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(208, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 14);
            this.label13.TabIndex = 41;
            this.label13.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(208, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 14);
            this.label2.TabIndex = 40;
            this.label2.Text = "To:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(208, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 14);
            this.label11.TabIndex = 40;
            this.label11.Text = "To:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(208, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 14);
            this.label9.TabIndex = 39;
            this.label9.Text = "To:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(208, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 14);
            this.label7.TabIndex = 42;
            this.label7.Text = "To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(208, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 14);
            this.label5.TabIndex = 43;
            this.label5.Text = "To:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(28, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 34;
            this.label12.Text = "From Unit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
            this.label1.TabIndex = 35;
            this.label1.Text = "From User:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(32, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 14);
            this.label8.TabIndex = 35;
            this.label8.Text = "From Vat:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(24, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 36;
            this.label10.Text = "From Dept:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(3, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 14);
            this.label14.TabIndex = 37;
            this.label14.Text = "From Supplier:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(5, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 14);
            this.label15.TabIndex = 38;
            this.label15.Text = "From Prod Cd:";
            // 
            // txttounit
            // 
            this.txttounit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txttounit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttounit.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txttounit.Location = new System.Drawing.Point(240, 126);
            this.txttounit.Name = "txttounit";
            this.txttounit.Size = new System.Drawing.Size(112, 20);
            this.txttounit.TabIndex = 8;
            // 
            // TxtToUser
            // 
            this.TxtToUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.TxtToUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtToUser.Font = new System.Drawing.Font("Arial", 8.25F);
            this.TxtToUser.Location = new System.Drawing.Point(240, 178);
            this.TxtToUser.Name = "TxtToUser";
            this.TxtToUser.Size = new System.Drawing.Size(112, 20);
            this.TxtToUser.TabIndex = 12;
            this.TxtToUser.Leave += new System.EventHandler(this.TxtToUser_Leave);
            // 
            // txtvatto
            // 
            this.txtvatto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtvatto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtvatto.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtvatto.Location = new System.Drawing.Point(240, 152);
            this.txtvatto.Name = "txtvatto";
            this.txtvatto.Size = new System.Drawing.Size(112, 20);
            this.txtvatto.TabIndex = 10;
            // 
            // txtDeptTo
            // 
            this.txtDeptTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtDeptTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeptTo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtDeptTo.Location = new System.Drawing.Point(240, 100);
            this.txtDeptTo.Name = "txtDeptTo";
            this.txtDeptTo.Size = new System.Drawing.Size(112, 20);
            this.txtDeptTo.TabIndex = 6;
            // 
            // txtSuppTo
            // 
            this.txtSuppTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtSuppTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuppTo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtSuppTo.Location = new System.Drawing.Point(240, 69);
            this.txtSuppTo.Name = "txtSuppTo";
            this.txtSuppTo.Size = new System.Drawing.Size(112, 20);
            this.txtSuppTo.TabIndex = 4;
            // 
            // txtfromunit
            // 
            this.txtfromunit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtfromunit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfromunit.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtfromunit.Location = new System.Drawing.Point(92, 126);
            this.txtfromunit.Name = "txtfromunit";
            this.txtfromunit.Size = new System.Drawing.Size(115, 20);
            this.txtfromunit.TabIndex = 7;
            // 
            // txtFromUser
            // 
            this.txtFromUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtFromUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromUser.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtFromUser.Location = new System.Drawing.Point(92, 178);
            this.txtFromUser.Name = "txtFromUser";
            this.txtFromUser.Size = new System.Drawing.Size(115, 20);
            this.txtFromUser.TabIndex = 11;
            this.txtFromUser.Leave += new System.EventHandler(this.txtFromUser_Leave);
            // 
            // txtvatfrom
            // 
            this.txtvatfrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtvatfrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtvatfrom.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtvatfrom.Location = new System.Drawing.Point(92, 152);
            this.txtvatfrom.Name = "txtvatfrom";
            this.txtvatfrom.Size = new System.Drawing.Size(115, 20);
            this.txtvatfrom.TabIndex = 9;
            // 
            // txtProdTo
            // 
            this.txtProdTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtProdTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdTo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtProdTo.Location = new System.Drawing.Point(240, 40);
            this.txtProdTo.Name = "txtProdTo";
            this.txtProdTo.Size = new System.Drawing.Size(112, 20);
            this.txtProdTo.TabIndex = 2;
            // 
            // txtDeptFrom
            // 
            this.txtDeptFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtDeptFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeptFrom.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtDeptFrom.Location = new System.Drawing.Point(92, 100);
            this.txtDeptFrom.Name = "txtDeptFrom";
            this.txtDeptFrom.Size = new System.Drawing.Size(115, 20);
            this.txtDeptFrom.TabIndex = 5;
            // 
            // txtSuppFrom
            // 
            this.txtSuppFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtSuppFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuppFrom.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtSuppFrom.Location = new System.Drawing.Point(92, 69);
            this.txtSuppFrom.Name = "txtSuppFrom";
            this.txtSuppFrom.Size = new System.Drawing.Size(115, 20);
            this.txtSuppFrom.TabIndex = 3;
            // 
            // txtProdFrom
            // 
            this.txtProdFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtProdFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdFrom.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtProdFrom.Location = new System.Drawing.Point(92, 40);
            this.txtProdFrom.Name = "txtProdFrom";
            this.txtProdFrom.Size = new System.Drawing.Size(115, 20);
            this.txtProdFrom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(85, 204);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 34);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(208, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(25, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 38;
            this.label4.Text = "From Date:";
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 315);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txttounit;
        private System.Windows.Forms.TextBox TxtToUser;
        private System.Windows.Forms.TextBox txtvatto;
        private System.Windows.Forms.TextBox txtDeptTo;
        private System.Windows.Forms.TextBox txtSuppTo;
        private System.Windows.Forms.TextBox txtfromunit;
        private System.Windows.Forms.TextBox txtFromUser;
        private System.Windows.Forms.TextBox txtvatfrom;
        private System.Windows.Forms.TextBox txtProdTo;
        private System.Windows.Forms.TextBox txtDeptFrom;
        private System.Windows.Forms.TextBox txtSuppFrom;
        private System.Windows.Forms.TextBox txtProdFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}