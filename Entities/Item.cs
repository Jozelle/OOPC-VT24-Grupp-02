namespace CarService.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<UsedItem> UsedItems { get; set; }
    }

    public class SparePart : Item
    {
        public int Inventory { get; set; }

    }

    public class Service : Item
    {

    }
}