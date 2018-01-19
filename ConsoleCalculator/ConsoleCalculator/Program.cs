using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mano pirma programa! Koks tavo vardas?");

            string name = Console.ReadLine();
            Console.WriteLine("Labas, " +                     name);

            Console.ReadLine(); 
        }
    }
}
