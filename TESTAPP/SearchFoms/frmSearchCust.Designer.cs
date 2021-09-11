
namespace SHOPLITE.SearchFoms
{
    partial class frmSearchCust
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCust = new System.Windows.Forms.DataGridView();
            this.CustCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchCust = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCust)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCust
            // 
            this.dgvCust.AllowUserToAddRows = false;
            this.dgvCust.AllowUserToDeleteRows = false;
            this.dgvCust.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(206)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(251)))));
            this.dgvCust.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCust.BackgroundColor = System.Drawing.Color.White;
            this.dgvCust.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCust.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCust.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCust.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustCd,
            this.CustNm});
            this.dgvCust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCust.EnableHeadersVisualStyles = false;
            this.dgvCust.Location = new System.Drawing.Point(0, 24);
            this.dgvCust.MultiSelect = false;
            this.dgvCust.Name = "dgvCust";
            this.dgvCust.ReadOnly = true;
            this.dgvCust.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCust.RowHeadersVisible = false;
            this.dgvCust.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            this.dgvCust.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCust.Size = new System.Drawing.Size(416, 185);
            this.dgvCust.TabIndex = 5;
            this.dgvCust.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCust_CellDoubleClick);
            this.dgvCust.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCust_KeyDown);
            // 
            // CustCd
            // 
            this.CustCd.DataPropertyName = "CustCd";
            this.CustCd.HeaderText = "Customer Code";
            this.CustCd.Name = "CustCd";
            this.CustCd.ReadOnly = true;
            this.CustCd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustCd.Width = 150;
            // 
            // CustNm
            // 
            this.CustNm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustNm.DataPropertyName = "CustNm";
            this.CustNm.HeaderText = "Customer Name";
            this.CustNm.Name = "CustNm";
            this.CustNm.ReadOnly = true;
            this.CustNm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtSearchCust
            // 
            this.txtSearchCust.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCust.Location = new System.Drawing.Point(0, 0);
            this.txtSearchCust.Name = "txtSearchCust";
            this.txtSearchCust.Size = new System.Drawing.Size(416, 24);
            this.txtSearchCust.TabIndex = 4;
            this.txtSearchCust.TextChanged += new System.EventHandler(this.txtSearchCust_TextChanged);
            // 
            // frmSearchCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 209);
            this.Controls.Add(this.dgvCust);
            this.Controls.Add(this.txtSearchCust);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchCust";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Customer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchCust_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustNm;
        private System.Windows.Forms.TextBox txtSearchCust;
    }
}