using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryApp
{
    public partial class StaffPage : UserControl
    {
        private Panel homePanel;
        private string staffSSN;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        public StaffPage(Panel _homePanel, string _staffSSN)
        {
            InitializeComponent();
            this.homePanel = _homePanel;
            this.staffSSN = _staffSSN;
            loadStaffInfo();
            loadMembers();
            loadSubordinates();
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
            BookSearchPage bookSearchPage = new BookSearchPage(this.homePanel, int.Parse(staffSSN), false);
            bookSearchPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(bookSearchPage);
        }

        private void loadStaffInfo()
        {
            // Load staff information based on the staffSSN
            // You can use the staffSSN to query the database and retrieve staff details
            // For example:
            // string query = "SELECT * FROM Staff WHERE SSN = @SSN";
            // Use SqlCommand and SqlDataReader to execute the query and populate the UI controls with staff information
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Fname FROM Staff WHERE SSN = @SSN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SSN", staffSSN);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate UI controls with staff information
                        // For example:
                        // firstNameTextBox.Text = reader["FirstName"].ToString();
                        // lastNameTextBox.Text = reader["LastName"].ToString();
                        // addressTextBox.Text = reader["Address"].ToString();
                        // etc.
                        headerLabel.Text = $"Welcome, {reader["Fname"].ToString()}!";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading staff information: {ex.Message}");
                }
            }
        }

        private void loadMembers()
        {
            // Load members information from the database and populate the UI controls
            // You can use a DataGridView or ListView to display the members list
            // For example:
            // string query = "SELECT * FROM Members";
            // Use SqlCommand and SqlDataReader to execute the query and populate the UI controls with members information
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Member_id, Fname, Lname, Status FROM MEMBER";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    membersListBox.Items.Clear();
                    while (reader.Read())
                    {
                        // Populate UI controls with members information
                        // For example:
                        membersListBox.Items.Add($"{reader["Member_id"]} - {reader["Fname"]} {reader["Lname"]} - {reader["Status"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading members information: {ex.Message}");
                }
            }
        }

        private void searchMembersButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "SELECT Member_id, Fname, Lname, Status FROM dbo.MEMBER WHERE Fname LIKE @Search OR Lname LIKE @Search OR Member_id LIKE @Search";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + membersSearchTextBox.Text + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            membersListBox.Items.Clear();
                            while (reader.Read())
                            {
                                membersListBox.Items.Add($"{reader.GetInt32(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetString(3)}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void fineButton_Click(object sender, EventArgs e)
        {
            if (membersListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from the list first.");
                return;
            }

            string input = Interaction.InputBox("Enter Fine Amount and Reason. Make sure they are comma sperated:", "Fine Input");

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO dbo.FINE (Fine_id, Member_id, Staff_ssn, Amount, Date_issued, Reason, Status) VALUES (@Fine_id, @Member_id, @Staff_ssn, @Amount, @Date_issued, @Reason, @Status);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fine_id", Random.Shared.Next(100, 999));
                        cmd.Parameters.AddWithValue("@Member_id", membersListBox.SelectedItem.ToString().Split("-")[0].Trim());
                        cmd.Parameters.AddWithValue("@Staff_ssn", staffSSN);
                        cmd.Parameters.AddWithValue("@Amount", input.Split(",")[0].Trim());
                        cmd.Parameters.AddWithValue("@Date_issued", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Reason", input.Split(",")[1].Trim());
                        cmd.Parameters.AddWithValue("@Status", "Unpaid");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void showFineHoldersButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = @"
                                    SELECT DISTINCT dbo.MEMBER.Member_id, Fname, Lname, dbo.MEMBER.Status 
                                    FROM dbo.MEMBER 
                                    JOIN dbo.FINE ON dbo.MEMBER.Member_id = dbo.FINE.Member_id 
                                    WHERE  dbo.FINE.Date_paid IS NULL;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            membersListBox.Items.Clear();
                            while (reader.Read())
                            {
                                membersListBox.Items.Add($"{reader.GetInt32(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetString(3)}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void changeMemberStatusButton_Click(object sender, EventArgs e)
        {
            if (membersListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from the list first.");
                return;
            }

            string input = Interaction.InputBox("Enter new status:", "Status Input");
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "UPDATE MEMBER SET Status=@status WHERE Member_id=@member_id;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", input);
                        cmd.Parameters.AddWithValue("@member_id", membersListBox.SelectedItem.ToString().Split("-")[0].Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                loadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void membersListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 1. Verify the double-click landed directly on an actual item (not blank space)
            int index = membersListBox.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches || membersListBox.SelectedItem == null)
            {
                return;
            }

            // 2. Get the selected item text safely
            string selectedText = membersListBox.SelectedItem.ToString();
            string memberId = selectedText.Split('-')[0].Trim();
            string name = selectedText.Split('-')[1].Trim();
            string fineList = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "SELECT Fname, Lname, Amount, Date_issued, Date_paid, Reason, dbo.FINE.Status FROM dbo.FINE JOIN dbo.STAFF ON Staff_ssn=Ssn WHERE Member_id=@member_id;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@member_id", memberId);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            membersListBox.Items.Clear();
                            while (reader.Read())
                            {
                                object value = reader.IsDBNull(4) ? "" : reader.GetDateTime(4);
                                fineList += $"Issued By : {reader.GetString(0)} {reader.GetString(1)} Amount: {reader.GetDecimal(2)} Issued on: {reader.GetDateTime(3):yyyy-MM-dd} Paid On: {value:yyyy-MM-dd)} Reason: {reader.GetString(5)} Status: {reader.GetString(6)}\n";
                            }
                        }
                        MessageBox.Show(fineList, $"{name}'s Fines");
                    }
                }
                loadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            // 3. Perform your action (e.g., open details, show popup, or run a SQL query)

        }

        private void loadSubordinates()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT STAFF.Ssn, Fname, Lname, Status, Phone_no, Address FROM STAFF JOIN STAFF_PHONE ON STAFF.Ssn = STAFF_PHONE.Ssn WHERE Super_ssn = @ssn";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ssn", staffSSN);
                    SqlDataReader reader = command.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        // Populate UI controls with members information
                        // For example:
                        listBox1.Items.Add($"{reader["Ssn"]} - {reader["Fname"]} {reader["Lname"]} - {reader["Status"]} - {reader["Phone_no"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading members information: {ex.Message}");
                }
            }
        }

        private void subordinatesSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "SELECT STAFF.Ssn, Fname, Lname, Status, Phone_no, Address FROM STAFF JOIN STAFF_PHONE ON STAFF.Ssn = STAFF_PHONE.Ssn WHERE Super_ssn = @ssn AND (Fname LIKE @Search OR Lname LIKE @Search)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + subordinatesSearchTextbox.Text + "%");
                        cmd.Parameters.AddWithValue("@ssn", staffSSN);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            listBox1.Items.Clear();
                            while (reader.Read())
                            {
                                listBox1.Items.Add($"{reader["Ssn"]} - {reader["Fname"]} {reader["Lname"]} - {reader["Status"]} - {reader["Phone_no"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void changeStaffStatusButton_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from the list first.");
                return;
            }

            string input = Interaction.InputBox("Enter new status:", "Status Input");
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "UPDATE STAFF SET Status=@status WHERE Ssn=@ssn;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", input);
                        cmd.Parameters.AddWithValue("@ssn", listBox1.SelectedItem.ToString().Split("-")[0].Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                loadSubordinates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
