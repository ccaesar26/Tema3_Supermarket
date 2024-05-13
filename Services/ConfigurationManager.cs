using System.IO;
using System.Text.Json;

namespace Supermarket.Services;

public static class ConfigurationManager
{
    private const string ConfigFilePath = "AppSettings.json";

    public static string? GetSetting(string settingName)
    {
        try
        {
            using var configFile = File.OpenText(ConfigFilePath);
            using var jsonDoc = JsonDocument.Parse(configFile.ReadToEnd());
            var root = jsonDoc.RootElement;

            return root.TryGetProperty(settingName, out var settingValue) 
                ? settingValue.GetString() 
                : null;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Config file not found.");
            return null;
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid JSON format in config file.");
            return null;
        }
    }
}
