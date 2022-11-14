using Projekt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Pojistovna
    {
        public delegate void Pokracuj();
        public event Pokracuj Pokracovani;

        private Databaze databaze;
        public Pojistovna()
        {
            databaze = new Databaze();
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
            
            // Tvorba instance a její přidání do databáze
            
            databaze.PridatKlienta(Jmeno, Prijmeni, TelCislo, Vek);

            // Výpis tvořené instance

            Console.WriteLine("\nByl vytvořen klient {0} {1}, kterému je {2} let a jeho telefonní číslo je {3}.", Jmeno, Prijmeni, Vek, TelCislo);

            OnPokracovani();
        }
        protected virtual void OnPokracovani()
        {
            Pokracovani?.Invoke();
        }
        public void VypisKlienta()
        {
            Console.WriteLine("\nVýpis všech klientů:");
            foreach (Klient i in databaze.NajdiSeznam())
            {
                Console.WriteLine(i);
            }

            OnPokracovani();
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
            Klient vysledek = (from X in databaze.NajdiSeznam()
                               where (X.Jmeno.ToLower() == JmenoHledat.ToLower() && X.Prijmeni.ToLower() == PrijmeniHledat.ToLower())
                               select X).FirstOrDefault();
            if (vysledek != null)
            {
                Console.WriteLine("\n" + vysledek);

            }
            else
            {
                Console.WriteLine("\nKlient {0} neexistuje.", JmenoHledat);
            }

            OnPokracovani();
        }
    }
}