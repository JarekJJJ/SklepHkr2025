using SklepHkr2025.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepHkr2025.Model.Shop
{
    public class ItemForListVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? ShopCategoryId { get; set; }
        public ShopCategoryForListVm? ShopCategory { get; set; }
        public int? PriceGroupId { get; set; }
        public PriceGroupForListVm? PriceGroup { get; set; }
        public VatRateEnum VatRate { get; set; } = VatRateEnum.Vat23;
        public string? EanCode { get; set; }
        public string? ItemSymbol { get; set; }
        public Guid? MainImageId { get; set; } 
        public ICollection<ItemImageForListVm>? ItemImages { get; set; } = new List<ItemImageForListVm>();
        public int ProducentId { get; set; }
        public ProducentForListVm? Producent { get; set; }
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
