namespace SHOPLITE.ModalForms
{
    partial class frmProductlist
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
            this.LblClose = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.fromdt = new System.Windows.Forms.DateTimePicker();
            this.txtDeptTo = new System.Windows.Forms.TextBox();
            this.txtSuppTo = new System.Windows.Forms.TextBox();
            this.txtProdTo = new System.Windows.Forms.TextBox();
            this.txtDeptFrom = new System.Windows.Forms.TextBox();
            this.txtSuppFrom = new System.Windows.Forms.TextBox();
            this.txtProdFrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtvatfrom = new System.Windows.Forms.TextBox();
            this.txtvatto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rdall = new System.Windows.Forms.RadioButton();
            this.rdpositive = new System.Windows.Forms.RadioButton();
            this.rdnegative = new System.Windows.Forms.RadioButton();
            this.rdzero = new System.Windows.Forms.RadioButton();
            this.txtfromunit = new System.Windows.Forms.TextBox();
            this.txttounit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.LblClose);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 41);
            this.panel1.TabIndex = 12;
            // 
            // LblClose
            // 
            this.LblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblClose.AutoSize = true;
            this.LblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClose.ForeColor = System.Drawing.Color.White;
            this.LblClose.Location = new System.Drawing.Point(303, 13);
            this.LblClose.Name = "LblClose";
            this.LblClose.Size = new System.Drawing.Size(69, 17);
            this.LblClose.TabIndex = 0;
            this.LblClose.Text = "[CLOSE]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(51, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(235, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "View Product List Reports";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(24, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 63);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(201, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.Location = new System.Drawing.Point(77, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 38);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdzero);
            this.groupBox1.Controls.Add(this.rdnegative);
            this.groupBox1.Controls.Add(this.rdpositive);
            this.groupBox1.Controls.Add(this.rdall);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtto);
            this.groupBox1.Controls.Add(this.fromdt);
            this.groupBox1.Controls.Add(this.txttounit);
            this.groupBox1.Controls.Add(this.txtvatto);
            this.groupBox1.Controls.Add(this.txtDeptTo);
            this.groupBox1.Controls.Add(this.txtSuppTo);
            this.groupBox1.Controls.Add(this.txtfromunit);
            this.groupBox1.Controls.Add(this.txtvatfrom);
            this.groupBox1.Controls.Add(this.txtProdTo);
            this.groupBox1.Controls.Add(this.txtDeptFrom);
            this.groupBox1.Controls.Add(this.txtSuppFrom);
            this.groupBox1.Controls.Add(this.txtProdFrom);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 232);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd-MMM-yyyy";
            this.dtto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(236, 22);
            this.dtto.Name = "dtto";
            this.dtto.ShowUpDown = true;
            this.dtto.Size = new System.Drawing.Size(112, 22);
            this.dtto.TabIndex = 1;
            // 
            // fromdt
            // 
            this.fromdt.CustomFormat = "dd-MMM-yyyy";
            this.fromdt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromdt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromdt.Location = new System.Drawing.Point(83, 22);
            this.fromdt.Name = "fromdt";
            this.fromdt.ShowUpDown = true;
            this.fromdt.Size = new System.Drawing.Size(115, 22);
            this.fromdt.TabIndex = 0;
            // 
            // txtDeptTo
            // 
            this.txtDeptTo.Location = new System.Drawing.Point(236, 111);
            this.txtDeptTo.Name = "txtDeptTo";
            this.txtDeptTo.Size = new System.Drawing.Size(112, 20);
            this.txtDeptTo.TabIndex = 7;
            // 
            // txtSuppTo
            // 
            this.txtSuppTo.Location = new System.Drawing.Point(236, 80);
            this.txtSuppTo.Name = "txtSuppTo";
            this.txtSuppTo.Size = new System.Drawing.Size(112, 20);
            this.txtSuppTo.TabIndex = 5;
            // 
            // txtProdTo
            // 
            this.txtProdTo.Location = new System.Drawing.Point(236, 51);
            this.txtProdTo.Name = "txtProdTo";
            this.txtProdTo.Size = new System.Drawing.Size(112, 20);
            this.txtProdTo.TabIndex = 3;
            // 
            // txtDeptFrom
            // 
            this.txtDeptFrom.Location = new System.Drawing.Point(83, 111);
            this.txtDeptFrom.Name = "txtDeptFrom";
            this.txtDeptFrom.Size = new System.Drawing.Size(115, 20);
            this.txtDeptFrom.TabIndex = 6;
            // 
            // txtSuppFrom
            // 
            this.txtSuppFrom.Location = new System.Drawing.Point(83, 80);
            this.txtSuppFrom.Name = "txtSuppFrom";
            this.txtSuppFrom.Size = new System.Drawing.Size(115, 20);
            this.txtSuppFrom.TabIndex = 4;
            // 
            // txtProdFrom
            // 
            this.txtProdFrom.Location = new System.Drawing.Point(83, 51);
            this.txtProdFrom.Name = "txtProdFrom";
            this.txtProdFrom.Size = new System.Drawing.Size(115, 20);
            this.txtProdFrom.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(18, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "From Dept:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "From Supplier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "From Prod Cd:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "From Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(204, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "To:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(204, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(204, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(204, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "To:";
            // 
            // txtvatfrom
            // 
            this.txtvatfrom.Location = new System.Drawing.Point(83, 163);
            this.txtvatfrom.Name = "txtvatfrom";
            this.txtvatfrom.Size = new System.Drawing.Size(115, 20);
            this.txtvatfrom.TabIndex = 6;
            // 
            // txtvatto
            // 
            this.txtvatto.Location = new System.Drawing.Point(236, 163);
            this.txtvatto.Name = "txtvatto";
            this.txtvatto.Size = new System.Drawing.Size(112, 20);
            this.txtvatto.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(18, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "From Vat:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(204, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "To:";
            // 
            // rdall
            // 
            this.rdall.AutoSize = true;
            this.rdall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdall.Location = new System.Drawing.Point(34, 203);
            this.rdall.Name = "rdall";
            this.rdall.Size = new System.Drawing.Size(36, 17);
            this.rdall.TabIndex = 25;
            this.rdall.TabStop = true;
            this.rdall.Text = "All";
            this.rdall.UseVisualStyleBackColor = true;
            // 
            // rdpositive
            // 
            this.rdpositive.AutoSize = true;
            this.rdpositive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdpositive.Location = new System.Drawing.Point(96, 203);
            this.rdpositive.Name = "rdpositive";
            this.rdpositive.Size = new System.Drawing.Size(62, 17);
            this.rdpositive.TabIndex = 25;
            this.rdpositive.TabStop = true;
            this.rdpositive.Text = "Positive";
            this.rdpositive.UseVisualStyleBackColor = true;
            // 
            // rdnegative
            // 
            this.rdnegative.AutoSize = true;
            this.rdnegative.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdnegative.Location = new System.Drawing.Point(184, 203);
            this.rdnegative.Name = "rdnegative";
            this.rdnegative.Size = new System.Drawing.Size(68, 17);
            this.rdnegative.TabIndex = 25;
            this.rdnegative.TabStop = true;
            this.rdnegative.Text = "Negative";
            this.rdnegative.UseVisualStyleBackColor = true;
            // 
            // rdzero
            // 
            this.rdzero.AutoSize = true;
            this.rdzero.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rdzero.Location = new System.Drawing.Point(285, 203);
            this.rdzero.Name = "rdzero";
            this.rdzero.Size = new System.Drawing.Size(47, 17);
            this.rdzero.TabIndex = 25;
            this.rdzero.TabStop = true;
            this.rdzero.Text = "Zero";
            this.rdzero.UseVisualStyleBackColor = true;
            // 
            // txtfromunit
            // 
            this.txtfromunit.Location = new System.Drawing.Point(83, 137);
            this.txtfromunit.Name = "txtfromunit";
            this.txtfromunit.Size = new System.Drawing.Size(115, 20);
            this.txtfromunit.TabIndex = 6;
            // 
            // txttounit
            // 
            this.txttounit.Location = new System.Drawing.Point(236, 137);
            this.txttounit.Name = "txttounit";
            this.txttounit.Size = new System.Drawing.Size(112, 20);
            this.txttounit.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(18, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "From Unit:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(204, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "To:";
            // 
            // frmProductlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 357);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProductlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductlist";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.DateTimePicker fromdt;
        private System.Windows.Forms.TextBox txtDeptTo;
        private System.Windows.Forms.TextBox txtSuppTo;
        private System.Windows.Forms.TextBox txtProdTo;
        private System.Windows.Forms.TextBox txtDeptFrom;
        private System.Windows.Forms.TextBox txtSuppFrom;
        private System.Windows.Forms.TextBox txtProdFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdzero;
        private System.Windows.Forms.RadioButton rdnegative;
        private System.Windows.Forms.RadioButton rdpositive;
        private System.Windows.Forms.RadioButton rdall;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvatto;
        private System.Windows.Forms.TextBox txtvatfrom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txttounit;
        private System.Windows.Forms.TextBox txtfromunit;
    }
}