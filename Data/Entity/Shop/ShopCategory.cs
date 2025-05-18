namespace SklepHkr2025.Data.Entity.Shop
{
    public class ShopCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? IdParentCategory { get; set; }
    }
}
