
namespace SHOPLITE.ModalForms
{
    partial class frmEditDept
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
            this.deptCdTextBox = new System.Windows.Forms.TextBox();
            this.deptNmTextBox = new System.Windows.Forms.TextBox();
            deptCdLabel = new System.Windows.Forms.Label();
            deptNmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deptCdLabel
            // 
            deptCdLabel.AutoSize = true;
            deptCdLabel.Location = new System.Drawing.Point(40, 34);
            deptCdLabel.Name = "deptCdLabel";
            deptCdLabel.Size = new System.Drawing.Size(78, 15);
            deptCdLabel.TabIndex = 6;
            deptCdLabel.Text = "Dept Code:";
            // 
            // deptNmLabel
            // 
            deptNmLabel.AutoSize = true;
            deptNmLabel.Location = new System.Drawing.Point(35, 75);
            deptNmLabel.Name = "deptNmLabel";
            deptNmLabel.Size = new System.Drawing.Size(83, 15);
            deptNmLabel.TabIndex = 8;
            deptNmLabel.Text = "Dept Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(287, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(126, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // deptCdTextBox
            // 
            this.deptCdTextBox.Location = new System.Drawing.Point(126, 32);
            this.deptCdTextBox.Name = "deptCdTextBox";
            this.deptCdTextBox.ReadOnly = true;
            this.deptCdTextBox.Size = new System.Drawing.Size(132, 21);
            this.deptCdTextBox.TabIndex = 7;
            // 
            // deptNmTextBox
            // 
            this.deptNmTextBox.Location = new System.Drawing.Point(126, 72);
            this.deptNmTextBox.Name = "deptNmTextBox";
            this.deptNmTextBox.Size = new System.Drawing.Size(331, 21);
            this.deptNmTextBox.TabIndex = 9;
            // 
            // frmEditDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orchid;
            this.ClientSize = new System.Drawing.Size(494, 166);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(deptCdLabel);
            this.Controls.Add(this.deptCdTextBox);
            this.Controls.Add(deptNmLabel);
            this.Controls.Add(this.deptNmTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditDept";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Department";
            this.Load += new System.EventHandler(this.frmEditDept_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox deptCdTextBox;
        private System.Windows.Forms.TextBox deptNmTextBox;
    }
}