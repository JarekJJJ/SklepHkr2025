namespace SklepHkr2025.Services.Files
{
    public interface ISaveFile
    {
        Task<string?> SaveFileToDiskAsync(string fileName, string filePath, string fileContent);
    }
}