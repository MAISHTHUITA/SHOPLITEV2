
namespace SHOPLITE.ModalForms
{
    partial class frmEditUnit
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
            System.Windows.Forms.Label deptCdLabel;
            System.Windows.Forms.Label deptNmLabel;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUnitCd = new System.Windows.Forms.TextBox();
            this.txtUnitNm = new System.Windows.Forms.TextBox();
            deptCdLabel = new System.Windows.Forms.Label();
            deptNmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deptCdLabel
            // 
            deptCdLabel.AutoSize = true;
            deptCdLabel.Location = new System.Drawing.Point(28, 40);
            deptCdLabel.Name = "deptCdLabel";
            deptCdLabel.Size = new System.Drawing.Size(57, 13);
            deptCdLabel.TabIndex = 6;
            deptCdLabel.Text = "Unit Code:";
            // 
            // deptNmLabel
            // 
            deptNmLabel.AutoSize = true;
            deptNmLabel.Location = new System.Drawing.Point(25, 75);
            deptNmLabel.Name = "deptNmLabel";
            deptNmLabel.Size = new System.Drawing.Size(60, 13);
            deptNmLabel.TabIndex = 8;
            deptNmLabel.Text = "Unit Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(252, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(131, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUnitCd
            // 
            this.txtUnitCd.Location = new System.Drawing.Point(97, 37);
            this.txtUnitCd.Name = "txtUnitCd";
            this.txtUnitCd.ReadOnly = true;
            this.txtUnitCd.Size = new System.Drawing.Size(100, 20);
            this.txtUnitCd.TabIndex = 7;
            // 
            // txtUnitNm
            // 
            this.txtUnitNm.Location = new System.Drawing.Point(97, 72);
            this.txtUnitNm.Name = "txtUnitNm";
            this.txtUnitNm.Size = new System.Drawing.Size(333, 20);
            this.txtUnitNm.TabIndex = 9;
            // 
            // frmEditUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 162);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(deptCdLabel);
            this.Controls.Add(this.txtUnitCd);
            this.Controls.Add(deptNmLabel);
            this.Controls.Add(this.txtUnitNm);
            this.Name = "frmEditUnit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Unit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUnitCd;
        private System.Windows.Forms.TextBox txtUnitNm;
    }
}