
namespace SHOPLITE
{
    partial class frmManagement
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
            this.btnReason = new System.Windows.Forms.Button();
            this.btnGroups = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlmain = new System.Windows.Forms.Panel();
            this.btnBackUpDB = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(3)))), ((int)(((byte)(109)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnBackUpDB);
            this.panel1.Controls.Add(this.btnReason);
            this.panel1.Controls.Add(this.btnGroups);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 61);
            this.panel1.TabIndex = 0;
            // 
            // btnReason
            // 
            this.btnReason.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReason.FlatAppearance.BorderSize = 3;
            this.btnReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReason.ForeColor = System.Drawing.Color.White;
            this.btnReason.Location = new System.Drawing.Point(191, 10);
            this.btnReason.Name = "btnReason";
            this.btnReason.Size = new System.Drawing.Size(83, 35);
            this.btnReason.TabIndex = 0;
            this.btnReason.Text = "Reason";
            this.btnReason.UseVisualStyleBackColor = true;
            this.btnReason.Click += new System.EventHandler(this.btnReason_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGroups.FlatAppearance.BorderSize = 3;
            this.btnGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroups.ForeColor = System.Drawing.Color.White;
            this.btnGroups.Location = new System.Drawing.Point(102, 10);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(83, 35);
            this.btnGroups.TabIndex = 0;
            this.btnGroups.Text = "GROUPS";
            this.btnGroups.UseVisualStyleBackColor = true;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(13, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "USERS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlmain
            // 
            this.pnlmain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlmain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlmain.Location = new System.Drawing.Point(204, 117);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(412, 316);
            this.pnlmain.TabIndex = 1;
            // 
            // btnBackUpDB
            // 
            this.btnBackUpDB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBackUpDB.FlatAppearance.BorderSize = 3;
            this.btnBackUpDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackUpDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackUpDB.ForeColor = System.Drawing.Color.White;
            this.btnBackUpDB.Location = new System.Drawing.Point(280, 10);
            this.btnBackUpDB.Name = "btnBackUpDB";
            this.btnBackUpDB.Size = new System.Drawing.Size(83, 35);
            this.btnBackUpDB.TabIndex = 0;
            this.btnBackUpDB.Text = "Back-Up";
            this.btnBackUpDB.UseVisualStyleBackColor = true;
            this.btnBackUpDB.Click += new System.EventHandler(this.btnBackUpDB_Click);
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 471);
            this.ControlBox = false;
            this.Controls.Add(this.pnlmain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmManagement";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReason;
        private System.Windows.Forms.Button btnGroups;
        private System.Windows.Forms.Button btnBackUpDB;
    }
}