
namespace SHOPLITE.ModalForms
{
    partial class frmPurchaseOrder
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
            this.dtpValidto = new System.Windows.Forms.DateTimePicker();
            this.dtpPoDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupcd = new System.Windows.Forms.TextBox();
            this.txtInstr2 = new System.Windows.Forms.TextBox();
            this.txtInstr1 = new System.Windows.Forms.TextBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.txtDeliverto = new System.Windows.Forms.TextBox();
            this.txtPoNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtProdNm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProdCd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtCurQty = new System.Windows.Forms.TextBox();
            this.txtSp = new System.Windows.Forms.TextBox();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvPo = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.lblSupname = new System.Windows.Forms.Label();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSupname);
            this.panel1.Controls.Add(this.dtpValidto);
            this.panel1.Controls.Add(this.dtpPoDate);
            this.panel1.Controls.Add(this.txtSupcd);
            this.panel1.Controls.Add(this.txtInstr2);
            this.panel1.Controls.Add(this.txtInstr1);
            this.panel1.Controls.Add(this.txtRefNo);
            this.panel1.Controls.Add(this.txtDeliverto);
            this.panel1.Controls.Add(this.txtPoNo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 95);
            this.panel1.TabIndex = 0;
            // 
            // dtpValidto
            // 
            this.dtpValidto.CustomFormat = "dd-MMM-yyyy";
            this.dtpValidto.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpValidto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValidto.Location = new System.Drawing.Point(516, 5);
            this.dtpValidto.Name = "dtpValidto";
            this.dtpValidto.Size = new System.Drawing.Size(110, 22);
            this.dtpValidto.TabIndex = 2;
            // 
            // dtpPoDate
            // 
            this.dtpPoDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPoDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpPoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPoDate.Location = new System.Drawing.Point(320, 5);
            this.dtpPoDate.Name = "dtpPoDate";
            this.dtpPoDate.Size = new System.Drawing.Size(110, 22);
            this.dtpPoDate.TabIndex = 2;
            // 
            // txtSupcd
            // 
            this.txtSupcd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.txtSupcd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupcd.Location = new System.Drawing.Point(108, 34);
            this.txtSupcd.Name = "txtSupcd";
            this.txtSupcd.Size = new System.Drawing.Size(100, 22);
            this.txtSupcd.TabIndex = 1;
            // 
            // txtInstr2
            // 
            this.txtInstr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstr2.Location = new System.Drawing.Point(516, 62);
            this.txtInstr2.Name = "txtInstr2";
            this.txtInstr2.Size = new System.Drawing.Size(328, 22);
            this.txtInstr2.TabIndex = 1;
            // 
            // txtInstr1
            // 
            this.txtInstr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstr1.Location = new System.Drawing.Point(108, 62);
            this.txtInstr1.Name = "txtInstr1";
            this.txtInstr1.Size = new System.Drawing.Size(334, 22);
            this.txtInstr1.TabIndex = 1;
            // 
            // txtRefNo
            // 
            this.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNo.Location = new System.Drawing.Point(720, 5);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(124, 22);
            this.txtRefNo.TabIndex = 1;
            // 
            // txtDeliverto
            // 
            this.txtDeliverto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliverto.Location = new System.Drawing.Point(538, 34);
            this.txtDeliverto.Name = "txtDeliverto";
            this.txtDeliverto.Size = new System.Drawing.Size(306, 22);
            this.txtDeliverto.TabIndex = 1;
            // 
            // txtPoNo
            // 
            this.txtPoNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPoNo.Location = new System.Drawing.Point(108, 5);
            this.txtPoNo.Name = "txtPoNo";
            this.txtPoNo.Size = new System.Drawing.Size(100, 22);
            this.txtPoNo.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(448, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Instr. 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Instr. 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Valid Upto.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "PO Date.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(657, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ref No.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Deliver To.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "LPO No.";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtProdNm);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtProdCd);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtUnit);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.txtCurQty);
            this.panel2.Controls.Add(this.txtSp);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtCp);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtVat);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 65);
            this.panel2.TabIndex = 1;
            // 
            // txtProdNm
            // 
            this.txtProdNm.BackColor = System.Drawing.Color.White;
            this.txtProdNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdNm.Location = new System.Drawing.Point(298, 5);
            this.txtProdNm.Name = "txtProdNm";
            this.txtProdNm.Size = new System.Drawing.Size(328, 22);
            this.txtProdNm.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Description.";
            // 
            // txtProdCd
            // 
            this.txtProdCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.txtProdCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdCd.Location = new System.Drawing.Point(108, 5);
            this.txtProdCd.Name = "txtProdCd";
            this.txtProdCd.Size = new System.Drawing.Size(100, 22);
            this.txtProdCd.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Product Code.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(634, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "Unit";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(752, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "Vat";
            // 
            // txtUnit
            // 
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Location = new System.Drawing.Point(669, 5);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(64, 22);
            this.txtUnit.TabIndex = 1;
            // 
            // txtCurQty
            // 
            this.txtCurQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurQty.Location = new System.Drawing.Point(451, 34);
            this.txtCurQty.Name = "txtCurQty";
            this.txtCurQty.Size = new System.Drawing.Size(59, 22);
            this.txtCurQty.TabIndex = 1;
            // 
            // txtSp
            // 
            this.txtSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSp.Location = new System.Drawing.Point(298, 34);
            this.txtSp.Name = "txtSp";
            this.txtSp.Size = new System.Drawing.Size(60, 22);
            this.txtSp.TabIndex = 1;
            // 
            // txtCp
            // 
            this.txtCp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCp.Location = new System.Drawing.Point(108, 34);
            this.txtCp.Name = "txtCp";
            this.txtCp.Size = new System.Drawing.Size(70, 22);
            this.txtCp.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(374, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 14);
            this.label15.TabIndex = 0;
            this.label15.Text = "Cur. Qty.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(242, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Cur. SP.";
            // 
            // txtVat
            // 
            this.txtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVat.Location = new System.Drawing.Point(787, 5);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(57, 22);
            this.txtVat.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "Cur. CP.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(526, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 14);
            this.label16.TabIndex = 0;
            this.label16.Text = "Qty.";
            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Location = new System.Drawing.Point(566, 34);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(59, 22);
            this.txtQty.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(657, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(768, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.BtnExit);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 310);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 95);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 74);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(855, 19);
            this.panel4.TabIndex = 0;
            // 
            // dgvPo
            // 
            this.dgvPo.AllowUserToAddRows = false;
            this.dgvPo.AllowUserToDeleteRows = false;
            this.dgvPo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.dgvPo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCode,
            this.Description,
            this.Unit,
            this.Quantity,
            this.CurCP,
            this.CurSP,
            this.Vat,
            this.Amount});
            this.dgvPo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPo.EnableHeadersVisualStyles = false;
            this.dgvPo.Location = new System.Drawing.Point(0, 160);
            this.dgvPo.Name = "dgvPo";
            this.dgvPo.ReadOnly = true;
            this.dgvPo.Size = new System.Drawing.Size(857, 150);
            this.dgvPo.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(192, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 36);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(424, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(540, 16);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 36);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblSupname
            // 
            this.lblSupname.AutoSize = true;
            this.lblSupname.Location = new System.Drawing.Point(254, 38);
            this.lblSupname.Name = "lblSupname";
            this.lblSupname.Size = new System.Drawing.Size(0, 14);
            this.lblSupname.TabIndex = 3;
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Prod. Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.ReadOnly = true;
            this.ProductCode.Width = 110;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 70;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // CurCP
            // 
            this.CurCP.HeaderText = "CP";
            this.CurCP.Name = "CurCP";
            this.CurCP.ReadOnly = true;
            this.CurCP.Width = 80;
            // 
            // CurSP
            // 
            this.CurSP.HeaderText = "SP";
            this.CurSP.Name = "CurSP";
            this.CurSP.ReadOnly = true;
            this.CurSP.Width = 80;
            // 
            // Vat
            // 
            this.Vat.HeaderText = "Vat";
            this.Vat.Name = "Vat";
            this.Vat.ReadOnly = true;
            this.Vat.Width = 70;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.ClientSize = new System.Drawing.Size(857, 405);
            this.Controls.Add(this.dgvPo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSupcd;
        private System.Windows.Forms.TextBox txtInstr1;
        private System.Windows.Forms.TextBox txtPoNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpValidto;
        private System.Windows.Forms.DateTimePicker dtpPoDate;
        private System.Windows.Forms.TextBox txtInstr2;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.TextBox txtDeliverto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtProdCd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProdNm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtSp;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCurQty;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvPo;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblSupname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}