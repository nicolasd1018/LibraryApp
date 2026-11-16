using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class manageDependentsPage : UserControl
    {
        private Panel homePanel;
        public manageDependentsPage(Panel homePanel)
        {
            InitializeComponent();
            this.homePanel = homePanel;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            UserPage userPage = new UserPage(this.homePanel, 0);
            userPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(userPage);
        }
    }
}
