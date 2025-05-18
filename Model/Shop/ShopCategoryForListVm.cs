using System.ComponentModel.DataAnnotations;

namespace SklepHkr2025.Model.Shop
{
    public class ShopCategoryForListVm
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Nazwa kategorii nie może być dłuższa niż {0} znaków.")]
        [Display(Name = "Nazwa kategorii")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Nazwa kategorii może zawierać tylko litery i cyfry.")]
        public string Name { get; set; } = string.Empty;
        public string? IdParentCategory { get; set; }

    }
}
