﻿
namespace SHOPLITE.ModalForms
{
    partial class frmChangeSp
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProdNm = new System.Windows.Forms.TextBox();
            this.txtProdCd = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.NewWholesaleSptxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.WholesaleoldSptxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "PRODUCT NAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "NEW R.S.P:";
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Location = new System.Drawing.Point(349, 122);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(53, 20);
            this.txtNewPrice.TabIndex = 5;
            this.txtNewPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Curr. R.S.P";
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(349, 90);
            this.txtSP.Name = "txtSP";
            this.txtSP.ReadOnly = true;
            this.txtSP.Size = new System.Drawing.Size(53, 20);
            this.txtSP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "PRODUCT CODE:";
            // 
            // txtProdNm
            // 
            this.txtProdNm.Location = new System.Drawing.Point(143, 59);
            this.txtProdNm.Name = "txtProdNm";
            this.txtProdNm.ReadOnly = true;
            this.txtProdNm.Size = new System.Drawing.Size(298, 20);
            this.txtProdNm.TabIndex = 7;
            // 
            // txtProdCd
            // 
            this.txtProdCd.Location = new System.Drawing.Point(143, 29);
            this.txtProdCd.Name = "txtProdCd";
            this.txtProdCd.ReadOnly = true;
            this.txtProdCd.Size = new System.Drawing.Size(102, 20);
            this.txtProdCd.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 39);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(143, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // NewWholesaleSptxt
            // 
            this.NewWholesaleSptxt.Location = new System.Drawing.Point(143, 122);
            this.NewWholesaleSptxt.Name = "NewWholesaleSptxt";
            this.NewWholesaleSptxt.Size = new System.Drawing.Size(53, 20);
            this.NewWholesaleSptxt.TabIndex = 5;
            this.NewWholesaleSptxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "NEW W.S.P:";
            // 
            // WholesaleoldSptxt
            // 
            this.WholesaleoldSptxt.Location = new System.Drawing.Point(143, 91);
            this.WholesaleoldSptxt.Name = "WholesaleoldSptxt";
            this.WholesaleoldSptxt.ReadOnly = true;
            this.WholesaleoldSptxt.Size = new System.Drawing.Size(53, 20);
            this.WholesaleoldSptxt.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Curr. W.S.P";
            // 
            // frmChangeSp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(461, 210);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NewWholesaleSptxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.WholesaleoldSptxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProdNm);
            this.Controls.Add(this.txtProdCd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeSp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Selling Price";
            this.Load += new System.EventHandler(this.frmChangeSp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProdNm;
        private System.Windows.Forms.TextBox txtProdCd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox NewWholesaleSptxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox WholesaleoldSptxt;
        private System.Windows.Forms.Label label6;
    }
}