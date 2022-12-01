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
            Console.WriteLine("Records of the insured");
            Console.WriteLine("---------------------------");
            Console.WriteLine("\nChoose your action:");
            Console.WriteLine("1 - Add new client");
            Console.WriteLine("2 - Show all clients");
            Console.WriteLine("3 - Find client");
            Console.WriteLine("4 - Exit app");

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
                        Pokracuj();
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
            if (new [] { '1', '2', '3' }.Contains(volba))
            {
                Console.WriteLine("\nContinue by choosing your action");
            } else
            {
                Console.WriteLine("Invalid action, choose again please");
            }
           prvnispusteni = false;
           ZvolVolbu();
           VypisMenu();
        }
        public void Konec()
        {
            Console.WriteLine("\nThank you for choosing my app. Exiting now...");
            Console.WriteLine("Author : Rostislav Danko");
        }
    }
}
