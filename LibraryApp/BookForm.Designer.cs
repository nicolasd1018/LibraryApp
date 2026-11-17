namespace LibraryApp
{
    partial class BookForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleTextBox = new TextBox();
            authorTextBox = new TextBox();
            isbnTextBox = new TextBox();
            genreTextBox = new TextBox();
            publisherBox = new TextBox();
            yearPublishedTextBox = new TextBox();
            titleLabel = new Label();
            authorLabel = new Label();
            isbnLabel = new Label();
            genreLabel = new Label();
            publisherLabel = new Label();
            yearPublishedLabel = new Label();
            shelfComboBox = new ComboBox();
            shelfLabel = new Label();
            saveButton = new Button();
            availabilityTextBox = new TextBox();
            availabilityLabel = new Label();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(111, 47);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(125, 27);
            titleTextBox.TabIndex = 0;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(317, 47);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(125, 27);
            authorTextBox.TabIndex = 1;
            // 
            // isbnTextBox
            // 
            isbnTextBox.Location = new Point(569, 50);
            isbnTextBox.Name = "isbnTextBox";
            isbnTextBox.Size = new Size(125, 27);
            isbnTextBox.TabIndex = 2;
            // 
            // genreTextBox
            // 
            genreTextBox.Location = new Point(111, 110);
            genreTextBox.Name = "genreTextBox";
            genreTextBox.Size = new Size(125, 27);
            genreTextBox.TabIndex = 3;
            // 
            // publisherBox
            // 
            publisherBox.Location = new Point(317, 110);
            publisherBox.Name = "publisherBox";
            publisherBox.Size = new Size(125, 27);
            publisherBox.TabIndex = 4;
            // 
            // yearPublishedTextBox
            // 
            yearPublishedTextBox.Location = new Point(569, 113);
            yearPublishedTextBox.Name = "yearPublishedTextBox";
            yearPublishedTextBox.Size = new Size(125, 27);
            yearPublishedTextBox.TabIndex = 5;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(55, 50);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(38, 20);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(261, 50);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(54, 20);
            authorLabel.TabIndex = 7;
            authorLabel.Text = "Author";
            // 
            // isbnLabel
            // 
            isbnLabel.AutoSize = true;
            isbnLabel.Location = new Point(493, 53);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.Size = new Size(41, 20);
            isbnLabel.TabIndex = 8;
            isbnLabel.Text = "ISBN";
            // 
            // genreLabel
            // 
            genreLabel.AutoSize = true;
            genreLabel.Location = new Point(55, 113);
            genreLabel.Name = "genreLabel";
            genreLabel.Size = new Size(48, 20);
            genreLabel.TabIndex = 9;
            genreLabel.Text = "Genre";
            // 
            // publisherLabel
            // 
            publisherLabel.AutoSize = true;
            publisherLabel.Location = new Point(246, 113);
            publisherLabel.Name = "publisherLabel";
            publisherLabel.Size = new Size(69, 20);
            publisherLabel.TabIndex = 10;
            publisherLabel.Text = "Publisher";
            // 
            // yearPublishedLabel
            // 
            yearPublishedLabel.AutoSize = true;
            yearPublishedLabel.Location = new Point(465, 117);
            yearPublishedLabel.Name = "yearPublishedLabel";
            yearPublishedLabel.Size = new Size(105, 20);
            yearPublishedLabel.TabIndex = 11;
            yearPublishedLabel.Text = "Year Published";
            // 
            // shelfComboBox
            // 
            shelfComboBox.FormattingEnabled = true;
            shelfComboBox.Location = new Point(317, 164);
            shelfComboBox.Name = "shelfComboBox";
            shelfComboBox.Size = new Size(377, 28);
            shelfComboBox.TabIndex = 12;
            // 
            // shelfLabel
            // 
            shelfLabel.AutoSize = true;
            shelfLabel.Location = new Point(259, 167);
            shelfLabel.Name = "shelfLabel";
            shelfLabel.Size = new Size(42, 20);
            shelfLabel.TabIndex = 13;
            shelfLabel.Text = "Shelf";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(335, 232);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 14;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // availabilityTextBox
            // 
            availabilityTextBox.Location = new Point(111, 165);
            availabilityTextBox.Name = "availabilityTextBox";
            availabilityTextBox.Size = new Size(125, 27);
            availabilityTextBox.TabIndex = 15;
            // 
            // availabilityLabel
            // 
            availabilityLabel.AutoSize = true;
            availabilityLabel.Location = new Point(22, 168);
            availabilityLabel.Name = "availabilityLabel";
            availabilityLabel.Size = new Size(83, 20);
            availabilityLabel.TabIndex = 16;
            availabilityLabel.Text = "Availability";
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(availabilityLabel);
            Controls.Add(availabilityTextBox);
            Controls.Add(saveButton);
            Controls.Add(shelfLabel);
            Controls.Add(shelfComboBox);
            Controls.Add(yearPublishedLabel);
            Controls.Add(publisherLabel);
            Controls.Add(genreLabel);
            Controls.Add(isbnLabel);
            Controls.Add(authorLabel);
            Controls.Add(titleLabel);
            Controls.Add(yearPublishedTextBox);
            Controls.Add(publisherBox);
            Controls.Add(genreTextBox);
            Controls.Add(isbnTextBox);
            Controls.Add(authorTextBox);
            Controls.Add(titleTextBox);
            Name = "BookForm";
            Text = "BookForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private TextBox authorTextBox;
        private TextBox isbnTextBox;
        private TextBox genreTextBox;
        private TextBox publisherBox;
        private TextBox yearPublishedTextBox;
        private Label titleLabel;
        private Label authorLabel;
        private Label isbnLabel;
        private Label genreLabel;
        private Label publisherLabel;
        private Label yearPublishedLabel;
        private ComboBox shelfComboBox;
        private Label shelfLabel;
        private Button saveButton;
        private TextBox availabilityTextBox;
        private Label availabilityLabel;
    }
}