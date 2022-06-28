using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spargo.BLL.Interfaces;
using Spargo.BLL.Services;
using Spargo.DAO;
using Spargo.DAO.Interfaces;
using Spargo.Entities.Options;
using System;
using System.IO;

namespace SpargoPharmaetheuticalTestProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            var configuration = builder.Build();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IProductService, ProductService>();
                    services.AddTransient<IPharmacyService, PharmacyService>();
                    services.AddTransient<IStockService, StockService>();
                    services.AddTransient<IStoreHouseService, StoreHouseService>();

                    services.AddTransient<IProductDAO, ProductDAO>();
                    services.AddTransient<IPharmacyDAO, PharmacyDAO>();
                    services.AddTransient<IStockDAO, StockDAO>();
                    services.AddTransient<IStoreHouseDAO, StoreHouseDAO>();

                    services.Configure<ConnectionStringOptions>(configuration.GetSection("ConnectionStrings"));
                })
                .Build();

            var ProductService = ActivatorUtilities.CreateInstance<ProductService>(host.Services);
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}