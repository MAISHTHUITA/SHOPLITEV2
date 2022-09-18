
namespace SHOPLITE.ModalForms
{
    partial class frmGdRcv
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
            this.dgvgd = new System.Windows.Forms.DataGridView();
            this.ProdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatAmnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlgdproduct = new System.Windows.Forms.Panel();
            this.btngdclear = new System.Windows.Forms.Button();
            this.btngdadd = new System.Windows.Forms.Button();
            this.txtgdDesc = new System.Windows.Forms.TextBox();
            this.txtgdQty = new System.Windows.Forms.TextBox();
            this.txtgdCuqty = new System.Windows.Forms.TextBox();
            this.txtgdSp = new System.Windows.Forms.TextBox();
            this.txtgdCp = new System.Windows.Forms.TextBox();
            this.txtgdVatcd = new System.Windows.Forms.TextBox();
            this.txtgdUnit = new System.Windows.Forms.TextBox();
            this.txtgdProdNm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgd = new System.Windows.Forms.DateTimePicker();
            this.txtgdsupcd = new System.Windows.Forms.TextBox();
            this.txtInv = new System.Windows.Forms.TextBox();
            this.txtSn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsupnm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTtlAmt = new System.Windows.Forms.Label();
            this.lblVatAmt = new System.Windows.Forms.Label();
            this.lblNetAmt = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btngdPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btngdCancel = new System.Windows.Forms.Button();
            this.btngdNew = new System.Windows.Forms.Button();
            this.btngdSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgd)).BeginInit();
            this.pnlgdproduct.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvgd
            // 
            this.dgvgd.AllowUserToAddRows = false;
            this.dgvgd.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvgd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvgd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvgd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdCode,
            this.ProdDesc,
            this.Unit,
            this.Qty,
            this.Cost,
            this.VatAmnt,
            this.Amount});
            this.dgvgd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvgd.EnableHeadersVisualStyles = false;
            this.dgvgd.Location = new System.Drawing.Point(0, 139);
            this.dgvgd.Name = "dgvgd";
            this.dgvgd.ReadOnly = true;
            this.dgvgd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvgd.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvgd.RowHeadersWidth = 40;
            this.dgvgd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(164)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvgd.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvgd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvgd.Size = new System.Drawing.Size(914, 172);
            this.dgvgd.TabIndex = 5;
            this.dgvgd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRcv_CellDoubleClick);
            this.dgvgd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRcv_CellFormatting);
            // 
            // ProdCode
            // 
            this.ProdCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdCode.HeaderText = "Prod Code";
            this.ProdCode.Name = "ProdCode";
            this.ProdCode.ReadOnly = true;
            this.ProdCode.Width = 120;
            // 
            // ProdDesc
            // 
            this.ProdDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProdDesc.HeaderText = "Prod Desc";
            this.ProdDesc.Name = "ProdDesc";
            this.ProdDesc.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 80;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 70;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Width = 70;
            // 
            // VatAmnt
            // 
            this.VatAmnt.HeaderText = "VatAmnt";
            this.VatAmnt.Name = "VatAmnt";
            this.VatAmnt.ReadOnly = true;
            this.VatAmnt.Width = 80;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // pnlgdproduct
            // 
            this.pnlgdproduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlgdproduct.Controls.Add(this.btngdclear);
            this.pnlgdproduct.Controls.Add(this.btngdadd);
            this.pnlgdproduct.Controls.Add(this.txtgdDesc);
            this.pnlgdproduct.Controls.Add(this.txtgdQty);
            this.pnlgdproduct.Controls.Add(this.txtgdCuqty);
            this.pnlgdproduct.Controls.Add(this.txtgdSp);
            this.pnlgdproduct.Controls.Add(this.txtgdCp);
            this.pnlgdproduct.Controls.Add(this.txtgdVatcd);
            this.pnlgdproduct.Controls.Add(this.txtgdUnit);
            this.pnlgdproduct.Controls.Add(this.txtgdProdNm);
            this.pnlgdproduct.Controls.Add(this.label5);
            this.pnlgdproduct.Controls.Add(this.label11);
            this.pnlgdproduct.Controls.Add(this.label10);
            this.pnlgdproduct.Controls.Add(this.label9);
            this.pnlgdproduct.Controls.Add(this.label8);
            this.pnlgdproduct.Controls.Add(this.label7);
            this.pnlgdproduct.Controls.Add(this.label6);
            this.pnlgdproduct.Controls.Add(this.label4);
            this.pnlgdproduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlgdproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlgdproduct.Location = new System.Drawing.Point(0, 69);
            this.pnlgdproduct.Name = "pnlgdproduct";
            this.pnlgdproduct.Size = new System.Drawing.Size(914, 70);
            this.pnlgdproduct.TabIndex = 6;
            // 
            // btngdclear
            // 
            this.btngdclear.Location = new System.Drawing.Point(792, 41);
            this.btngdclear.Name = "btngdclear";
            this.btngdclear.Size = new System.Drawing.Size(91, 22);
            this.btngdclear.TabIndex = 3;
            this.btngdclear.Text = "CLEAR";
            this.btngdclear.UseVisualStyleBackColor = true;
            this.btngdclear.Click += new System.EventHandler(this.btngdclear_Click);
            // 
            // btngdadd
            // 
            this.btngdadd.Location = new System.Drawing.Point(707, 41);
            this.btngdadd.Name = "btngdadd";
            this.btngdadd.Size = new System.Drawing.Size(75, 22);
            this.btngdadd.TabIndex = 2;
            this.btngdadd.Text = "ADD";
            this.btngdadd.UseVisualStyleBackColor = true;
            this.btngdadd.Click += new System.EventHandler(this.btngdadd_Click);
            // 
            // txtgdDesc
            // 
            this.txtgdDesc.BackColor = System.Drawing.Color.White;
            this.txtgdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdDesc.Enabled = false;
            this.txtgdDesc.ForeColor = System.Drawing.Color.Black;
            this.txtgdDesc.Location = new System.Drawing.Point(313, 9);
            this.txtgdDesc.Name = "txtgdDesc";
            this.txtgdDesc.Size = new System.Drawing.Size(403, 21);
            this.txtgdDesc.TabIndex = 1;
            // 
            // txtgdQty
            // 
            this.txtgdQty.BackColor = System.Drawing.Color.White;
            this.txtgdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdQty.ForeColor = System.Drawing.Color.Black;
            this.txtgdQty.Location = new System.Drawing.Point(572, 42);
            this.txtgdQty.Name = "txtgdQty";
            this.txtgdQty.Size = new System.Drawing.Size(98, 21);
            this.txtgdQty.TabIndex = 1;
            this.txtgdQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgdQty_KeyPress);
            // 
            // txtgdCuqty
            // 
            this.txtgdCuqty.BackColor = System.Drawing.Color.White;
            this.txtgdCuqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdCuqty.Enabled = false;
            this.txtgdCuqty.ForeColor = System.Drawing.Color.Black;
            this.txtgdCuqty.Location = new System.Drawing.Point(413, 42);
            this.txtgdCuqty.Name = "txtgdCuqty";
            this.txtgdCuqty.Size = new System.Drawing.Size(81, 21);
            this.txtgdCuqty.TabIndex = 1;
            // 
            // txtgdSp
            // 
            this.txtgdSp.BackColor = System.Drawing.Color.White;
            this.txtgdSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdSp.Enabled = false;
            this.txtgdSp.ForeColor = System.Drawing.Color.Black;
            this.txtgdSp.Location = new System.Drawing.Point(278, 42);
            this.txtgdSp.Name = "txtgdSp";
            this.txtgdSp.Size = new System.Drawing.Size(72, 21);
            this.txtgdSp.TabIndex = 1;
            // 
            // txtgdCp
            // 
            this.txtgdCp.BackColor = System.Drawing.Color.White;
            this.txtgdCp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdCp.Enabled = false;
            this.txtgdCp.ForeColor = System.Drawing.Color.Black;
            this.txtgdCp.Location = new System.Drawing.Point(171, 42);
            this.txtgdCp.Name = "txtgdCp";
            this.txtgdCp.Size = new System.Drawing.Size(75, 21);
            this.txtgdCp.TabIndex = 1;
            // 
            // txtgdVatcd
            // 
            this.txtgdVatcd.BackColor = System.Drawing.Color.White;
            this.txtgdVatcd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdVatcd.Enabled = false;
            this.txtgdVatcd.ForeColor = System.Drawing.Color.Black;
            this.txtgdVatcd.Location = new System.Drawing.Point(91, 42);
            this.txtgdVatcd.Name = "txtgdVatcd";
            this.txtgdVatcd.Size = new System.Drawing.Size(49, 21);
            this.txtgdVatcd.TabIndex = 1;
            // 
            // txtgdUnit
            // 
            this.txtgdUnit.BackColor = System.Drawing.Color.White;
            this.txtgdUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdUnit.Enabled = false;
            this.txtgdUnit.ForeColor = System.Drawing.Color.Black;
            this.txtgdUnit.Location = new System.Drawing.Point(778, 9);
            this.txtgdUnit.Name = "txtgdUnit";
            this.txtgdUnit.Size = new System.Drawing.Size(91, 21);
            this.txtgdUnit.TabIndex = 1;
            // 
            // txtgdProdNm
            // 
            this.txtgdProdNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(181)))));
            this.txtgdProdNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgdProdNm.ForeColor = System.Drawing.Color.Black;
            this.txtgdProdNm.Location = new System.Drawing.Point(91, 7);
            this.txtgdProdNm.Name = "txtgdProdNm";
            this.txtgdProdNm.Size = new System.Drawing.Size(155, 21);
            this.txtgdProdNm.TabIndex = 0;
            this.txtgdProdNm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgdProdNm_KeyDown);
            this.txtgdProdNm.Leave += new System.EventHandler(this.txtgdProdNm_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Desc:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(500, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Qty Rcvd:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(354, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Curr. Qty:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "S.P:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "C.P:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Vat Code:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(724, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Unit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prod Code:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtgd);
            this.panel3.Controls.Add(this.txtgdsupcd);
            this.panel3.Controls.Add(this.txtInv);
            this.panel3.Controls.Add(this.txtSn);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblsupnm);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(914, 69);
            this.panel3.TabIndex = 4;
            // 
            // dtgd
            // 
            this.dtgd.CustomFormat = "dd-MMM-yyyy";
            this.dtgd.Enabled = false;
            this.dtgd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtgd.Location = new System.Drawing.Point(356, 9);
            this.dtgd.Name = "dtgd";
            this.dtgd.Size = new System.Drawing.Size(154, 22);
            this.dtgd.TabIndex = 2;
            // 
            // txtgdsupcd
            // 
            this.txtgdsupcd.Location = new System.Drawing.Point(90, 35);
            this.txtgdsupcd.Name = "txtgdsupcd";
            this.txtgdsupcd.Size = new System.Drawing.Size(155, 22);
            this.txtgdsupcd.TabIndex = 2;
            this.txtgdsupcd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgdsupcd_KeyDown);
            this.txtgdsupcd.Leave += new System.EventHandler(this.txtgdsupcd_Leave);
            // 
            // txtInv
            // 
            this.txtInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInv.Location = new System.Drawing.Point(752, 9);
            this.txtInv.Name = "txtInv";
            this.txtInv.Size = new System.Drawing.Size(118, 22);
            this.txtInv.TabIndex = 1;
            // 
            // txtSn
            // 
            this.txtSn.Location = new System.Drawing.Point(90, 9);
            this.txtSn.Name = "txtSn";
            this.txtSn.Size = new System.Drawing.Size(155, 22);
            this.txtSn.TabIndex = 0;
            this.txtSn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgdsupcd_KeyDown);
            this.txtSn.Leave += new System.EventHandler(this.txtSn_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sup. Cd:";
            // 
            // lblsupnm
            // 
            this.lblsupnm.AutoSize = true;
            this.lblsupnm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblsupnm.Location = new System.Drawing.Point(264, 39);
            this.lblsupnm.Name = "lblsupnm";
            this.lblsupnm.Size = new System.Drawing.Size(0, 14);
            this.lblsupnm.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(665, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inv No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial No.";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Controls.Add(this.btngdPrint);
            this.panel7.Controls.Add(this.btnExit);
            this.panel7.Controls.Add(this.btngdCancel);
            this.panel7.Controls.Add(this.btngdNew);
            this.panel7.Controls.Add(this.btngdSave);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 311);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(914, 145);
            this.panel7.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTtlAmt);
            this.panel1.Controls.Add(this.lblVatAmt);
            this.panel1.Controls.Add(this.lblNetAmt);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 81);
            this.panel1.TabIndex = 3;
            // 
            // lblTtlAmt
            // 
            this.lblTtlAmt.AutoSize = true;
            this.lblTtlAmt.Location = new System.Drawing.Point(754, 51);
            this.lblTtlAmt.Name = "lblTtlAmt";
            this.lblTtlAmt.Size = new System.Drawing.Size(0, 14);
            this.lblTtlAmt.TabIndex = 1;
            // 
            // lblVatAmt
            // 
            this.lblVatAmt.AutoSize = true;
            this.lblVatAmt.Location = new System.Drawing.Point(753, 30);
            this.lblVatAmt.Name = "lblVatAmt";
            this.lblVatAmt.Size = new System.Drawing.Size(0, 14);
            this.lblVatAmt.TabIndex = 1;
            // 
            // lblNetAmt
            // 
            this.lblNetAmt.AutoSize = true;
            this.lblNetAmt.Location = new System.Drawing.Point(754, 11);
            this.lblNetAmt.Name = "lblNetAmt";
            this.lblNetAmt.Size = new System.Drawing.Size(0, 14);
            this.lblNetAmt.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(677, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Total Amt:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(687, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "Vat Amt:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(685, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "Net Amt:";
            // 
            // btngdPrint
            // 
            this.btngdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))), ((int)(((byte)(143)))));
            this.btngdPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.btngdPrint.FlatAppearance.BorderSize = 2;
            this.btngdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngdPrint.ForeColor = System.Drawing.Color.White;
            this.btngdPrint.Location = new System.Drawing.Point(400, 96);
            this.btngdPrint.Name = "btngdPrint";
            this.btngdPrint.Size = new System.Drawing.Size(99, 36);
            this.btngdPrint.TabIndex = 2;
            this.btngdPrint.Text = "Print";
            this.btngdPrint.UseVisualStyleBackColor = false;
            this.btngdPrint.Click += new System.EventHandler(this.btngdPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))), ((int)(((byte)(143)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(658, 96);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btngdCancel
            // 
            this.btngdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))), ((int)(((byte)(143)))));
            this.btngdCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.btngdCancel.FlatAppearance.BorderSize = 2;
            this.btngdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngdCancel.ForeColor = System.Drawing.Color.White;
            this.btngdCancel.Location = new System.Drawing.Point(529, 96);
            this.btngdCancel.Name = "btngdCancel";
            this.btngdCancel.Size = new System.Drawing.Size(99, 36);
            this.btngdCancel.TabIndex = 3;
            this.btngdCancel.Text = "Cancel";
            this.btngdCancel.UseVisualStyleBackColor = false;
            this.btngdCancel.Click += new System.EventHandler(this.btngdCancel_Click);
            // 
            // btngdNew
            // 
            this.btngdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))), ((int)(((byte)(143)))));
            this.btngdNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.btngdNew.FlatAppearance.BorderSize = 2;
            this.btngdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngdNew.ForeColor = System.Drawing.Color.White;
            this.btngdNew.Location = new System.Drawing.Point(148, 96);
            this.btngdNew.Name = "btngdNew";
            this.btngdNew.Size = new System.Drawing.Size(99, 36);
            this.btngdNew.TabIndex = 0;
            this.btngdNew.Text = "New";
            this.btngdNew.UseVisualStyleBackColor = false;
            this.btngdNew.Click += new System.EventHandler(this.btngdNew_Click);
            // 
            // btngdSave
            // 
            this.btngdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))), ((int)(((byte)(143)))));
            this.btngdSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(192)))), ((int)(((byte)(240)))));
            this.btngdSave.FlatAppearance.BorderSize = 2;
            this.btngdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngdSave.ForeColor = System.Drawing.Color.White;
            this.btngdSave.Location = new System.Drawing.Point(273, 96);
            this.btngdSave.Name = "btngdSave";
            this.btngdSave.Size = new System.Drawing.Size(99, 36);
            this.btngdSave.TabIndex = 1;
            this.btngdSave.Text = "Save";
            this.btngdSave.UseVisualStyleBackColor = false;
            this.btngdSave.Click += new System.EventHandler(this.btngdSave_Click);
            // 
            // frmGdRcv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(914, 456);
            this.ControlBox = false;
            this.Controls.Add(this.dgvgd);
            this.Controls.Add(this.pnlgdproduct);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGdRcv";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmGdRcv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvgd)).EndInit();
            this.pnlgdproduct.ResumeLayout(false);
            this.pnlgdproduct.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvgd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatAmnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Panel pnlgdproduct;
        private System.Windows.Forms.Button btngdclear;
        private System.Windows.Forms.Button btngdadd;
        private System.Windows.Forms.TextBox txtgdDesc;
        private System.Windows.Forms.TextBox txtgdQty;
        private System.Windows.Forms.TextBox txtgdCuqty;
        private System.Windows.Forms.TextBox txtgdSp;
        private System.Windows.Forms.TextBox txtgdCp;
        private System.Windows.Forms.TextBox txtgdVatcd;
        private System.Windows.Forms.TextBox txtgdUnit;
        private System.Windows.Forms.TextBox txtgdProdNm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtgd;
        private System.Windows.Forms.TextBox txtgdsupcd;
        private System.Windows.Forms.TextBox txtInv;
        private System.Windows.Forms.TextBox txtSn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblsupnm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btngdPrint;
        private System.Windows.Forms.Button btngdCancel;
        private System.Windows.Forms.Button btngdNew;
        private System.Windows.Forms.Button btngdSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTtlAmt;
        private System.Windows.Forms.Label lblVatAmt;
        private System.Windows.Forms.Label lblNetAmt;
    }
}