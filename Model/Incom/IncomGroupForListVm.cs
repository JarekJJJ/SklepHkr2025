namespace SklepHkr2025.Model.Incom
{
    public class IncomGroupForListVm
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IdGroup { get; set; } = string.Empty;
        public string? IdMainGroup { get; set; }
        public bool IsMainGroup { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
