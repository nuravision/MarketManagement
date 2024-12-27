using DaataAccess.Context;
using MargetManagement.Core.Models;
using ProductManagement.Business.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Services
{
    public class MarketServices
    {
        public void Add()
        {
            NameInput:
            Console.Write("Elave etmek istediyiniz Marketin adini daxil edin:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                ConsoleColor.Red.WriteLine("Marketin adini bos girdiniz zehmet olmasa duzgun daxil edin.");
                goto NameInput;
            }
            AddressInput:
            Console.Write("Elave etmek istediyiniz marketin addresini daxil edin:");
            string? address = Console.ReadLine();
            if (string.IsNullOrEmpty(address))
            {
                ConsoleColor.Red.WriteLine("Marketin addresini bos girdiniz zehmet olmasa duzgun daxil edin.");
                goto AddressInput;
            }
            Market markets=new Market(name,address);
            AppDbContext<Market>.datas.Add(markets);
        }
        public void ShowMarket()
        {
            if (AppDbContext<Market>.datas.Count==0)
            {
                Console.WriteLine("Her hansi bir market tapilmadi.");
                return;
            }
            Console.WriteLine("Marketler");
            foreach(Market market in AppDbContext<Market>.datas)
            {
                market.ShowMarket();
            }
        }
        public void MarketProductDelete(Product product)
        {
            Market? chosenMarket=ChooseMarket();
            if (chosenMarket==null)
            {
                Console.WriteLine("Market tapilmadi.");
                return;
            }
            if (!chosenMarket.Products.ContainsKey(product)) {
                Console.WriteLine("Bu marketde bu mehsul movcud deyil.");
                return;
            }
            chosenMarket.Products.Remove(product);
            Console.WriteLine("Product Marketden silindi.");
        }
        public Market? ChooseMarket()
        {
            if (AppDbContext<Market>.datas.Count==0)
            {
                return null;
            }
            IdLabell:
            ShowMarket();
            Console.WriteLine("Secmek istediyiniz marketin Id-sini daxil edin:");
            int chosenMarketId;
            Int32.TryParse(Console.ReadLine(),out chosenMarketId);
            if (chosenMarketId<=0)
            {
                Console.WriteLine("Bele bir Id movcud deyil.Id-ni duzgun daxil edin.");
                goto IdLabell;
            }
            return AppDbContext<Market>.datas.FirstOrDefault((Market) => Market.Id == chosenMarketId);
        }
        public void ShowProductss()
        {
            Market? chosennmarket = ChooseMarket();
            if (chosennmarket is null)
            {
                Console.WriteLine("Market Tapilmadi.");
                return;
            }
            if (chosennmarket.Products.Keys.Count==0) {
                Console.WriteLine("Marketde product yoxdur.");
                return;
            }
            Console.WriteLine("Marketdeki productlar:");
            foreach (Product product in chosennmarket.Products.Keys)
            {
                product.PrintInfoProduct();
            }
        }
        public void MarketUpdate()
        {
            if (AppDbContext<Market>.datas.Count==0)
            {
                Console.WriteLine("Her hansi bir market tapilmadi.");
            }
            Market? chosenMarket = ChooseMarket();
            if (chosenMarket==null)
            {
                Console.WriteLine("Market tapilmadi.");
                return;
            }
            Console.WriteLine("Tapilan Market Bilgileri");
            chosenMarket.ShowMarket();
            RetryName:
            Console.Write("Ad daxil edin:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Adi bos daxil etdiniz, duzgun daxil edin.");
                goto RetryName;
            }
            RetryAddresss:
            Console.Write("Address daxil edin:");
            string? address = Console.ReadLine();
            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Addressi bos daxil etdiniz, duzgun daxil edin.");
                goto RetryAddresss;
            }
            chosenMarket.Name = name;
            chosenMarket.Address=address;
        }
        public void MarketDelete()
        {
            if (AppDbContext<Market>.datas.Count == 0)
            {
                Console.WriteLine("Market tapilmadi.");
                return;
            }
            Market? chosenMarket = ChooseMarket();
            if (chosenMarket is null)
            {
                Console.WriteLine("Market tapilmadi.");
                return;
            }
            AppDbContext<Market>.datas.Remove(chosenMarket);
            Console.WriteLine("Market silindi.");
        }
        public void ADddProductToMarket(Product product)
        {
            Market? chosenMarkeet = ChooseMarket();
            if (chosenMarkeet == null)
            {
                Console.WriteLine("Market tapilmadi.");
                return;
            }
            if (chosenMarkeet.Products.ContainsKey(product))
            {
                Console.WriteLine("Bu markete bu product daha evvel elave olunub.");
                return;
            }
            int say;
            Console.Write("Elave etmek istediyiniz mehsulun sayini daxil edin:");
            Int32.TryParse(Console.ReadLine(), out say);
            chosenMarkeet.Products.Add(product,say);
            ConsoleColor.Green.WriteLine("\nProduct Markete elave edildi.");
        }
        public void ProductSell(Product product)
        {
            Market chosenMarket = ChooseMarket();

            if (chosenMarket == null)
            {
                Console.WriteLine("Market tapilmadi.");
                return;
            }

            int chosenProductId;
            Console.WriteLine("Id:");
            while (!Int32.TryParse(Console.ReadLine(), out chosenProductId) || chosenProductId <= 0)
            {
                Console.WriteLine("Bele bir formatda Id movcud deyil. Id-ni duzgun daxil edin.");
            }

            Product foundProduct = null;
            foreach (var item in chosenMarket.Products)
            {
                if (item.Key.Id == chosenProductId)
                {
                    foundProduct = item.Key;
                    break;
                }
            }

            if (foundProduct == null)
            {
                Console.WriteLine("Bu mehsul magazada tapilmadi.");
                return;
            }

            int productSize;
            Console.WriteLine("Satmaq istediyiniz mehsulun sayini daxil edin:");
            while (!Int32.TryParse(Console.ReadLine(), out productSize) || productSize <= 0)
            {
                Console.WriteLine("Zehmet olmasa duzgun daxil edin:");
            }

            if (productSize > chosenMarket.Products[foundProduct])
            {
                Console.WriteLine("Magazada bu mehsuldan bu qeder yoxdur.");
                return;
            }

            chosenMarket.Products[foundProduct] -= productSize;

            if (chosenMarket.Products[foundProduct] == 0)
            {
                chosenMarket.Products.Remove(foundProduct);
            }

            Console.WriteLine("Mehsul satildi.");
            Console.WriteLine($"Qalan Product sayi:{chosenMarket.Products[foundProduct]}");

        }
    }
}
