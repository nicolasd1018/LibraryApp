using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class CreateStaffAccount : UserControl
    {
        private Panel homePanel;
        public CreateStaffAccount(Panel _homePanel)
        {
            InitializeComponent();
            this.homePanel = _homePanel;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text) || string.IsNullOrWhiteSpace(ssnTextBox.Text) || string.IsNullOrWhiteSpace(addressTextBox.Text) || comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else
            {
                this.homePanel.Controls.Clear();
                StaffPage staffPage = new StaffPage(this.homePanel);
                staffPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(staffPage);
            }
        }
    }
}
