using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class StaffPage : UserControl
    {
        private Panel homePanel;
        public StaffPage(Panel _homePanel)
        {
            InitializeComponent();
            this.homePanel = _homePanel;
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
            //this.homePanel.Controls.Clear();
            //BookSearchPage bookSearchPage = new BookSearchPage(this.homePanel);
            //bookSearchPage.Dock = DockStyle.Fill;
            //this.homePanel.Controls.Add(bookSearchPage);    
        }
    }
}
