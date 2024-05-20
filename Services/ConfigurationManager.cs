using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Supermarket.Services;

public static class ConfigurationManager
{
    private const string ConfigFilePath = "appsettings.json";

    public static string? GetSetting(string settingName)
    {
        try
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName + "\\" + ConfigFilePath;
            using var configFile = File.OpenText(path);
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
    
    public static string? GetConnectionString()
    {
        var parentFullName = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        if (parentFullName == null) return null;
        
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(parentFullName)
            .AddJsonFile(ConfigFilePath, optional: false, reloadOnChange: true)
            .Build();
        
        return config.GetConnectionString("SupermarketDb");
    }
    
    public static string? GetConnectionStringDbContext()
    {
        var parentFullName = Directory.GetCurrentDirectory();
        
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(parentFullName)
            .AddJsonFile(ConfigFilePath, optional: false, reloadOnChange: true)
            .Build();
        
        return config.GetConnectionString("SupermarketDb");
    }
}
