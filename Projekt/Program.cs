using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {

            // Inicializace instancí 
            Menu menu = new Menu();
            // Registrace eventů
            menu.pojistovna.Pokracovani += menu.Pokracuj;

            // Základní Výpis Menu
            menu.VypisMenu();
        }

    }
}
