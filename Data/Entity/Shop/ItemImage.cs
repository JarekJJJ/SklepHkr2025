namespace SklepHkr2025.Data.Entity.Shop
{
    public class ItemImage
    {
        public Guid Id { get; set; }
        public string ImageFileName { get; set; } = string.Empty;
        public int? ItemId { get; set; }
        public Item? Item { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Updated
        {
            get; set;
        }
    }
}