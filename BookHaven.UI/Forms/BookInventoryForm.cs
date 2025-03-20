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
    public partial class BookInventoryForm : Form
    {
        public BookInventoryForm()
        {
            InitializeComponent();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void BookInventoryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookHeavenDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.bookHeavenDataSet.Books);

        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dgvBooks.DataSource = DBHelper.GetAllBooks();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                txtGenre.Text = row.Cells["Genre"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStock.Text = row.Cells["StockQuantity"].Value.ToString();
            }



        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string isbn = txtISBN.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            if (DBHelper.AddBook(title, author, genre, isbn, price, stock))
            {
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Failed to add book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadBooks();
            }
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            int bookID = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string isbn = txtISBN.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            if (DBHelper.UpdateBook(bookID, title, author, genre, isbn, price, stock))
            {
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Failed to update book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadBooks();
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int bookID = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
                if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (DBHelper.DeleteBook(bookID))
                    {
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadBooks();
                    }
                }
            }
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadBooks()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtISBN.Clear();
            txtPrice.Clear();
            txtStock.Clear();
        }
    }
}
