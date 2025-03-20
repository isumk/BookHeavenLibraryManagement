using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library_Management_SystemAD.BookHaven.Database;


namespace library_Management_SystemAD.BookHaven.UI
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            DataTable dt = DBHelper.GetAllCustomers();
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"Name LIKE '%{txtName.Text}%' OR Contact LIKE '%{txtName.Text}%'";
            dgvCustomers.DataSource = dv;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = DBHelper.GetAllCustomers();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (DBHelper.AddCustomer(txtName.Text, txtContact.Text, txtEmail.Text, txtAddress.Text))
            {
                MessageBox.Show("Customer added successfully!");
                LoadCustomers();
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells[0].Value);
                if (DBHelper.UpdateCustomer(id, txtName.Text, txtContact.Text, txtEmail.Text, txtAddress.Text))
                {
                    MessageBox.Show("Customer updated successfully!");
                    LoadCustomers();
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells[0].Value);
                if (MessageBox.Show("Are you sure to delete this customer?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (DBHelper.DeleteCustomer(id))
                    {
                        MessageBox.Show("Customer deleted successfully!");
                        LoadCustomers();
                    }
                }
            }
        }
    }
}