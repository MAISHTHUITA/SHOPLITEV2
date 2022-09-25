
namespace SHOPLITE.ModalForms
{
    partial class frmDepartmentMaster
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
            System.Windows.Forms.Label deptCdLabel1;
            System.Windows.Forms.Label deptNmLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.IsDeptActive = new System.Windows.Forms.CheckBox();
            this.btnDeptCancel = new System.Windows.Forms.Button();
            this.btnListDept = new System.Windows.Forms.Button();
            this.btnEditDept = new System.Windows.Forms.Button();
            this.btnNewDept = new System.Windows.Forms.Button();
            this.deptCdTextBox = new System.Windows.Forms.TextBox();
            this.deptNmTextBox = new System.Windows.Forms.TextBox();
            deptCdLabel1 = new System.Windows.Forms.Label();
            deptNmLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // deptCdLabel1
            // 
            deptCdLabel1.AutoSize = true;
            deptCdLabel1.Location = new System.Drawing.Point(37, 30);
            deptCdLabel1.Name = "deptCdLabel1";
            deptCdLabel1.Size = new System.Drawing.Size(73, 13);
            deptCdLabel1.TabIndex = 0;
            deptCdLabel1.Text = "Dept Code:";
            // 
            // deptNmLabel
            // 
            deptNmLabel.AutoSize = true;
            deptNmLabel.Location = new System.Drawing.Point(33, 69);
            deptNmLabel.Name = "deptNmLabel";
            deptNmLabel.Size = new System.Drawing.Size(76, 13);
            deptNmLabel.TabIndex = 2;
            deptNmLabel.Text = "Dept Name:";
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
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Department Master";
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.IsDeptActive);
            this.panel5.Controls.Add(this.btnDeptCancel);
            this.panel5.Controls.Add(this.btnListDept);
            this.panel5.Controls.Add(this.btnEditDept);
            this.panel5.Controls.Add(this.btnNewDept);
            this.panel5.Controls.Add(deptCdLabel1);
            this.panel5.Controls.Add(this.deptCdTextBox);
            this.panel5.Controls.Add(deptNmLabel);
            this.panel5.Controls.Add(this.deptNmTextBox);
            this.panel5.Location = new System.Drawing.Point(55, 156);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(469, 182);
            this.panel5.TabIndex = 2;
            // 
            // IsDeptActive
            // 
            this.IsDeptActive.AutoSize = true;
            this.IsDeptActive.Checked = true;
            this.IsDeptActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsDeptActive.Location = new System.Drawing.Point(312, 28);
            this.IsDeptActive.Name = "IsDeptActive";
            this.IsDeptActive.Size = new System.Drawing.Size(76, 17);
            this.IsDeptActive.TabIndex = 5;
            this.IsDeptActive.Text = "Is Active";
            this.IsDeptActive.UseVisualStyleBackColor = true;
            // 
            // btnDeptCancel
            // 
            this.btnDeptCancel.Location = new System.Drawing.Point(334, 117);
            this.btnDeptCancel.Name = "btnDeptCancel";
            this.btnDeptCancel.Size = new System.Drawing.Size(75, 36);
            this.btnDeptCancel.TabIndex = 4;
            this.btnDeptCancel.Text = "CLEAR";
            this.btnDeptCancel.UseVisualStyleBackColor = true;
            this.btnDeptCancel.Click += new System.EventHandler(this.btnDeptCancel_Click);
            // 
            // btnListDept
            // 
            this.btnListDept.Location = new System.Drawing.Point(242, 117);
            this.btnListDept.Name = "btnListDept";
            this.btnListDept.Size = new System.Drawing.Size(75, 36);
            this.btnListDept.TabIndex = 4;
            this.btnListDept.Text = "LIST";
            this.btnListDept.UseVisualStyleBackColor = true;
            this.btnListDept.Click += new System.EventHandler(this.btnListDept_Click);
            // 
            // btnEditDept
            // 
            this.btnEditDept.Location = new System.Drawing.Point(150, 117);
            this.btnEditDept.Name = "btnEditDept";
            this.btnEditDept.Size = new System.Drawing.Size(75, 36);
            this.btnEditDept.TabIndex = 4;
            this.btnEditDept.Text = "EDIT";
            this.btnEditDept.UseVisualStyleBackColor = true;
            this.btnEditDept.Click += new System.EventHandler(this.btnEditDept_Click);
            // 
            // btnNewDept
            // 
            this.btnNewDept.Location = new System.Drawing.Point(58, 117);
            this.btnNewDept.Name = "btnNewDept";
            this.btnNewDept.Size = new System.Drawing.Size(75, 36);
            this.btnNewDept.TabIndex = 4;
            this.btnNewDept.Text = "NEW";
            this.btnNewDept.UseVisualStyleBackColor = true;
            this.btnNewDept.Click += new System.EventHandler(this.btnNewDept_Click);
            // 
            // deptCdTextBox
            // 
            this.deptCdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(181)))));
            this.deptCdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deptCdTextBox.Location = new System.Drawing.Point(126, 26);
            this.deptCdTextBox.Name = "deptCdTextBox";
            this.deptCdTextBox.Size = new System.Drawing.Size(118, 21);
            this.deptCdTextBox.TabIndex = 1;
            this.deptCdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.deptTextBox_KeyDown);
            this.deptCdTextBox.Leave += new System.EventHandler(this.deptCdTextBox_Leave);
            // 
            // deptNmTextBox
            // 
            this.deptNmTextBox.Location = new System.Drawing.Point(126, 66);
            this.deptNmTextBox.Name = "deptNmTextBox";
            this.deptNmTextBox.Size = new System.Drawing.Size(320, 21);
            this.deptNmTextBox.TabIndex = 3;
            // 
            // frmDepartmentMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 450);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDepartmentMaster";
            this.Text = "frmDepartmentMaster";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox IsDeptActive;
        private System.Windows.Forms.Button btnDeptCancel;
        private System.Windows.Forms.Button btnListDept;
        private System.Windows.Forms.Button btnEditDept;
        private System.Windows.Forms.Button btnNewDept;
        private System.Windows.Forms.TextBox deptCdTextBox;
        private System.Windows.Forms.TextBox deptNmTextBox;
    }
}