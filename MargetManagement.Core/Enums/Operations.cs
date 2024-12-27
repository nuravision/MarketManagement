using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargetManagement.Core.Enums
{
    public enum ConsoleOperations
    {
        PRODUCT_OPERATIONS=1,
        MARKET_OPERATIONS=2,
        EXIT=3
    }
    public enum ProductOperations
    {
        PRODUCT_ADD=1,
        PRODUCT_UPDATE=2,
        PRODUCT_SORTING=3,
        PRODUCT_DELETE=4,
        PRODUCT_MARKETWHEREPRODUCTSOLD=5,
        PRODUCT_MENYU=6
    }
    public enum MarketOperations
    {
        MARKET_ADD=1,
        MARKET_UPDATE=2,
        MARKET_SORTING=3,
        MARKET_DELETE=4,
        MARKET_ADDPRODUCTSMARKET=5,
        MARKET_SORTINGPRODUCTSMARKET=6,
        MARKET_PRODUCTDELETE=7,
        MARKET_PRODUCTSOLD=8,
        MARKET_MENYU=9
    }
}
