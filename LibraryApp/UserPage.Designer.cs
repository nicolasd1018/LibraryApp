namespace LibraryApp
{
    partial class UserPage
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
            checkedOutBooksLabel = new Label();
            checkedoutBooksListBox = new ListBox();
            finesLabel = new Label();
            finesListBox = new ListBox();
            userHeader = new Label();
            searchBooksButton = new Button();
            manageDependentsButton = new Button();
            logoutButton = new Button();
            SuspendLayout();
            // 
            // checkedOutBooksLabel
            // 
            checkedOutBooksLabel.AutoSize = true;
            checkedOutBooksLabel.Location = new Point(83, 139);
            checkedOutBooksLabel.Name = "checkedOutBooksLabel";
            checkedOutBooksLabel.Size = new Size(137, 20);
            checkedOutBooksLabel.TabIndex = 0;
            checkedOutBooksLabel.Text = "Checked Out Books";
            checkedOutBooksLabel.Click += label1_Click;
            // 
            // checkedoutBooksListBox
            // 
            checkedoutBooksListBox.ForeColor = Color.Black;
            checkedoutBooksListBox.FormattingEnabled = true;
            checkedoutBooksListBox.HorizontalScrollbar = true;
            checkedoutBooksListBox.Location = new Point(48, 178);
            checkedoutBooksListBox.Name = "checkedoutBooksListBox";
            checkedoutBooksListBox.Size = new Size(301, 224);
            checkedoutBooksListBox.TabIndex = 1;
            // 
            // finesLabel
            // 
            finesLabel.AutoSize = true;
            finesLabel.Location = new Point(438, 139);
            finesLabel.Name = "finesLabel";
            finesLabel.Size = new Size(42, 20);
            finesLabel.TabIndex = 2;
            finesLabel.Text = "Fines";
            finesLabel.Click += label1_Click_1;
            // 
            // finesListBox
            // 
            finesListBox.FormattingEnabled = true;
            finesListBox.HorizontalScrollbar = true;
            finesListBox.Location = new Point(382, 178);
            finesListBox.Name = "finesListBox";
            finesListBox.Size = new Size(168, 224);
            finesListBox.TabIndex = 3;
            // 
            // userHeader
            // 
            userHeader.AutoSize = true;
            userHeader.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userHeader.Location = new Point(254, 19);
            userHeader.Name = "userHeader";
            userHeader.Size = new Size(263, 54);
            userHeader.TabIndex = 7;
            userHeader.Text = "'s Home Page";
            // 
            // searchBooksButton
            // 
            searchBooksButton.Location = new Point(606, 178);
            searchBooksButton.Name = "searchBooksButton";
            searchBooksButton.Size = new Size(108, 29);
            searchBooksButton.TabIndex = 8;
            searchBooksButton.Text = "Search Books";
            searchBooksButton.UseVisualStyleBackColor = true;
            searchBooksButton.Click += searchBooksButton_Click;
            // 
            // manageDependentsButton
            // 
            manageDependentsButton.Location = new Point(573, 228);
            manageDependentsButton.Name = "manageDependentsButton";
            manageDependentsButton.Size = new Size(169, 29);
            manageDependentsButton.TabIndex = 9;
            manageDependentsButton.Text = "Manage Dependents";
            manageDependentsButton.UseVisualStyleBackColor = true;
            manageDependentsButton.Click += manageDependentsButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(708, 19);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(94, 29);
            logoutButton.TabIndex = 10;
            logoutButton.Text = "Log out";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // UserPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(logoutButton);
            Controls.Add(manageDependentsButton);
            Controls.Add(searchBooksButton);
            Controls.Add(userHeader);
            Controls.Add(finesListBox);
            Controls.Add(finesLabel);
            Controls.Add(checkedoutBooksListBox);
            Controls.Add(checkedOutBooksLabel);
            Name = "UserPage";
            Size = new Size(818, 459);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label checkedOutBooksLabel;
        private ListBox checkedoutBooksListBox;
        private Label finesLabel;
        private ListBox finesListBox;
        private Label userHeader;
        private Button searchBooksButton;
        private Button manageDependentsButton;
        private Button logoutButton;
    }
}
