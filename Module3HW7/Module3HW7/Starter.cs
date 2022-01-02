using Module3HW7.Helpers;
using Module3HW7.Services;

namespace Module3HW7;

public class Starter
{
    private readonly LoggerService _loggerService;
    private readonly FileService _fileService;
    private readonly Actions _actions;
    private readonly Random _random;

    public Starter(LoggerService loggerService, FileService fileService)
    {
        _loggerService = loggerService;
        _fileService = fileService;
        _actions = new Actions(_loggerService);
        _random = new Random();
    }

    private void WriteLogger(int countIteration)
    {
        for (var i = 0; i < countIteration; i++)
        {
            var numberMethod = _random.Next(3);

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