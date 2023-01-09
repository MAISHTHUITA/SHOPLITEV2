namespace SHOPLITE
{
    partial class frmSettings
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
            this.Printerbox = new System.Windows.Forms.GroupBox();
            this.rjButton1 = new SHOPLITE.RJButton();
            this.listofprinters = new SHOPLITE.RJComboBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnChangePolicy = new SHOPLITE.RJToggleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.changepolicy = new SHOPLITE.RJToggleButton();
            this.Printerbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Printerbox
            // 
            this.Printerbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Printerbox.Controls.Add(this.rjButton1);
            this.Printerbox.Controls.Add(this.listofprinters);
            this.Printerbox.Controls.Add(this.lblPrinter);
            this.Printerbox.Controls.Add(this.label5);
            this.Printerbox.Controls.Add(this.label3);
            this.Printerbox.Controls.Add(this.label4);
            this.Printerbox.Controls.Add(this.label2);
            this.Printerbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Printerbox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Printerbox.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.Printerbox.Location = new System.Drawing.Point(12, 52);
            this.Printerbox.Name = "Printerbox";
            this.Printerbox.Padding = new System.Windows.Forms.Padding(10);
            this.Printerbox.Size = new System.Drawing.Size(776, 101);
            this.Printerbox.TabIndex = 0;
            this.Printerbox.TabStop = false;
            this.Printerbox.Text = "Select Receipt Printer";
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(504, 45);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(82, 30);
            this.rjButton1.TabIndex = 2;
            this.rjButton1.Text = "Set";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // listofprinters
            // 
            this.listofprinters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listofprinters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listofprinters.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.listofprinters.BorderSize = 1;
            this.listofprinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.listofprinters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listofprinters.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.listofprinters.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.listofprinters.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.listofprinters.ListTextColor = System.Drawing.Color.DimGray;
            this.listofprinters.Location = new System.Drawing.Point(266, 45);
            this.listofprinters.MinimumSize = new System.Drawing.Size(200, 30);
            this.listofprinters.Name = "listofprinters";
            this.listofprinters.Padding = new System.Windows.Forms.Padding(1);
            this.listofprinters.Size = new System.Drawing.Size(200, 30);
            this.listofprinters.TabIndex = 1;
            this.listofprinters.Texts = "";
            // 
            // lblPrinter
            // 
            this.lblPrinter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinter.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lblPrinter.Location = new System.Drawing.Point(261, 24);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(104, 19);
            this.lblPrinter.TabIndex = 0;
            this.lblPrinter.Text = "Current Printer";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label5.Location = new System.Drawing.Point(246, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = ":";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label3.Location = new System.Drawing.Point(246, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label4.Location = new System.Drawing.Point(118, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Available Printers";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label2.Location = new System.Drawing.Point(117, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Printer";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label1.Location = new System.Drawing.Point(258, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "APPLICATION SETTINGS ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnChangePolicy);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.groupBox1.Location = new System.Drawing.Point(18, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Indicate to show VAT calculations on Receipt";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label6.Location = new System.Drawing.Point(86, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Show Vat calculation on Receipt";
            // 
            // BtnChangePolicy
            // 
            this.BtnChangePolicy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnChangePolicy.AutoSize = true;
            this.BtnChangePolicy.Checked = true;
            this.BtnChangePolicy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnChangePolicy.Location = new System.Drawing.Point(376, 25);
            this.BtnChangePolicy.MinimumSize = new System.Drawing.Size(45, 22);
            this.BtnChangePolicy.Name = "BtnChangePolicy";
            this.BtnChangePolicy.OffBackColor = System.Drawing.Color.Thistle;
            this.BtnChangePolicy.OffToggleColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.BtnChangePolicy.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnChangePolicy.OnToggleColor = System.Drawing.Color.LawnGreen;
            this.BtnChangePolicy.Size = new System.Drawing.Size(45, 22);
            this.BtnChangePolicy.TabIndex = 0;
            this.BtnChangePolicy.UseVisualStyleBackColor = true;
            this.BtnChangePolicy.CheckedChanged += new System.EventHandler(this.rjToggleButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.changepolicy);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.groupBox2.Location = new System.Drawing.Point(18, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Show Invoices In Reports";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label7.Location = new System.Drawing.Point(86, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Show Invoices calculation on Reports";
            // 
            // changepolicy
            // 
            this.changepolicy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changepolicy.AutoSize = true;
            this.changepolicy.Checked = true;
            this.changepolicy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changepolicy.Location = new System.Drawing.Point(376, 25);
            this.changepolicy.MinimumSize = new System.Drawing.Size(45, 22);
            this.changepolicy.Name = "changepolicy";
            this.changepolicy.OffBackColor = System.Drawing.Color.Thistle;
            this.changepolicy.OffToggleColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.changepolicy.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.changepolicy.OnToggleColor = System.Drawing.Color.LawnGreen;
            this.changepolicy.Size = new System.Drawing.Size(45, 22);
            this.changepolicy.TabIndex = 0;
            this.changepolicy.UseVisualStyleBackColor = true;
            this.changepolicy.CheckedChanged += new System.EventHandler(this.changepolicy_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Printerbox);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.Printerbox.ResumeLayout(false);
            this.Printerbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Printerbox;
        private System.Windows.Forms.Label label1;
        private RJComboBox listofprinters;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private RJButton rjButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private RJToggleButton BtnChangePolicy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private RJToggleButton changepolicy;
    }
}