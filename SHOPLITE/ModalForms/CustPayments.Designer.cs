namespace SHOPLITE.ModalForms
{
    partial class CustPayments
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnCancel = new SHOPLITE.RJButton();
            this.BtnSave = new SHOPLITE.RJButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbOther = new SHOPLITE.RJRadioButton();
            this.rdbCheque = new SHOPLITE.RJRadioButton();
            this.rdbMpesa = new SHOPLITE.RJRadioButton();
            this.rdbCash = new SHOPLITE.RJRadioButton();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.txtPaymentDescription = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPostCustomerName = new System.Windows.Forms.TextBox();
            this.txtPostCustomerLimitDays = new System.Windows.Forms.TextBox();
            this.txtPostCustomerLimit = new System.Windows.Forms.TextBox();
            this.txtPostCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.BtnCancel);
            this.panel4.Controls.Add(this.BtnSave);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.txtPostCustomerName);
            this.panel4.Controls.Add(this.txtPostCustomerLimitDays);
            this.panel4.Controls.Add(this.txtPostCustomerLimit);
            this.panel4.Controls.Add(this.txtPostCustomer);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(38, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(493, 329);
            this.panel4.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnCancel.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCancel.BorderRadius = 0;
            this.BtnCancel.BorderSize = 0;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(267, 267);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(150, 40);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.TextColor = System.Drawing.Color.White;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSave.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnSave.BorderRadius = 0;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.Enabled = false;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(83, 267);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(150, 40);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbOther);
            this.groupBox1.Controls.Add(this.rdbCheque);
            this.groupBox1.Controls.Add(this.rdbMpesa);
            this.groupBox1.Controls.Add(this.rdbCash);
            this.groupBox1.Controls.Add(this.txtRef);
            this.groupBox1.Controls.Add(this.txtPaymentDescription);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(16, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 137);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PAYMENT OPTIONS";
            // 
            // rdbOther
            // 
            this.rdbOther.AutoSize = true;
            this.rdbOther.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.rdbOther.Location = new System.Drawing.Point(326, 26);
            this.rdbOther.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbOther.Name = "rdbOther";
            this.rdbOther.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbOther.Size = new System.Drawing.Size(72, 21);
            this.rdbOther.TabIndex = 2;
            this.rdbOther.Text = "OTHER";
            this.rdbOther.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbOther.UseVisualStyleBackColor = true;
            // 
            // rdbCheque
            // 
            this.rdbCheque.AutoSize = true;
            this.rdbCheque.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.rdbCheque.Location = new System.Drawing.Point(245, 26);
            this.rdbCheque.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbCheque.Name = "rdbCheque";
            this.rdbCheque.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbCheque.Size = new System.Drawing.Size(81, 21);
            this.rdbCheque.TabIndex = 2;
            this.rdbCheque.Text = "CHEQUE";
            this.rdbCheque.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbCheque.UseVisualStyleBackColor = true;
            // 
            // rdbMpesa
            // 
            this.rdbMpesa.AutoSize = true;
            this.rdbMpesa.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.rdbMpesa.Location = new System.Drawing.Point(170, 26);
            this.rdbMpesa.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbMpesa.Name = "rdbMpesa";
            this.rdbMpesa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbMpesa.Size = new System.Drawing.Size(73, 21);
            this.rdbMpesa.TabIndex = 2;
            this.rdbMpesa.Text = "MPESA";
            this.rdbMpesa.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbMpesa.UseVisualStyleBackColor = true;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Checked = true;
            this.rdbCash.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.rdbCash.Location = new System.Drawing.Point(103, 26);
            this.rdbCash.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbCash.Size = new System.Drawing.Size(66, 21);
            this.rdbCash.TabIndex = 2;
            this.rdbCash.Text = "CASH";
            this.rdbCash.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(343, 58);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(88, 22);
            this.txtRef.TabIndex = 1;
            // 
            // txtPaymentDescription
            // 
            this.txtPaymentDescription.Location = new System.Drawing.Point(160, 91);
            this.txtPaymentDescription.Name = "txtPaymentDescription";
            this.txtPaymentDescription.Size = new System.Drawing.Size(271, 22);
            this.txtPaymentDescription.TabIndex = 2;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(160, 58);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(83, 22);
            this.txtAmount.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "PAYMENT TYPE";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(248, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "REFERENCE";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "DESCRIPTION";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(319, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(136, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "AMOUNT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = ":";
            // 
            // txtPostCustomerName
            // 
            this.txtPostCustomerName.Location = new System.Drawing.Point(134, 44);
            this.txtPostCustomerName.Name = "txtPostCustomerName";
            this.txtPostCustomerName.ReadOnly = true;
            this.txtPostCustomerName.Size = new System.Drawing.Size(313, 22);
            this.txtPostCustomerName.TabIndex = 1;
            this.txtPostCustomerName.TabStop = false;
            // 
            // txtPostCustomerLimitDays
            // 
            this.txtPostCustomerLimitDays.Location = new System.Drawing.Point(382, 90);
            this.txtPostCustomerLimitDays.Name = "txtPostCustomerLimitDays";
            this.txtPostCustomerLimitDays.ReadOnly = true;
            this.txtPostCustomerLimitDays.Size = new System.Drawing.Size(65, 22);
            this.txtPostCustomerLimitDays.TabIndex = 1;
            this.txtPostCustomerLimitDays.TabStop = false;
            // 
            // txtPostCustomerLimit
            // 
            this.txtPostCustomerLimit.Location = new System.Drawing.Point(134, 90);
            this.txtPostCustomerLimit.Name = "txtPostCustomerLimit";
            this.txtPostCustomerLimit.ReadOnly = true;
            this.txtPostCustomerLimit.Size = new System.Drawing.Size(91, 22);
            this.txtPostCustomerLimit.TabIndex = 1;
            this.txtPostCustomerLimit.TabStop = false;
            // 
            // txtPostCustomer
            // 
            this.txtPostCustomer.Location = new System.Drawing.Point(134, 14);
            this.txtPostCustomer.Name = "txtPostCustomer";
            this.txtPostCustomer.Size = new System.Drawing.Size(122, 22);
            this.txtPostCustomer.TabIndex = 0;
            this.txtPostCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPostCustomer_KeyDown);
            this.txtPostCustomer.Leave += new System.EventHandler(this.txtPostCustomer_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "CUSTOMER LIMIT DAYS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "CUSTOMER LIMIT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "CUSTOMER NAME";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "CUSTOMER CODE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 39);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(143, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAPTURE CUSTOMER PAYMENTS";
            // 
            // CustPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(560, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CustPayments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustPayments";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private RJButton BtnCancel;
        private RJButton BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private RJRadioButton rdbOther;
        private RJRadioButton rdbCheque;
        private RJRadioButton rdbMpesa;
        private RJRadioButton rdbCash;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.TextBox txtPaymentDescription;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPostCustomerName;
        private System.Windows.Forms.TextBox txtPostCustomerLimitDays;
        private System.Windows.Forms.TextBox txtPostCustomerLimit;
        private System.Windows.Forms.TextBox txtPostCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}