namespace LibraryApp
{
    partial class CreateStaffAccount
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
            ssnLabel = new Label();
            ssnTextBox = new TextBox();
            birthdayLabel = new Label();
            comboBox1 = new ComboBox();
            birthdayTextBox = new TextBox();
            genderLabel = new Label();
            firstNameLabel = new Label();
            firstNameTextBox = new TextBox();
            middleInitialLabel = new Label();
            middleInitialTextBox = new TextBox();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            addressLabel = new Label();
            addressTextBox = new TextBox();
            phoneNumberLabel = new Label();
            textBox1 = new TextBox();
            createAccountButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(210, 23);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(420, 60);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Create Staff Account";
            // 
            // ssnLabel
            // 
            ssnLabel.AutoSize = true;
            ssnLabel.Location = new Point(69, 105);
            ssnLabel.Name = "ssnLabel";
            ssnLabel.Size = new Size(36, 20);
            ssnLabel.TabIndex = 1;
            ssnLabel.Text = "SSN";
            // 
            // ssnTextBox
            // 
            ssnTextBox.Location = new Point(111, 102);
            ssnTextBox.Name = "ssnTextBox";
            ssnTextBox.Size = new Size(133, 27);
            ssnTextBox.TabIndex = 2;
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new Point(281, 105);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new Size(64, 20);
            birthdayLabel.TabIndex = 3;
            birthdayLabel.Text = "Birthday";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "M", "F", "X" });
            comboBox1.Location = new Point(588, 102);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            // 
            // birthdayTextBox
            // 
            birthdayTextBox.Location = new Point(351, 102);
            birthdayTextBox.Name = "birthdayTextBox";
            birthdayTextBox.Size = new Size(125, 27);
            birthdayTextBox.TabIndex = 5;
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(522, 105);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(57, 20);
            genderLabel.TabIndex = 6;
            genderLabel.Text = "Gender";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(69, 161);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 7;
            firstNameLabel.Text = "First Name";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(155, 154);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(190, 27);
            firstNameTextBox.TabIndex = 8;
            // 
            // middleInitialLabel
            // 
            middleInitialLabel.AutoSize = true;
            middleInitialLabel.Location = new Point(371, 161);
            middleInitialLabel.Name = "middleInitialLabel";
            middleInitialLabel.Size = new Size(26, 20);
            middleInitialLabel.TabIndex = 9;
            middleInitialLabel.Text = "MI";
            // 
            // middleInitialTextBox
            // 
            middleInitialTextBox.Location = new Point(403, 154);
            middleInitialTextBox.Name = "middleInitialTextBox";
            middleInitialTextBox.Size = new Size(27, 27);
            middleInitialTextBox.TabIndex = 10;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(477, 161);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 11;
            lastNameLabel.Text = "Last Name";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(562, 158);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(177, 27);
            lastNameTextBox.TabIndex = 12;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(69, 214);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(62, 20);
            addressLabel.TabIndex = 13;
            addressLabel.Text = "Address";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(137, 207);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(602, 27);
            addressTextBox.TabIndex = 14;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(69, 258);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(77, 20);
            phoneNumberLabel.TabIndex = 15;
            phoneNumberLabel.Text = "Phone No.";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(152, 251);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(587, 27);
            textBox1.TabIndex = 16;
            // 
            // createAccountButton
            // 
            createAccountButton.Location = new Point(361, 305);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(94, 29);
            createAccountButton.TabIndex = 17;
            createAccountButton.Text = "Create Account";
            createAccountButton.UseVisualStyleBackColor = true;
            createAccountButton.Click += createAccountButton_Click;
            // 
            // CreateStaffAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(createAccountButton);
            Controls.Add(textBox1);
            Controls.Add(phoneNumberLabel);
            Controls.Add(addressTextBox);
            Controls.Add(addressLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(middleInitialTextBox);
            Controls.Add(middleInitialLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(firstNameLabel);
            Controls.Add(genderLabel);
            Controls.Add(birthdayTextBox);
            Controls.Add(comboBox1);
            Controls.Add(birthdayLabel);
            Controls.Add(ssnTextBox);
            Controls.Add(ssnLabel);
            Controls.Add(headerLabel);
            Name = "CreateStaffAccount";
            Size = new Size(818, 429);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label ssnLabel;
        private TextBox ssnTextBox;
        private Label birthdayLabel;
        private ComboBox comboBox1;
        private TextBox birthdayTextBox;
        private Label genderLabel;
        private Label firstNameLabel;
        private TextBox firstNameTextBox;
        private Label middleInitialLabel;
        private TextBox middleInitialTextBox;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private Label addressLabel;
        private TextBox addressTextBox;
        private Label phoneNumberLabel;
        private TextBox textBox1;
        private Button createAccountButton;
    }
}
