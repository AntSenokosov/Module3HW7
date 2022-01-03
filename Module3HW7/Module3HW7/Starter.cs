using Module3HW7.Helpers;
using Module3HW7.Helpers.Abstract;
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
        RunFile();
    }

    private async void RunFile()
    {
        _loggerService.Backup += Backup;
        var first = Task.Run(() => WriteLogger(50));
        var second = Task.Run(() => WriteLogger(50));

        await Task.WhenAll(new[] { first, second });
    }

    private void Backup()
    {
        _fileService.WriteBackupFile();
    }

    private void WriteLogger(int countIteration)
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
                _loggerService.LogWarning($"Action got this custom Exception: {e.Message}");
            }
            catch (Exception e)
            {
                _loggerService.LogError($"Action failed by reason: {e}");
            }
        }
    }
}