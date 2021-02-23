using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRFoodyWa.Helpers
{
    public class Settings : ISettings
    {
        public Settings()
        {
            Configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .AddJsonFile("appsettings.Development.json")
                 .Build();
        }

        public IConfiguration Configuration { get; }

        public string GetStorageTablePrimaryConnectionString() {
            return Configuration["AzureTableStorageOptions:PrimaryConnectionString"];
        }

        public string GetStorageTableSecondaryConnectionString() {
            return Configuration["AzureTableStorageOptions:SecondaryConnectionString"];
        }

        public string GetApiKey()
        {
            return Configuration["ApiKey"];
        }

        public string GetApplicationName()
        {
            return Configuration["ApplicationName"];
        }
    }
}
