
namespace SHOPLITE
{
    partial class frmPOS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdWholesale = new System.Windows.Forms.RadioButton();
            this.RdRetail = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtProdDesc = new System.Windows.Forms.TextBox();
            this.TxtProdUnit = new System.Windows.Forms.TextBox();
            this.txtVatPer = new System.Windows.Forms.TextBox();
            this.TxtVat = new System.Windows.Forms.TextBox();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.TxtProdSp = new System.Windows.Forms.TextBox();
            this.TxtProdCd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancelReceipt = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.lbltotalamount = new System.Windows.Forms.Label();
            this.lblvantamount = new System.Windows.Forms.Label();
            this.lblNetamount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.GvReceipt = new System.Windows.Forms.DataGridView();
            this.ProdCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 94);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdWholesale);
            this.groupBox1.Controls.Add(this.RdRetail);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(186, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RdWholesale
            // 
            this.RdWholesale.AutoSize = true;
            this.RdWholesale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RdWholesale.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdWholesale.ForeColor = System.Drawing.Color.White;
            this.RdWholesale.Location = new System.Drawing.Point(358, 20);
            this.RdWholesale.Name = "RdWholesale";
            this.RdWholesale.Size = new System.Drawing.Size(126, 29);
            this.RdWholesale.TabIndex = 1;
            this.RdWholesale.Text = "Wholesale";
            this.RdWholesale.UseVisualStyleBackColor = true;
            this.RdWholesale.CheckedChanged += new System.EventHandler(this.RdWholesale_CheckedChanged);
            // 
            // RdRetail
            // 
            this.RdRetail.AutoSize = true;
            this.RdRetail.Checked = true;
            this.RdRetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RdRetail.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdRetail.ForeColor = System.Drawing.Color.White;
            this.RdRetail.Location = new System.Drawing.Point(218, 20);
            this.RdRetail.Name = "RdRetail";
            this.RdRetail.Size = new System.Drawing.Size(83, 29);
            this.RdRetail.TabIndex = 1;
            this.RdRetail.TabStop = true;
            this.RdRetail.Text = "Retail";
            this.RdRetail.UseVisualStyleBackColor = true;
            this.RdRetail.CheckedChanged += new System.EventHandler(this.RdRetail_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.OrangeRed;
            this.label11.Location = new System.Drawing.Point(17, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Customer Category:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TxtProdDesc);
            this.panel2.Controls.Add(this.TxtProdUnit);
            this.panel2.Controls.Add(this.txtVatPer);
            this.panel2.Controls.Add(this.TxtVat);
            this.panel2.Controls.Add(this.TxtQty);
            this.panel2.Controls.Add(this.TxtProdSp);
            this.panel2.Controls.Add(this.TxtProdCd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 94);
            this.panel2.TabIndex = 0;
            // 
            // TxtProdDesc
            // 
            this.TxtProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdDesc.Enabled = false;
            this.TxtProdDesc.Location = new System.Drawing.Point(334, 13);
            this.TxtProdDesc.Name = "TxtProdDesc";
            this.TxtProdDesc.Size = new System.Drawing.Size(340, 23);
            this.TxtProdDesc.TabIndex = 2;
            // 
            // TxtProdUnit
            // 
            this.TxtProdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProdUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdUnit.Enabled = false;
            this.TxtProdUnit.Location = new System.Drawing.Point(782, 13);
            this.TxtProdUnit.Name = "TxtProdUnit";
            this.TxtProdUnit.Size = new System.Drawing.Size(65, 23);
            this.TxtProdUnit.TabIndex = 2;
            // 
            // txtVatPer
            // 
            this.txtVatPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatPer.Enabled = false;
            this.txtVatPer.Location = new System.Drawing.Point(426, 54);
            this.txtVatPer.Name = "txtVatPer";
            this.txtVatPer.Size = new System.Drawing.Size(66, 23);
            this.txtVatPer.TabIndex = 2;
            // 
            // TxtVat
            // 
            this.TxtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVat.Enabled = false;
            this.TxtVat.Location = new System.Drawing.Point(262, 54);
            this.TxtVat.Name = "TxtVat";
            this.TxtVat.Size = new System.Drawing.Size(66, 23);
            this.TxtVat.TabIndex = 2;
            // 
            // TxtQty
            // 
            this.TxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtQty.Location = new System.Drawing.Point(575, 53);
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(87, 23);
            this.TxtQty.TabIndex = 1;
            this.TxtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQty_KeyDown);
            this.TxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQty_KeyPress);
            // 
            // TxtProdSp
            // 
            this.TxtProdSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdSp.Enabled = false;
            this.TxtProdSp.Location = new System.Drawing.Point(112, 53);
            this.TxtProdSp.Name = "TxtProdSp";
            this.TxtProdSp.Size = new System.Drawing.Size(95, 23);
            this.TxtProdSp.TabIndex = 2;
            this.TxtProdSp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProdSp_KeyPress);
            // 
            // TxtProdCd
            // 
            this.TxtProdCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdCd.Location = new System.Drawing.Point(112, 13);
            this.TxtProdCd.Name = "TxtProdCd";
            this.TxtProdCd.Size = new System.Drawing.Size(95, 23);
            this.TxtProdCd.TabIndex = 0;
            this.TxtProdCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProdCd_KeyDown);
            this.TxtProdCd.Leave += new System.EventHandler(this.TxtProdCd_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Desc:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(680, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product Unit:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Vat (%):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Vat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quantity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Code:";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(745, 45);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 38);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(859, 47);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 35);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 517);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 35);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancelReceipt);
            this.panel4.Controls.Add(this.BtnSave);
            this.panel4.Controls.Add(this.lbltotalamount);
            this.panel4.Controls.Add(this.lblvantamount);
            this.panel4.Controls.Add(this.lblNetamount);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 417);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(961, 100);
            this.panel4.TabIndex = 2;
            // 
            // btnCancelReceipt
            // 
            this.btnCancelReceipt.Location = new System.Drawing.Point(495, 39);
            this.btnCancelReceipt.Name = "btnCancelReceipt";
            this.btnCancelReceipt.Size = new System.Drawing.Size(75, 48);
            this.btnCancelReceipt.TabIndex = 2;
            this.btnCancelReceipt.Text = "CANCEL";
            this.btnCancelReceipt.UseVisualStyleBackColor = true;
            this.btnCancelReceipt.Click += new System.EventHandler(this.btnCancelReceipt_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(319, 39);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 48);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lbltotalamount
            // 
            this.lbltotalamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalamount.AutoSize = true;
            this.lbltotalamount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalamount.Location = new System.Drawing.Point(840, 69);
            this.lbltotalamount.Name = "lbltotalamount";
            this.lbltotalamount.Size = new System.Drawing.Size(43, 18);
            this.lbltotalamount.TabIndex = 1;
            this.lbltotalamount.Text = "0.00";
            // 
            // lblvantamount
            // 
            this.lblvantamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblvantamount.AutoSize = true;
            this.lblvantamount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvantamount.Location = new System.Drawing.Point(840, 44);
            this.lblvantamount.Name = "lblvantamount";
            this.lblvantamount.Size = new System.Drawing.Size(43, 18);
            this.lblvantamount.TabIndex = 1;
            this.lblvantamount.Text = "0.00";
            // 
            // lblNetamount
            // 
            this.lblNetamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetamount.AutoSize = true;
            this.lblNetamount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetamount.Location = new System.Drawing.Point(840, 19);
            this.lblNetamount.Name = "lblNetamount";
            this.lblNetamount.Size = new System.Drawing.Size(43, 18);
            this.lblNetamount.TabIndex = 1;
            this.lblNetamount.Text = "0.00";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(732, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total Amount:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(743, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Vat Amount:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(741, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Net Amount:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.GvReceipt);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(961, 229);
            this.panel5.TabIndex = 3;
            // 
            // GvReceipt
            // 
            this.GvReceipt.AllowUserToAddRows = false;
            this.GvReceipt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.GvReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GvReceipt.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GvReceipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdCd,
            this.ProdNm,
            this.ProdUnit,
            this.Qty,
            this.ProdSp,
            this.VatCode,
            this.Total,
            this.LineVat,
            this.Remove});
            this.GvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvReceipt.EnableHeadersVisualStyles = false;
            this.GvReceipt.Location = new System.Drawing.Point(0, 0);
            this.GvReceipt.Margin = new System.Windows.Forms.Padding(7);
            this.GvReceipt.Name = "GvReceipt";
            this.GvReceipt.ReadOnly = true;
            this.GvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvReceipt.Size = new System.Drawing.Size(961, 229);
            this.GvReceipt.TabIndex = 0;
            this.GvReceipt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvReceipt_CellDoubleClick);
            // 
            // ProdCd
            // 
            this.ProdCd.HeaderText = "Product Code";
            this.ProdCd.Name = "ProdCd";
            this.ProdCd.ReadOnly = true;
            this.ProdCd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProdCd.Width = 130;
            // 
            // ProdNm
            // 
            this.ProdNm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProdNm.HeaderText = "Product Description";
            this.ProdNm.Name = "ProdNm";
            this.ProdNm.ReadOnly = true;
            this.ProdNm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProdUnit
            // 
            this.ProdUnit.HeaderText = "Unit";
            this.ProdUnit.Name = "ProdUnit";
            this.ProdUnit.ReadOnly = true;
            this.ProdUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProdUnit.Width = 80;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Qty.Width = 80;
            // 
            // ProdSp
            // 
            this.ProdSp.HeaderText = "S.P.";
            this.ProdSp.Name = "ProdSp";
            this.ProdSp.ReadOnly = true;
            this.ProdSp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProdSp.Width = 80;
            // 
            // VatCode
            // 
            this.VatCode.HeaderText = "Vat";
            this.VatCode.Name = "VatCode";
            this.VatCode.ReadOnly = true;
            this.VatCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VatCode.Width = 80;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LineVat
            // 
            this.LineVat.HeaderText = "";
            this.LineVat.Name = "LineVat";
            this.LineVat.ReadOnly = true;
            this.LineVat.Visible = false;
            // 
            // Remove
            // 
            this.Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove.HeaderText = "";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.Text = "Edit";
            this.Remove.ToolTipText = "Remove item. Requires a Password.";
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 552);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView GvReceipt;
        private System.Windows.Forms.TextBox TxtProdDesc;
        private System.Windows.Forms.TextBox TxtProdUnit;
        private System.Windows.Forms.TextBox TxtProdSp;
        private System.Windows.Forms.TextBox TxtProdCd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtVat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVatPer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbltotalamount;
        private System.Windows.Forms.Label lblvantamount;
        private System.Windows.Forms.Label lblNetamount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineVat;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.Button btnCancelReceipt;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdWholesale;
        private System.Windows.Forms.RadioButton RdRetail;
        private System.Windows.Forms.Label label11;
    }
}