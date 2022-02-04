using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form {
        private List<Customer> customers = null;
        public frmCustomers() {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e) {
            customers = CustomerDB.GetCustomers();
            foreach (Customer customer in customers) {
                lstCustomers.Items.Add(customer.GetDisplayText());
            }
        }

        private void RefreshCustomers() {
            lstCustomers.Items.Clear();
            foreach (Customer customer in customers) {
                lstCustomers.Items.Add(customer.GetDisplayText());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmAddCustomer frm = new frmAddCustomer();
            Customer newCustomer = frm.GetNewCustomer();
            if (newCustomer != null) {
                customers.Add(newCustomer);
                CustomerDB.SaveCustomers(customers);
                RefreshCustomers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            int deleteIndex = lstCustomers.SelectedIndex;
            Customer deleteCustomer = customers[deleteIndex];
            DialogResult response = MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo);
            if(response == DialogResult.No) {
                return;
            }
            customers.Remove(deleteCustomer);
            CustomerDB.SaveCustomers(customers);
            RefreshCustomers();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
