using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class BookForm : Form
    {
        private bool isUpdate;
        private string connectionString = @"Server=localhost;Database=Library System ;Trusted_Connection=True;TrustServerCertificate=True;";
        private string isbn;
        private string title;
        private string author;
        private string publisher;
        private string publicationYears;
        private string genre;
        private string availability;
        private string bookshelfId;

        public BookForm()
        {
            InitializeComponent();
            isUpdate = false;
            loadShelves();
        }

        public BookForm(string isbn, string title, string author, string publisher, string publicationYears, string genre, string availability, string bookshelfId)
        {
            InitializeComponent();
            isUpdate = true;
            loadShelves();
            this.isbn = isbn;
            isbnTextBox.Text = isbn;
            this.title = title;
            titleTextBox.Text = title;
            this.author = author;
            authorTextBox.Text = author;
            this.publisher = publisher;
            publisherBox.Text = publisher;
            this.publicationYears = publicationYears;
            yearPublishedTextBox.Text = publicationYears;
            this.genre = genre;
            genreTextBox.Text = genre;
            this.availability = availability;
            availabilityTextBox.Text = availability;
            this.bookshelfId = bookshelfId;
            int index = shelfComboBox.FindString($"Shelf {bookshelfId}");
            shelfComboBox.SelectedIndex = index;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(authorTextBox.Text) || string.IsNullOrWhiteSpace(isbnTextBox.Text) ||
                string.IsNullOrWhiteSpace(genreTextBox.Text) || string.IsNullOrWhiteSpace(publisherBox.Text) || string.IsNullOrWhiteSpace(yearPublishedTextBox.Text) ||
                string.IsNullOrWhiteSpace(availabilityTextBox.Text) || string.IsNullOrWhiteSpace(shelfComboBox.SelectedItem.ToString())))
            {    if (isUpdate)
                {
                    using (SqlConnection conn = new SqlConnection(this.connectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // 1. Compare dbo.BOOK fields against original holders
                            List<string> bookUpdates = new List<string>();
                            using (SqlCommand cmdBook = new SqlCommand())
                            {
                                cmdBook.Connection = conn;
                                cmdBook.Transaction = transaction;

                                string newTitle = titleTextBox.Text.Trim();
                                if (newTitle != this.title)
                                {
                                    bookUpdates.Add("Title = @Title");
                                    cmdBook.Parameters.AddWithValue("@Title", newTitle);
                                }

                                string newAuthor = authorTextBox.Text.Trim();
                                if (newAuthor != this.author)
                                {
                                    bookUpdates.Add("Author = @Author");
                                    cmdBook.Parameters.AddWithValue("@Author", newAuthor);
                                }

                                string newPublisher = publisherBox.Text.Trim();
                                if (newPublisher != this.publisher)
                                {
                                    bookUpdates.Add("Publisher = @Publisher");
                                    cmdBook.Parameters.AddWithValue("@Publisher", newPublisher);
                                }

                                string newGenre = genreTextBox.Text.Trim();
                                if (newGenre != this.genre)
                                {
                                    bookUpdates.Add("Genre = @Genre");
                                    cmdBook.Parameters.AddWithValue("@Genre", newGenre);
                                }

                                string newYear = yearPublishedTextBox.Text.Trim();
                                if (newYear != this.publicationYears)
                                {
                                    bookUpdates.Add("Publication_year = @Publication_year");
                                    cmdBook.Parameters.AddWithValue("@Publication_year", int.Parse(newYear));
                                }

                                string newIsbn = isbnTextBox.Text.Trim();
                                if (newIsbn != this.isbn)
                                {
                                    bookUpdates.Add("ISBN = @NewISBN");
                                    cmdBook.Parameters.AddWithValue("@NewISBN", newIsbn);
                                }

                                if (bookUpdates.Count > 0)
                                {
                                    cmdBook.CommandText = $"UPDATE dbo.BOOK SET {string.Join(", ", bookUpdates)} WHERE ISBN = @OriginalISBN;";
                                    cmdBook.Parameters.AddWithValue("@OriginalISBN", this.isbn);
                                    cmdBook.ExecuteNonQuery();
                                }
                            }

                            // 2. Compare dbo.BOOK_COPY fields against original holders
                            List<string> copyUpdates = new List<string>();
                            using (SqlCommand cmdCopy = new SqlCommand())
                            {
                                cmdCopy.Connection = conn;
                                cmdCopy.Transaction = transaction;

                                string newAvailability = availabilityTextBox.Text.Trim();
                                if (newAvailability != this.availability)
                                {
                                    copyUpdates.Add("Availability = @Availability");
                                    cmdCopy.Parameters.AddWithValue("@Availability", newAvailability);
                                }

                                string selectedShelfId = shelfComboBox.SelectedItem.ToString().Split('-')[0].Trim().Split(' ')[1].Trim();
                                if (selectedShelfId != this.bookshelfId)
                                {
                                    copyUpdates.Add("Bookshelf_id = @Bookshelf_id");
                                    cmdCopy.Parameters.AddWithValue("@Bookshelf_id", int.Parse(selectedShelfId));
                                }

                                if (copyUpdates.Count > 0)
                                {
                                    cmdCopy.CommandText = $"UPDATE dbo.BOOK_COPY SET {string.Join(", ", copyUpdates)} WHERE ISBN = @TargetISBN;";
                                    cmdCopy.Parameters.AddWithValue("@TargetISBN", isbnTextBox.Text.Trim());
                                    cmdCopy.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("SQL Error: " + ex.Message);
                        }
                    }

                }
                else
                {
                    string memberQuery = "INSERT INTO BOOK (ISBN, Title, Author, Publisher, Publication_year, Genre) VALUES (@ISBN, @Title, @Author, @Publisher, @Publication_year, @Genre);";
                    string memberPhoneQuery = "INSERT INTO BOOK_COPY (ISBN, Copy_id, Bookshelf_id, Availability) VALUES (@ISBN, @Copy_id, @Bookshelf_id, @availability);";

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(this.connectionString))
                        {
                            conn.Open();
                            SqlTransaction transaction = conn.BeginTransaction();


                            using (SqlCommand cmd = new SqlCommand(memberQuery, conn, transaction))
                            {

                                cmd.Parameters.AddWithValue("@ISBN", isbnTextBox.Text);
                                cmd.Parameters.AddWithValue("@Title", titleTextBox.Text);
                                cmd.Parameters.AddWithValue("@Author", authorTextBox.Text);
                                cmd.Parameters.AddWithValue("@Publisher", publisherBox.Text);
                                cmd.Parameters.AddWithValue("@Publication_year", yearPublishedTextBox.Text);
                                cmd.Parameters.AddWithValue("@Genre", genreTextBox.Text);

                                cmd.ExecuteNonQuery();

                            }

                            using (SqlCommand cmd = new SqlCommand(memberPhoneQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ISBN", isbnTextBox.Text);
                                cmd.Parameters.AddWithValue("@Copy_id", Random.Shared.Next(100,999));
                                cmd.Parameters.AddWithValue("@Bookshelf_id", int.Parse(shelfComboBox.SelectedItem.ToString().Split("-")[0].Trim().Split(" ")[1].Trim()));
                                cmd.Parameters.AddWithValue("@availability", availabilityTextBox.Text);

                                cmd.ExecuteNonQuery();

                            }
                            transaction.Commit();
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("SQL Error: " + ex.Message);
                    }
                }
            }
        }

        private void loadShelves()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string query = "SELECT Bookshelf_id, Section_name, Floor, Aisle FROM BOOKSHELF JOIN SECTION ON BOOKSHELF.Section_id = SECTION.Section_id;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shelfComboBox.Items.Add($"Shelf {reader["Bookshelf_id"]} - Section {reader["Section_name"]} - Floor {reader["Floor"]} - Aisle {reader["Aisle"]}");
                        }
                    }
                }
            }
        }
    }
}
