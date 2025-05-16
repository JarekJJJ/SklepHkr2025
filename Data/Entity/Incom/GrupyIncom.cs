namespace SklepHkr2025.Data.Entity.Incom
{
    public class GrupyIncom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IdGroup { get; set; } = string.Empty;
        public string? IdMainGroup { get; set; }
    }
}
