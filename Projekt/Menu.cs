using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt
{
    internal class Menu
    {
        private char volba { get; set; }

        private Pojistovna pojistovna;


        private bool prvnispusteni = true;
        public Menu()
        {
            pojistovna = new Pojistovna();

            // Registrace eventu
            pojistovna.Pokracovani += Pokracuj;
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

            if (prvnispusteni == true)
            {
                char volba = ZvolVolbu();
            }
            // Načtení uživatelské volby z menu a reakce
            bool pokracuj = true;
            while (pokracuj == true)
            {
                switch (volba)
                {
                    case '1':
                        PridatKlienta();
                        break;

                    case '2':
                        VypisKlienta();
                        break;

                    case '3':
                        HledejKlienta();
                        break;

                    case '4':
                        pokracuj = false;
                        break;

                    default:
                        Default();
                        volba = ZvolVolbu();
                        break;
                }
            }
        }

        public char VratVolbu()
        {
            return volba;
        }
        public char ZvolVolbu()
        {
            volba = Console.ReadKey().KeyChar;
            return volba;
        }
        public void PridatKlienta()
        {
            pojistovna.PridatKlienta();
        }
        public void VypisKlienta()
        {
            pojistovna.VypisKlienta();
        }
        public void HledejKlienta()
        {
            pojistovna.HledejKlienta();
        }
        public void Pokracuj()
        {
           Console.WriteLine("\nPokračujte stiskem volby");
           prvnispusteni = false;
           ZvolVolbu();
           VypisMenu();
        }
        public void Konec()
        {
            Console.WriteLine("\nDěkuji za použití aplikace, nyní proběhne její vypnutí.");
            Console.WriteLine("Autor : Rostislav Danko");
        }
        public void Default()
        {
            Console.WriteLine("Neplatná Volba, zvol si prosím znovu");
        }
    }
}
