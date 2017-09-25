using GrmMusic.Loader;
using GrmMusic.Loader.Interface;
using GrmMusic.Search;
using GrmMusic.Search.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrmMusic.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IDataLoaderService, FileLoaderService>()
                .AddSingleton<ISearchService, SearchService>()
                .AddSingleton<IParserService, ParserService>()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            Task.Run(() =>
            {
                var dataLoaderService = serviceProvider.GetRequiredService<IDataLoaderService>();
                var searchService = serviceProvider.GetRequiredService<ISearchService>();

                var musicData = dataLoaderService.LoadMusicContractsData();
                searchService.LoadData(musicData);

                while (true)
                {
                    var command = Console.ReadLine();
                    searchService.Search(command);
                }

            }).Wait();
        }
    }
}
