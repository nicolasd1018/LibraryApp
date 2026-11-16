using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class UserPage : UserControl
    {
        private Panel homePanel;

        public UserPage(Panel homePanel)
        {
            InitializeComponent();
            this.homePanel = homePanel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            LoginPage loginPage = new LoginPage(this.homePanel);
            loginPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(loginPage);
        }

        private void searchBooksButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            BookSearchPage bookSearchPage = new BookSearchPage(this.homePanel);
            bookSearchPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(bookSearchPage);
        }

        private void manageDependentsButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            manageDependentsPage manageDependentsPage = new manageDependentsPage(this.homePanel);
            manageDependentsPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(manageDependentsPage);
        }
    }
}
