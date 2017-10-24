using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains
{
   public class Accommodation:EntityBase
    {
        public string Name { get; set; }
        public int AccommodationTypeId { get; set; }
        public AccommodationType AccommodationType { get; set; }
        public int IconId { get; set; }
        public Icon Icon { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public int Star { get; set; }
    }
}
