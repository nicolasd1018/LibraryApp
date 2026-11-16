namespace LibraryApp
{
    partial class StaffLoginPage
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
            loginButton = new Button();
            createAccountButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(297, 34);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(233, 60);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Staff Login";
            // 
            // ssnLabel
            // 
            ssnLabel.AutoSize = true;
            ssnLabel.Location = new Point(285, 171);
            ssnLabel.Name = "ssnLabel";
            ssnLabel.Size = new Size(36, 20);
            ssnLabel.TabIndex = 1;
            ssnLabel.Text = "SSN";
            // 
            // ssnTextBox
            // 
            ssnTextBox.Location = new Point(327, 164);
            ssnTextBox.Name = "ssnTextBox";
            ssnTextBox.Size = new Size(158, 27);
            ssnTextBox.TabIndex = 2;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(491, 164);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(62, 29);
            loginButton.TabIndex = 3;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // createAccountButton
            // 
            createAccountButton.Location = new Point(351, 197);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(125, 29);
            createAccountButton.TabIndex = 4;
            createAccountButton.Text = "Create Account";
            createAccountButton.UseVisualStyleBackColor = true;
            createAccountButton.Click += createAccountButton_Click;
            // 
            // StaffLoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(createAccountButton);
            Controls.Add(loginButton);
            Controls.Add(ssnTextBox);
            Controls.Add(ssnLabel);
            Controls.Add(headerLabel);
            Name = "StaffLoginPage";
            Size = new Size(818, 444);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label ssnLabel;
        private TextBox ssnTextBox;
        private Button loginButton;
        private Button createAccountButton;
    }
}
