using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using MimeKit;

namespace LibraryApp
{
    public partial class UserPage : UserControl
    {
        private Panel homePanel;
        private int memberId;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";

        public UserPage(Panel homePanel, int memberId)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.memberId = memberId;
            loadMemberInfo();
            loadCheckedOutBooks();
            loadFines();
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

        private void loadMemberInfo()
        {
            string query = "SELECT Fname FROM dbo.MEMBER WHERE Member_id = @Member_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Member_id", this.memberId.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userHeader.Text = reader.GetString(0) + userHeader.Text;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        private void loadCheckedOutBooks()
        {
            string query = "SELECT b.Title, Due_date FROM dbo.BOOK as b JOIN dbo.BOOK_COPY as c ON c.ISBN = b.ISBN JOIN dbo.BORROWS ON c.Copy_id = dbo.BORROWS.Copy_id WHERE Member_id = @Member_id AND dbo.BORROWS.Return_date IS NULL";
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Member_id", this.memberId.ToString());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                checkedoutBooksListBox.Items.Add("No books checked out.");
                                return;
                            }
                            while (reader.Read())
                            {
                                checkedoutBooksListBox.Items.Add($"{reader.GetString(0)} (Due: {reader.GetDateTime(1):yyyy-MM-dd})");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

        private void loadFines()
        {
            string query = "SELECT Date_issued, Amount, Reason FROM dbo.FINE WHERE Member_id = @Member_id AND Date_paid IS NULL;";
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Member_id", this.memberId.ToString());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                finesListBox.Items.Add("No outstanding fines.");
                                return;
                            }
                            while (reader.Read())
                            {
                                finesListBox.Items.Add($"Date: {reader.GetDateTime(0):yyyy-MM-dd}, Amount: ${reader.GetDecimal(1):F2}, Reason: {reader.GetString(2)}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }
    }
}
