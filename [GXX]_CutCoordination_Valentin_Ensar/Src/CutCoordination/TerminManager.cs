using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;



namespace G06_DBI_CutCoordination
{
    internal class TerminManager
    {


        public static Termin AddTermin(string vorname, string nachname, string telefonnummer, string datum, string uhrzeit, int dauer, int dienstleistung)
        {
            Termin newTermin = new Termin
            {
                Vorname = vorname,
                Nachname = nachname,
                Telefonnummer = telefonnummer,
                Datum = datum,
                Uhrzeit = uhrzeit,
                Dauer = dauer,
                DienstID = dienstleistung
            };
            return newTermin;

        }
            
            
        
        public static void AddTerminToSql(Termin termin)
        {
            string path = "Data Source=database/friseur.db";
            using (SqliteConnection connection = new SqliteConnection(path))
            {

                connection.Open();
                
            }

        }
    }
}
