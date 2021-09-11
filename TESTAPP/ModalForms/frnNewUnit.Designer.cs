
namespace SHOPLITE.ModalForms
{
    partial class frnNewUnit
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
            this.txtUnitcd = new System.Windows.Forms.TextBox();
            this.txtUnitnm = new System.Windows.Forms.TextBox();
            deptCdLabel = new System.Windows.Forms.Label();
            deptNmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(246, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // deptCdLabel
            // 
            deptCdLabel.AutoSize = true;
            deptCdLabel.Location = new System.Drawing.Point(22, 63);
            deptCdLabel.Name = "deptCdLabel";
            deptCdLabel.Size = new System.Drawing.Size(57, 13);
            deptCdLabel.TabIndex = 6;
            deptCdLabel.Text = "Unit Code:";
            // 
            // txtUnitcd
            // 
            this.txtUnitcd.Location = new System.Drawing.Point(91, 60);
            this.txtUnitcd.Name = "txtUnitcd";
            this.txtUnitcd.Size = new System.Drawing.Size(100, 20);
            this.txtUnitcd.TabIndex = 7;
            // 
            // deptNmLabel
            // 
            deptNmLabel.AutoSize = true;
            deptNmLabel.Location = new System.Drawing.Point(19, 98);
            deptNmLabel.Name = "deptNmLabel";
            deptNmLabel.Size = new System.Drawing.Size(60, 13);
            deptNmLabel.TabIndex = 8;
            deptNmLabel.Text = "Unit Name:";
            // 
            // txtUnitnm
            // 
            this.txtUnitnm.Location = new System.Drawing.Point(91, 95);
            this.txtUnitnm.Name = "txtUnitnm";
            this.txtUnitnm.Size = new System.Drawing.Size(333, 20);
            this.txtUnitnm.TabIndex = 9;
            // 
            // frnNewUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 180);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(deptCdLabel);
            this.Controls.Add(this.txtUnitcd);
            this.Controls.Add(deptNmLabel);
            this.Controls.Add(this.txtUnitnm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frnNewUnit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Unit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUnitcd;
        private System.Windows.Forms.TextBox txtUnitnm;
    }
}