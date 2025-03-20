using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace library_Management_SystemAD.BookHaven.Database
{
    public static class DatabaseHelper
    {
        public static string connectionString = "Server=DESKTOP-URN6SR5\\SQLEXPRESS;Database=BookHeaven;Integrated Security=True;";

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }

    public static class DBHelper
    {
        private static readonly string connectionString = "Server=DESKTOP-URN6SR5\\SQLEXPRESS;Database=BookHeaven;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable GetAllBooks()
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Books";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static bool AddBook(string title, string author, string genre, string isbn, decimal price, int stock)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO Books (Title, Author, Genre, ISBN, Price, StockQuantity) " +
                               "VALUES (@Title, @Author, @Genre, @ISBN, @Price, @StockQuantity)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@StockQuantity", stock);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool UpdateBook(int bookID, string title, string author, string genre, string isbn, decimal price, int stock)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE Books SET Title=@Title, Author=@Author, Genre=@Genre, ISBN=@ISBN, Price=@Price, StockQuantity=@StockQuantity " +
                               "WHERE BookID=@BookID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Author", author);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@StockQuantity", stock);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteBook(int bookID)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM Books WHERE BookID=@BookID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookID", bookID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool AddCustomer(string name, string contact, string email, string address)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name, Contact, Email, Address) VALUES (@Name, @Contact, @Email, @Address)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static DataTable GetAllCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customers", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool UpdateCustomer(int id, string name, string contact, string email, string address)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET Name=@Name, Contact=@Contact, Email=@Email, Address=@Address WHERE CustomerID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteCustomer(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
