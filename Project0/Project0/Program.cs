using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
                Customer createdCust;
                while (true)
                {
                    createdCust = op.AddCustomer();
                    if (createdCust != null)
                    {
                        Console.WriteLine($"New Customer created for {createdCust.FirstName} {createdCust.LastName} as customer ID: {createdCust.ID}");
                    }
                    else
                    {
                        Console.WriteLine("Customer creating cancelled.");
                        continue;
                    }
                }
            }
                //Customer test = new Customer();
                //Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");
                //string[] titles = { "First name", "Last Name", "Address Line 1", "Address Line 2", "City", "State", "Zip Code", "Phone" };
                //string[] data = { test.FirstName, test.LastName, test.AddressLine1, test.AddressLine2, test.City, test.State, test.ZipCode, test.Phone };
                //for (int i = 0; i < titles.Length; i++)
                //{
                //    Console.WriteLine("{0,-20} {1,-20}", titles[i] , data[i]);
                //}
            
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
