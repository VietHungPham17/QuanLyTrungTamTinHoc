namespace QuanLyTrungTamTinHoc.Report
{
    partial class FrmTuitionDebtReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TuitionDebtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TranscriptSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TuitionDebtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranscriptSummaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TuitionDebtBindingSource
            // 
            this.TuitionDebtBindingSource.DataSource = typeof(DTLayer.TuitionDebt);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TuitionDebtBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "StudentM.Report.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(18, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(625, 660);
            this.reportViewer1.TabIndex = 0;
            // 
            // TranscriptSummaryBindingSource
            // 
            this.TranscriptSummaryBindingSource.DataSource = typeof(DTLayer.TranscriptSummary);
            // 
            // FrmTuitionDebtReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(658, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmTuitionDebtReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo học viên nợ phí";
            this.Load += new System.EventHandler(this.FrmReportTuitionDebt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TuitionDebtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranscriptSummaryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TuitionDebtBindingSource;
        private System.Windows.Forms.BindingSource TranscriptSummaryBindingSource;
    }
}