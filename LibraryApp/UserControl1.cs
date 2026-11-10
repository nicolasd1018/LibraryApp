using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class LoginPage : UserControl
    {
        Panel homePanel;
        public LoginPage(Panel _homePanel)
        {
            InitializeComponent();
            this.homePanel = _homePanel;
        }

        private void MemberLoginButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            UserControl2 passwordPage = new UserControl2();
            passwordPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(passwordPage);
        }
    }
}
