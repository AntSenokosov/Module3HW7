namespace Module3HW7.Services.Abstract;

public interface IFileService
{
    public void CreateFile(string directory, string fileName, string fileExtension);
    public Task WriteFileAsync(string text);
    public void WriteBackupFile();
}