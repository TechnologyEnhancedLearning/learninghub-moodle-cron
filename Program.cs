using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HttpCallExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();

            // Get URL from configuration
            string url = config["Settings:Url"];
            string password = config["Settings:Password"];

            string fullUrl = url + password;

            // Create an HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(10);
                // Make the HTTP GET request
                _ = await client.GetAsync(fullUrl);
            }
        }
    }
}
