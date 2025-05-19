using SklepHkr2025.Model.Enums;

namespace SklepHkr2025.Data.Entity.Shop
{
    public class PriceGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? PriceMarkUpA { get; set; }
        public int? PriceMarkUpB { get; set; }
        public int? PriceMarkUpC { get; set; }
        public DateTime? Created { get; set; } 
        public DateTime? Updated { get; set; } = DateTime.Now;
    }
}
