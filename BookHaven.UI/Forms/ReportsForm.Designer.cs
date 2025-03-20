
namespace library_Management_SystemAD.BookHaven.UI
{
    partial class ReportsForm
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
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.usrNavPanel1 = new library_Management_SystemAD.BookHaven.UI.UsrNavPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(465, 133);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(121, 21);
            this.cmbReportType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Type";
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(244, 250);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(523, 150);
            this.dgvReport.TabIndex = 2;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(392, 195);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(98, 23);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Location = new System.Drawing.Point(508, 195);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(101, 23);
            this.btnExportToPDF.TabIndex = 4;
            this.btnExportToPDF.Text = "Export To PDF";
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            // 
            // usrNavPanel1
            // 
            this.usrNavPanel1.Location = new System.Drawing.Point(0, 0);
            this.usrNavPanel1.Name = "usrNavPanel1";
            this.usrNavPanel1.Size = new System.Drawing.Size(199, 422);
            this.usrNavPanel1.TabIndex = 5;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usrNavPanel1);
            this.Controls.Add(this.btnExportToPDF);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbReportType);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExportToPDF;
        private UsrNavPanel usrNavPanel1;
    }
}