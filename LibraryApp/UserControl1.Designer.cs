namespace LibraryApp
{
    partial class LoginPage
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
            label1 = new Label();
            MemberLoginButton = new Button();
            StaffLoginButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(311, 75);
            label1.Name = "label1";
            label1.Size = new Size(182, 81);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // MemberLoginButton
            // 
            MemberLoginButton.Location = new Point(158, 254);
            MemberLoginButton.Name = "MemberLoginButton";
            MemberLoginButton.Size = new Size(94, 29);
            MemberLoginButton.TabIndex = 1;
            MemberLoginButton.Text = "Member";
            MemberLoginButton.UseVisualStyleBackColor = true;
            MemberLoginButton.Click += MemberLoginButton_Click;
            // 
            // StaffLoginButton
            // 
            StaffLoginButton.Location = new Point(530, 254);
            StaffLoginButton.Name = "StaffLoginButton";
            StaffLoginButton.Size = new Size(94, 29);
            StaffLoginButton.TabIndex = 2;
            StaffLoginButton.Text = "Staff";
            StaffLoginButton.UseVisualStyleBackColor = true;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(StaffLoginButton);
            Controls.Add(MemberLoginButton);
            Controls.Add(label1);
            Name = "LoginPage";
            Size = new Size(818, 557);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button MemberLoginButton;

        private Button StaffLoginButton;
    }
}
