
namespace SHOPLITE.SearchFoms
{
    partial class frmSearchDept
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
            this.dgvDepts = new System.Windows.Forms.DataGridView();
            this.DeptCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchDept = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDepts
            // 
            this.dgvDepts.AllowUserToAddRows = false;
            this.dgvDepts.AllowUserToDeleteRows = false;
            this.dgvDepts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(206)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(251)))));
            this.dgvDepts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepts.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(54)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptCd,
            this.DeptNm});
            this.dgvDepts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepts.EnableHeadersVisualStyles = false;
            this.dgvDepts.Location = new System.Drawing.Point(0, 24);
            this.dgvDepts.MultiSelect = false;
            this.dgvDepts.Name = "dgvDepts";
            this.dgvDepts.ReadOnly = true;
            this.dgvDepts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDepts.RowHeadersVisible = false;
            this.dgvDepts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.dgvDepts.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDepts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepts.Size = new System.Drawing.Size(523, 213);
            this.dgvDepts.TabIndex = 3;
            this.dgvDepts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepts_CellDoubleClick);
            this.dgvDepts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDepts_KeyDown);
            // 
            // DeptCd
            // 
            this.DeptCd.DataPropertyName = "DeptCd";
            this.DeptCd.HeaderText = "Department Code";
            this.DeptCd.Name = "DeptCd";
            this.DeptCd.ReadOnly = true;
            this.DeptCd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeptCd.Width = 150;
            // 
            // DeptNm
            // 
            this.DeptNm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeptNm.DataPropertyName = "DeptNm";
            this.DeptNm.HeaderText = "Department Name";
            this.DeptNm.Name = "DeptNm";
            this.DeptNm.ReadOnly = true;
            this.DeptNm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtSearchDept
            // 
            this.txtSearchDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchDept.Location = new System.Drawing.Point(0, 0);
            this.txtSearchDept.Name = "txtSearchDept";
            this.txtSearchDept.Size = new System.Drawing.Size(523, 24);
            this.txtSearchDept.TabIndex = 2;
            this.txtSearchDept.TextChanged += new System.EventHandler(this.txtSearchDept_TextChanged);
            // 
            // frmSearchDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 237);
            this.Controls.Add(this.dgvDepts);
            this.Controls.Add(this.txtSearchDept);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchDept";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Department";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchDept_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDepts;
        private System.Windows.Forms.TextBox txtSearchDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptNm;
    }
}