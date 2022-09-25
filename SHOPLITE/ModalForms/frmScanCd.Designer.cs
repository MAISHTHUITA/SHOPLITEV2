
namespace SHOPLITE.ModalForms
{
    partial class frmScanCd
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProdCd = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvScans = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdNm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScanCd = new System.Windows.Forms.TextBox();
            this.btnAddScan = new System.Windows.Forms.Button();
            this.btnClearScan = new System.Windows.Forms.Button();
            this.ScanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unitcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScans)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PRODUCT CODE";
            // 
            // txtProdCd
            // 
            this.txtProdCd.Location = new System.Drawing.Point(112, 20);
            this.txtProdCd.Name = "txtProdCd";
            this.txtProdCd.ReadOnly = true;
            this.txtProdCd.Size = new System.Drawing.Size(100, 20);
            this.txtProdCd.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(70, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvScans
            // 
            this.dgvScans.AllowUserToAddRows = false;
            this.dgvScans.AllowUserToDeleteRows = false;
            this.dgvScans.AllowUserToResizeColumns = false;
            this.dgvScans.AllowUserToResizeRows = false;
            this.dgvScans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScanCode,
            this.Unitcd});
            this.dgvScans.Location = new System.Drawing.Point(15, 111);
            this.dgvScans.Name = "dgvScans";
            this.dgvScans.ReadOnly = true;
            this.dgvScans.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvScans.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScans.Size = new System.Drawing.Size(411, 150);
            this.dgvScans.TabIndex = 3;
            this.dgvScans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScans_CellDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(151, 267);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 37);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(232, 267);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 37);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "CANCEL";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PRODUCT NAME";
            // 
            // txtProdNm
            // 
            this.txtProdNm.Location = new System.Drawing.Point(112, 53);
            this.txtProdNm.Name = "txtProdNm";
            this.txtProdNm.ReadOnly = true;
            this.txtProdNm.Size = new System.Drawing.Size(314, 20);
            this.txtProdNm.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ADD SCANCODE";
            // 
            // txtScanCd
            // 
            this.txtScanCd.Location = new System.Drawing.Point(110, 83);
            this.txtScanCd.Name = "txtScanCd";
            this.txtScanCd.Size = new System.Drawing.Size(197, 20);
            this.txtScanCd.TabIndex = 1;
            // 
            // btnAddScan
            // 
            this.btnAddScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddScan.ForeColor = System.Drawing.Color.Green;
            this.btnAddScan.Location = new System.Drawing.Point(337, 79);
            this.btnAddScan.Name = "btnAddScan";
            this.btnAddScan.Size = new System.Drawing.Size(33, 26);
            this.btnAddScan.TabIndex = 2;
            this.btnAddScan.Text = "+";
            this.btnAddScan.UseVisualStyleBackColor = true;
            this.btnAddScan.Click += new System.EventHandler(this.btnAddScan_Click);
            // 
            // btnClearScan
            // 
            this.btnClearScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearScan.Location = new System.Drawing.Point(393, 79);
            this.btnClearScan.Name = "btnClearScan";
            this.btnClearScan.Size = new System.Drawing.Size(33, 26);
            this.btnClearScan.TabIndex = 2;
            this.btnClearScan.Text = "-";
            this.btnClearScan.UseVisualStyleBackColor = true;
            this.btnClearScan.Click += new System.EventHandler(this.btnClearScan_Click);
            // 
            // ScanCode
            // 
            this.ScanCode.DataPropertyName = "ScanCd";
            this.ScanCode.HeaderText = "Scancode";
            this.ScanCode.Name = "ScanCode";
            this.ScanCode.ReadOnly = true;
            this.ScanCode.Width = 180;
            // 
            // Unitcd
            // 
            this.Unitcd.DataPropertyName = "Unitcd";
            this.Unitcd.HeaderText = "Unit Code";
            this.Unitcd.Name = "Unitcd";
            this.Unitcd.ReadOnly = true;
            // 
            // frmScanCd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 317);
            this.Controls.Add(this.dgvScans);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClearScan);
            this.Controls.Add(this.btnAddScan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtScanCd);
            this.Controls.Add(this.txtProdNm);
            this.Controls.Add(this.txtProdCd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanCd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan Code";
            this.Load += new System.EventHandler(this.frmScanCd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProdCd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvScans;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdNm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScanCd;
        private System.Windows.Forms.Button btnAddScan;
        private System.Windows.Forms.Button btnClearScan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unitcd;
    }
}