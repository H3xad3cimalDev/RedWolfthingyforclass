using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedWolfDataCrunch
{
    class Program
    {
        static void Main(string[] args)
        {
            RedWolf redWolf1 = new RedWolf(Gender.Male, Class.UpperClass, 1, 5, 0.1143f, "Ee", "aa", "LL");
            RedWolf redWolf2 = new RedWolf(Gender.Female, Class.NormalClass, 2, 3, 0.1104f, "Ee", "aa", "LL");

            RedWolf child  = redWolf1.Breed(redWolf2);

            Output.PrintRedWolf(child);

            Console.Read();
        }
    }
}
