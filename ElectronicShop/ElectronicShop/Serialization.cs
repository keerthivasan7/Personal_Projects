using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Data;
using System.Xml.Serialization;

namespace ElectronicShop
{
    class Serialization
    {

        public Serialization()
        {
  
        }
        public void XmlSerializeProduct(Product ob, string path)
        {
            string path1 = path;
       
            FileStream file;

            if (File.Exists(@path1) == false)
            {
                file = new FileStream(@path1, FileMode.Create);
                XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
                Stock ProductDetails = new Stock();
                ProductDetails.listofProduct.Add(ob);
                Serializer.Serialize(file, ProductDetails);
                file.Close();
            }
            else
            {
                    XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
                    
                    file = new FileStream(path1, FileMode.Open, FileAccess.Read);
                    var Details = Serializer.Deserialize(file) as Stock;
                    file.Close();
                    Details.listofProduct.Add(ob);

                    file = new FileStream(path1, FileMode.Open, FileAccess.ReadWrite);
                    Serializer = new XmlSerializer(typeof(Stock));
                    Serializer.Serialize(file, Details);
                    file.Close();
            }
        }
        public void XmlSerializeProduct1(Product ob, string path)
        {
            string path1 = path;

            FileStream file;

            if (File.Exists(@path1) == false)
            {
                file = new FileStream(@path1, FileMode.Create);
                XmlSerializer Serializer = new XmlSerializer(typeof(Stock));
                Stock ProductDetails = new Stock();
                ProductDetails.productsSell.Add(ob);
                Serializer.Serialize(file, ProductDetails);
                file.Close();
            }
            else
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(Stock));

                file = new FileStream(path1, FileMode.Open, FileAccess.Read);
                var Details = Serializer.Deserialize(file) as Stock;
                file.Close();
                Details.productsSell.Add(ob);

                file = new FileStream(path1, FileMode.Open, FileAccess.ReadWrite);
                Serializer = new XmlSerializer(typeof(Stock));
                Serializer.Serialize(file, Details);
                file.Close();
            }
        }
        public void XmlSerializeCustomer1(CustomerDetails ob)
        {
            string path1 = "C:/Users/H351442/Downloads/ElectronicShop/Dummy/Customer.xml";

            FileStream file;

            if (File.Exists(path1) == false)
            {
                file = new FileStream(@path1, FileMode.Create);
                XmlSerializer Serializer = new XmlSerializer(typeof(Sales));
                Sales customer = new Sales();
                customer.customerDetails.Add(ob);
                Serializer.Serialize(file, customer);
                file.Close();
            }
            else
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(Sales));
                file = new FileStream(path1, FileMode.Open, FileAccess.Read);
                var Details = Serializer.Deserialize(file) as Sales;
                file.Close();
                Details.customerDetails.Add(ob);

                file = new FileStream(path1, FileMode.Open, FileAccess.ReadWrite);
                Serializer = new XmlSerializer(typeof(Sales));
                Serializer.Serialize(file, Details);
                file.Close();
            }
        }
    }
}
