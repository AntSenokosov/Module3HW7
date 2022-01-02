using Module3HW7.Services.Abstract;
using Module3HW7.Configs;
using Newtonsoft.Json;

namespace Module3HW7.Services;

public class ConfigService : IConfigService
{
    private const string Path = "config.json";
    private Config? _config;

    public ConfigService()
    {
        LoadConfig();
    }

    public Config? Config => _config;

    private void LoadConfig()
    {
        var text = File.ReadAllText(Path);
        _config = JsonConvert.DeserializeObject<Config>(text);
    }
}