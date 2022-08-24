
namespace SHOPLITE
{
    partial class frmReports
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
            this.btnViewGrn = new System.Windows.Forms.Button();
            this.btnStockcard = new System.Windows.Forms.Button();
            this.btnPrcChange = new System.Windows.Forms.Button();
            this.mainpnl = new System.Windows.Forms.Panel();
            this.btnProdlist = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.btnProdlist);
            this.panel1.Controls.Add(this.btnViewGrn);
            this.panel1.Controls.Add(this.btnStockcard);
            this.panel1.Controls.Add(this.btnPrcChange);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 58);
            this.panel1.TabIndex = 0;
            // 
            // btnViewGrn
            // 
            this.btnViewGrn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnViewGrn.FlatAppearance.BorderSize = 2;
            this.btnViewGrn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewGrn.ForeColor = System.Drawing.Color.White;
            this.btnViewGrn.Location = new System.Drawing.Point(186, 13);
            this.btnViewGrn.Name = "btnViewGrn";
            this.btnViewGrn.Size = new System.Drawing.Size(73, 39);
            this.btnViewGrn.TabIndex = 0;
            this.btnViewGrn.Text = "View Grn";
            this.btnViewGrn.UseVisualStyleBackColor = true;
            this.btnViewGrn.Click += new System.EventHandler(this.btnViewgrn_Click);
            // 
            // btnStockcard
            // 
            this.btnStockcard.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnStockcard.FlatAppearance.BorderSize = 2;
            this.btnStockcard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockcard.ForeColor = System.Drawing.Color.White;
            this.btnStockcard.Location = new System.Drawing.Point(99, 13);
            this.btnStockcard.Name = "btnStockcard";
            this.btnStockcard.Size = new System.Drawing.Size(73, 39);
            this.btnStockcard.TabIndex = 0;
            this.btnStockcard.Text = "Stock Card";
            this.btnStockcard.UseVisualStyleBackColor = true;
            this.btnStockcard.Click += new System.EventHandler(this.btnStockCard_Click);
            // 
            // btnPrcChange
            // 
            this.btnPrcChange.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPrcChange.FlatAppearance.BorderSize = 2;
            this.btnPrcChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrcChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrcChange.ForeColor = System.Drawing.Color.White;
            this.btnPrcChange.Location = new System.Drawing.Point(12, 13);
            this.btnPrcChange.Name = "btnPrcChange";
            this.btnPrcChange.Size = new System.Drawing.Size(73, 39);
            this.btnPrcChange.TabIndex = 0;
            this.btnPrcChange.Text = "Price Change";
            this.btnPrcChange.UseVisualStyleBackColor = true;
            this.btnPrcChange.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainpnl
            // 
            this.mainpnl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainpnl.BackColor = System.Drawing.Color.Transparent;
            this.mainpnl.Location = new System.Drawing.Point(210, 127);
            this.mainpnl.Name = "mainpnl";
            this.mainpnl.Size = new System.Drawing.Size(476, 358);
            this.mainpnl.TabIndex = 1;
            // 
            // btnProdlist
            // 
            this.btnProdlist.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnProdlist.FlatAppearance.BorderSize = 2;
            this.btnProdlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdlist.ForeColor = System.Drawing.Color.White;
            this.btnProdlist.Location = new System.Drawing.Point(281, 12);
            this.btnProdlist.Name = "btnProdlist";
            this.btnProdlist.Size = new System.Drawing.Size(73, 39);
            this.btnProdlist.TabIndex = 0;
            this.btnProdlist.Text = "Product List";
            this.btnProdlist.UseVisualStyleBackColor = true;
            this.btnProdlist.Click += new System.EventHandler(this.btnProdlist_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 629);
            this.Controls.Add(this.mainpnl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReports";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainpnl;
        private System.Windows.Forms.Button btnPrcChange;
        private System.Windows.Forms.Button btnStockcard;
        private System.Windows.Forms.Button btnViewGrn;
        private System.Windows.Forms.Button btnProdlist;
    }
}