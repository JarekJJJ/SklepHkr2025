namespace SklepHkr2025.Model.Shop
{
    public class ItemImageForListVm
    {
        public Guid? Id { get; set; }
        public string? ImageName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public int? ItemId { get; set; }
        public ItemForListVm? Item { get; set; } = new ItemForListVm();

    }
}