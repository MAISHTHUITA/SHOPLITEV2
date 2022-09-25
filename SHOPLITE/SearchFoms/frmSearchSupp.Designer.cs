
namespace SHOPLITE.SearchFoms
{
    partial class frmSearchSupp
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
            this.dgvSupp = new System.Windows.Forms.DataGridView();
            this.SuppCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchSupp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSupp
            // 
            this.dgvSupp.AllowUserToAddRows = false;
            this.dgvSupp.AllowUserToDeleteRows = false;
            this.dgvSupp.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(206)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(251)))));
            this.dgvSupp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupp.BackgroundColor = System.Drawing.Color.White;
            this.dgvSupp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSupp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SuppCd,
            this.SupplierNam});
            this.dgvSupp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupp.EnableHeadersVisualStyles = false;
            this.dgvSupp.Location = new System.Drawing.Point(0, 24);
            this.dgvSupp.MultiSelect = false;
            this.dgvSupp.Name = "dgvSupp";
            this.dgvSupp.ReadOnly = true;
            this.dgvSupp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSupp.RowHeadersVisible = false;
            this.dgvSupp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.dgvSupp.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSupp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupp.Size = new System.Drawing.Size(416, 185);
            this.dgvSupp.TabIndex = 3;
            this.dgvSupp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupp_CellDoubleClick);
            this.dgvSupp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSupp_KeyDown);
            // 
            // SuppCd
            // 
            this.SuppCd.DataPropertyName = "SuppCd";
            this.SuppCd.HeaderText = "Supplier Code";
            this.SuppCd.Name = "SuppCd";
            this.SuppCd.ReadOnly = true;
            this.SuppCd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SuppCd.Width = 150;
            // 
            // SupplierNam
            // 
            this.SupplierNam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierNam.DataPropertyName = "SuppNm";
            this.SupplierNam.HeaderText = "Supplier Name";
            this.SupplierNam.Name = "SupplierNam";
            this.SupplierNam.ReadOnly = true;
            this.SupplierNam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtSearchSupp
            // 
            this.txtSearchSupp.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchSupp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSupp.Location = new System.Drawing.Point(0, 0);
            this.txtSearchSupp.Name = "txtSearchSupp";
            this.txtSearchSupp.Size = new System.Drawing.Size(416, 24);
            this.txtSearchSupp.TabIndex = 2;
            this.txtSearchSupp.TextChanged += new System.EventHandler(this.txtSearchSupp_TextChanged);
            // 
            // frmSearchSupp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 209);
            this.Controls.Add(this.dgvSupp);
            this.Controls.Add(this.txtSearchSupp);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchSupp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Supplier";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchSupp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSupp;
        private System.Windows.Forms.TextBox txtSearchSupp;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierNam;
    }
}