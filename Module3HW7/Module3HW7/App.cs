using Microsoft.Extensions.DependencyInjection;
using Module3HW7.Services;
using Module3HW7.Services.Abstract;

namespace Module3HW7;

public class App
{
    public void RunApp()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<Actions>()
            .AddSingleton<ILoggerService, LoggerService>()
            .AddTransient<IFileService, FileService>()
            .AddTransient<IConfigService, ConfigService>()
            .AddTransient<Starter>()
            .BuildServiceProvider();

        var start = serviceProvider.GetService<Starter>();
        start?.Run();
    }
}