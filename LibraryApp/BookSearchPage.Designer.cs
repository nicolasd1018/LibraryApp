namespace LibraryApp
{
    partial class BookSearchPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleTextBox = new TextBox();
            isbnTextBox = new TextBox();
            authorTextBox = new TextBox();
            genreTextBox = new TextBox();
            publisherTextBox = new TextBox();
            yearFromTextBox = new TextBox();
            yearToTextBox = new TextBox();
            titleLable = new Label();
            isbnLabel = new Label();
            authorLabel = new Label();
            genreLabel = new Label();
            publisherLabel = new Label();
            yearPublishedLabel = new Label();
            label1 = new Label();
            headerLabel = new Label();
            searchedBooksBox = new ListBox();
            searchButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(145, 103);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(125, 27);
            titleTextBox.TabIndex = 0;
            // 
            // isbnTextBox
            // 
            isbnTextBox.Location = new Point(350, 103);
            isbnTextBox.Name = "isbnTextBox";
            isbnTextBox.Size = new Size(125, 27);
            isbnTextBox.TabIndex = 1;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(145, 167);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(125, 27);
            authorTextBox.TabIndex = 2;
            // 
            // genreTextBox
            // 
            genreTextBox.Location = new Point(350, 167);
            genreTextBox.Name = "genreTextBox";
            genreTextBox.Size = new Size(125, 27);
            genreTextBox.TabIndex = 3;
            // 
            // publisherTextBox
            // 
            publisherTextBox.Location = new Point(589, 103);
            publisherTextBox.Name = "publisherTextBox";
            publisherTextBox.Size = new Size(125, 27);
            publisherTextBox.TabIndex = 4;
            // 
            // yearFromTextBox
            // 
            yearFromTextBox.Location = new Point(611, 168);
            yearFromTextBox.Name = "yearFromTextBox";
            yearFromTextBox.Size = new Size(38, 27);
            yearFromTextBox.TabIndex = 5;
            // 
            // yearToTextBox
            // 
            yearToTextBox.Location = new Point(676, 167);
            yearToTextBox.Name = "yearToTextBox";
            yearToTextBox.Size = new Size(38, 27);
            yearToTextBox.TabIndex = 6;
            // 
            // titleLable
            // 
            titleLable.AutoSize = true;
            titleLable.Location = new Point(91, 106);
            titleLable.Name = "titleLable";
            titleLable.Size = new Size(38, 20);
            titleLable.TabIndex = 7;
            titleLable.Text = "Title";
            // 
            // isbnLabel
            // 
            isbnLabel.AutoSize = true;
            isbnLabel.Location = new Point(303, 110);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.Size = new Size(41, 20);
            isbnLabel.TabIndex = 8;
            isbnLabel.Text = "ISBN";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(533, 106);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(54, 20);
            authorLabel.TabIndex = 9;
            authorLabel.Text = "Author";
            // 
            // genreLabel
            // 
            genreLabel.AutoSize = true;
            genreLabel.Location = new Point(91, 174);
            genreLabel.Name = "genreLabel";
            genreLabel.Size = new Size(48, 20);
            genreLabel.TabIndex = 10;
            genreLabel.Text = "Genre";
            // 
            // publisherLabel
            // 
            publisherLabel.AutoSize = true;
            publisherLabel.Location = new Point(275, 174);
            publisherLabel.Name = "publisherLabel";
            publisherLabel.Size = new Size(69, 20);
            publisherLabel.TabIndex = 11;
            publisherLabel.Text = "Publisher";
            // 
            // yearPublishedLabel
            // 
            yearPublishedLabel.AutoSize = true;
            yearPublishedLabel.Location = new Point(491, 170);
            yearPublishedLabel.Name = "yearPublishedLabel";
            yearPublishedLabel.Size = new Size(105, 20);
            yearPublishedLabel.TabIndex = 12;
            yearPublishedLabel.Text = "Year Published";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(655, 174);
            label1.Name = "label1";
            label1.Size = new Size(15, 20);
            label1.TabIndex = 13;
            label1.Text = "-";
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(334, 18);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(153, 60);
            headerLabel.TabIndex = 14;
            headerLabel.Text = "Search";
            // 
            // searchedBooksBox
            // 
            searchedBooksBox.FormattingEnabled = true;
            searchedBooksBox.Location = new Point(91, 260);
            searchedBooksBox.Name = "searchedBooksBox";
            searchedBooksBox.Size = new Size(623, 144);
            searchedBooksBox.TabIndex = 15;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(362, 214);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(94, 28);
            searchButton.TabIndex = 16;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            backButton.Location = new Point(21, 18);
            backButton.Name = "backButton";
            backButton.Size = new Size(59, 29);
            backButton.TabIndex = 17;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // BookSearchPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backButton);
            Controls.Add(searchButton);
            Controls.Add(searchedBooksBox);
            Controls.Add(headerLabel);
            Controls.Add(label1);
            Controls.Add(yearPublishedLabel);
            Controls.Add(publisherLabel);
            Controls.Add(genreLabel);
            Controls.Add(authorLabel);
            Controls.Add(isbnLabel);
            Controls.Add(titleLable);
            Controls.Add(yearToTextBox);
            Controls.Add(yearFromTextBox);
            Controls.Add(publisherTextBox);
            Controls.Add(genreTextBox);
            Controls.Add(authorTextBox);
            Controls.Add(isbnTextBox);
            Controls.Add(titleTextBox);
            Name = "BookSearchPage";
            Size = new Size(818, 441);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private TextBox isbnTextBox;
        private TextBox authorTextBox;
        private TextBox genreTextBox;
        private TextBox publisherTextBox;
        private TextBox yearFromTextBox;
        private TextBox yearToTextBox;
        private Label titleLable;
        private Label isbnLabel;
        private Label authorLabel;
        private Label genreLabel;
        private Label publisherLabel;
        private Label yearPublishedLabel;
        private Label label1;
        private Label headerLabel;
        private ListBox searchedBooksBox;
        private Button searchButton;
        private Button backButton;
    }
}
