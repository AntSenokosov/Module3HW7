using Module3HW7.Helpers;
using Module3HW7.Helpers.Abstract;
using Module3HW7.Models;
using Module3HW7.Services.Abstract;

namespace Module3HW7;

public class Starter
{
    private readonly ILoggerService _loggerService;
    private readonly IFileService _fileService;
    private readonly IActions _actions;
    private readonly Random _random;

    public Starter(IActions actions, ILoggerService loggerService, IFileService fileService)
    {
        _actions = actions;
        _loggerService = loggerService;
        _fileService = fileService;
        _random = new Random();
    }

    public void Run()
    {
        _loggerService.Backup += Backup;
        var list = new List<Task>();

        list.Add(Task.Run(async () =>
        {
            await WriteLogger(50);
        }));

        list.Add(Task.Run(async () =>
        {
            await WriteLogger(50);
        }));

        Task.WaitAll(list.ToArray());
    }

    private void Backup()
    {
        _fileService.WriteBackupFile();
    }

    private async Task WriteLogger(int countIteration)
    {
        for (var i = 0; i < countIteration; i++)
        {
            var numberMethod = _random.Next(0, 3);

            try
            {
                switch (numberMethod)
                {
                    case 0:
                        _actions.InfoMethod();
                        break;
                    case 1:
                        _actions.WarningMethod();
                        break;
                    case 2:
                        _actions.ErrorMethod();
                        break;
                }
            }
            catch (BusinessException e)
            {
                await _loggerService.LogWarning($"Action got this custom Exception: {e.Message}");
            }
            catch (Exception e)
            {
                await _loggerService.LogError($"Action failed by reason: {e}");
            }
        }
    }
}