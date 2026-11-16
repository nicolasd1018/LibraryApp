using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Data.SqlClient;
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
        private string connectionString = @"Server=localhost;Database=Library System;Trusted_Connection=True;TrustServerCertificate=True;";
        private List<(string Email, int MemberId)> usedEmails;
        public UserControl2(Panel homePanel, bool isMemberLogin)
        {
            InitializeComponent();
            this.homePanel = homePanel;
            this.isMemberLogin = isMemberLogin;
            this.usedEmails = new List<(string Email, int MemberId)>();
            this.loadUsedEmailsAndIDs();
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
                if (!usedEmails.Exists(email => email.Email.Equals(userNameTextBox.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("This email is not registered. Please create an account first.");
                    return;
                }
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
                    await client.AuthenticateAsync("nicolasgabrieldiaz2001@gmail.com", "/* your app password */");

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
                    EmailCode emailCodePage = new EmailCode(this.homePanel, usedEmails.Find(email => email.Email.Equals(userNameTextBox.Text.Trim(), StringComparison.OrdinalIgnoreCase)).MemberId, verificationCode);
                    emailCodePage.Dock = DockStyle.Fill;
                    this.homePanel.Controls.Add(emailCodePage);
                }
            }
            
        }

        private void loadUsedEmailsAndIDs()
        {
            string query = "SELECT Email, Member_id FROM dbo.MEMBER;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Connected, but dbo.MEMBER has 0 rows.");
                            return;
                        }

                        while (reader.Read())
                        {
                            usedEmails.Add((reader.GetString(0), reader.GetInt32(1)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
        }

    }
}
