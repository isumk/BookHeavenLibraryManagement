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
    public partial class UsrNavPanel : UserControl
    {
        public UsrNavPanel()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenForm(new DashboardForm());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenForm(new BookInventoryForm());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenForm(new CustomerForm());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            OpenForm(new SalesForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenForm(new OrderForm());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenForm(new SupplierForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenForm(new ReportsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
          
             this.Hide();
             new LoginForm().Show();
            
        }

        private void OpenForm(Form newForm)
        {
            Form currentForm = this.FindForm(); // Get the current form
            newForm.Show();
            currentForm.Hide(); // Close the current form
        }
    }
}
