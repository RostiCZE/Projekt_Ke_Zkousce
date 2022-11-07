using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Databaze
    {
        private List<Klient> seznam { get; set; }
        public Databaze()
        {
            seznam = new List<Klient>();
        }
        public void PridatKlienta()
        {
            // Načtení dat pro tvorbu instance klienta

            Console.WriteLine("\nZadejte jméno klienta:");
            string Jmeno = "";
            while (string.IsNullOrEmpty(Jmeno))
            {
                Jmeno = Console.ReadLine().Trim();
            }

            Console.WriteLine("Zadejte příjmení klienta:");
            string Prijmeni = "";
            while (string.IsNullOrEmpty(Prijmeni))
            {
                Prijmeni = Console.ReadLine().Trim();
            }

            Console.WriteLine("Zadejte telefonní číslo klienta:");
            int TelCislo;
            while (!int.TryParse(Console.ReadLine(), out TelCislo))
                Console.WriteLine("Neplatné číslo, zadejte prosím znovu:");

            Console.WriteLine("Zadejte věk klienta:");
            int Vek;
            while (!int.TryParse(Console.ReadLine(), out Vek))
                Console.WriteLine("Neplatné číslo, zadejte prosím znovu:");

            // Tvorba instance klienta

            Klient klient = new Klient(Jmeno, Prijmeni, TelCislo, Vek);
            seznam.Add(klient);

            // Výpis tvořené instance

            Console.WriteLine("\nByl vytvořen klient {0} {1}, kterému je {2} let a jeho telefonní číslo je {3}.", klient.Jmeno, klient.Prijmeni, klient.Vek, klient.Cislo);
        }
        public void VypisKlientu()
        {
            Console.WriteLine("\nVýpis všech klientů:");
            foreach (Klient i in seznam)
            {
                Console.WriteLine(i);
            }
        }
        public void HledejKlienta()
        {
            // Načtení dat od uživatele pro hledání klienta

            Console.WriteLine("\nZadejte jméno klienta:");
            string JmenoHledat = "";
            while (string.IsNullOrEmpty(JmenoHledat))
            {
                JmenoHledat = Console.ReadLine().Trim();
            }

            Console.WriteLine("Zadejte příjmení klienta:");
            string PrijmeniHledat = "";
            while (string.IsNullOrEmpty(PrijmeniHledat))
            {
                PrijmeniHledat = Console.ReadLine().Trim();
            }

            // Vyhledání klienta
            Klient vysledek = seznam.Find(
                delegate (Klient kl)
                {
                    return kl.Jmeno == JmenoHledat && kl.Prijmeni == PrijmeniHledat;
                }
                );
            if (vysledek != null)
            {
                Console.WriteLine("\n" + vysledek);

            }
            else
            {
                Console.WriteLine("\nKlient {0} neexistuje.", JmenoHledat);
            }

        }
        public void Konec()
        {
            Console.WriteLine("\nDěkuji za použití aplikace, nyní proběhne její vypnutí.");
            Console.WriteLine("Autor : Rostislav Danko");
        }
    }
}
