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

        public static List<Termin> LoadTerminsFromSql(List<Termin> termins)
        {
            string path = "Data Source=database/friseur.db";
            using (SqliteConnection connection = new SqliteConnection(path))
            { 
                connection.Open();

                string query = @"SELECT * FROM Termine;";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Termin termin = new Termin();

                            termin.Vorname = reader.GetString(1);
                            termin.Nachname = reader.GetString(2);
                            termin.Telefonnummer = reader.GetString(3);
                            termin.Datum = reader.GetString(4);
                            termin.Uhrzeit = reader.GetString(5);
                            termin.Dauer = reader.GetInt32(6);
                            termin.DienstID = reader.GetInt32(7);
            
                            termins.Add(termin);
                        }
                    }
                }
            }
            return termins;
        }
        public static void NewTermin(string vorname, string nachname, string telefonnummer, string datum, string uhrzeit, int dauer, int dienstleistung)
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
            AddTerminToSql(newTermin);
            

        }
            
            
        
        public static void AddTerminToSql(Termin termin)
        {
            
            string path = "Data Source=database/friseur.db";
            using (SqliteConnection connection = new SqliteConnection(path))
            {

                connection.Open();
                string query = "INSERT INTO Termine (Vorname, Nachname, Telefonnummer, Datum, Uhrzeit, Dauer, DienstID) VALUES (@Vorname, @Nachname, @Telefonnummer, @Datum, @Uhrzeit, @Dauer, @DienstID)";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Vorname", termin.Vorname);
                    command.Parameters.AddWithValue("@Nachname", termin.Nachname);
                    command.Parameters.AddWithValue("@Telefonnummer", termin.Telefonnummer);
                    command.Parameters.AddWithValue("@Datum", termin.Datum);
                    command.Parameters.AddWithValue("@Uhrzeit", termin.Uhrzeit);
                    command.Parameters.AddWithValue("@Dauer", termin.Dauer);
                    command.Parameters.AddWithValue("@DienstID", termin.DienstID);
                    command.ExecuteNonQuery();
                }
                
            }

        }
    }
}
