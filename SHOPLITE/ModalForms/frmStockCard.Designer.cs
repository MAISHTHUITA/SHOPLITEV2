﻿
namespace SHOPLITE.ModalForms
{
    partial class frmStockCard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.fromdt = new System.Windows.Forms.DateTimePicker();
            this.txtDeptTo = new System.Windows.Forms.TextBox();
            this.txtSuppTo = new System.Windows.Forms.TextBox();
            this.txtProdTo = new System.Windows.Forms.TextBox();
            this.txtDeptFrom = new System.Windows.Forms.TextBox();
            this.txtSuppFrom = new System.Windows.Forms.TextBox();
            this.txtProdFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblClose = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtto);
            this.groupBox1.Controls.Add(this.fromdt);
            this.groupBox1.Controls.Add(this.txtDeptTo);
            this.groupBox1.Controls.Add(this.txtSuppTo);
            this.groupBox1.Controls.Add(this.txtProdTo);
            this.groupBox1.Controls.Add(this.txtDeptFrom);
            this.groupBox1.Controls.Add(this.txtSuppFrom);
            this.groupBox1.Controls.Add(this.txtProdFrom);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(6, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtto
            // 
            this.dtto.CustomFormat = "dd-MMM-yyyy";
            this.dtto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtto.Location = new System.Drawing.Point(248, 40);
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
            this.fromdt.Location = new System.Drawing.Point(95, 40);
            this.fromdt.Name = "fromdt";
            this.fromdt.ShowUpDown = true;
            this.fromdt.Size = new System.Drawing.Size(115, 22);
            this.fromdt.TabIndex = 0;
            // 
            // txtDeptTo
            // 
            this.txtDeptTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtDeptTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeptTo.Location = new System.Drawing.Point(248, 129);
            this.txtDeptTo.Name = "txtDeptTo";
            this.txtDeptTo.Size = new System.Drawing.Size(112, 23);
            this.txtDeptTo.TabIndex = 7;
            this.txtDeptTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeptTo_KeyDown);
            this.txtDeptTo.Leave += new System.EventHandler(this.txtDeptTo_Leave);
            // 
            // txtSuppTo
            // 
            this.txtSuppTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtSuppTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuppTo.Location = new System.Drawing.Point(248, 98);
            this.txtSuppTo.Name = "txtSuppTo";
            this.txtSuppTo.Size = new System.Drawing.Size(112, 23);
            this.txtSuppTo.TabIndex = 5;
            this.txtSuppTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppTo_KeyDown);
            this.txtSuppTo.Leave += new System.EventHandler(this.txtSuppTo_Leave);
            // 
            // txtProdTo
            // 
            this.txtProdTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtProdTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdTo.Location = new System.Drawing.Point(248, 69);
            this.txtProdTo.Name = "txtProdTo";
            this.txtProdTo.Size = new System.Drawing.Size(112, 23);
            this.txtProdTo.TabIndex = 3;
            this.txtProdTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProdTo_KeyDown);
            this.txtProdTo.Leave += new System.EventHandler(this.txtProdTo_Leave);
            // 
            // txtDeptFrom
            // 
            this.txtDeptFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtDeptFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeptFrom.Location = new System.Drawing.Point(95, 129);
            this.txtDeptFrom.Name = "txtDeptFrom";
            this.txtDeptFrom.Size = new System.Drawing.Size(115, 23);
            this.txtDeptFrom.TabIndex = 6;
            this.txtDeptFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeptFrom_KeyDown);
            this.txtDeptFrom.Leave += new System.EventHandler(this.txtDeptFrom_Leave);
            // 
            // txtSuppFrom
            // 
            this.txtSuppFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtSuppFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuppFrom.Location = new System.Drawing.Point(95, 98);
            this.txtSuppFrom.Name = "txtSuppFrom";
            this.txtSuppFrom.Size = new System.Drawing.Size(115, 23);
            this.txtSuppFrom.TabIndex = 4;
            this.txtSuppFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuppFrom_KeyDown);
            this.txtSuppFrom.Leave += new System.EventHandler(this.txtSuppFrom_Leave);
            // 
            // txtProdFrom
            // 
            this.txtProdFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(187)))));
            this.txtProdFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdFrom.Location = new System.Drawing.Point(95, 69);
            this.txtProdFrom.Name = "txtProdFrom";
            this.txtProdFrom.Size = new System.Drawing.Size(115, 23);
            this.txtProdFrom.TabIndex = 2;
            this.txtProdFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProdFrom_KeyDown);
            this.txtProdFrom.Leave += new System.EventHandler(this.txtProdFrom_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "To:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "To:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "From Dept:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "From Supplier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "From Prod Cd:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "From Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(24, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 63);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(77, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 38);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.panel1.TabIndex = 9;
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
            this.LblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "View StockCard Reports";
            // 
            // frmStockCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(388, 357);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmPriceChange_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.DateTimePicker fromdt;
        private System.Windows.Forms.TextBox txtDeptTo;
        private System.Windows.Forms.TextBox txtSuppTo;
        private System.Windows.Forms.TextBox txtProdTo;
        private System.Windows.Forms.TextBox txtDeptFrom;
        private System.Windows.Forms.TextBox txtSuppFrom;
        private System.Windows.Forms.TextBox txtProdFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblClose;
        private System.Windows.Forms.Label label10;
    }
}