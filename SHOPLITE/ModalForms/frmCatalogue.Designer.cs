namespace SHOPLITE.ModalForms
{
    partial class frmCatalogue
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblClose = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtToDept = new System.Windows.Forms.TextBox();
            this.txtFromDept = new System.Windows.Forms.TextBox();
            this.txtToSupplier = new System.Windows.Forms.TextBox();
            this.txtfromSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdWithoutCp = new System.Windows.Forms.RadioButton();
            this.rdWithCp = new System.Windows.Forms.RadioButton();
            this.BtnCancel = new SHOPLITE.RJButton();
            this.BtnPrint = new SHOPLITE.RJButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(94)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.LblClose);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 41);
            this.panel1.TabIndex = 10;
            // 
            // LblClose
            // 
            this.LblClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblClose.AutoSize = true;
            this.LblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClose.ForeColor = System.Drawing.Color.White;
            this.LblClose.Location = new System.Drawing.Point(303, 13);
            this.LblClose.Name = "LblClose";
            this.LblClose.Size = new System.Drawing.Size(69, 17);
            this.LblClose.TabIndex = 0;
            this.LblClose.Text = "[CLOSE]";
            this.LblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "View Product Catalogue";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.txtToDept);
            this.panel2.Controls.Add(this.txtFromDept);
            this.panel2.Controls.Add(this.txtToSupplier);
            this.panel2.Controls.Add(this.txtfromSupplier);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 142);
            this.panel2.TabIndex = 11;
            // 
            // txtToDept
            // 
            this.txtToDept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtToDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(181)))));
            this.txtToDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToDept.Location = new System.Drawing.Point(253, 56);
            this.txtToDept.Name = "txtToDept";
            this.txtToDept.Size = new System.Drawing.Size(100, 22);
            this.txtToDept.TabIndex = 13;
            this.txtToDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtToDept_KeyDown);
            // 
            // txtFromDept
            // 
            this.txtFromDept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFromDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(181)))));
            this.txtFromDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromDept.Location = new System.Drawing.Point(126, 56);
            this.txtFromDept.Name = "txtFromDept";
            this.txtFromDept.Size = new System.Drawing.Size(100, 22);
            this.txtFromDept.TabIndex = 13;
            this.txtFromDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFromDept_KeyDown);
            // 
            // txtToSupplier
            // 
            this.txtToSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtToSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(181)))));
            this.txtToSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToSupplier.Location = new System.Drawing.Point(253, 19);
            this.txtToSupplier.Name = "txtToSupplier";
            this.txtToSupplier.Size = new System.Drawing.Size(100, 22);
            this.txtToSupplier.TabIndex = 13;
            this.txtToSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtToSupplier_KeyDown);
            // 
            // txtfromSupplier
            // 
            this.txtfromSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtfromSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(181)))));
            this.txtfromSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfromSupplier.Location = new System.Drawing.Point(126, 19);
            this.txtfromSupplier.Name = "txtfromSupplier";
            this.txtfromSupplier.Size = new System.Drawing.Size(100, 22);
            this.txtfromSupplier.TabIndex = 13;
            this.txtfromSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfromSupplier_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "From Department";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "To";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "From Supplier";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.rdWithoutCp);
            this.panel3.Controls.Add(this.rdWithCp);
            this.panel3.Location = new System.Drawing.Point(12, 238);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 37);
            this.panel3.TabIndex = 13;
            // 
            // rdWithoutCp
            // 
            this.rdWithoutCp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdWithoutCp.AutoSize = true;
            this.rdWithoutCp.Location = new System.Drawing.Point(203, 4);
            this.rdWithoutCp.Name = "rdWithoutCp";
            this.rdWithoutCp.Size = new System.Drawing.Size(101, 18);
            this.rdWithoutCp.TabIndex = 0;
            this.rdWithoutCp.Text = "Without B.P.";
            this.rdWithoutCp.UseVisualStyleBackColor = true;
            // 
            // rdWithCp
            // 
            this.rdWithCp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdWithCp.AutoSize = true;
            this.rdWithCp.Checked = true;
            this.rdWithCp.Location = new System.Drawing.Point(93, 4);
            this.rdWithCp.Name = "rdWithCp";
            this.rdWithCp.Size = new System.Drawing.Size(80, 18);
            this.rdWithCp.TabIndex = 0;
            this.rdWithCp.TabStop = true;
            this.rdWithCp.Text = "With B.P.";
            this.rdWithCp.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnCancel.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCancel.BorderRadius = 0;
            this.BtnCancel.BorderSize = 0;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(186, 293);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(150, 40);
            this.BtnCancel.TabIndex = 14;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.TextColor = System.Drawing.Color.White;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnPrint.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnPrint.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BtnPrint.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnPrint.BorderRadius = 0;
            this.BtnPrint.BorderSize = 0;
            this.BtnPrint.FlatAppearance.BorderSize = 0;
            this.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrint.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.Color.White;
            this.BtnPrint.Location = new System.Drawing.Point(24, 294);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(150, 40);
            this.BtnPrint.TabIndex = 14;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.TextColor = System.Drawing.Color.White;
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // frmCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(388, 357);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCatalogue";
            this.Text = "frmCatalogue";
            this.Load += new System.EventHandler(this.frmCatalogue_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtToDept;
        private System.Windows.Forms.TextBox txtFromDept;
        private System.Windows.Forms.TextBox txtToSupplier;
        private System.Windows.Forms.TextBox txtfromSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private RJButton BtnPrint;
        private RJButton BtnCancel;
        private System.Windows.Forms.RadioButton rdWithCp;
        private System.Windows.Forms.RadioButton rdWithoutCp;
    }
}