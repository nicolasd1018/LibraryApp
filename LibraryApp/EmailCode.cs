using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class EmailCode : UserControl
    {
        private Panel homePanel;
        private int userId;
        private int code;

        public EmailCode(Panel homePanel, int userId, int code)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.userId = userId;
            this.code = code;
        }

        private void sendCodeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeTextBox.Text))
            {
                MessageBox.Show("Please enter the code.");
                return;
            }

            if (int.TryParse(codeTextBox.Text, out int enteredCode))
            {
                if (enteredCode == this.code)
                {
                    // Code is correct
                    this.homePanel.Controls.Clear();
                    UserPage userPage = new UserPage(this.homePanel, this.userId);
                    userPage.Dock = DockStyle.Fill;
                    this.homePanel.Controls.Add(userPage);
                }
                else
                {
                    MessageBox.Show("Invalid code.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid code.");
            }
        }
    }
}
