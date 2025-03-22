using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library_Management_SystemAD.BookHaven.Database;
using library_Management_SystemAD.BookHaven.UI.Forms;

namespace library_Management_SystemAD.BookHaven.UI
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            LoadCustomers();
            LoadOrderTypes();
            LoadOrderStatuses();
        }

        // Helper method to get the database connection string
        public static class DatabaseHelper
        {
            public static string GetConnectionString()
            {
                return "Server=DESKTOP-URN6SR5\\SQLEXPRESS;Database=BookHeaven;Integrated Security=True;"; // Replace with your actual connection string
            }
        }

        // Handle book removal event from SelectBookForm
        private void OnBookRemoved(string bookName, int quantity)
        {
            // Search the DataGridView for the book by name
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["BookName"].Value.ToString() == bookName)
                {
                    // Remove the row if the book is found
                    dgvOrders.Rows.Remove(row);
                    break;
                }
            }

            // Update the total price after the book removal
            UpdateTotalPrice();
        }

        private void LoadOrderTypes()
        {
            // Sample delivery methods
            comboBoxOrderType.Items.Add("In-store Pickup");
            comboBoxOrderType.Items.Add("Delivery");
            comboBoxOrderType.SelectedIndex = 0;
        }

        private void LoadOrderStatuses()
        {
            // Sample order statuses
            comboBoxOrderStatus.Items.Add("Pending");
            comboBoxOrderStatus.Items.Add("Completed");
            comboBoxOrderStatus.Items.Add("Shipped");
            comboBoxOrderStatus.SelectedIndex = 0; // Set default selection
        }

        // Method to update the total price based on the books in the DataGridView
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["TotalAmount"].Value != null)
                {
                    totalPrice += Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                }
            }
            txtTotal.Text = totalPrice.ToString("0.00"); // Update the total price textbox
        }

        // Event handler for "Place Order" button
        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            // Place the order (existing logic to save order data to the database)
            string customer = cmbCustomer.SelectedValue.ToString(); // Use SelectedValue instead of SelectedItem
            string orderType = comboBoxOrderType.SelectedItem.ToString();
            string orderStatus = comboBoxOrderStatus.SelectedItem.ToString();
            decimal totalAmount = Convert.ToDecimal(txtTotal.Text);

            int orderID = InsertOrder(customer, DateTime.Now, totalAmount, orderType, orderStatus);

            // Insert order details (each book in DataGridView)
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["BookTitle"].Value != null &&
                    row.Cells["Quantity"].Value != null &&
                    row.Cells["Price"].Value != null &&
                    row.Cells["Total"].Value != null)
                {
                    string BookID = row.Cells["BookTitle"].Value.ToString();
                    int Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal Price = Convert.ToDecimal(row.Cells["Price"].Value);
                    decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                    InsertOrderDetails(orderID, BookID, Quantity, Price, total);
                }
                else
                {
                    MessageBox.Show("Please ensure all order details are filled out.");
                }
            }

            MessageBox.Show("Order placed successfully!");
        }

        // Helper methods for database operations
        private int InsertOrder(string customerID, DateTime orderDate, decimal totalAmount, string deliveryMethod, string orderStatus)
        {
            string query = @"
                INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, DeliveryMethod, Status)
                VALUES (@CustomerID, @OrderDate, @TotalAmount, @DeliveryMethod, @Status);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@DeliveryMethod", deliveryMethod);
                    cmd.Parameters.AddWithValue("@Status", orderStatus);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void InsertOrderDetails(int orderID, string bookName, int quantity, decimal unitPrice, decimal totalPrice)
        {
            string query = @"
                INSERT INTO OrderDetails (OrderID, BookTitle, Quantity, UnitPrice, TotalPrice)
                VALUES (@OrderID, @BookTitle, @Quantity, @UnitPrice, @TotalPrice)";

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Parameters.AddWithValue("@BookTitle", bookName);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadCustomers()
        {
            cmbCustomer.DataSource = null; // Clear bindings
            cmbCustomer.Items.Clear();      // Clear old items

            string connectionString = DatabaseHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CustomerID, Name FROM Customers", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCustomer.DataSource = dt;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "CustomerID";
                cmbCustomer.SelectedIndex = -1; // No default selection
            }
        }

        // Method to get the selected OrderID from the DataGridView
        private int GetSelectedOrderID()
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int selectedOrderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
                return selectedOrderID;
            }
            else
            {
                MessageBox.Show("Please select an order.");
                return -1; // Return -1 if no order is selected
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            int orderID = GetSelectedOrderID();
            if (orderID != -1)
            {
                DeleteOrder(orderID);
            }
        }

        private void DeleteOrder(int orderID)
        {
            string query = @"
                DELETE FROM OrderDetails WHERE OrderID = @OrderID;
                DELETE FROM Orders WHERE OrderID = @OrderID";

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Order deleted successfully!");
        }

        private void buttonSelectBook_Click(object sender, EventArgs e)
        {
            SelectBooksForm selectBookForm = new SelectBooksForm();
            if (selectBookForm.ShowDialog() == DialogResult.OK)
            {
                string bookName = selectBookForm.SelectedBookTitle;
                int quantity = selectBookForm.SelectedQuantity;
                decimal price = selectBookForm.SelectedBookPrice;
                decimal totalPrice = quantity * price;

                // Assuming "OrderID" is one of the columns in dgvOrders
                dgvOrders.Rows.Add(bookName, quantity, price, totalPrice); // Add to DataGridView

                UpdateTotalPrice();
            }
        }

        
    }
}



