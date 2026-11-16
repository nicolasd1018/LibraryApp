namespace LibraryApp
{
    partial class manageDependentsPage
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
            nameTextBox = new TextBox();
            birthdayTextBox = new TextBox();
            genderTextBox = new TextBox();
            relationshipTextBox = new TextBox();
            headerLabel = new Label();
            nameLabel = new Label();
            birthdayLabel = new Label();
            genderLabel = new Label();
            relationshipLabel = new Label();
            addButton = new Button();
            listBox1 = new ListBox();
            deleteButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(78, 135);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(125, 27);
            nameTextBox.TabIndex = 0;
            // 
            // birthdayTextBox
            // 
            birthdayTextBox.Location = new Point(295, 135);
            birthdayTextBox.Name = "birthdayTextBox";
            birthdayTextBox.Size = new Size(125, 27);
            birthdayTextBox.TabIndex = 1;
            // 
            // genderTextBox
            // 
            genderTextBox.Location = new Point(502, 135);
            genderTextBox.Name = "genderTextBox";
            genderTextBox.Size = new Size(47, 27);
            genderTextBox.TabIndex = 2;
            // 
            // relationshipTextBox
            // 
            relationshipTextBox.Location = new Point(652, 135);
            relationshipTextBox.Name = "relationshipTextBox";
            relationshipTextBox.Size = new Size(125, 27);
            relationshipTextBox.TabIndex = 3;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(259, 23);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(261, 60);
            headerLabel.TabIndex = 4;
            headerLabel.Text = "Dependents";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(23, 138);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(49, 20);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Name";
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new Point(225, 138);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new Size(64, 20);
            birthdayLabel.TabIndex = 6;
            birthdayLabel.Text = "Birthday";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(439, 138);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(57, 20);
            genderLabel.TabIndex = 7;
            genderLabel.Text = "Gender";
            // 
            // relationshipLabel
            // 
            relationshipLabel.AutoSize = true;
            relationshipLabel.Location = new Point(555, 138);
            relationshipLabel.Name = "relationshipLabel";
            relationshipLabel.Size = new Size(91, 20);
            relationshipLabel.TabIndex = 8;
            relationshipLabel.Text = "Relationship";
            // 
            // addButton
            // 
            addButton.Location = new Point(364, 200);
            addButton.Name = "addButton";
            addButton.Size = new Size(56, 29);
            addButton.TabIndex = 9;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addDependentButton_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(78, 257);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(699, 104);
            listBox1.TabIndex = 10;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(353, 391);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 11;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            backButton.Location = new Point(23, 23);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 12;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // manageDependentsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backButton);
            Controls.Add(deleteButton);
            Controls.Add(listBox1);
            Controls.Add(addButton);
            Controls.Add(relationshipLabel);
            Controls.Add(genderLabel);
            Controls.Add(birthdayLabel);
            Controls.Add(nameLabel);
            Controls.Add(headerLabel);
            Controls.Add(relationshipTextBox);
            Controls.Add(genderTextBox);
            Controls.Add(birthdayTextBox);
            Controls.Add(nameTextBox);
            Name = "manageDependentsPage";
            Size = new Size(818, 464);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private TextBox birthdayTextBox;
        private TextBox genderTextBox;
        private TextBox relationshipTextBox;
        private Label headerLabel;
        private Label nameLabel;
        private Label birthdayLabel;
        private Label genderLabel;
        private Label relationshipLabel;
        private Button addButton;
        private ListBox listBox1;
        private Button deleteButton;
        private Button backButton;
    }
}
