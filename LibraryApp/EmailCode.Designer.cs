namespace LibraryApp
{
    partial class EmailCode
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
            codeTextBox = new TextBox();
            EnterEmailCodeLabel = new Label();
            sendCodeButton = new Button();
            SuspendLayout();
            // 
            // codeTextBox
            // 
            codeTextBox.Location = new Point(323, 177);
            codeTextBox.Name = "codeTextBox";
            codeTextBox.Size = new Size(125, 27);
            codeTextBox.TabIndex = 0;
            // 
            // EnterEmailCodeLabel
            // 
            EnterEmailCodeLabel.AutoSize = true;
            EnterEmailCodeLabel.Location = new Point(194, 184);
            EnterEmailCodeLabel.Name = "EnterEmailCodeLabel";
            EnterEmailCodeLabel.Size = new Size(123, 20);
            EnterEmailCodeLabel.TabIndex = 1;
            EnterEmailCodeLabel.Text = "Enter Email Code";
            // 
            // sendCodeButton
            // 
            sendCodeButton.Location = new Point(464, 177);
            sendCodeButton.Name = "sendCodeButton";
            sendCodeButton.Size = new Size(94, 29);
            sendCodeButton.TabIndex = 2;
            sendCodeButton.Text = "Send";
            sendCodeButton.UseVisualStyleBackColor = true;
            sendCodeButton.Click += sendCodeButton_Click;
            // 
            // EmailCode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sendCodeButton);
            Controls.Add(EnterEmailCodeLabel);
            Controls.Add(codeTextBox);
            Name = "EmailCode";
            Size = new Size(818, 397);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox codeTextBox;
        private Label EnterEmailCodeLabel;
        private Button sendCodeButton;
    }
}
