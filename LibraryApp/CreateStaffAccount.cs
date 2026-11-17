using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class CreateStaffAccount : UserControl
    {
        private Panel homePanel;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
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
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
                        string staffQuery = "INSERT INTO Staff (Fname, Lname, Ssn, Address, Sex, Salary, Status) VALUES (@Fname, @Lname, @SSN, @Address, @Sex, @Salary, @Status)";
                        string staffPhoneQuery = "INSERT INTO Staff_Phone (Ssn, Phone_no) VALUES (@SSN, @Phone_no)";
                        using (SqlCommand cmd = new SqlCommand(staffQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Fname", firstNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@Lname", lastNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@SSN", ssnTextBox.Text);
                            cmd.Parameters.AddWithValue("@Address", addressTextBox.Text);
                            cmd.Parameters.AddWithValue("@Sex", comboBox1.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Salary", 50000);
                            cmd.Parameters.AddWithValue("@Status", "Available");
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmdPhone = new SqlCommand(staffPhoneQuery, conn, transaction))
                        {
                            cmdPhone.Parameters.AddWithValue("@SSN", ssnTextBox.Text);
                            cmdPhone.Parameters.AddWithValue("@Phone_no", textBox1.Text);
                            cmdPhone.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    return;
                }
                this.homePanel.Controls.Clear();
                StaffPage staffPage = new StaffPage(this.homePanel, ssnTextBox.Text);
                staffPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(staffPage);
            }
        }
    }
}
