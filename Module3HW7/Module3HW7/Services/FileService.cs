using Module3HW7.Services.Abstract;

namespace Module3HW7.Services;

public class FileService : IFileService
{
    public string ReadFile(string path)
    {
        var text = File.ReadAllText(path);

        return text;
    }

    public IDisposable CreateFile(string path)
    {
        var fileInfo = new FileInfo(path);

        if (!fileInfo.Exists)
        {
            fileInfo.Create().Close();
        }

        var streamWriter = new StreamWriter(path, true, System.Text.Encoding.Default);

        return streamWriter;
    }

    public void WriteFile(IDisposable streamWriter, string text)
    {
        var writer = streamWriter as StreamWriter;

        writer?.WriteLine(text);
    }

    public void CloseFile(IDisposable streamWriter)
    {
        var writer = streamWriter as StreamWriter;

        writer?.Close();
        writer?.Dispose();
    }
}