namespace SklepHkr2025.Services.Files
{
    public interface IFileService
    {
        Task<string?> SaveFileToDiskAsync(string fileName, string filePath, string fileContent);
        (bool Exists, DateTime? LastWriteTime) GetFileInfo(string fullPath);
    }
}