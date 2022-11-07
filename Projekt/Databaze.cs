using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public void PridatKlienta(string jmeno, string prijmeni, int Telcislo, int vek)
        {
            seznam.Add(new Klient(jmeno, prijmeni, Telcislo, vek));
        }
        public List<Klient> NajdiSeznam()
        {
            return seznam;
        }
    }
}
