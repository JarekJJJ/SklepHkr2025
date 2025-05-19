namespace SklepHkr2025.Model.Shop
{
    public class TreeCategoryForListVm
    {
        public string IdCategory { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<TreeCategoryForListVm>? ChildCategories { get; set; } = new List<TreeCategoryForListVm>();
    }
}
