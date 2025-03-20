using library_Management_SystemAD.BookHaven.Database;
using library_Management_SystemAD.BookHaven.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_Management_SystemAD.BookHaven.UI
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }
        private DataTable cart = new DataTable();

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void usrNavPanel1_Load(object sender, EventArgs e)
        {

        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    totalPrice += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            txtTotalPrice.Text = totalPrice.ToString("0.00"); // Update the total price textbox
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Open the Select Book popup form
            SelectBooksForm selectBooksForm = new SelectBooksForm();
            if (selectBooksForm.ShowDialog() == DialogResult.OK)
            {
                // Add the selected book to the cart DataGridView
                dgvCart.Rows.Add(
                    selectBooksForm.SelectedBookTitle,
                    selectBooksForm.SelectedQuantity,
                    selectBooksForm.SelectedBookPrice,
                    selectBooksForm.SelectedQuantity * selectBooksForm.SelectedBookPrice
                );

                // Update total price after adding book
                UpdateTotalPrice();
            }
        }

    }
}
