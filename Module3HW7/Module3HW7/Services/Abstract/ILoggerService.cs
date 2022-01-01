namespace Module3HW7.Services.Abstract;

public interface ILoggerService
{
    public void LogError(string message);
    public void LogInfo(string message);
    public void LogWarning(string message);
    public void WriteFile(string filePath);
}