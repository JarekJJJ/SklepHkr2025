using SklepHkr2025.Model.Enums;
using SklepHkr2025.Model.Shop;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepHkr2025.Data.Entity.Shop
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? ShopCategoryId { get; set; }
        public ShopCategory? ShopCategory { get; set; }
        public int? PriceGroupId { get; set; }
        public PriceGroup? PriceGroup { get; set; }
        public VatRateEnum VatRate { get; set; } = VatRateEnum.Vat23;
        public string? EanCode { get; set; }
        public string? ItemSymbol { get; set; }
        public Guid? MainImageId { get; set; }
        public ICollection<ItemImage>? ItemImages { get; set; } = new List<ItemImage>();
        public int ProducentId { get; set; }
        public Producent? Producent { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Lenght { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Width { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Height { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
