
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtcustcode = new System.Windows.Forms.TextBox();
            this.rBExistingCustomer = new System.Windows.Forms.RadioButton();
            this.rBWalkinCustomer = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RdRetail = new System.Windows.Forms.RadioButton();
            this.RdWholesale = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtProdUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtProdSp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVatPer = new System.Windows.Forms.TextBox();
            this.TxtVat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtProdDesc = new System.Windows.Forms.TextBox();
            this.TxtProdCd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltips = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNetamount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbltotalamount = new System.Windows.Forms.Label();
            this.lblvantamount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelReceipt = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label11 = new System.Windows.Forms.Label();
            this.lblcustlimit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(961, 114);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(18, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblcustlimit);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.lblCustomerName);
            this.groupBox5.Controls.Add(this.txtcustcode);
            this.groupBox5.Controls.Add(this.rBExistingCustomer);
            this.groupBox5.Controls.Add(this.rBWalkinCustomer);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(278, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(646, 60);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CUSTOMER TYPE";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(275, 29);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 20);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Visible = false;
            // 
            // txtcustcode
            // 
            this.txtcustcode.BackColor = System.Drawing.Color.White;
            this.txtcustcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcustcode.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustcode.Location = new System.Drawing.Point(167, 26);
            this.txtcustcode.Name = "txtcustcode";
            this.txtcustcode.Size = new System.Drawing.Size(91, 26);
            this.txtcustcode.TabIndex = 2;
            this.txtcustcode.Visible = false;
            this.txtcustcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcustcode_KeyDown);
            this.txtcustcode.Leave += new System.EventHandler(this.txtcustcode_Leave);
            // 
            // rBExistingCustomer
            // 
            this.rBExistingCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rBExistingCustomer.AutoSize = true;
            this.rBExistingCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBExistingCustomer.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBExistingCustomer.ForeColor = System.Drawing.Color.White;
            this.rBExistingCustomer.Location = new System.Drawing.Point(85, 27);
            this.rBExistingCustomer.Name = "rBExistingCustomer";
            this.rBExistingCustomer.Size = new System.Drawing.Size(76, 24);
            this.rBExistingCustomer.TabIndex = 1;
            this.rBExistingCustomer.Text = "Existing";
            this.rBExistingCustomer.UseVisualStyleBackColor = true;
            this.rBExistingCustomer.CheckedChanged += new System.EventHandler(this.rBExistingCustomer_CheckedChanged);
            // 
            // rBWalkinCustomer
            // 
            this.rBWalkinCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rBWalkinCustomer.AutoSize = true;
            this.rBWalkinCustomer.Checked = true;
            this.rBWalkinCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBWalkinCustomer.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBWalkinCustomer.ForeColor = System.Drawing.Color.White;
            this.rBWalkinCustomer.Location = new System.Drawing.Point(6, 27);
            this.rBWalkinCustomer.Name = "rBWalkinCustomer";
            this.rBWalkinCustomer.Size = new System.Drawing.Size(75, 24);
            this.rBWalkinCustomer.TabIndex = 1;
            this.rBWalkinCustomer.TabStop = true;
            this.rBWalkinCustomer.Text = "Walk In ";
            this.rBWalkinCustomer.UseVisualStyleBackColor = false;
            this.rBWalkinCustomer.CheckedChanged += new System.EventHandler(this.rBWalkinCustomer_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RdRetail);
            this.groupBox4.Controls.Add(this.RdWholesale);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(10, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 60);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CUSTOMER CATEGORY";
            // 
            // RdRetail
            // 
            this.RdRetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdRetail.AutoSize = true;
            this.RdRetail.Checked = true;
            this.RdRetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RdRetail.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdRetail.ForeColor = System.Drawing.Color.White;
            this.RdRetail.Location = new System.Drawing.Point(5, 27);
            this.RdRetail.Name = "RdRetail";
            this.RdRetail.Size = new System.Drawing.Size(61, 24);
            this.RdRetail.TabIndex = 1;
            this.RdRetail.TabStop = true;
            this.RdRetail.Text = "Retail";
            this.RdRetail.UseVisualStyleBackColor = false;
            this.RdRetail.CheckedChanged += new System.EventHandler(this.RdRetail_CheckedChanged);
            // 
            // RdWholesale
            // 
            this.RdWholesale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdWholesale.AutoSize = true;
            this.RdWholesale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RdWholesale.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdWholesale.ForeColor = System.Drawing.Color.White;
            this.RdWholesale.Location = new System.Drawing.Point(103, 27);
            this.RdWholesale.Name = "RdWholesale";
            this.RdWholesale.Size = new System.Drawing.Size(89, 24);
            this.RdWholesale.TabIndex = 1;
            this.RdWholesale.Text = "Wholesale";
            this.RdWholesale.UseVisualStyleBackColor = true;
            this.RdWholesale.CheckedChanged += new System.EventHandler(this.RdWholesale_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.TxtProdDesc);
            this.panel2.Controls.Add(this.TxtProdCd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 167);
            this.panel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtProdUnit);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtQty);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(467, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 117);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classification";
            // 
            // TxtProdUnit
            // 
            this.TxtProdUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtProdUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdUnit.Enabled = false;
            this.TxtProdUnit.Location = new System.Drawing.Point(94, 30);
            this.TxtProdUnit.Name = "TxtProdUnit";
            this.TxtProdUnit.Size = new System.Drawing.Size(91, 23);
            this.TxtProdUnit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "UNIT:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TxtQty
            // 
            this.TxtQty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtQty.Location = new System.Drawing.Point(94, 66);
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(91, 23);
            this.TxtQty.TabIndex = 0;
            this.TxtQty.Enter += new System.EventHandler(this.TxtQty_Enter);
            this.TxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQty_KeyPress);
            this.TxtQty.Leave += new System.EventHandler(this.TxtQty_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "QUANTITY:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtProdSp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtVatPer);
            this.groupBox2.Controls.Add(this.TxtVat);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(18, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pricing";
            // 
            // TxtProdSp
            // 
            this.TxtProdSp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtProdSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdSp.Enabled = false;
            this.TxtProdSp.Location = new System.Drawing.Point(97, 30);
            this.TxtProdSp.Name = "TxtProdSp";
            this.TxtProdSp.Size = new System.Drawing.Size(123, 23);
            this.TxtProdSp.TabIndex = 2;
            this.TxtProdSp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProdSp_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "SELL PRICE:";
            // 
            // txtVatPer
            // 
            this.txtVatPer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVatPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatPer.Enabled = false;
            this.txtVatPer.Location = new System.Drawing.Point(97, 57);
            this.txtVatPer.Name = "txtVatPer";
            this.txtVatPer.Size = new System.Drawing.Size(123, 23);
            this.txtVatPer.TabIndex = 2;
            // 
            // TxtVat
            // 
            this.TxtVat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVat.Enabled = false;
            this.TxtVat.Location = new System.Drawing.Point(97, 83);
            this.TxtVat.Name = "TxtVat";
            this.TxtVat.Size = new System.Drawing.Size(123, 23);
            this.TxtVat.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "VAT (%):";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "VAT:";
            // 
            // TxtProdDesc
            // 
            this.TxtProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdDesc.Enabled = false;
            this.TxtProdDesc.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProdDesc.Location = new System.Drawing.Point(381, 7);
            this.TxtProdDesc.Name = "TxtProdDesc";
            this.TxtProdDesc.Size = new System.Drawing.Size(567, 31);
            this.TxtProdDesc.TabIndex = 2;
            // 
            // TxtProdCd
            // 
            this.TxtProdCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtProdCd.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProdCd.Location = new System.Drawing.Point(76, 7);
            this.TxtProdCd.Name = "TxtProdCd";
            this.TxtProdCd.Size = new System.Drawing.Size(164, 31);
            this.TxtProdCd.TabIndex = 0;
            this.TxtProdCd.Enter += new System.EventHandler(this.TxtProdCd_Enter);
            this.TxtProdCd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProdCd_KeyDown);
            this.TxtProdCd.Leave += new System.EventHandler(this.TxtProdCd_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "DESCRIPTION:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "CODE:";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAdd.FlatAppearance.BorderSize = 2;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.Location = new System.Drawing.Point(699, 53);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(99, 95);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(56)))), ((int)(((byte)(13)))));
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCancel.FlatAppearance.BorderSize = 2;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.Location = new System.Drawing.Point(836, 53);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 95);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbltips);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 517);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 35);
            this.panel3.TabIndex = 1;
            // 
            // lbltips
            // 
            this.lbltips.AutoSize = true;
            this.lbltips.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltips.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbltips.Location = new System.Drawing.Point(115, 9);
            this.lbltips.Name = "lbltips";
            this.lbltips.Size = new System.Drawing.Size(0, 17);
            this.lbltips.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Linen;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.btnCancelReceipt);
            this.panel4.Controls.Add(this.BtnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 379);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(961, 138);
            this.panel4.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MintCream;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.lblNetamount);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.lbltotalamount);
            this.panel6.Controls.Add(this.lblvantamount);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(961, 49);
            this.panel6.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(110, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Net Amount:";
            // 
            // lblNetamount
            // 
            this.lblNetamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetamount.AutoSize = true;
            this.lblNetamount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetamount.Location = new System.Drawing.Point(233, 11);
            this.lblNetamount.Name = "lblNetamount";
            this.lblNetamount.Size = new System.Drawing.Size(50, 26);
            this.lblNetamount.TabIndex = 1;
            this.lblNetamount.Text = "0.00";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(366, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 26);
            this.label9.TabIndex = 0;
            this.label9.Text = "Vat Amount:";
            // 
            // lbltotalamount
            // 
            this.lbltotalamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalamount.AutoSize = true;
            this.lbltotalamount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalamount.Location = new System.Drawing.Point(734, 11);
            this.lbltotalamount.Name = "lbltotalamount";
            this.lbltotalamount.Size = new System.Drawing.Size(50, 26);
            this.lbltotalamount.TabIndex = 1;
            this.lbltotalamount.Text = "0.00";
            // 
            // lblvantamount
            // 
            this.lblvantamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblvantamount.AutoSize = true;
            this.lblvantamount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvantamount.Location = new System.Drawing.Point(483, 11);
            this.lblvantamount.Name = "lblvantamount";
            this.lblvantamount.Size = new System.Drawing.Size(50, 26);
            this.lblvantamount.TabIndex = 1;
            this.lblvantamount.Text = "0.00";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(603, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 26);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total Amount:";
            // 
            // btnCancelReceipt
            // 
            this.btnCancelReceipt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(56)))), ((int)(((byte)(13)))));
            this.btnCancelReceipt.FlatAppearance.BorderSize = 0;
            this.btnCancelReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReceipt.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelReceipt.ForeColor = System.Drawing.Color.White;
            this.btnCancelReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelReceipt.Image")));
            this.btnCancelReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelReceipt.Location = new System.Drawing.Point(576, 64);
            this.btnCancelReceipt.Name = "btnCancelReceipt";
            this.btnCancelReceipt.Size = new System.Drawing.Size(136, 62);
            this.btnCancelReceipt.TabIndex = 2;
            this.btnCancelReceipt.Text = "CANCEL";
            this.btnCancelReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelReceipt.UseVisualStyleBackColor = false;
            this.btnCancelReceipt.Click += new System.EventHandler(this.btnCancelReceipt_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSave.BackColor = System.Drawing.Color.SlateBlue;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(326, 64);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(140, 62);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.GvReceipt);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 281);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(961, 98);
            this.panel5.TabIndex = 3;
            // 
            // GvReceipt
            // 
            this.GvReceipt.AllowUserToAddRows = false;
            this.GvReceipt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.GvReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GvReceipt.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GvReceipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(233)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(233)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.GvReceipt.RowHeadersVisible = false;
            this.GvReceipt.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GvReceipt.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.GvReceipt.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.GvReceipt.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.GvReceipt.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GvReceipt.RowTemplate.Height = 35;
            this.GvReceipt.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvReceipt.Size = new System.Drawing.Size(961, 98);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(457, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Customer Limit:";
            this.label11.Visible = false;
            // 
            // lblcustlimit
            // 
            this.lblcustlimit.AutoSize = true;
            this.lblcustlimit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcustlimit.Location = new System.Drawing.Point(565, 29);
            this.lblcustlimit.Name = "lblcustlimit";
            this.lblcustlimit.Size = new System.Drawing.Size(34, 20);
            this.lblcustlimit.TabIndex = 3;
            this.lblcustlimit.Text = "0.00";
            this.lblcustlimit.Visible = false;
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbltips;
        private System.Windows.Forms.RadioButton rBExistingCustomer;
        private System.Windows.Forms.RadioButton rBWalkinCustomer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtcustcode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblcustlimit;
        private System.Windows.Forms.Label label11;
    }
}