using Module3HW7.Services.Abstract;
using Module3HW7.Helpers.Abstract;

namespace Module3HW7.Helpers;

public class Actions : IActions
{
    private readonly ILoggerService _logger;

    public Actions(ILoggerService logger)
    {
        _logger = logger;
    }

    public bool ErrorMethod()
    {
        throw new Exception("I broke a logic");
    }

    public bool InfoMethod()
    {
        _logger.LogInfo("Start method: " + nameof(InfoMethod));

        return true;
    }

    public bool WarningMethod()
    {
        throw new BusinessException("Skipped logic in method");
    }
}