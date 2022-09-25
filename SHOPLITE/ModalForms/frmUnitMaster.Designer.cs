
namespace SHOPLITE.ModalForms
{
    partial class frmUnitMaster
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.IsUnitActive = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUnitList = new System.Windows.Forms.Button();
            this.btnEditUnit = new System.Windows.Forms.Button();
            this.btnNewUnit = new System.Windows.Forms.Button();
            this.txtUnitCd = new System.Windows.Forms.TextBox();
            this.txtUnitNm = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(37, 47);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 13);
            label2.TabIndex = 0;
            label2.Text = "Unit Code:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(33, 78);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(71, 13);
            label3.TabIndex = 2;
            label3.Text = "Unit Name:";
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
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unit Master";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(517, 19);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(69, 17);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.IsUnitActive);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.btnUnitList);
            this.panel6.Controls.Add(this.btnEditUnit);
            this.panel6.Controls.Add(this.btnNewUnit);
            this.panel6.Controls.Add(label2);
            this.panel6.Controls.Add(this.txtUnitCd);
            this.panel6.Controls.Add(label3);
            this.panel6.Controls.Add(this.txtUnitNm);
            this.panel6.Location = new System.Drawing.Point(55, 149);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(469, 199);
            this.panel6.TabIndex = 2;
            // 
            // IsUnitActive
            // 
            this.IsUnitActive.AutoSize = true;
            this.IsUnitActive.Checked = true;
            this.IsUnitActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsUnitActive.Location = new System.Drawing.Point(293, 45);
            this.IsUnitActive.Name = "IsUnitActive";
            this.IsUnitActive.Size = new System.Drawing.Size(76, 17);
            this.IsUnitActive.TabIndex = 5;
            this.IsUnitActive.Text = "Is Active";
            this.IsUnitActive.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnUnitList
            // 
            this.btnUnitList.Location = new System.Drawing.Point(261, 128);
            this.btnUnitList.Name = "btnUnitList";
            this.btnUnitList.Size = new System.Drawing.Size(75, 36);
            this.btnUnitList.TabIndex = 4;
            this.btnUnitList.Text = "LIST";
            this.btnUnitList.UseVisualStyleBackColor = true;
            this.btnUnitList.Click += new System.EventHandler(this.btnUnitList_Click);
            // 
            // btnEditUnit
            // 
            this.btnEditUnit.Location = new System.Drawing.Point(164, 128);
            this.btnEditUnit.Name = "btnEditUnit";
            this.btnEditUnit.Size = new System.Drawing.Size(75, 36);
            this.btnEditUnit.TabIndex = 4;
            this.btnEditUnit.Text = "EDIT";
            this.btnEditUnit.UseVisualStyleBackColor = true;
            this.btnEditUnit.Click += new System.EventHandler(this.btnEditUnit_Click);
            // 
            // btnNewUnit
            // 
            this.btnNewUnit.Location = new System.Drawing.Point(75, 128);
            this.btnNewUnit.Name = "btnNewUnit";
            this.btnNewUnit.Size = new System.Drawing.Size(75, 36);
            this.btnNewUnit.TabIndex = 4;
            this.btnNewUnit.Text = "NEW";
            this.btnNewUnit.UseVisualStyleBackColor = true;
            this.btnNewUnit.Click += new System.EventHandler(this.btnNewUnit_Click);
            // 
            // txtUnitCd
            // 
            this.txtUnitCd.Location = new System.Drawing.Point(121, 43);
            this.txtUnitCd.Name = "txtUnitCd";
            this.txtUnitCd.Size = new System.Drawing.Size(118, 21);
            this.txtUnitCd.TabIndex = 1;
            this.txtUnitCd.Click += new System.EventHandler(this.txtUnitCd_Leave);
            // 
            // txtUnitNm
            // 
            this.txtUnitNm.Location = new System.Drawing.Point(121, 75);
            this.txtUnitNm.Name = "txtUnitNm";
            this.txtUnitNm.Size = new System.Drawing.Size(320, 21);
            this.txtUnitNm.TabIndex = 3;
            // 
            // frmUnitMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUnitMaster";
            this.Text = "frmUnitMaster";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUnitList;
        private System.Windows.Forms.Button btnEditUnit;
        private System.Windows.Forms.Button btnNewUnit;
        private System.Windows.Forms.TextBox txtUnitCd;
        private System.Windows.Forms.TextBox txtUnitNm;
        private System.Windows.Forms.CheckBox IsUnitActive;
    }
}