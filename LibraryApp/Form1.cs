namespace LibraryApp
{
    public partial class HolderPage : Form
    {
        public HolderPage()
        {
            InitializeComponent();
            panel1.Controls.Clear();
            LoginPage loginPage = new LoginPage(panel1);
            loginPage.Dock = DockStyle.Fill;
            panel1.Controls.Add(loginPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
