using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                StoreOperation op = serviceProvider.GetService<StoreOperation>();
                op.AddCustomer();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.ClearProviders();
                configure.SetMinimumLevel(LogLevel.Information);
            }
                ).AddTransient<StoreOperation>();
        }
    }
}
