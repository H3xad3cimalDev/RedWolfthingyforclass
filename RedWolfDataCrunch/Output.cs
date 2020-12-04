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

        private static void PrintProperty(string prop_name, object value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\t{prop_name}");
            Console.ResetColor();
            Console.Write(" \u2192 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(value);
            Console.ResetColor();
            Console.WriteLine(";");
            Console.ResetColor();
        }

        public static void PrintRedWolf(RedWolf wolf)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Red Wolf ");
            Console.ResetColor();
            Console.Write($"\u2192 {wolf.ID} ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("| ");
            Console.ResetColor();
            Console.Write("Data: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("{");
            Console.ResetColor();

            //Console.WriteLine($"Red Wolf \u2192 {wolf.ID} | Data: {{");
            PrintProperty("Gender", wolf.Gender == Gender.Male ? "Male" : "Female");
            PrintProperty("Class", wolf.Class == Class.UpperClass ? "Upper-Class" : "Normal-Class");
            PrintProperty("ID", wolf.ID);
            PrintProperty("Age", wolf.Age);
            PrintProperty("Kinship", wolf.Kinship);
            PrintProperty("EarSize", wolf.EarSize);
            PrintProperty("PawSize", wolf.PawSize);
            PrintProperty("LegLength", wolf.PawSize);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}");
            Console.ResetColor();

            //Console.Write($"\t Gender \u2192 {wolf.Gender}");
        }
    }
}
