using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedWolfDataCrunch
{
    // This is a simple class that helps print out data in different contextes
    public class Output
    {
        public static void PrintOperation(object output)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("]");
            Console.ResetColor();
            Console.WriteLine($" {output}");
        }

        public static void PrintError(object output)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {output}");
            Console.ResetColor();
        }

        public static void PrintWarning(object output)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("-");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" {output}");
            Console.ResetColor();
        }
    }
}
