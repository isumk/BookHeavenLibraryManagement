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
using library_Management_SystemAD.BookHaven.UI.Forms;
using library_Management_SystemAD.BookHaven.Database;

namespace library_Management_SystemAD.BookHaven.UI.Forms
{
    public partial class SelectBooksForm: Form
    {

        // Connection string — update with your DB details
        string connectionString = "Server=DESKTOP-URN6SR5\\SQLEXPRESS;Database=BookHeaven;Integrated Security=True;";

        public string SelectedBookTitle { get; private set; }
        public decimal SelectedBookPrice { get; private set; }
        public int SelectedQuantity { get; private set; }

        public SelectBooksForm()
        {
            InitializeComponent();
            LoadBooks();
        }

        // Load available books into the DataGridView
        private void LoadBooks()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT BookID, Title, Author, Price, StockQuantity FROM Books WHERE StockQuantity > 0";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewBooks.DataSource = dt;
            }
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        // Add selected book and quantity back to Sales form
        private void btnAddBook_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewBooks.SelectedRows[0];
                SelectedBookTitle = row.Cells["Title"].Value.ToString();
                SelectedBookPrice = Convert.ToDecimal(row.Cells["Price"].Value);
                SelectedQuantity = (int)numericQuantity.Value;

                if (SelectedQuantity <= 0)
                {
                    MessageBox.Show("Please select a quantity greater than 0.");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a book first.");
            }
        }
    }
}

