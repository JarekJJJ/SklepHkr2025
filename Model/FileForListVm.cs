namespace SklepHkr2025.Model
{
    public class FileForListVm
    {
        public int? Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public long? FileSize { get; set; }
        public IFormFile? File { get; set; }

    }
}
