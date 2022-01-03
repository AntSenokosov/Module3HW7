namespace Module3HW7.Services.Abstract;

public interface ILoggerService
{
    public event Action Backup;
    public void LogError(string message);
    public void LogInfo(string message);
    public void LogWarning(string message);
}