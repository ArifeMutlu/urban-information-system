using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains
{
  public  class Sport:EntityBase
    {

        public string Name { get; set; }
        public int SportTypesId { get; set; }
        public SportTypes SportTypes { get; set; }
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
