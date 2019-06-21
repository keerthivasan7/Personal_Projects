using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop
{
    public class Sales
    {
        public List<CustomerDetails> customerDetails = new List<CustomerDetails>();
        public void AddCustomer(CustomerDetails obj)
        {
            customerDetails.Add(obj);
            Serialization ob = new Serialization();
            ob.XmlSerializeCustomer1(obj);
        }
        public bool CustomerAvailabity(double phNum)
        {
            foreach (var item in customerDetails)
            {
                if(item.PhoneNumber == phNum)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
