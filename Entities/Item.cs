using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    public class Item
    {
  
        public int ItemID { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public ICollection<Repair> Repairs { get; set; }

    }
}
