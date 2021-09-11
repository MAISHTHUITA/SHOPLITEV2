
namespace SHOPLITE.PrintingForms
{
    partial class frmPrint
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
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.CausesValidation = false;
            this.ReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewer.DisplayStatusBar = false;
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.EnableDrillDown = false;
            this.ReportViewer.EnableRefresh = false;
            this.ReportViewer.EnableToolTips = false;
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.ShowCloseButton = false;
            this.ReportViewer.ShowCopyButton = false;
            this.ReportViewer.ShowGroupTreeButton = false;
            this.ReportViewer.ShowLogo = false;
            this.ReportViewer.ShowParameterPanelButton = false;
            this.ReportViewer.ShowRefreshButton = false;
            this.ReportViewer.Size = new System.Drawing.Size(902, 665);
            this.ReportViewer.TabIndex = 0;
            this.ReportViewer.TabStop = false;
            this.ReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 665);
            this.Controls.Add(this.ReportViewer);
            this.Name = "frmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
    }
}