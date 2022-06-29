using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spargo.BLL.Services;
using Spargo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpargoPharmaetheuticalTestProject.TestTools
{
    public static class ConsoleStartup
    {
        public static void Init(IHost host)
        {
            var productService = ActivatorUtilities.CreateInstance<ProductService>(host.Services);
            var storeHouseService = ActivatorUtilities.CreateInstance<StoreHouseService>(host.Services);
            var stockService = ActivatorUtilities.CreateInstance<StockService>(host.Services);
            var pharmacyService = ActivatorUtilities.CreateInstance<PharmacyService>(host.Services);

            //Add Products 
            int firstDrug = productService.AddProduct(new Product() { Name = "Ибупрофен" });
            int secondDrug = productService.AddProduct(new Product() { Name = "Пенталгин" });
            int thirdDrug = productService.AddProduct(new Product() { Name = "Триазаверин" });

            //Add Pharamcies
            int firstPharmacyId = pharmacyService.AddPharmacy(new Pharmacy()
            {
                Name = "PharmacyToCheck",
                Adress = "Kolomyazhsky",
                PhoneNumber = "9(222)394-22-22"
            });

            int secondPharmacyId = pharmacyService.AddPharmacy(new Pharmacy()
            {
                Name = "Pharmacy2",
                Adress = "Kolomyazhsky",
                PhoneNumber = "9(222)394-22-22"
            });

            //Add StoreHouses for Pharmacies
            int firstPharmacy1StoreHouse = storeHouseService.AddStoreHouse(new StoreHouse()
            {
                PharmacyId = firstPharmacyId,
                StoreName = "First Store Name"
            });

            int firstPharmacy2StoreHouse = storeHouseService.AddStoreHouse(new StoreHouse()
            {
                PharmacyId = firstPharmacyId,
                StoreName = "First Store Name"
            });

            int secondPharmacy1StoreHouse = storeHouseService.AddStoreHouse(new StoreHouse()
            {
                PharmacyId = secondPharmacyId,
                StoreName = "Third Store Name"
            });

            //Add Stocks to StoreHouses
            int firstStoreHouseStock_One = stockService.AddStock(new Stock() { ProductId = firstDrug, StockNumber = 2, StoreHouseId = firstPharmacy1StoreHouse });
            int firstStoreHouseStock_Two = stockService.AddStock(new Stock() { ProductId = firstDrug, StockNumber = 4, StoreHouseId = firstPharmacy1StoreHouse });
            int firstStoreHouseStock_Three = stockService.AddStock(new Stock() { ProductId = secondDrug, StockNumber = 1, StoreHouseId = firstPharmacy1StoreHouse });

            int secondStoreHouseStock_One = stockService.AddStock(new Stock() { ProductId = secondDrug, StockNumber = 3, StoreHouseId = firstPharmacy2StoreHouse });
            int secondStoreHouseStock_Two = stockService.AddStock(new Stock() { ProductId = thirdDrug, StockNumber = 4, StoreHouseId = firstPharmacy2StoreHouse });

            //Stocks for Second Pharmacy That won't be checked
            int thirdStoreHouseStock_One = stockService.AddStock(new Stock() { ProductId = firstDrug, StockNumber=20, StoreHouseId = secondPharmacy1StoreHouse });
            int thirdStoreHouseStock_Two = stockService.AddStock(new Stock() { ProductId = secondDrug, StockNumber = 20, StoreHouseId = secondPharmacy1StoreHouse });
            int thirdStoreHouseStock_Three = stockService.AddStock(new Stock() { ProductId = thirdDrug, StockNumber = 20, StoreHouseId = secondPharmacy1StoreHouse });

            //Checkin First Pharmacy Products
            Console.WriteLine("Products in First Pharmacy");
            var productList = pharmacyService.GetProductsInPharmacy(firstPharmacyId);
            foreach (var item in productList)
            {
                Console.WriteLine($"{item.ProductName} - {item.ProductQuantity}");
            }

        }
    }
}
