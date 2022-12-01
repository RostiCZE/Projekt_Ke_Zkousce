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

            Console.WriteLine("\nType clients name:");
            string Jmeno = "";
            while (string.IsNullOrEmpty(Jmeno))
            {
                Jmeno = Console.ReadLine().Trim();
            }

            Console.WriteLine("Type clients last name:");
            string Prijmeni = "";
            while (string.IsNullOrEmpty(Prijmeni))
            {
                Prijmeni = Console.ReadLine().Trim();
            }

            Console.WriteLine("Type clients phone number:");
            int TelCislo;
            while (!int.TryParse(Console.ReadLine(), out TelCislo))
                Console.WriteLine("Invalid number, please type it again:");

            Console.WriteLine("Type clients age:");
            int Vek;
            while (!int.TryParse(Console.ReadLine(), out Vek))
                Console.WriteLine("Invalid number, please type it again:");
            
            // Tvorba instance a její přidání do databáze
            
            databaze.PridatKlienta(Jmeno, Prijmeni, TelCislo, Vek);

            // Výpis tvořené instance

            Console.WriteLine("\nClient {0} {1} was created, the client is {2} years old and clients phone number is {3}.", Jmeno, Prijmeni, Vek, TelCislo);

            OnPokracovani();
        }
        protected virtual void OnPokracovani()
        {
            Pokracovani?.Invoke();
        }
        public void VypisKlienta()
        {
            Console.WriteLine("\nAll clients:");
            foreach (Klient i in databaze.NajdiSeznam())
            {
                Console.WriteLine(i);
            }

            OnPokracovani();
        }
        public void HledejKlienta()
        {
            // Načtení dat od uživatele pro hledání klienta

            Console.WriteLine("\nType clients name:");
            string JmenoHledat = "";
            while (string.IsNullOrEmpty(JmenoHledat))
            {
                JmenoHledat = Console.ReadLine().Trim();
            }

            Console.WriteLine("Type clients last name:");
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
                Console.WriteLine("\nClient {0} doesnt exist.", JmenoHledat);
            }

            OnPokracovani();
        }
    }
}