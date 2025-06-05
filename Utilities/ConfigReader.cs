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

        public static string Browser => configuration["Browser"];
        public static string BaseUrl => configuration["BaseUrl"];
        public static int ImplicitWait => int.Parse(configuration["Timeouts:ImplicitWait"]);
        public static int ExplicitWait => int.Parse(configuration["Timeouts:ExplicitWait"]);
    }
}
