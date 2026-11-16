using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class StaffLoginPage : UserControl
    {
        Panel homePanel;
        public StaffLoginPage(Panel _homePanel)
        {
            InitializeComponent();
            this.homePanel = _homePanel;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            CreateStaffAccount staffPage = new CreateStaffAccount(this.homePanel);
            staffPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(staffPage);


        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ssnTextBox.Text))
            {
                MessageBox.Show("Please enter social security number.");
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
