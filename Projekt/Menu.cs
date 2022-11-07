using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Menu
    {
        public Menu()
        {

        }
        public void VypisMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Evidence pojištěných");
            Console.WriteLine("---------------------------");
            Console.WriteLine("\nVyberte si akci:");
            Console.WriteLine("1 - Přidat nového klienta");
            Console.WriteLine("2 - Vypsat všechny klienty");
            Console.WriteLine("3 - Vyhledat klienta");
            Console.WriteLine("4 - Ukončit aplikaci");
        }
        public void Pokracuj()
        {
            Console.WriteLine("\nPokračujte stiskem další volby");
        }
    }
}
