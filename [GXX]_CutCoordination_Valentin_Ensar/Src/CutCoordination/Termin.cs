using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace G06_DBI_CutCoordination
{
    public class Termin
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Telefonnummer { get; set; }
        public string Datum { get; set; }
        public string Uhrzeit { get; set; }
        public int Dauer { get; set; }
        public int DienstID{ get; set; }

        public override string ToString()
        {
            return $"{Vorname};{Dauer}";
        }
    }
}
