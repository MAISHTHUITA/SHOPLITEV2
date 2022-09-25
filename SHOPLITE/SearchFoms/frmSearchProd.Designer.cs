
namespace SHOPLITE.SearchFoms
{
    partial class frmSearchProd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProds = new System.Windows.Forms.DataGridView();
            this.ProdCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchProd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProds
            // 
            this.dgvProds.AllowUserToAddRows = false;
            this.dgvProds.AllowUserToDeleteRows = false;
            this.dgvProds.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(206)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(251)))));
            this.dgvProds.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProds.BackgroundColor = System.Drawing.Color.White;
            this.dgvProds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProds.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdCd,
            this.ProdNm,
            this.Qty,
            this.UnitCd,
            this.Cp,
            this.Sp});
            this.dgvProds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProds.EnableHeadersVisualStyles = false;
            this.dgvProds.Location = new System.Drawing.Point(0, 24);
            this.dgvProds.MultiSelect = false;
            this.dgvProds.Name = "dgvProds";
            this.dgvProds.ReadOnly = true;
            this.dgvProds.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProds.RowHeadersVisible = false;
            this.dgvProds.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.dgvProds.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProds.Size = new System.Drawing.Size(867, 315);
            this.dgvProds.TabIndex = 5;
            this.dgvProds.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProds_CellContentDoubleClick);
            this.dgvProds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProds_KeyDown);
            this.dgvProds.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProds_KeyUp);
            // 
            // ProdCd
            // 
            this.ProdCd.DataPropertyName = "ProdCd";
            this.ProdCd.HeaderText = "Product Code";
            this.ProdCd.Name = "ProdCd";
            this.ProdCd.ReadOnly = true;
            this.ProdCd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProdCd.Width = 150;
            // 
            // ProdNm
            // 
            this.ProdNm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProdNm.DataPropertyName = "ProdNm";
            this.ProdNm.HeaderText = "Product Description";
            this.ProdNm.Name = "ProdNm";
            this.ProdNm.ReadOnly = true;
            this.ProdNm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "QtyAvble";
            this.Qty.HeaderText = "Qty Avai.";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 130;
            // 
            // UnitCd
            // 
            this.UnitCd.DataPropertyName = "UnitCd";
            this.UnitCd.HeaderText = "Unit";
            this.UnitCd.Name = "UnitCd";
            this.UnitCd.ReadOnly = true;
            // 
            // Cp
            // 
            this.Cp.DataPropertyName = "Cp";
            this.Cp.HeaderText = "C. Price";
            this.Cp.Name = "Cp";
            this.Cp.ReadOnly = true;
            // 
            // Sp
            // 
            this.Sp.DataPropertyName = "Sp";
            this.Sp.HeaderText = "S. Price";
            this.Sp.Name = "Sp";
            this.Sp.ReadOnly = true;
            // 
            // txtSearchProd
            // 
            this.txtSearchProd.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProd.Location = new System.Drawing.Point(0, 0);
            this.txtSearchProd.Name = "txtSearchProd";
            this.txtSearchProd.Size = new System.Drawing.Size(867, 24);
            this.txtSearchProd.TabIndex = 4;
            this.txtSearchProd.TextChanged += new System.EventHandler(this.txtSearchProd_TextChanged);
            // 
            // frmSearchProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 339);
            this.Controls.Add(this.dgvProds);
            this.Controls.Add(this.txtSearchProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchProd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSearchProd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchProd_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProds;
        private System.Windows.Forms.TextBox txtSearchProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sp;
    }
}