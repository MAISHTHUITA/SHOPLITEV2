
namespace SHOPLITE
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.AppCloseBtn = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.lblLogindate = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftSidePanel = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.BtnUser = new System.Windows.Forms.Button();
            this.btnPos = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnManagement = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.LeftSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(22)))), ((int)(((byte)(205)))));
            this.TopPanel.Controls.Add(this.label6);
            this.TopPanel.Controls.Add(this.AppCloseBtn);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1134, 55);
            this.TopPanel.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(25, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(275, 29);
            this.label6.TabIndex = 1;
            this.label6.Text = "SHOPLITE VERSION 2";
            // 
            // AppCloseBtn
            // 
            this.AppCloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AppCloseBtn.BackColor = System.Drawing.Color.Red;
            this.AppCloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.AppCloseBtn.FlatAppearance.BorderSize = 5;
            this.AppCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppCloseBtn.Location = new System.Drawing.Point(1047, 9);
            this.AppCloseBtn.Name = "AppCloseBtn";
            this.AppCloseBtn.Size = new System.Drawing.Size(75, 37);
            this.AppCloseBtn.TabIndex = 0;
            this.AppCloseBtn.Text = "EXIT";
            this.AppCloseBtn.UseVisualStyleBackColor = false;
            this.AppCloseBtn.Click += new System.EventHandler(this.AppCloseBtn_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(134)))), ((int)(((byte)(103)))));
            this.BottomPanel.Controls.Add(this.lblLogindate);
            this.BottomPanel.Controls.Add(this.lblCompany);
            this.BottomPanel.Controls.Add(this.lblBranch);
            this.BottomPanel.Controls.Add(this.lblUser);
            this.BottomPanel.Controls.Add(this.lblVersion);
            this.BottomPanel.Controls.Add(this.label4);
            this.BottomPanel.Controls.Add(this.label5);
            this.BottomPanel.Controls.Add(this.label3);
            this.BottomPanel.Controls.Add(this.label2);
            this.BottomPanel.Controls.Add(this.label1);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 685);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1134, 30);
            this.BottomPanel.TabIndex = 2;
            // 
            // lblLogindate
            // 
            this.lblLogindate.AutoSize = true;
            this.lblLogindate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogindate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLogindate.Location = new System.Drawing.Point(104, 8);
            this.lblLogindate.Name = "lblLogindate";
            this.lblLogindate.Size = new System.Drawing.Size(0, 14);
            this.lblLogindate.TabIndex = 1;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.White;
            this.lblCompany.Location = new System.Drawing.Point(289, 8);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(0, 14);
            this.lblCompany.TabIndex = 0;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranch.ForeColor = System.Drawing.Color.White;
            this.lblBranch.Location = new System.Drawing.Point(609, 8);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(0, 14);
            this.lblBranch.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(867, 8);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 14);
            this.lblUser.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(1032, 8);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 14);
            this.lblVersion.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(961, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "VERSION:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(816, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "USER:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(532, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "BRANCH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(212, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "COMPANY:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN DATE:";
            // 
            // LeftSidePanel
            // 
            this.LeftSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(148)))), ((int)(((byte)(243)))));
            this.LeftSidePanel.Controls.Add(this.btnSetting);
            this.LeftSidePanel.Controls.Add(this.BtnUser);
            this.LeftSidePanel.Controls.Add(this.btnPos);
            this.LeftSidePanel.Controls.Add(this.btnProducts);
            this.LeftSidePanel.Controls.Add(this.btnReports);
            this.LeftSidePanel.Controls.Add(this.btnInventory);
            this.LeftSidePanel.Controls.Add(this.btnManagement);
            this.LeftSidePanel.Controls.Add(this.btnDashboard);
            this.LeftSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSidePanel.Location = new System.Drawing.Point(0, 55);
            this.LeftSidePanel.Name = "LeftSidePanel";
            this.LeftSidePanel.Size = new System.Drawing.Size(215, 630);
            this.LeftSidePanel.TabIndex = 3;
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(12, 535);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(189, 46);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "   Setting";
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = false;
            // 
            // BtnUser
            // 
            this.BtnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnUser.BackColor = System.Drawing.Color.Transparent;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUser.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.Image = ((System.Drawing.Image)(resources.GetObject("BtnUser.Image")));
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(12, 578);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(189, 46);
            this.BtnUser.TabIndex = 0;
            this.BtnUser.Text = "LOG OUT";
            this.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // btnPos
            // 
            this.btnPos.BackColor = System.Drawing.Color.Transparent;
            this.btnPos.FlatAppearance.BorderSize = 0;
            this.btnPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPos.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPos.Image = ((System.Drawing.Image)(resources.GetObject("btnPos.Image")));
            this.btnPos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPos.Location = new System.Drawing.Point(18, 214);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(189, 46);
            this.btnPos.TabIndex = 0;
            this.btnPos.Text = "  &Point of Sale";
            this.btnPos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPos.UseVisualStyleBackColor = false;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.Transparent;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(15, 58);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(189, 46);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "    &Masters";
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(18, 162);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(189, 46);
            this.btnReports.TabIndex = 0;
            this.btnReports.Text = "   &Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(18, 110);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(189, 46);
            this.btnInventory.TabIndex = 0;
            this.btnInventory.Text = "   &Inventory";
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnManagement
            // 
            this.btnManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnManagement.FlatAppearance.BorderSize = 0;
            this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagement.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnManagement.Image")));
            this.btnManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.Location = new System.Drawing.Point(12, 483);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(189, 46);
            this.btnManagement.TabIndex = 0;
            this.btnManagement.Text = "   Mana&gement";
            this.btnManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManagement.UseVisualStyleBackColor = false;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(15, 6);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(189, 46);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "   &Dash-Board";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPanel.Location = new System.Drawing.Point(215, 55);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(919, 630);
            this.MainPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 715);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.LeftSidePanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SHOP LITE VERSION 2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.LeftSidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel LeftSidePanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btnPos;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button BtnUser;
        private System.Windows.Forms.Button btnProducts;
        public System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label lblLogindate;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AppCloseBtn;
        private System.Windows.Forms.Label label6;
    }
}

