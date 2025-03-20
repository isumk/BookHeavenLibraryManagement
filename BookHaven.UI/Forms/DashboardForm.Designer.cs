
namespace library_Management_SystemAD.BookHaven.UI
{
    partial class DashboardForm
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
            this.usrNavPanel1 = new library_Management_SystemAD.BookHaven.UI.UsrNavPanel();
            this.SuspendLayout();
            // 
            // usrNavPanel1
            // 
            this.usrNavPanel1.Location = new System.Drawing.Point(1, 1);
            this.usrNavPanel1.Name = "usrNavPanel1";
            this.usrNavPanel1.Size = new System.Drawing.Size(199, 408);
            this.usrNavPanel1.TabIndex = 0;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 409);
            this.Controls.Add(this.usrNavPanel1);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrNavPanel usrNavPanel1;
    }
}