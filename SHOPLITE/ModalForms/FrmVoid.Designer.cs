namespace SHOPLITE.ModalForms
{
    partial class FrmVoid
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.reportdgv = new System.Windows.Forms.DataGridView();
            this.PosNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsVoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Void = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(914, 71);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.reportdgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(914, 333);
            this.panel3.TabIndex = 2;
            // 
            // reportdgv
            // 
            this.reportdgv.AllowUserToAddRows = false;
            this.reportdgv.AllowUserToDeleteRows = false;
            this.reportdgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.reportdgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportdgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportdgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.reportdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PosNumber,
            this.PosDate,
            this.Amnt,
            this.comment,
            this.UserName,
            this.IsVoid,
            this.Void});
            this.reportdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportdgv.EnableHeadersVisualStyles = false;
            this.reportdgv.Location = new System.Drawing.Point(0, 0);
            this.reportdgv.Name = "reportdgv";
            this.reportdgv.ReadOnly = true;
            this.reportdgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.reportdgv.RowHeadersVisible = false;
            this.reportdgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportdgv.ShowCellErrors = false;
            this.reportdgv.ShowCellToolTips = false;
            this.reportdgv.ShowEditingIcon = false;
            this.reportdgv.ShowRowErrors = false;
            this.reportdgv.Size = new System.Drawing.Size(914, 333);
            this.reportdgv.TabIndex = 0;
            this.reportdgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PosNumber
            // 
            this.PosNumber.HeaderText = "Receipt Number";
            this.PosNumber.Name = "PosNumber";
            this.PosNumber.ReadOnly = true;
            // 
            // PosDate
            // 
            this.PosDate.HeaderText = "Date";
            this.PosDate.Name = "PosDate";
            this.PosDate.ReadOnly = true;
            // 
            // Amnt
            // 
            this.Amnt.HeaderText = "Amount";
            this.Amnt.Name = "Amnt";
            this.Amnt.ReadOnly = true;
            // 
            // comment
            // 
            this.comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comment.HeaderText = "Customer";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Prepared By";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // IsVoid
            // 
            this.IsVoid.HeaderText = "Is Void?";
            this.IsVoid.Name = "IsVoid";
            this.IsVoid.ReadOnly = true;
            // 
            // Void
            // 
            this.Void.HeaderText = "Void";
            this.Void.Name = "Void";
            this.Void.ReadOnly = true;
            this.Void.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Void.Text = "Void Receipt";
            this.Void.UseColumnTextForButtonValue = true;
            // 
            // FrmVoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 456);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmVoid";
            this.Text = "FrmVoid";
            this.Load += new System.EventHandler(this.FrmVoid_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportdgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView reportdgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsVoid;
        private System.Windows.Forms.DataGridViewButtonColumn Void;
    }
}