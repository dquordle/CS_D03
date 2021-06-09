using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace d03
{
    class Progran
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0 || (args[0] != "apod" && args[0] != "neows") || args.Length > 2)
            {
                Console.WriteLine("Invalid data. Check your input and try again.");
                return;
            }
            IConfiguration Configuration;
            ConfigurationBuilder configurationBuilder =
                new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
            if (args[0] == "apod")
            {
                ApodClient apodClient = new ApodClient(Configuration["ApiKey"]);
                try
                {
                    MediaOfToday[] mediaOfToday = await apodClient.GetAsync(int.Parse(args[1]));
                    foreach (var media in mediaOfToday)
                    {
                        Console.WriteLine(media.ToString() + "\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (args[0] == "neows")
            {
                int ResultCount = Int32.MaxValue;
                if (args.Length == 2)
                    ResultCount = int.Parse(args[1]);
                NeoWsClient neoWsClient = new NeoWsClient(Configuration["ApiKey"]);
                AsteroidRequest request = new AsteroidRequest(DateTime.Parse(Configuration["NeoWs:StartDate"]),
                    DateTime.Parse(Configuration["NeoWs:EndDate"]), ResultCount);
                try
                {
                    AsteroidLookUp[] asteroidLookUps = await neoWsClient.GetAsync(request);
                    foreach (var asteroid in asteroidLookUps)
                    {
                        Console.WriteLine(asteroid.ToString() + "\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}