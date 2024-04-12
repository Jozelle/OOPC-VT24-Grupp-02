using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Entities
{



    [PrimaryKey(nameof(RepairId), nameof(ItemId))]
    public class RepairItem
    {
        public int RepairId { get; set; }
        public Repair Repair {  get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set;}

    }
}
