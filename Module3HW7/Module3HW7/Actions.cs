using Module3HW7.Helpers;
using Module3HW7.Services.Abstract;

namespace Module3HW7;

public class Actions
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