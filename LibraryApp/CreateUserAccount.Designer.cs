namespace LibraryApp
{
    partial class CreateUserAccount
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
            firstNameTextBox = new TextBox();
            middleInitialTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            firstNameLabel = new Label();
            middleInititialLabel = new Label();
            lastNameLabel = new Label();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            addressTextBox = new TextBox();
            addressLabel = new Label();
            createMemberAccountButton = new Button();
            phoneNumberLabel = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(216, 94);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(125, 27);
            firstNameTextBox.TabIndex = 0;
            // 
            // middleInitialTextBox
            // 
            middleInitialTextBox.Location = new Point(383, 93);
            middleInitialTextBox.Name = "middleInitialTextBox";
            middleInitialTextBox.Size = new Size(33, 27);
            middleInitialTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(507, 94);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(125, 27);
            lastNameTextBox.TabIndex = 2;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(130, 101);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 3;
            firstNameLabel.Text = "First Name";
            // 
            // middleInititialLabel
            // 
            middleInititialLabel.AutoSize = true;
            middleInititialLabel.Location = new Point(351, 100);
            middleInititialLabel.Name = "middleInititialLabel";
            middleInititialLabel.Size = new Size(26, 20);
            middleInititialLabel.TabIndex = 4;
            middleInititialLabel.Text = "MI";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(422, 100);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 5;
            lastNameLabel.Text = "Last Name";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(130, 135);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(216, 132);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(416, 27);
            emailTextBox.TabIndex = 7;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(216, 201);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(416, 27);
            addressTextBox.TabIndex = 8;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(130, 204);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(62, 20);
            addressLabel.TabIndex = 9;
            addressLabel.Text = "Address";
            // 
            // createMemberAccountButton
            // 
            createMemberAccountButton.Location = new Point(296, 259);
            createMemberAccountButton.Name = "createMemberAccountButton";
            createMemberAccountButton.Size = new Size(205, 29);
            createMemberAccountButton.TabIndex = 10;
            createMemberAccountButton.Text = "Create Member Account";
            createMemberAccountButton.UseVisualStyleBackColor = true;
            createMemberAccountButton.Click += createMemberAccountButton_Click;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(130, 169);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(77, 20);
            phoneNumberLabel.TabIndex = 11;
            phoneNumberLabel.Text = "Phone No.";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 167);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(416, 27);
            textBox1.TabIndex = 12;
            // 
            // CreateUserAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(phoneNumberLabel);
            Controls.Add(createMemberAccountButton);
            Controls.Add(addressLabel);
            Controls.Add(addressTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(middleInititialLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(middleInitialTextBox);
            Controls.Add(firstNameTextBox);
            Name = "CreateUserAccount";
            Size = new Size(818, 415);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameTextBox;
        private TextBox middleInitialTextBox;
        private TextBox lastNameTextBox;
        private Label firstNameLabel;
        private Label middleInititialLabel;
        private Label lastNameLabel;
        private Label emailLabel;
        private TextBox emailTextBox;
        private TextBox addressTextBox;
        private Label addressLabel;
        private Button createMemberAccountButton;
        private Label phoneNumberLabel;
        private TextBox textBox1;
    }
}
