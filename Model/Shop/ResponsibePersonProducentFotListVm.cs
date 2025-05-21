using SklepHkr2025.Data.Entity.Shop;

namespace SklepHkr2025.Model.Shop
{
    public class ResponsibePersonProducentFotListVm
    {
        public int? Id { get; set; }
        public int? incomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CountryCode { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? logoFileName { get; set; }
        public ICollection<ItemForListVm>? Items { get; set; } = new List<ItemForListVm>();
        public int? ProducentDetailId { get; set; }
        public ProducentDetailForListVm? ProducentDetail { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
