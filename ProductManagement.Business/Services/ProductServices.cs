using MargetManagement.Core.Models;
using ProductManagement.Business.Helpers.Extensions;
using DaataAccess.Context;

namespace ProductManagement.Business.Services
{
    public class ProductServices
    {        
        public void Add()
        {
            NameInput:
            Console.Write("Elave etmek istediyiniz mehsulun adini daxil edin:");
            string? name=Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                ConsoleColor.Red.WriteLine("Mehsulun adini bos girdiniz zehmet olmasa duzgun daxil edin.");
                goto NameInput;
            }
            DescriptionInput:
            Console.Write("Elave etmek istediyiniz mehsulun tesvirini daxil edin:");
            string? description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                ConsoleColor.Red.WriteLine("Mehsulun tesvirini bos girdiniz zehmet olmasa duzgun daxil edin.");
                goto DescriptionInput;
            }
            PriceInput:
            Console.Write("Mehsulun qiymetini daxil edin:");
            double price;
            double.TryParse(Console.ReadLine(), out price);
            if (price <= 0) {
                Console.WriteLine("Mehsulun qiymeti 0-dan boyuk olmalidir.Zehmet olmasa duzgun daxil edin");
                goto PriceInput;    
            }
            Product product=new Product(name,description,price);
            AppDbContext<Product>.datas.Add(product);
        }
        public void ShowProducts()
        {
            if (AppDbContext<Product>.datas.Count==0)
            {
                Console.WriteLine("Her hansi product tapilmadi.");
                return;
            }
            Console.WriteLine("Productlar");
            foreach (Product product in AppDbContext<Product>.datas)
            {
                product.PrintInfoProduct();
            }
        }
        public Product? ChooseProduct()
        {
            if (AppDbContext<Product>.datas.Count==0)
            {
                return null;
            }
            IdInput:
            ShowProducts();
            Console.Write("Secim etmek istediyiniz mehsulun Id-sini daxil edin:");
            int chosenProductId;
            Int32.TryParse(Console.ReadLine(), out chosenProductId);    
            if (chosenProductId <= 0) {
                Console.WriteLine("Id-ni duzgun formatda daxil edin.");
                goto IdInput;
            }
            return AppDbContext<Product>.datas.FirstOrDefault((product) => product.Id == chosenProductId);
        }
        public void EditProduct()
        {
            if (AppDbContext<Product>.datas.Count == 0)
            {
                Console.WriteLine("Her hansi bir Product tapilmadi.");
            }
            Product? chosenproduct= ChooseProduct();
            if (chosenproduct == null)
            {
                Console.WriteLine("Product tapilmadi");
                return;
            }
            Console.WriteLine("Tapilan Product Bilgileri");
            chosenproduct.PrintInfoProduct();
            RetryName:
            Console.Write("Ad daxil edin:");
            string? name=Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Adi bos daxil etdiniz, duzgun daxil edin.");
                goto RetryName;
            }
            RetryDescription:
            Console.Write("Description daxil edin:");
            string? description=Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Descriptionu bos daxil etdiniz, duzgun daxil edin.");
                goto RetryDescription;
            }
            RetryPrice:
            Console.Write("Price daxil edin:");
            int price;
            Int32.TryParse (Console.ReadLine(), out price);
            if (price <= 0)
            {
                Console.WriteLine("Mehsulun qiymeti 0-dan boyuk olmalidir.Zehmet olmasa duzgun daxil edin.");
                goto RetryPrice;
            }
            chosenproduct.Name = name;
            chosenproduct.Description = description;
            chosenproduct.Price = price;
        }
        public void Delete()
        {
            if (AppDbContext<Product>.datas.Count == 0)
            {
                Console.WriteLine("Product tapilmadi.");
                return; 
            }
            Product? chosenProduct=ChooseProduct();
            if (chosenProduct is null)
            {
                Console.WriteLine("Product tapilmadi.");
                return;
            }
            if (check(chosenProduct))
            {
                Console.WriteLine("Bu mehsul basqa marketde oldugu ucun siline bilmez.");
                return;
            }
            AppDbContext<Product>.datas.Remove(chosenProduct);
            ConsoleColor.Green.WriteLine("Mehsul silindi");
        }
        public void ShowProductMarkets()
        {
            if (AppDbContext<Product>.datas.Count==0)
            {
                Console.WriteLine("Product tapilmadi.");
                return;
            }
            Product? chosenProduct=ChooseProduct();
            if (chosenProduct is null)
            {
                Console.WriteLine("Product tapilmadi");
                return;
            }
            List<Market> productMarkets= AppDbContext<Market>.datas.FindAll((market)=>market.Products.Keys.Contains(chosenProduct));
            if (productMarkets.Count==0)
            {
                Console.WriteLine("Product hec bir marketde tapilmadi.");
                return;
            }
            Console.WriteLine("Productun satildigi marketler");
            foreach (Market market in productMarkets)
            {
                market.ShowMarket();
            }
        }
        public bool check(Product Product)
        {
            foreach (Market market in AppDbContext<Market>.datas)
            {
                if (market.Products.Keys.Contains(Product))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
