using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains
{
     public class FoodDrinkType:EntityBase
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public  string Name { get; set; }
    }
}
