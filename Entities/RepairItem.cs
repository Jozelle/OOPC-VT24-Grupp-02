using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{
    internal class RepairItem
    {

        public Repair Repair {  get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set;}

    }
}
