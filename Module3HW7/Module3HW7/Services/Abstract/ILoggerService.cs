using Module3HW7.Models;

namespace Module3HW7.Services.Abstract;

public interface ILoggerService
{
    public event Action Backup;
    public Task LogError(string message);
    public Task LogInfo(string message);
    public Task LogWarning(string message);
    public Task LogAsync(string message, TypeLogger typeLogger);
}