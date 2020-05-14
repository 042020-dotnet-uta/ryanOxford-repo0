using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Project0
{
    /// <summary>
    /// Class to run the program
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                StoreOperation op = serviceProvider.GetService<StoreOperation>();
                op.start();
                
                
                
                //To recreate the database, uncomment this next line
                //op.SeedDB();
            }

        }
        /// <summary>
        /// method to add in the logging element
        /// </summary>
        /// <param name="services"></param>
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
