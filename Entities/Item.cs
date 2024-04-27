namespace CarService.Entities
{
    public class Item
    {

        public int ItemId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<UsedItem> RepairItems { get; set; }

    }
}
