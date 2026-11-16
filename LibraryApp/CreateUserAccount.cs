using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class CreateUserAccount : UserControl
    {
        private Panel homePanel;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        private List<string> usedEmails;
        public CreateUserAccount(Panel homePanel)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.usedEmails = new List<string>();
            this.loadUsedEmails();
        }

        private void createMemberAccountButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(middleInitialTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else
            {
                if (usedEmails.Contains(emailTextBox.Text))
                {
                    MessageBox.Show("This email is already in use. Please use a different email.");
                    return;
                }
                int memberId = Random.Shared.Next(100000, 999999);
                this.createNewMember(firstNameTextBox.Text, middleInitialTextBox.Text, lastNameTextBox.Text, emailTextBox.Text, addressTextBox.Text, textBox1.Text, memberId);
                this.homePanel.Controls.Clear();
                UserPage userPage = new UserPage(this.homePanel, memberId);
                userPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(userPage);
            }
        }

        private void loadUsedEmails()
        {
            string query = "SELECT Email FROM dbo.MEMBER;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Connected, but dbo.MEMBER has 0 rows.");
                            return;
                        }

                        while (reader.Read())
                        {
                            usedEmails.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        private void createNewMember(string firstName, string middleInitial, string lastName, string email, string address, string phoneNumber, int memberId)
        {
            string memberQuery = "INSERT INTO dbo.MEMBER (Member_id, Fname, Minit, Lname, Email, Address, Join_date, Status) VALUES (@Member_id, @Fname, @Minit, @Lname, @Email, @Address, @Join_date, @Status);";
            string memberPhoneQuery = "INSERT INTO dbo.MEMBER_PHONE (Member_id, Phone_no) VALUES (@Member_id, @Phone_no);";

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    
                    using (SqlCommand cmd = new SqlCommand(memberQuery, conn, transaction))
                    {
                        
                        cmd.Parameters.AddWithValue("@Member_id", memberId.ToString());
                        cmd.Parameters.AddWithValue("@Fname", firstName);
                        cmd.Parameters.AddWithValue("@Lname", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Join_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Status", "Good");

                        cmd.ExecuteNonQuery();

                    }

                    using (SqlCommand cmd = new SqlCommand(memberPhoneQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Member_id", memberId.ToString());
                        cmd.Parameters.AddWithValue("@Phone_no", phoneNumber);

                        cmd.ExecuteNonQuery();

                    }
                    this.usedEmails.Add(email);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }
    }
}
