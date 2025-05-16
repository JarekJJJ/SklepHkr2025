namespace SklepHkr2025.Services.Files
{
    public class SaveFile : ISaveFile
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
    }
}
