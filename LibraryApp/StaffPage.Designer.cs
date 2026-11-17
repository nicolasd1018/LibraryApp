namespace LibraryApp
{
    partial class StaffPage
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
            headerLabel = new Label();
            membersLabel = new Label();
            membersListBox = new ListBox();
            fineButton = new Button();
            membersSearchTextBox = new TextBox();
            searchMembersButton = new Button();
            subordinatesLabel = new Label();
            subordinatesSearchTextbox = new TextBox();
            subordinatesSearchButton = new Button();
            listBox1 = new ListBox();
            logoutButton = new Button();
            searchBooksButton = new Button();
            changeMemberStatusButton = new Button();
            changeStaffStatusButton = new Button();
            showFineHoldersButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(244, 18);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(324, 60);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "'s Staff Account";
            // 
            // membersLabel
            // 
            membersLabel.AutoSize = true;
            membersLabel.Location = new Point(109, 96);
            membersLabel.Name = "membersLabel";
            membersLabel.Size = new Size(71, 20);
            membersLabel.TabIndex = 1;
            membersLabel.Text = "Members";
            // 
            // membersListBox
            // 
            membersListBox.FormattingEnabled = true;
            membersListBox.HorizontalScrollbar = true;
            membersListBox.Location = new Point(53, 152);
            membersListBox.Name = "membersListBox";
            membersListBox.Size = new Size(198, 164);
            membersListBox.TabIndex = 2;
            membersListBox.MouseDoubleClick += membersListBox_MouseDoubleClick;
            // 
            // fineButton
            // 
            fineButton.Location = new Point(53, 331);
            fineButton.Name = "fineButton";
            fineButton.Size = new Size(80, 29);
            fineButton.TabIndex = 3;
            fineButton.Text = "Issue Fine";
            fineButton.UseVisualStyleBackColor = true;
            fineButton.Click += fineButton_Click;
            // 
            // membersSearchTextBox
            // 
            membersSearchTextBox.Location = new Point(53, 119);
            membersSearchTextBox.Name = "membersSearchTextBox";
            membersSearchTextBox.Size = new Size(198, 27);
            membersSearchTextBox.TabIndex = 4;
            // 
            // searchMembersButton
            // 
            searchMembersButton.Location = new Point(259, 121);
            searchMembersButton.Name = "searchMembersButton";
            searchMembersButton.Size = new Size(61, 29);
            searchMembersButton.TabIndex = 5;
            searchMembersButton.Text = "Search";
            searchMembersButton.UseVisualStyleBackColor = true;
            searchMembersButton.Click += searchMembersButton_Click;
            // 
            // subordinatesLabel
            // 
            subordinatesLabel.AutoSize = true;
            subordinatesLabel.Location = new Point(371, 90);
            subordinatesLabel.Name = "subordinatesLabel";
            subordinatesLabel.Size = new Size(96, 20);
            subordinatesLabel.TabIndex = 6;
            subordinatesLabel.Text = "Subordinates";
            // 
            // subordinatesSearchTextbox
            // 
            subordinatesSearchTextbox.Location = new Point(342, 121);
            subordinatesSearchTextbox.Name = "subordinatesSearchTextbox";
            subordinatesSearchTextbox.Size = new Size(150, 27);
            subordinatesSearchTextbox.TabIndex = 7;
            // 
            // subordinatesSearchButton
            // 
            subordinatesSearchButton.Location = new Point(498, 120);
            subordinatesSearchButton.Name = "subordinatesSearchButton";
            subordinatesSearchButton.Size = new Size(61, 29);
            subordinatesSearchButton.TabIndex = 8;
            subordinatesSearchButton.Text = "Search";
            subordinatesSearchButton.UseVisualStyleBackColor = true;
            subordinatesSearchButton.Click += subordinatesSearchButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.Location = new Point(342, 154);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 164);
            listBox1.TabIndex = 9;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(688, 18);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(94, 29);
            logoutButton.TabIndex = 10;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // searchBooksButton
            // 
            searchBooksButton.Location = new Point(682, 331);
            searchBooksButton.Name = "searchBooksButton";
            searchBooksButton.Size = new Size(105, 29);
            searchBooksButton.TabIndex = 11;
            searchBooksButton.Text = "Search Books";
            searchBooksButton.UseVisualStyleBackColor = true;
            searchBooksButton.Click += searchBooksButton_Click;
            // 
            // changeMemberStatusButton
            // 
            changeMemberStatusButton.Location = new Point(139, 331);
            changeMemberStatusButton.Name = "changeMemberStatusButton";
            changeMemberStatusButton.Size = new Size(112, 29);
            changeMemberStatusButton.TabIndex = 12;
            changeMemberStatusButton.Text = "Change Status";
            changeMemberStatusButton.UseVisualStyleBackColor = true;
            changeMemberStatusButton.Click += changeMemberStatusButton_Click;
            // 
            // changeStaffStatusButton
            // 
            changeStaffStatusButton.Location = new Point(358, 331);
            changeStaffStatusButton.Name = "changeStaffStatusButton";
            changeStaffStatusButton.Size = new Size(119, 29);
            changeStaffStatusButton.TabIndex = 13;
            changeStaffStatusButton.Text = "Change Status";
            changeStaffStatusButton.UseVisualStyleBackColor = true;
            changeStaffStatusButton.Click += changeStaffStatusButton_Click;
            // 
            // showFineHoldersButton
            // 
            showFineHoldersButton.Location = new Point(76, 366);
            showFineHoldersButton.Name = "showFineHoldersButton";
            showFineHoldersButton.Size = new Size(152, 29);
            showFineHoldersButton.TabIndex = 14;
            showFineHoldersButton.Text = "Show Fine Holders";
            showFineHoldersButton.UseVisualStyleBackColor = true;
            showFineHoldersButton.Click += showFineHoldersButton_Click;
            // 
            // StaffPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(showFineHoldersButton);
            Controls.Add(changeStaffStatusButton);
            Controls.Add(changeMemberStatusButton);
            Controls.Add(searchBooksButton);
            Controls.Add(logoutButton);
            Controls.Add(listBox1);
            Controls.Add(subordinatesSearchButton);
            Controls.Add(subordinatesSearchTextbox);
            Controls.Add(subordinatesLabel);
            Controls.Add(searchMembersButton);
            Controls.Add(membersSearchTextBox);
            Controls.Add(fineButton);
            Controls.Add(membersListBox);
            Controls.Add(membersLabel);
            Controls.Add(headerLabel);
            Name = "StaffPage";
            Size = new Size(818, 425);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label membersLabel;
        private ListBox membersListBox;
        private Button fineButton;
        private TextBox membersSearchTextBox;
        private Button searchMembersButton;
        private Label subordinatesLabel;
        private TextBox subordinatesSearchTextbox;
        private Button subordinatesSearchButton;
        private ListBox listBox1;
        private Button logoutButton;
        private Button searchBooksButton;
        private Button changeMemberStatusButton;
        private Button changeStaffStatusButton;
        private Button showFineHoldersButton;
    }
}
