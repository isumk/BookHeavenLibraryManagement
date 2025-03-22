using library_Management_SystemAD.BookHaven.Database;
using library_Management_SystemAD.BookHaven.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_Management_SystemAD.BookHaven.UI
{
    public partial class SalesForm : Form
    {
        private string connectionString = "Server=DESKTOP-URN6SR5\\SQLEXPRESS;Database=BookHeaven;Integrated Security=True;";

        public SalesForm()
        {
            InitializeComponent();
            LoadCustomersIntoComboBox();


        }
        private DataTable cart = new DataTable();

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void usrNavPanel1_Load(object sender, EventArgs e)
        {

        }

        private void SalesForm_Load(object sender, EventArgs e)
        {

        }



        // This function calculates the total price from the cart items
        private decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (DataRow row in dgvCart.Rows)
            {
                if (decimal.TryParse(row["Total"].ToString(), out decimal rowTotal))
                {
                    total += rowTotal;
                }
            }
            return total;
        }
        private void ShowReceipt(string customerName)
        {
            string receipt = $"Receipt\n-------------------\nCustomer: {customerName}\nDate: {DateTime.Now}\n\n";
            foreach (DataRow row in dgvCart.Rows)
            {
                receipt += $"{row["BookTitle"]} x {row["Quantity"]} - {row["Total"]}\n";
            }
            receipt += $"\nTotal: {GetTotalPrice()}\n-------------------\nThank you for shopping with us!";
            MessageBox.Show(receipt, "Receipt");
        }


        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerName = comboBoxBooks.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Please select a customer.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Insert Order
                    SqlCommand cmdOrder = new SqlCommand("INSERT INTO Orders (CustomerName, OrderDate, TotalAmount) OUTPUT INSERTED.OrderID VALUES (@CustomerName, @OrderDate, @TotalAmount)", con);
                    cmdOrder.Parameters.AddWithValue("@CustomerName", customerName);
                    cmdOrder.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmdOrder.Parameters.AddWithValue("@TotalAmount", GetTotalPrice());

                    int orderId = (int)cmdOrder.ExecuteScalar();

                    // Insert Order Details
                    foreach (DataRow row in dgvCart.Rows)
                    {
                        SqlCommand cmdDetail = new SqlCommand("INSERT INTO OrderDetails (OrderID, BookID, Quantity, Price, Total) VALUES (@OrderID, @BookID, @Quantity, @Price, @Total)", con);
                        cmdDetail.Parameters.AddWithValue("@OrderID", orderId);
                        cmdDetail.Parameters.AddWithValue("@BookID", row["BookID"]);
                        cmdDetail.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        cmdDetail.Parameters.AddWithValue("@Price", row["Price"]);
                        cmdDetail.Parameters.AddWithValue("@Total", row["Total"]);
                        cmdDetail.ExecuteNonQuery();
                    }

                    con.Close();
                }

                // Show Receipt
                ShowReceipt(customerName);

                // Clear cart
                dgvCart.Rows.Clear();
                UpdateTotalPrice();
                MessageBox.Show("Checkout successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            // Remove selected item from cart
            if (dgvCart.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCart.SelectedRows)
                {
                    dgvCart.Rows.RemoveAt(row.Index);
                }

                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadCustomersIntoComboBox()
        {
            comboBoxBooks.DataSource = null; // Clear bindings
            comboBoxBooks.Items.Clear();      // Clear old items

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CustomerID, Name FROM Customers", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxBooks.DataSource = dt;
                comboBoxBooks.DisplayMember = "Name";
                comboBoxBooks.ValueMember = "CustomerID";
                comboBoxBooks.SelectedIndex = -1; // No default selection
            }
        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
