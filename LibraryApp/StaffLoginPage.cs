using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LibraryApp
{
    public partial class StaffLoginPage : UserControl
    {
        Panel homePanel;
        private List<string> staffSsns = new List<string>();
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        public StaffLoginPage(Panel _homePanel)
        {
            InitializeComponent();
            this.homePanel = _homePanel;
            loadStaffSsns();
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
            else if (!staffSsns.Contains(ssnTextBox.Text))
            {
                MessageBox.Show("Invalid social security number. Please try again.");
                return;
            }
            else
            {
                this.homePanel.Controls.Clear();
                StaffPage staffPage = new StaffPage(this.homePanel, ssnTextBox.Text);
                staffPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(staffPage);
            }
        }

        private void loadStaffSsns()
        {
            // Load staff SSNs from the database and populate the staffSsns list
            // Example:
            // staffSsns.Add("123-45-6789");
            // staffSsns.Add("987-65-4321");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT SSN FROM Staff";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                staffSsns.Add(reader.GetString(0));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff SSNs: {ex.Message}");
            }
        }
    }
}
