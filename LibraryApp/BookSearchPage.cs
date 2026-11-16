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
    public partial class BookSearchPage : UserControl
    {
        private Panel homePanel;
        private int memberId;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        public BookSearchPage(Panel homePanel, int memberId)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.memberId = memberId;
            loadBooks();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
           this.homePanel.Controls.Clear();
            UserPage userPage = new UserPage(this.homePanel, this.memberId);
            userPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(userPage);
        }

        private void loadBooks()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string query = "SELECT Title, Author, dbo.BOOK_COPY.ISBN, Genre, Section_name, Floor, Aisle, Publisher, Publication_Year, Availability FROM dbo.BOOK JOIN dbo.BOOK_COPY ON dbo.BOOK.ISBN = dbo.BOOK_COPY.ISBN JOIN dbo.BOOKSHELF ON dbo.BOOK_COPY.Bookshelf_id = dbo.BOOKSHELF.Bookshelf_id JOIN dbo.SECTION ON dbo.BOOKSHELF.Section_id = dbo.SECTION.Section_id;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchedBooksBox.Items.Add($"{reader.GetString(0)} by {reader.GetString(1)} (ISBN: {reader.GetString(2)}) - Genre: {reader.GetString(3)} - Section: {reader.GetString(4)} - Floor: {reader.GetInt32(5)} - Aisle: {reader.GetString(6)} - Publisher: {reader.GetString(7)} - Year: {reader.GetInt32(8)} - Availability: {reader.GetString(9)}");
                        }
                    }
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchedBooksBox.Items.Clear();

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                // 1. Remove the semicolon after 1=1
                string query = "SELECT Title, Author, dbo.BOOK_COPY.ISBN, Genre, Section_name, Floor, Aisle, Publisher, Publication_Year, Availability " +
                               "FROM dbo.BOOK JOIN dbo.BOOK_COPY ON dbo.BOOK.ISBN = dbo.BOOK_COPY.ISBN JOIN dbo.BOOKSHELF ON dbo.BOOK_COPY.Bookshelf_id = dbo.BOOKSHELF.Bookshelf_id JOIN dbo.SECTION ON dbo.BOOKSHELF.Section_id = dbo.SECTION.Section_id " +
                               "WHERE 1=1";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    // 2. Give each parameter a unique name (@title, @author, @genre, @publisher)
                    if (!string.IsNullOrWhiteSpace(titleTextBox.Text))
                    {
                        query += " AND Title LIKE @title";
                        cmd.Parameters.AddWithValue("@title", "%" + titleTextBox.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(isbnTextBox.Text))
                    {
                        query += " AND BOOK_COPY.ISBN LIKE @isbn";
                        cmd.Parameters.AddWithValue("@isbn", "%" + isbnTextBox.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(authorTextBox.Text))
                    {
                        query += " AND Author LIKE @author";
                        cmd.Parameters.AddWithValue("@author", "%" + authorTextBox.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(genreTextBox.Text))
                    {
                        query += " AND Genre LIKE @genre";
                        cmd.Parameters.AddWithValue("@genre", "%" + genreTextBox.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(publisherTextBox.Text))
                    {
                        query += " AND Publisher LIKE @publisher";
                        cmd.Parameters.AddWithValue("@publisher", "%" + publisherTextBox.Text.Trim() + "%");
                    }

                    // 3. Parse years safely as integers
                    if (int.TryParse(yearFromTextBox.Text.Trim(), out int yearFrom))
                    {
                        query += " AND Publication_Year >= @yearFrom";
                        cmd.Parameters.AddWithValue("@yearFrom", yearFrom);
                    }
                    if (int.TryParse(yearToTextBox.Text.Trim(), out int yearTo))
                    {
                        query += " AND Publication_Year <= @yearTo";
                        cmd.Parameters.AddWithValue("@yearTo", yearTo);
                    }

                    // 4. Assign the completed query string to cmd.CommandText before executing
                    cmd.CommandText = query;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchedBooksBox.Items.Add(
                                $"{reader["Title"]} by {reader["Author"]} (ISBN: {reader["ISBN"]}) - " +
                                $"Genre: {reader["Genre"]} - Section: {reader["Section_name"]} - Floor: {reader["Floor"]} - Aisle: {reader["Aisle"]} - Publisher: {reader["Publisher"]} - Year: {reader["Publication_Year"]} - Availability: {reader["Availability"]}"
                            );
                        }
                    }
                }
            }

        }
    }
}
