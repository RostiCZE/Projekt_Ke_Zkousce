using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Klient
    {
        public string Jmeno { get;  set; }
        public string Prijmeni { get;  set; }
        public int TelCislo { get;  set; }
        public int Vek { get;  set; }

        public Klient(string jmeno, string prijmeni, int telcislo, int vek)
        { 
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.TelCislo = telcislo;
            this.Vek = vek;
        }
        public override string ToString()
        {
            return Jmeno + " " + Prijmeni + "," + " telefon: " + TelCislo + "," + " věk: " + Vek;
        }
    }
}
