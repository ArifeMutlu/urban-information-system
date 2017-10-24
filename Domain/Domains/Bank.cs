using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains
{
   public class Bank:EntityBase
    {
       public string Name { get; set; }
        public int BankTypeId { get; set; }
        public BankType BankType { get; set; }
        public int IconId { get; set; }
        public Icon Icon { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
    }
}
