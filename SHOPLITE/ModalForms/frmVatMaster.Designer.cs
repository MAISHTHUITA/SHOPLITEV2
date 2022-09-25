
namespace SHOPLITE.ModalForms
{
    partial class frmVatMaster
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
            this.lblClose = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.IsVatActive = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnVatList = new System.Windows.Forms.Button();
            this.btnEditVat = new System.Windows.Forms.Button();
            this.btnNewVat = new System.Windows.Forms.Button();
            this.txtVatPercentage = new System.Windows.Forms.TextBox();
            this.txtVatCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(32)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 47);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vat Master";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(504, 19);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(69, 17);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.IsVatActive);
            this.panel7.Controls.Add(this.button6);
            this.panel7.Controls.Add(this.btnVatList);
            this.panel7.Controls.Add(this.btnEditVat);
            this.panel7.Controls.Add(this.btnNewVat);
            this.panel7.Controls.Add(this.txtVatPercentage);
            this.panel7.Controls.Add(this.txtVatCode);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(68, 132);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(463, 194);
            this.panel7.TabIndex = 2;
            // 
            // IsVatActive
            // 
            this.IsVatActive.AutoSize = true;
            this.IsVatActive.Checked = true;
            this.IsVatActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsVatActive.Location = new System.Drawing.Point(329, 48);
            this.IsVatActive.Name = "IsVatActive";
            this.IsVatActive.Size = new System.Drawing.Size(76, 17);
            this.IsVatActive.TabIndex = 3;
            this.IsVatActive.Text = "Is Active";
            this.IsVatActive.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(343, 119);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 34);
            this.button6.TabIndex = 2;
            this.button6.Text = "button2";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnVatList
            // 
            this.btnVatList.Location = new System.Drawing.Point(251, 119);
            this.btnVatList.Name = "btnVatList";
            this.btnVatList.Size = new System.Drawing.Size(75, 34);
            this.btnVatList.TabIndex = 2;
            this.btnVatList.Text = "LIST";
            this.btnVatList.UseVisualStyleBackColor = true;
            this.btnVatList.Click += new System.EventHandler(this.btnVatList_Click);
            // 
            // btnEditVat
            // 
            this.btnEditVat.Location = new System.Drawing.Point(157, 119);
            this.btnEditVat.Name = "btnEditVat";
            this.btnEditVat.Size = new System.Drawing.Size(75, 34);
            this.btnEditVat.TabIndex = 2;
            this.btnEditVat.Text = "EDIT";
            this.btnEditVat.UseVisualStyleBackColor = true;
            this.btnEditVat.Click += new System.EventHandler(this.btnEditVat_Click);
            // 
            // btnNewVat
            // 
            this.btnNewVat.Location = new System.Drawing.Point(66, 119);
            this.btnNewVat.Name = "btnNewVat";
            this.btnNewVat.Size = new System.Drawing.Size(75, 34);
            this.btnNewVat.TabIndex = 2;
            this.btnNewVat.Text = "NEW";
            this.btnNewVat.UseVisualStyleBackColor = true;
            this.btnNewVat.Click += new System.EventHandler(this.btnNewVat_Click);
            // 
            // txtVatPercentage
            // 
            this.txtVatPercentage.Location = new System.Drawing.Point(124, 72);
            this.txtVatPercentage.Name = "txtVatPercentage";
            this.txtVatPercentage.Size = new System.Drawing.Size(108, 21);
            this.txtVatPercentage.TabIndex = 1;
            // 
            // txtVatCode
            // 
            this.txtVatCode.Location = new System.Drawing.Point(124, 46);
            this.txtVatCode.Name = "txtVatCode";
            this.txtVatCode.Size = new System.Drawing.Size(108, 21);
            this.txtVatCode.TabIndex = 1;
            this.txtVatCode.Click += new System.EventHandler(this.txtVatCode_Leave);
            this.txtVatCode.Leave += new System.EventHandler(this.txtVatCode_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "VAT %:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "VAT CODE:";
            // 
            // frmVatMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVatMaster";
            this.Text = "frmVatMaster";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnVatList;
        private System.Windows.Forms.Button btnEditVat;
        private System.Windows.Forms.Button btnNewVat;
        private System.Windows.Forms.TextBox txtVatPercentage;
        private System.Windows.Forms.TextBox txtVatCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox IsVatActive;
    }
}