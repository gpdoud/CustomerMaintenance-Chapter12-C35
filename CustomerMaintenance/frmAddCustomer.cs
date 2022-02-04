using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        private Customer customer = null;

        public Customer GetNewCustomer() {
            ShowDialog();
            return customer;
        }
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!IsValidData()) {
                return;
            }
            customer = new Customer(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            Close();
        }
        private bool IsValidData() { 
            string message = string.Empty;
            message += Validator.IsPresent(txtFirstName.Text, txtFirstName.Tag.ToString());
            message += Validator.IsPresent(txtLastName.Text, txtLastName.Tag.ToString());
            message += Validator.IsValidEmail(txtEmail.Text, txtEmail.Tag.ToString());
            if(message.Length > 0) {
                MessageBox.Show(message, "Data Errors");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
