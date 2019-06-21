using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace ElectronicShop
{
    public partial class ShopOwnerPage : Form
    {
        Product product = new Product();
        string username;
        public double Sum = 0;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        CustomerDetails customerDetails = new CustomerDetails();
        Stock stock = new Stock();
        Sales sales = new Sales();
        List<double> CustomerModelNum = new List<double>();
        List<string> CustomerBrand = new List<string>();

        public ShopOwnerPage(string username)
        {
            InitializeComponent();
            WelcomeShopPagelbl.Text = "Welcome " + username;
            this.username = username;
            groupBoxCustomer.Visible = false;
            displaySuccessMsglbl.Visible = false;
            groupBoxCustomerDetails.Visible = false;
            dt.Columns.Add("Brand Name", typeof(string));
            dt.Columns.Add("Model Number", typeof(double));
            dt.Columns.Add("Number of Battery", typeof(int));
            dt.Columns.Add("Power Output", typeof(int));
            dt.Columns.Add("Item Count", typeof(int));
            dt.Columns.Add("Price", typeof(int));

            dt1.Columns.Add("Brand Name", typeof(string));
            dt1.Columns.Add("Model Number", typeof(double));
            dt1.Columns.Add("Number of Battery", typeof(int));
            dt1.Columns.Add("Power Output", typeof(int));
            dt1.Columns.Add("Item Count", typeof(int));
            dt1.Columns.Add("Price", typeof(int));
            dt1.Columns.Add("Enter Number of Item you want", typeof(int));
        }

        private void ShopOwnerPage_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
        
        }
        public void update()
        {
  
        }
        private void button1_Click(object sender, EventArgs e)
        {
    
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            WelcomePage form1 = new WelcomePage();
            form1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void UpdateGridViewUPS()
        {
           
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            UpdateGridViewUPS();
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteCustomerSelected()
        {
       
        }

        private void AddColoumntxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Viewbtn_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            string Voltage = VoltagelistBox2.GetItemText(VoltagelistBox2.SelectedItem);
            product.BrandName = BrandListBox1.GetItemText(BrandListBox1.SelectedItem);
            product.ModelNumber = Convert.ToDouble(ModelNametxt.Text);
            product.NumberOfBattery = Convert.ToInt32(NumberofBatterytxt.Text);
            product.PowerOutput = Convert.ToInt32(Voltage);
            product.ItemCount = Convert.ToInt32(ItemCounttxt.Text);
            product.Price = Convert.ToInt32(Pricetxt.Text);

            double passModel = Convert.ToDouble(ModelNametxt.Text);
          
            stock.AddProduct(product,passModel);
            ModelNametxt.Text = "";
            NumberofBatterytxt.Text = "";
            ItemCounttxt.Text = "";
            Pricetxt.Text = "";
            displaySuccessMsglbl.Visible = true;

            
        }

        private void StockView_Click(object sender, EventArgs e)
        {
            dt.Clear();

            string path1 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Product.xml";

            FileStream file;

            XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
            file = new FileStream(@path1, FileMode.Open, FileAccess.Read);
            var Details = Serializer.Deserialize(file) as Stock;
            file.Close();
       
            foreach (var item in Details.listofProduct)
            {
                string EnterBrand= EnterBrandListBox.GetItemText(EnterBrandListBox.SelectedItem);
                if (EnterBrand == "" && EnterModelNumbertxt.Text == "")
                {
                    DataRow dRow = dt.NewRow();
                    dt.Rows.Add(item.BrandName, item.ModelNumber, item.NumberOfBattery, item.PowerOutput, item.ItemCount, item.Price);
                    dt.Rows.Add(dRow);
                }
                else
                {
                    double Temp = Convert.ToDouble(EnterModelNumbertxt.Text);
                    if (item.BrandName.Equals(EnterBrand) && item.ModelNumber==Temp)
                    {
                        DataRow dRow = dt.NewRow();
                        dt.Rows.Add(item.BrandName, item.ModelNumber, item.NumberOfBattery, item.PowerOutput, item.ItemCount, item.Price);
                        dt.Rows.Add(dRow);
                    }
                }
            }

            dataGridView1.DataSource = dt;
        }
 

        private void Enterbtn_Click(object sender, EventArgs e)
        {
            string path2 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Customer.xml";
            string theDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            customerDetails.PhoneNumber = Convert.ToDouble(PhoneNumbertxt.Text);
            double phnNum = customerDetails.PhoneNumber;
            bool Detail = sales.CustomerAvailabity(phnNum);
            if (Detail == false)
            {
                groupBoxCustomer.Visible = true;
            }
            else
            {
                groupBoxCustomerDetails.Visible = true;
                DisplayCustomerDetails();
            }
   
        }
        public void DisplayCustomerDetails()
        {
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(double));
            string path2 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Customer.xml";

            groupBoxCustomerDetails.Visible = true;
            FileStream file;

            XmlSerializer Serializer = new XmlSerializer(typeof(Sales));
            file = new FileStream(@path2, FileMode.Open, FileAccess.Read);
            var Details = Serializer.Deserialize(file) as Sales;
            file.Close();

            foreach (var item in Details.customerDetails)
            {
                if (item.PhoneNumber == customerDetails.PhoneNumber)
                {
                    DataRow dRow = dt.NewRow();
                    dt.Rows.Add(item.Name, item.Address, item.Email, item.PhoneNumber);
                    dt.Rows.Add(dRow);
                }
            }
            dataGridView2.DataSource = dt;
            MessageBox.Show("Displayed Details is Correct?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        private void PhoneNumbertxt_Click(object sender, EventArgs e)
        {

        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int RdnNum = rnd.Next(52);

            string path2 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Customer.xml";
            string theDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        
            customerDetails.PhoneNumber = Convert.ToDouble(PhoneNumbertxt.Text);
            customerDetails.dateofBuying = theDate;
            customerDetails.Name = Nametxt.Text;
            customerDetails.Address = Addresstxt.Text;
            customerDetails.Email = Emailtxt.Text;
            customerDetails.BillNumber = RdnNum;
            string Something1 = string.Join(",", CustomerBrand);
            string Something2 = string.Join(",", CustomerModelNum);

            customerDetails.BroughtProduct = Something1;
            customerDetails.BroughtProductModel = Something2;

            sales.AddCustomer(customerDetails);

            PhoneNumbertxt.Text = "";
            groupBoxCustomerDetails.Visible =false;
            groupBoxCustomer.Visible = false;
            MessageBox.Show("Thank You");

        }

        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["Selltab"];
        }
        
        void CalculatePrice()                                                                                     //To Calculate Total price
        {
            int iTemp1 = 0;
            int iTemp2 = 0;
            int iTemp3 = 0;


            foreach (DataGridViewRow row in dataGridViewSell.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                   
                    string isSelected2 = Convert.ToString(row.Cells["Enter Number of Item you want"].Value);

                    if (isSelected2 != "")
                    {
                        string sTemp2 = Convert.ToString(row.Cells["Enter Number of Item you want"].Value);
                        iTemp2 = Convert.ToInt32(sTemp2);

                        string isSelected = Convert.ToString(row.Cells["Price"].Value);
                        string sTemp1 = Convert.ToString(row.Cells["Price"].Value);
                        iTemp1 = Convert.ToInt32(sTemp1);

                        string MdlNum = Convert.ToString(row.Cells["Model Number"].Value);
                        double MdlNum1 = Convert.ToDouble(MdlNum);

                        string CustomerBnd = Convert.ToString(row.Cells["Brand Name"].Value);

                        CustomerBrand.Add(CustomerBnd);
                        CustomerModelNum.Add(MdlNum1);

                        stock.SoldItems(MdlNum1, iTemp2);                                                          //In Stock Class Reduces Count
                    }
                
                    Sum = iTemp1 * iTemp2;
                   break;
                }
            }
                string iTotalPriceString = Convert.ToString(Sum);
                TotalPricetxt.Text = iTotalPriceString;
 
        }
      
        private void Checkbtn_Click(object sender, EventArgs e)
        {
            double MdlNum = Convert.ToDouble(ModelNametxt.Text);
            stock.CheckProduct(MdlNum);
        }

        private void Proccedbtn_Click(object sender, EventArgs e)
        {
           

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            bool Status=stock.FilterProducts(text,Convert.ToDouble(ModelNumberInputtxt.Text),trackBarPrice.Value);
            double MN = Convert.ToDouble(ModelNumberInputtxt.Text);
            if (Status)
            {                  
                dt1.Clear();
               
                FileStream file;
                string path2 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/ProductForClient.xml";
                XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
                file = new FileStream(@path2, FileMode.Open, FileAccess.Read);
                var DetailsList = Serializer.Deserialize(file) as Stock;
                file.Close();

                foreach (var item in DetailsList.productsSell)
                {
                    if ((item.BrandName).Equals(text) && item.ModelNumber == MN && item.Price > trackBarPrice.Value)
                    {
                        DataRow dRow = dt1.NewRow();
                        dt1.Rows.Add(item.BrandName, item.ModelNumber, item.NumberOfBattery, item.PowerOutput, item.ItemCount, item.Price);
                        dt1.Rows.Add(dRow);
                    }
                }
                dataGridViewSell.DataSource = dt1;
            }
            else
            {
                MessageBox.Show("Data Not Found");
            }

        }

        private void trackBarPrice_Scroll(object sender, EventArgs e)
        {
            PriceAbovelbl.Text = trackBarPrice.Value.ToString();
        }

        private void SellOKbtn_Click(object sender, EventArgs e)
        {

            CalculatePrice();
           
            tabControl1.SelectedTab = tabControl1.TabPages["CustomerPage"];
        }

        private void OkReportbtn_Click(object sender, EventArgs e)
        {
            string path2 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Customer.xml";
            if (File.Exists(path2))
            {
                string datatimeStart = dateTimePickerReport1.Value.ToString("yyyy-MM-dd");
                int Start = Simplify(datatimeStart);
                string datatimeEnd = dateTimePickerReport2.Value.ToString("yyyy-MM-dd");
                int End = Simplify(datatimeEnd);

                DataTable dtReport = new DataTable();

                dtReport.Columns.Add("Customer Name", typeof(string));
                dtReport.Columns.Add("Phone Number", typeof(double));
                dtReport.Columns.Add("Address", typeof(string));
                dtReport.Columns.Add("Mail ID", typeof(string));
                dtReport.Columns.Add("Date of purchase", typeof(string));
                dtReport.Columns.Add("Purchase Brand Name", typeof(string));
                dtReport.Columns.Add("Purchase Model Number", typeof(string));
                dtReport.Columns.Add("Bill Number", typeof(int));

                FileStream file;
                XmlSerializer Serializer = new XmlSerializer(typeof(Sales));
                file = new FileStream(@path2, FileMode.Open, FileAccess.Read);
                var DetailsList = Serializer.Deserialize(file) as Sales;
                file.Close();

                foreach (var item in DetailsList.customerDetails)
                {
                    string Tempdate = item.dateofBuying;
                    int iTempdata=Simplify(Tempdate);

                    if (Start <= iTempdata && iTempdata <= End)
                    {
                        DataRow dRow = dtReport.NewRow();
                        dtReport.Rows.Add(item.Name, item.PhoneNumber, item.Address, item.Email, item.dateofBuying, item.BroughtProduct, item.BroughtProductModel,item.BillNumber);
                        dtReport.Rows.Add(dRow);
                    }
                }
                dataGridViewReport.DataSource = dtReport;
                this.dataGridViewReport.DefaultCellStyle.Font = new Font("Arial", 10);
            }
            else
            {
                MessageBox.Show("Customer data not avaliable");
            }
        }

        private int Simplify(string sdata)
        {
            sdata = sdata.Replace('-', '0');
            int data = Convert.ToInt32(sdata);

            int n = data, t, sum = 0, remainder;
            t = n;

            while (t != 0)
            {
                remainder = t % 10;
                sum = sum + remainder;
                t = t / 10;
            }
            return sum;
        }
    }
}
