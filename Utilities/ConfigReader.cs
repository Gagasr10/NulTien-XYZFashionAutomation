using Microsoft.Extensions.Configuration;
using System.IO;

namespace NulTien_XYZFashionAutomation.Utilities
{
    public static class ConfigReader
    {
        private static IConfigurationRoot configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }

        public static string Browser =>
            configuration["Browser"] ?? throw new Exception("Browser not found in appsettings.json");

        public static string BaseUrl =>
            configuration["BaseUrl"] ?? throw new Exception("BaseUrl not found in appsettings.json");

        public static int ImplicitWait =>
            int.Parse(configuration["Timeouts:ImplicitWait"] ?? "5");

        public static int ExplicitWait =>
            int.Parse(configuration["Timeouts:ExplicitWait"] ?? "10");
    }
}
