
namespace SHOPLITE.ModalForms
{
    partial class frmViewGrn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromSupp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToSupp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFromGrn = new System.Windows.Forms.TextBox();
            this.txtToGrn = new System.Windows.Forms.TextBox();
            this.fromDt = new System.Windows.Forms.DateTimePicker();
            this.toDt = new System.Windows.Forms.DateTimePicker();
            this.rbSum = new System.Windows.Forms.RadioButton();
            this.rbDet = new System.Windows.Forms.RadioButton();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.LblClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 41);
            this.panel1.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "From Supp:";
            // 
            // txtFromSupp
            // 
            this.txtFromSupp.Location = new System.Drawing.Point(77, 153);
            this.txtFromSupp.Name = "txtFromSupp";
            this.txtFromSupp.Size = new System.Drawing.Size(100, 21);
            this.txtFromSupp.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "To Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "To Supp:";
            // 
            // txtToSupp
            // 
            this.txtToSupp.Location = new System.Drawing.Point(257, 153);
            this.txtToSupp.Name = "txtToSupp";
            this.txtToSupp.Size = new System.Drawing.Size(100, 21);
            this.txtToSupp.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "From Grn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "To Grn:";
            // 
            // txtFromGrn
            // 
            this.txtFromGrn.Location = new System.Drawing.Point(77, 183);
            this.txtFromGrn.Name = "txtFromGrn";
            this.txtFromGrn.Size = new System.Drawing.Size(100, 21);
            this.txtFromGrn.TabIndex = 4;
            this.txtFromGrn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromGrn_KeyPress);
            // 
            // txtToGrn
            // 
            this.txtToGrn.Location = new System.Drawing.Point(257, 183);
            this.txtToGrn.Name = "txtToGrn";
            this.txtToGrn.Size = new System.Drawing.Size(100, 21);
            this.txtToGrn.TabIndex = 5;
            this.txtToGrn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromGrn_KeyPress);
            // 
            // fromDt
            // 
            this.fromDt.CalendarMonthBackground = System.Drawing.Color.AntiqueWhite;
            this.fromDt.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.fromDt.CustomFormat = "dd-MMM-yyyy";
            this.fromDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDt.Location = new System.Drawing.Point(78, 123);
            this.fromDt.Name = "fromDt";
            this.fromDt.ShowUpDown = true;
            this.fromDt.Size = new System.Drawing.Size(99, 21);
            this.fromDt.TabIndex = 0;
            // 
            // toDt
            // 
            this.toDt.CalendarMonthBackground = System.Drawing.Color.AntiqueWhite;
            this.toDt.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue;
            this.toDt.CustomFormat = "dd-MMM-yyyy";
            this.toDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDt.Location = new System.Drawing.Point(257, 123);
            this.toDt.Name = "toDt";
            this.toDt.ShowUpDown = true;
            this.toDt.Size = new System.Drawing.Size(99, 21);
            this.toDt.TabIndex = 1;
            // 
            // rbSum
            // 
            this.rbSum.AutoSize = true;
            this.rbSum.Checked = true;
            this.rbSum.Location = new System.Drawing.Point(78, 214);
            this.rbSum.Name = "rbSum";
            this.rbSum.Size = new System.Drawing.Size(81, 17);
            this.rbSum.TabIndex = 4;
            this.rbSum.TabStop = true;
            this.rbSum.Text = "Summary";
            this.rbSum.UseVisualStyleBackColor = true;
            // 
            // rbDet
            // 
            this.rbDet.AutoSize = true;
            this.rbDet.Location = new System.Drawing.Point(257, 214);
            this.rbDet.Name = "rbDet";
            this.rbDet.Size = new System.Drawing.Size(72, 17);
            this.rbDet.TabIndex = 4;
            this.rbDet.TabStop = true;
            this.rbDet.Text = "Detailed";
            this.rbDet.UseVisualStyleBackColor = true;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(89, 296);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 41);
            this.BtnPrint.TabIndex = 6;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "View GRN Reports";
            // 
            // frmViewGrn
            // 
            this.AcceptButton = this.BtnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 357);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.rbDet);
            this.Controls.Add(this.rbSum);
            this.Controls.Add(this.toDt);
            this.Controls.Add(this.fromDt);
            this.Controls.Add(this.txtToGrn);
            this.Controls.Add(this.txtFromGrn);
            this.Controls.Add(this.txtToSupp);
            this.Controls.Add(this.txtFromSupp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewGrn";
            this.Text = "frmViewGrn";
            this.Load += new System.EventHandler(this.frmViewGrn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromSupp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToSupp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFromGrn;
        private System.Windows.Forms.TextBox txtToGrn;
        private System.Windows.Forms.DateTimePicker fromDt;
        private System.Windows.Forms.DateTimePicker toDt;
        private System.Windows.Forms.RadioButton rbSum;
        private System.Windows.Forms.RadioButton rbDet;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
    }
}