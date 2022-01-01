using Module3HW7.Models;
using Module3HW7.Services.Abstract;

namespace Module3HW7.Services;

public class LoggerService : ILoggerService
{
    private readonly IFileService _fileService;
    private IDisposable? _fileWritter;

    public LoggerService(IFileService fileService)
    {
        _fileService = fileService;
    }

    ~LoggerService()
    {
        _fileService.CloseFile(_fileWritter);
    }

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

    public void WriteFile(string filePath)
    {
        _fileWritter = _fileService.CreateFile(filePath);
    }

    private void Log(string message, TypeLogger typeLogger)
    {
        var log = $"{DateTime.UtcNow.ToString()}: {typeLogger.ToString()}: {message}";
        _fileService.WriteFile(_fileWritter, log);
    }
}