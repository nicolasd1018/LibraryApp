using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;


namespace LibraryApp
{
    public partial class UserControl2 : UserControl
    {
        private Panel homePanel;
        private bool isMemberLogin;
        public UserControl2(Panel homePanel, bool isMemberLogin)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.isMemberLogin = isMemberLogin;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            LoginPage loginPage = new LoginPage(this.homePanel);
            loginPage.Dock = DockStyle.Fill;
            this.homePanel.Controls.Add(loginPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.homePanel.Controls.Clear();
            if (isMemberLogin)
            {
                CreateUserAccount createUserAccount = new CreateUserAccount(this.homePanel);
                createUserAccount.Dock = DockStyle.Fill;
                this.homePanel.Controls.Add(createUserAccount);
            }
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            var verificationCode = Random.Shared.Next(100000, 999999);
            if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
            {
                MessageBox.Show("Please enter email address.");
                return;
            }
            else
            {
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Nicolas", "nicolasgabrieldiaz2001@gmail.com"));
                    message.To.Add(new MailboxAddress("", userNameTextBox.Text.Trim()));
                    message.Subject = "Login Code";
                    message.Body = new TextPart("plain")
                    {
                        Text = $"Hello,\n\nYour verification code is: { verificationCode.ToString()}\n\nIf you did not request this code, please ignore this email." // Generate a random 6-digit code
                    };

                    using var client = new SmtpClient(new MailKit.ProtocolLogger("smtp.log"));


                    // Connect to your SMTP server (example uses Gmail)
                    await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

                    // Use an App Password if 2FA is enabled
                    await client.AuthenticateAsync("nicolasgabrieldiaz2001@gmail.com", "");

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send email:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Failed to send email: {ex.InnerException?.Message ?? ex.Message}");
                    System.Diagnostics.Process.Start("notepad.exe", "smtp.log");

                }
                finally
                {
                    this.homePanel.Controls.Clear();
                    EmailCode emailCodePage = new EmailCode(this.homePanel, 0, verificationCode);
                    emailCodePage.Dock = DockStyle.Fill;
                    this.homePanel.Controls.Add(emailCodePage);
                }
            }
            
        }
    }
}
