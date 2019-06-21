using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop
{
    public class ClientDetails
    {
        public static string Name { get; set; }
        public string ClientName { get; set; }
        public string Type { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string HomeAddress { get; set; }
        public static List<string> ListTodelete
        {
            get;set;
        }


    }
}
