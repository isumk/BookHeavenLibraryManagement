
namespace library_Management_SystemAD.BookHaven.UI
{
    partial class SupplierForm
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
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnUpdateSupplier = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.usrNavPanel1 = new library_Management_SystemAD.BookHaven.UI.UsrNavPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliers.Location = new System.Drawing.Point(205, 236);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.Size = new System.Drawing.Size(542, 150);
            this.dgvSuppliers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(522, 109);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(97, 23);
            this.btnAddSupplier.TabIndex = 4;
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSupplier
            // 
            this.btnUpdateSupplier.Location = new System.Drawing.Point(522, 150);
            this.btnUpdateSupplier.Name = "btnUpdateSupplier";
            this.btnUpdateSupplier.Size = new System.Drawing.Size(97, 23);
            this.btnUpdateSupplier.TabIndex = 5;
            this.btnUpdateSupplier.Text = "Update Supplier";
            this.btnUpdateSupplier.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Location = new System.Drawing.Point(522, 194);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(97, 23);
            this.btnDeleteSupplier.TabIndex = 6;
            this.btnDeleteSupplier.Text = "Delete Supplier";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(361, 101);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(100, 20);
            this.txtSupplierName.TabIndex = 7;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(361, 143);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 20);
            this.txtContact.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(361, 191);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // usrNavPanel1
            // 
            this.usrNavPanel1.Location = new System.Drawing.Point(0, 0);
            this.usrNavPanel1.Name = "usrNavPanel1";
            this.usrNavPanel1.Size = new System.Drawing.Size(199, 422);
            this.usrNavPanel1.TabIndex = 10;
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usrNavPanel1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.btnDeleteSupplier);
            this.Controls.Add(this.btnUpdateSupplier);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSuppliers);
            this.Name = "SupplierForm";
            this.Text = "SupplierForm";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnUpdateSupplier;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtEmail;
        private UsrNavPanel usrNavPanel1;
    }
}