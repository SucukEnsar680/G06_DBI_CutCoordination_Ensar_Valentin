using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G06_DBI_CutCoordination
{
    internal class TerminManager
    {


        public static Termin AddTermin(string vorname, string nachname, string telefonnummer, string datum, string uhrzeit, int dauer)
        {
            Termin newTermin = new Termin
            {
                Vorname = vorname,
                Nachname = nachname,
                Telefonnummer = telefonnummer,
                Datum = datum,
                Uhrzeit = uhrzeit,
                Dauer = dauer
            };
            return newTermin;

        }
            
            
        }
        public static void AddTerminToSql(Termin termin)
        {
            //string path = "Data Source=database/friseur.db";

        }
    }
}
