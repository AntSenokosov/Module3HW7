using Module3HW7.Configs;
using Module3HW7.Models;
using Module3HW7.Services.Abstract;

namespace Module3HW7.Services;

public class LoggerService : ILoggerService
{
    private readonly IFileService _fileService;
    private readonly IConfigService _configService;
    private readonly LoggerConfig _loggerConfig;
    private int _countRecord = 0;

    public LoggerService(IFileService fileService, IConfigService configService)
    {
        _fileService = fileService;
        _configService = configService;
        _loggerConfig = _configService.Config.LoggerConfig;
        FileInit();
    }

    public event Action Backup;

    public void LogError(string message)
    {
        Log(message, TypeLogger.Error);
    }

    public void LogInfo(string message)
    {
        Log(message, TypeLogger.Info);
    }

    public void LogWarning(string message)
    {
        Log(message, TypeLogger.Warning);
    }

    private void FileInit()
    {
        var directory = _configService.Config.LoggerConfig.DirectoryLoggerPath;
        var fileName = DateTime.UtcNow.ToString(_configService.Config.LoggerConfig.NameFile);
        var fileExtension = _configService.Config.LoggerConfig.FileExtension;
        _fileService.CreateFile(directory, fileName, fileExtension);
    }

    private void WriteBackup(int count)
    {
        if (count % _loggerConfig.CountRecord == 0)
        {
            Backup?.Invoke();
        }
    }

    private void Log(string message, TypeLogger typeLogger)
    {
        var log = $"{DateTime.UtcNow.ToString(_loggerConfig.TimeFormat)}: {typeLogger.ToString()}: {message}";
        _fileService.WriteFileAsync(log);
        _countRecord++;
        WriteBackup(_countRecord);
    }
}