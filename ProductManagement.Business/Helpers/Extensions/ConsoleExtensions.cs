using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Helpers.Extensions
{
    public static class ConsoleExtensions
    {
        public static void WriteLine(this ConsoleColor consoleColor, string text="")
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Write(this ConsoleColor consoleColor, string text)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ResetColor();
        }

    }
}
