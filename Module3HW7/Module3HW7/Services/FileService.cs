using Module3HW7.Services.Abstract;

namespace Module3HW7.Services;

public class FileService : IFileService
{
    private readonly IConfigService _configService;
    private StreamWriter _streamWriter;
    private DirectoryInfo _directoryInfo;
    private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
    private string _filePath;
    private int _count = 0;

    public FileService(IConfigService configService)
    {
        _configService = configService;
        _filePath = GetFilePath(_configService.Config.LoggerConfig.DirectoryLoggerPath);
        CreateDirectory(_configService.Config.LoggerConfig.DirectoryLoggerPath);
    }

    public void CreateFile(string directory, string fileName, string fileExtension)
    {
        var path = GetFilePath(_configService.Config.LoggerConfig.DirectoryLoggerPath);
        _filePath = path;
        CreateDirectory(directory);
        _streamWriter = new StreamWriter(path, true);
    }

    public async Task WriteFileAsync(string text)
    {
        await _semaphore.WaitAsync();
        await _streamWriter.WriteLineAsync(text);
        await _streamWriter.FlushAsync();
        _semaphore.Release();
    }

    public void WriteBackupFile()
    {
        var directory = _configService.Config.LoggerConfig.DirectoryBackupPath;
        CreateDirectory(directory);
        File.Copy(_filePath, GetFilePath(directory, _count.ToString()));
        _count++;
    }

    private void CreateDirectory(string path)
    {
        _directoryInfo = new DirectoryInfo(path);

        if (!_directoryInfo.Exists)
        {
            _directoryInfo.Create();
        }
    }

    private string GetFilePath(string directory, string count = "")
    {
        if (count != string.Empty)
        {
            count = $"({count})";
        }

        var fileName = DateTime.UtcNow.ToString(_configService.Config.LoggerConfig.NameFile);
        var fileExtension = _configService.Config.LoggerConfig.FileExtension;

        return $"{directory}{fileName}{count}{fileExtension}";
    }
}