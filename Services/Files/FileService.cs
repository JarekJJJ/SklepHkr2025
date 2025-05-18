using System.Threading.Tasks;

namespace SklepHkr2025.Services.Files
{
    public class FileService : IFileService
    {
        public async Task<string?> SaveFileToDiskAsync(string fileName, string filePath, string fileContent)
        {
            try
            {
                // Ensure the directory exists
                Directory.CreateDirectory(filePath);
                // Combine the file path and name
                string fullPath = Path.Combine(filePath, fileName);
                // Write the content to the file asynchronously
                await File.WriteAllTextAsync(fullPath, fileContent);
                return fullPath;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                Console.WriteLine($"Error saving file: {ex.Message}");
                return null;
            }
        }
        public (bool Exists, DateTime? LastWriteTime) GetFileInfo(string fullPath)
        {
            try
            {
                // Check if the file exists
                if (File.Exists(fullPath))
                {
                    // Get the last write time of the file
                    DateTime lastWriteTime = File.GetLastWriteTime(fullPath);
                    return (true, lastWriteTime);
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log them)
                Console.WriteLine($"Error getting file info: {ex.Message}");
                return (false, null);
            }

        }
    }
}
