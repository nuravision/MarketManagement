using MargetManagement.Core.Enums;
using MargetManagement.Core.Models;
using ProductManagement.Business.Helpers.Extensions;
using ProductManagement.Business.Services;

ProductServices productServices = new ProductServices();
MarketServices marketServices = new MarketServices();
bool isContiniue = true;
while (isContiniue)
{
    WrongChoice:
    ConsoleColor.Red.WriteLine("Xos gelmisiniz.Secim edin.");
    Console.WriteLine("1.Product Emeliyyatlari");
    Console.WriteLine("2.Market Emeliyyatlari");
    Console.WriteLine("3.Cixis");
    int choice;
    Int32.TryParse(Console.ReadLine(), out choice);
    switch (choice)
    {

        case (int)ConsoleOperations.PRODUCT_OPERATIONS:
        ProductOperationsLabel:
            Console.WriteLine("Seciminizi daxil edin:");
            Console.WriteLine("1.Product elave et.");
            Console.WriteLine("2.Producte duzelis et.");
            Console.WriteLine("3.Productu sirala.");
            Console.WriteLine("4.Productu sil.");
            Console.WriteLine("5.Productun satildigi marketleri sirala.");
            Console.WriteLine("6.Ana menyuya qayit.");
            int choice1;
            Int32.TryParse(Console.ReadLine(), out choice1);
            switch (choice1)
            {
                case (int)ProductOperations.PRODUCT_ADD:
                    productServices.Add();
                    goto ProductOperationsLabel;
                case (int)ProductOperations.PRODUCT_UPDATE:
                    productServices.EditProduct();
                    goto ProductOperationsLabel;
                case (int)ProductOperations.PRODUCT_SORTING:
                    productServices.ShowProducts();
                    goto ProductOperationsLabel;
                case (int)ProductOperations.PRODUCT_DELETE:
                    productServices.Delete();
                    goto ProductOperationsLabel;
                case (int)ProductOperations.PRODUCT_MARKETWHEREPRODUCTSOLD:
                    productServices.ShowProductMarkets();
                    goto ProductOperationsLabel;
                case (int)ProductOperations.PRODUCT_MENYU:
                    goto WrongChoice;
                default:
                    Console.WriteLine("Secim yalnisdir.Seciminizi duzgun daxil edin:");
                    goto ProductOperationsLabel;
            }
            break;
        case (int)ConsoleOperations.MARKET_OPERATIONS:
            MarketOperationsLabel:
            Console.WriteLine("Seciminizi daxil edin:");
            Console.WriteLine("1.Market elave et.");
            Console.WriteLine("2.Markete duzelis et.");
            Console.WriteLine("3.Marketi sirala.");
            Console.WriteLine("4.Market sil.");
            Console.WriteLine("5.Markete product elave et.");
            Console.WriteLine("6.Marketdeki productu sirala.");
            Console.WriteLine("7.Marketdeki productu sil.");
            Console.WriteLine("8.Product satisi et.");
            Console.WriteLine("9.Ana menyuya geri qayit.");
            int choice2;
            Int32.TryParse (Console.ReadLine(), out choice2);
            switch (choice2)
            {
                case (int)MarketOperations.MARKET_ADD:
                    marketServices.Add();
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_UPDATE:
                    marketServices.MarketUpdate();
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_SORTING:
                    marketServices.ShowMarket();
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_DELETE:
                    marketServices.MarketDelete();
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_ADDPRODUCTSMARKET:
                    Product? product=productServices.ChooseProduct();
                    if (product is null)
                    {
                        Console.WriteLine("Product tapilmadi.");
                        goto MarketOperationsLabel;
                    }
                    marketServices.ADddProductToMarket(product);
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_SORTINGPRODUCTSMARKET:
                    marketServices.ShowProductss();
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_PRODUCTDELETE:
                    Product? product5 = productServices.ChooseProduct();
                    //if (product1 is null)
                    //{
                    //    Console.WriteLine("Product tapilmadi.");
                    //    goto MarketOperationsLabel;
                    //}
                    marketServices.MarketProductDelete(product5);
                    goto MarketOperationsLabel;
                    break;
                case (int)MarketOperations.MARKET_PRODUCTSOLD:
                    SellLabel:
                    Product? productt = productServices.ChooseProduct();
                    //if (productt is null)
                    //{
                    //    Console.WriteLine("Product tapilmadi.Duzgun daxil edin:");
                    //    goto SellLabel;
                    //}
                    marketServices.ProductSell(productt);
                    goto MarketOperationsLabel;
                case (int)MarketOperations.MARKET_MENYU:
                    goto WrongChoice;
                default:
                    Console.WriteLine("Secim yalnisdir.Seciminizi duzgun daxil edin:");
                    goto MarketOperationsLabel;
            }
            break;
        case (int)ConsoleOperations.EXIT:
            Console.WriteLine("Program bitti.Sagolun");
            isContiniue = false;
            break;
        default:
            Console.WriteLine("Zehmet olmasa seciminizi duzgun daxil edin:");
            goto WrongChoice;
    }
}
