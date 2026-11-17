using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool isMember;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        public BookSearchPage(Panel homePanel, int memberId, bool isMember)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.memberId = memberId;
            this.isMember = isMember;
            loadBooks();
            if (isMember)
            {
                addBookButton.Visible = false;
                editBookButton.Visible = false;
                deleteBookButton.Visible = false;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (isMember)
            {
                this.homePanel.Controls.Clear();
                UserPage userPage = new UserPage(this.homePanel, this.memberId);
                userPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(userPage);
            }
            else
            {
                this.homePanel.Controls.Clear();
                StaffPage staffPage = new StaffPage(this.homePanel, $"{memberId}");
                staffPage.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(staffPage);
            }
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
                        searchedBooksBox.Items.Clear();
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

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            int start = searchedBooksBox.SelectedItem.ToString().IndexOf("(ISBN: ") + 7; // 7 is the length of "(ISBN: "
            int end = searchedBooksBox.SelectedItem.ToString().IndexOf(")", start);

            string isbn = searchedBooksBox.SelectedItem.ToString().Substring(start, end - start).Trim();
            DialogResult confirm = MessageBox.Show(
            $"Permanently delete book (ISBN: {isbn}) and all its copies?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            string deleteBorrowsSql = "DELETE FROM dbo.BORROWS WHERE Copy_id IN (SELECT Copy_id FROM dbo.BOOK_COPY WHERE ISBN = @ISBN);";
            string deleteCopiesSql = "DELETE FROM dbo.BOOK_COPY WHERE ISBN = @ISBN;";
            string deleteBookSql = "DELETE FROM dbo.BOOK WHERE ISBN = @ISBN;";

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Delete borrow history referencing copies of this ISBN
                    using (SqlCommand cmd1 = new SqlCommand(deleteBorrowsSql, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@ISBN", isbn);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2. Delete physical copies in BOOK_COPY
                    using (SqlCommand cmd2 = new SqlCommand(deleteCopiesSql, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@ISBN", isbn);
                        cmd2.ExecuteNonQuery();
                    }

                    // 3. Delete main book record in BOOK
                    using (SqlCommand cmd3 = new SqlCommand(deleteBookSql, conn, transaction))
                    {
                        cmd3.Parameters.AddWithValue("@ISBN", isbn);
                        cmd3.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    searchedBooksBox.Items.Remove(searchedBooksBox.SelectedItem);

                    MessageBox.Show("Book and all related copies deleted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Delete failed and was rolled back: " + ex.Message);
                }
            }

        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            using (BookForm popup = new BookForm())
            {
                popup.StartPosition = FormStartPosition.CenterParent; // Centers over your current window
                DialogResult result = popup.ShowDialog();

                // Optional: Refresh your ListBox after the user clicks Save/OK on the popup
                if (result == DialogResult.OK)
                {
                    // Call your reload method here (e.g., loadBooks();)
                    loadBooks();
                }
            }

        }

        private void editBookButton_Click(object sender, EventArgs e)
        {
            int start = searchedBooksBox.SelectedItem.ToString().IndexOf("(ISBN: ") + 7; // 7 is the length of "(ISBN: "
            int end = searchedBooksBox.SelectedItem.ToString().IndexOf(")", start);

            string isbn = searchedBooksBox.SelectedItem.ToString().Substring(start, end - start).Trim();
            string query = @"
                            SELECT TOP 1 
                                b.ISBN, b.Title, b.Author, b.Publisher, b.Publication_year, b.Genre,
                                bc.Availability, bc.Bookshelf_id, s.Section_name, bs.Floor, bs.Aisle
                            FROM dbo.BOOK b
                            LEFT JOIN dbo.BOOK_COPY bc ON b.ISBN = bc.ISBN
                            LEFT JOIN dbo.BOOKSHELF bs ON bc.Bookshelf_id = bs.Bookshelf_id
                            LEFT JOIN dbo.SECTION s ON bs.Section_id = s.Section_id
                            WHERE b.ISBN = @ISBN;";

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", isbn.Trim());
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            using (BookForm popup = new BookForm(isbn.Trim(), $"{reader["Title"]}", $"{reader["Author"]}", $"{reader["Publisher"]}", $"{reader["Publication_year"]}", $"{reader["Genre"]}", $"{reader["Availability"]}", $"{reader["BookShelf_id"]}"))
                            {
                                popup.StartPosition = FormStartPosition.CenterParent; // Centers over your current window
                                DialogResult result = popup.ShowDialog();

                                // Optional: Refresh your ListBox after the user clicks Save/OK on the popup
                                if (result == DialogResult.OK)
                                {
                                    // Call your reload method here (e.g., loadBooks();)
                                    loadBooks();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No book found with that ISBN.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book: " + ex.Message);
            }

            
        }
    }
}
