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
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Telefonnummer { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Uhrzeit { get; set; }
        public int Dauer { get; set; }
        public int Dienst { get; set; } 
    }
}