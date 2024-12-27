using MargetManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Business.Services;
namespace DataAccess.Context
{
    public static class AppDbContext<T>
    {
        public static List<T> datas =new List<T>();
    }
}
