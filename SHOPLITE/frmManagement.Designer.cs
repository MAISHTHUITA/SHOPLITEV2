
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
            this.btn1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTill = new System.Windows.Forms.Button();
            this.btnBackUpDB = new System.Windows.Forms.Button();
            this.btnReason = new System.Windows.Forms.Button();
            this.btnGroups = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlmain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(3)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnTill);
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
            // btn1
            // 
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(729, 22);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 10);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(539, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 61);
            this.button3.TabIndex = 0;
            this.button3.Text = "REPRINT RECEIPTS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(448, -3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 61);
            this.button2.TabIndex = 0;
            this.button2.Text = "SALES";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnsale_Click);
            // 
            // btnTill
            // 
            this.btnTill.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnTill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTill.ForeColor = System.Drawing.Color.White;
            this.btnTill.Location = new System.Drawing.Point(357, -2);
            this.btnTill.Name = "btnTill";
            this.btnTill.Size = new System.Drawing.Size(92, 61);
            this.btnTill.TabIndex = 0;
            this.btnTill.Text = "TILL";
            this.btnTill.UseVisualStyleBackColor = true;
            this.btnTill.Click += new System.EventHandler(this.btnTill_Click);
            // 
            // btnBackUpDB
            // 
            this.btnBackUpDB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnBackUpDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackUpDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackUpDB.ForeColor = System.Drawing.Color.White;
            this.btnBackUpDB.Location = new System.Drawing.Point(266, -2);
            this.btnBackUpDB.Name = "btnBackUpDB";
            this.btnBackUpDB.Size = new System.Drawing.Size(92, 61);
            this.btnBackUpDB.TabIndex = 0;
            this.btnBackUpDB.Text = "Back-Up";
            this.btnBackUpDB.UseVisualStyleBackColor = true;
            this.btnBackUpDB.Click += new System.EventHandler(this.btnBackUpDB_Click);
            // 
            // btnReason
            // 
            this.btnReason.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReason.ForeColor = System.Drawing.Color.White;
            this.btnReason.Location = new System.Drawing.Point(175, -2);
            this.btnReason.Name = "btnReason";
            this.btnReason.Size = new System.Drawing.Size(92, 61);
            this.btnReason.TabIndex = 0;
            this.btnReason.Text = "Reason";
            this.btnReason.UseVisualStyleBackColor = true;
            this.btnReason.Click += new System.EventHandler(this.btnReason_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btnGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroups.ForeColor = System.Drawing.Color.White;
            this.btnGroups.Location = new System.Drawing.Point(84, -3);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(92, 61);
            this.btnGroups.TabIndex = 0;
            this.btnGroups.Text = "GROUPS";
            this.btnGroups.UseVisualStyleBackColor = true;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(-2, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "USERS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlmain
            // 
            this.pnlmain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlmain.BackColor = System.Drawing.Color.Transparent;
            this.pnlmain.Location = new System.Drawing.Point(204, 117);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(412, 316);
            this.pnlmain.TabIndex = 1;
            this.pnlmain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlmain_ControlRemoved);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 10);
            this.panel2.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(631, -2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 61);
            this.button4.TabIndex = 0;
            this.button4.Text = "VIEW RECEIPTS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnViewReceipts_Click);
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 471);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
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
        private System.Windows.Forms.Button btnTill;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button button4;
    }
}