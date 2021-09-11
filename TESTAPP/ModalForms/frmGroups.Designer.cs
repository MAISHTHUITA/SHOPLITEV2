
namespace SHOPLITE.ModalForms
{
    partial class frmGroups
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupname = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAddStock = new System.Windows.Forms.CheckBox();
            this.cbIssueStock = new System.Windows.Forms.CheckBox();
            this.cbViewStock = new System.Windows.Forms.CheckBox();
            this.cbAdjustStock = new System.Windows.Forms.CheckBox();
            this.cbManageUsers = new System.Windows.Forms.CheckBox();
            this.cbChangeSp = new System.Windows.Forms.CheckBox();
            this.cbChangeCp = new System.Windows.Forms.CheckBox();
            this.isGroupActive = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "GROUP CODE";
            // 
            // txtGroupcode
            // 
            this.txtGroupcode.Location = new System.Drawing.Point(108, 13);
            this.txtGroupcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGroupcode.Name = "txtGroupcode";
            this.txtGroupcode.Size = new System.Drawing.Size(81, 22);
            this.txtGroupcode.TabIndex = 0;
            this.txtGroupcode.Leave += new System.EventHandler(this.txtGroupcode_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "GROUP NAME";
            // 
            // txtGroupname
            // 
            this.txtGroupname.Location = new System.Drawing.Point(108, 41);
            this.txtGroupname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGroupname.Name = "txtGroupname";
            this.txtGroupname.Size = new System.Drawing.Size(209, 22);
            this.txtGroupname.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(60, 184);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 38);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 184);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "MANAGE USER GROUPS";
            // 
            // cbAddStock
            // 
            this.cbAddStock.AutoSize = true;
            this.cbAddStock.Location = new System.Drawing.Point(42, 88);
            this.cbAddStock.Name = "cbAddStock";
            this.cbAddStock.Size = new System.Drawing.Size(98, 18);
            this.cbAddStock.TabIndex = 2;
            this.cbAddStock.Text = "ADD STOCK";
            this.cbAddStock.UseVisualStyleBackColor = true;
            // 
            // cbIssueStock
            // 
            this.cbIssueStock.AutoSize = true;
            this.cbIssueStock.Location = new System.Drawing.Point(190, 88);
            this.cbIssueStock.Name = "cbIssueStock";
            this.cbIssueStock.Size = new System.Drawing.Size(110, 18);
            this.cbIssueStock.TabIndex = 3;
            this.cbIssueStock.Text = "ISSUE STOCK";
            this.cbIssueStock.UseVisualStyleBackColor = true;
            // 
            // cbViewStock
            // 
            this.cbViewStock.AutoSize = true;
            this.cbViewStock.Location = new System.Drawing.Point(190, 112);
            this.cbViewStock.Name = "cbViewStock";
            this.cbViewStock.Size = new System.Drawing.Size(106, 18);
            this.cbViewStock.TabIndex = 4;
            this.cbViewStock.Text = "VIEW STOCK";
            this.cbViewStock.UseVisualStyleBackColor = true;
            // 
            // cbAdjustStock
            // 
            this.cbAdjustStock.AutoSize = true;
            this.cbAdjustStock.Location = new System.Drawing.Point(42, 112);
            this.cbAdjustStock.Name = "cbAdjustStock";
            this.cbAdjustStock.Size = new System.Drawing.Size(118, 18);
            this.cbAdjustStock.TabIndex = 5;
            this.cbAdjustStock.Text = "ADJUST STOCK";
            this.cbAdjustStock.UseVisualStyleBackColor = true;
            // 
            // cbManageUsers
            // 
            this.cbManageUsers.AutoSize = true;
            this.cbManageUsers.Location = new System.Drawing.Point(42, 160);
            this.cbManageUsers.Name = "cbManageUsers";
            this.cbManageUsers.Size = new System.Drawing.Size(123, 18);
            this.cbManageUsers.TabIndex = 6;
            this.cbManageUsers.Text = "MANAGE USERS";
            this.cbManageUsers.UseVisualStyleBackColor = true;
            // 
            // cbChangeSp
            // 
            this.cbChangeSp.AutoSize = true;
            this.cbChangeSp.Location = new System.Drawing.Point(42, 136);
            this.cbChangeSp.Name = "cbChangeSp";
            this.cbChangeSp.Size = new System.Drawing.Size(98, 18);
            this.cbChangeSp.TabIndex = 8;
            this.cbChangeSp.Text = "CHANGE SP";
            this.cbChangeSp.UseVisualStyleBackColor = true;
            // 
            // cbChangeCp
            // 
            this.cbChangeCp.AutoSize = true;
            this.cbChangeCp.Location = new System.Drawing.Point(190, 136);
            this.cbChangeCp.Name = "cbChangeCp";
            this.cbChangeCp.Size = new System.Drawing.Size(99, 18);
            this.cbChangeCp.TabIndex = 7;
            this.cbChangeCp.Text = "CHANGE CP";
            this.cbChangeCp.UseVisualStyleBackColor = true;
            // 
            // isGroupActive
            // 
            this.isGroupActive.AutoSize = true;
            this.isGroupActive.Checked = true;
            this.isGroupActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isGroupActive.Location = new System.Drawing.Point(190, 161);
            this.isGroupActive.Name = "isGroupActive";
            this.isGroupActive.Size = new System.Drawing.Size(79, 18);
            this.isGroupActive.TabIndex = 11;
            this.isGroupActive.Text = "Is Active";
            this.isGroupActive.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtGroupcode);
            this.panel1.Controls.Add(this.isGroupActive);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbViewStock);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbChangeCp);
            this.panel1.Controls.Add(this.txtGroupname);
            this.panel1.Controls.Add(this.cbManageUsers);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cbIssueStock);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.cbChangeSp);
            this.panel1.Controls.Add(this.cbAddStock);
            this.panel1.Controls.Add(this.cbAdjustStock);
            this.panel1.Location = new System.Drawing.Point(27, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 240);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(3)))), ((int)(((byte)(109)))));
            this.panel2.Controls.Add(this.lblClose);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 47);
            this.panel2.TabIndex = 13;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(323, 13);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(69, 17);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "[CLOSE]";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 315);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmGroups";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAddStock;
        private System.Windows.Forms.CheckBox cbIssueStock;
        private System.Windows.Forms.CheckBox cbViewStock;
        private System.Windows.Forms.CheckBox cbAdjustStock;
        private System.Windows.Forms.CheckBox cbManageUsers;
        private System.Windows.Forms.CheckBox cbChangeSp;
        private System.Windows.Forms.CheckBox cbChangeCp;
        private System.Windows.Forms.CheckBox isGroupActive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblClose;
    }
}