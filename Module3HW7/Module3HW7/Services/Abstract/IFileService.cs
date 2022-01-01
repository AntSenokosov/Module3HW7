namespace Module3HW7.Services.Abstract;

public interface IFileService
{
    public string ReadFile(string path);
    public IDisposable CreateFile(string path);
    public void WriteFile(IDisposable? streamWriter, string text);
    public void CloseFile(IDisposable? streamWriter);
}