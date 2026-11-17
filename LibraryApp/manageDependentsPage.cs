using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LibraryApp
{
    public partial class manageDependentsPage : UserControl
    {
        private Panel homePanel;
        private int memberId;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        public manageDependentsPage(Panel homePanel, int memberId)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.memberId = memberId;
            loadDependents();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            UserPage userPage = new UserPage(this.homePanel, this.memberId);
            userPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(userPage);
        }

        private void addDependentButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO dbo.DEPENDENT (Member_id, Name, B_date, Relationship, Sex) VALUES (@Member_id, @Name, @B_date, @Relationship, @Sex)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Member_id", this.memberId);
                        cmd.Parameters.AddWithValue("@Name", nameTextBox.Text);
                        cmd.Parameters.AddWithValue("@B_date", birthdayTextBox.Text);
                        cmd.Parameters.AddWithValue("@Relationship", relationshipTextBox.Text);
                        cmd.Parameters.AddWithValue("@Sex", genderTextBox.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                listBox1.Items.Add($"{nameTextBox.Text} - {relationshipTextBox.Text} - {genderTextBox.Text} - {birthdayTextBox.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void loadDependents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    string query = "SELECT Name, Relationship, Sex, B_date FROM dbo.DEPENDENT WHERE Member_id = @Member_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Member_id", this.memberId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listBox1.Items.Add($"{reader.GetString(0)} - {reader.GetString(1)} - {reader.GetString(2)} - {reader.GetDateTime(3):yyyy-MM-dd}");
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            string query = "DELETE FROM dbo.DEPENDENT WHERE Member_id=@Member_id AND Name=@Name";
                try
                {
                    using (SqlConnection conn = new SqlConnection(this.connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Member_id", memberId);
                            cmd.Parameters.AddWithValue("@Name", listBox1.SelectedItem.ToString().Split("-")[0].Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                listBox1.Items.Remove(listBox1.SelectedItem.ToString());
                                MessageBox.Show("Record deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No matching record was found.");
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Note: Error 547 occurs if another table (like BORROWS) still references this record
                    MessageBox.Show("Delete failed: " + ex.Message);
                }

            
        }
    }
}
