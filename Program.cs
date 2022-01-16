using System;
using System.IO;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MediatR_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // create and configure the service container
            IServiceCollection serviceCollection = ConfigureServices();

            // build the service provider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IMediatorService? mediator = serviceProvider.GetService<IMediatorService>();

            FooEvent fooEvent = new FooEvent(123);

            mediator?.Dispatch(fooEvent);         

            System.Console.WriteLine("Press [ENTER] to quit");
            Console.Read();
        }

        private static IServiceCollection ConfigureServices()
        {            
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);     

            IConfigurationRoot configuration = builder.Build();

            IServiceCollection service = new ServiceCollection();


            service.AddLogging(configure => 
                {
                    configure.AddConsole();
                    configure.AddConfiguration(configuration.GetSection("Logging"));
                }).Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient<IMediatorService, MediatorService>()
                ;
            
            return service;
        }        


    }


}