using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class CreateUserAccount : UserControl
    {
        private Panel homePanel;

        public CreateUserAccount(Panel homePanel)
        {
            InitializeComponent();
            this.homePanel = homePanel;
        }

        private void createMemberAccountButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else
            {
                this.homePanel.Controls.Clear();
                UserPage userPage = new UserPage(this.homePanel);
                userPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(userPage);
            }
        }
    }
}
