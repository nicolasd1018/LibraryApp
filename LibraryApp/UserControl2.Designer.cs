namespace LibraryApp
{
    partial class UserControl2
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
            userNameTextBox = new TextBox();
            usernameLabel = new Label();
            backButton = new Button();
            LoginButton = new Button();
            createNewAccountButton = new Button();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(217, 153);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(348, 27);
            userNameTextBox.TabIndex = 0;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(165, 160);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(46, 20);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Email";
            usernameLabel.Click += label1_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(280, 198);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 4;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(416, 198);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 29);
            LoginButton.TabIndex = 5;
            LoginButton.Text = "Send Code";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // createNewAccountButton
            // 
            createNewAccountButton.Location = new Point(319, 248);
            createNewAccountButton.Name = "createNewAccountButton";
            createNewAccountButton.Size = new Size(160, 29);
            createNewAccountButton.TabIndex = 6;
            createNewAccountButton.Text = "Create New Account";
            createNewAccountButton.UseVisualStyleBackColor = true;
            createNewAccountButton.Click += button1_Click;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(createNewAccountButton);
            Controls.Add(LoginButton);
            Controls.Add(backButton);
            Controls.Add(usernameLabel);
            Controls.Add(userNameTextBox);
            Name = "UserControl2";
            Size = new Size(818, 525);
            Load += UserControl2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox userNameTextBox;
        private Label usernameLabel;
        private Button backButton;
        private Button LoginButton;
        private Button createNewAccountButton;
    }
}
