using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ElectronicShop
{
    public class Stock
    {
        public List<Product> listofProduct=new List<Product>();
        Serialization serialization = new Serialization();
        public List<Product> productsSell = new List<Product>();
        
        public Stock() { }
        public void AddProduct(Product obj,double iModelNumber)
        {
            int iPosition = 0;
            foreach (var prod in listofProduct)
            {
                if (prod.ModelNumber == iModelNumber)
                {
                    iPosition++;
                }
            }
            if (iPosition == 0)
            {
                listofProduct.Add(obj);
            }
            
            serialization.XmlSerializeProduct(obj, "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Product.xml");
        }
        public void CheckProduct(double iModelNumber)
        {
            foreach (var prod in listofProduct)
            {
                if (prod.ModelNumber == iModelNumber)
                {
                  
                }
            }
        }
        public List<Product> ReturnList(List<Product> products)
        {
            return listofProduct;
        }
      public void SoldItems(double MdlNumber, int Count)
        {
            string path1 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Product.xml";
            FileStream file;
            XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
            file = new FileStream(path1, FileMode.Open, FileAccess.Read);
            var Details = Serializer.Deserialize(file) as Stock;
            file.Close();
            File.Delete("C:/Users/H351442/Downloads/ElectronicShop/Dummy/Product.xml");

            foreach (var products1 in Details.listofProduct)
            {
                int k = 0;
                Product ob1 = new Product();
                if (products1.ModelNumber == MdlNumber)
                {
                    int a = products1.ItemCount- Count;
                    ob1.ItemCount = a;
                    k++;
                }
                
                ob1.BrandName = products1.BrandName;
                ob1.ModelNumber = products1.ModelNumber;
                ob1.PowerOutput = products1.PowerOutput;
                ob1.NumberOfBattery = products1.NumberOfBattery;
                if (k != 1)
                {
                    ob1.ItemCount = products1.ItemCount;
                }
                ob1.Price = products1.Price;
                serialization.XmlSerializeProduct(ob1, "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Product.xml");
            }

        }


        public bool FilterProducts(string brandName,double model,int price)
        {
            string path1 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Product.xml";
            string path2 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/ProductForClient.xml";
            FileStream file;
            XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
            file = new FileStream(path1, FileMode.Open, FileAccess.Read);
            var Details = Serializer.Deserialize(file) as Stock;
            file.Close();

            int i = 0;
            foreach (var products1 in Details.listofProduct)
            {
                if((products1.BrandName).Equals(brandName) && products1.ModelNumber==model && products1.Price>price)
                {
                    Product ob = new Product();
                    ob.BrandName = products1.BrandName;
                    ob.ModelNumber = products1.ModelNumber;
                    ob.PowerOutput = products1.PowerOutput;
                    ob.NumberOfBattery = products1.NumberOfBattery;
                    ob.ItemCount = products1.ItemCount;
                    ob.Price = products1.Price;
                    productsSell.Add(ob);
                    serialization.XmlSerializeProduct1(ob, "C:/Users/H351442/Downloads/ElectronicShop/Dummy/ProductForClient.xml");
                    i++;
                }
            }
            if(i>0)
            {
                return true;
            }
            return false;
        }
    }
}
