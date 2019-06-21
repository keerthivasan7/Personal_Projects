using System;
using System.Windows.Forms;

namespace ElectronicShop
{
    public partial class WelcomePage : Form
    {

        public WelcomePage()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ShopOwnerLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage form2 = new LoginPage(ShopOwnerLogin.Text);
            form2.ShowDialog();
            //ShopOwnerPage shopOwnerPage = new ShopOwnerPage("121");
            //shopOwnerPage.Show();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
           
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
