﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
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

                            termin.Id = reader.GetInt32(0);
                            termin.Vorname = reader.GetString(1);
                            termin.Nachname = reader.GetString(2);
                            termin.Telefonnummer = reader.GetString(3);
                            string dateStr = reader.GetString(4);
                            string uhrzeitStr = reader.GetString(5);
                            termin.Dauer = reader.GetInt32(6);
                            termin.Dienst = reader.GetInt32(7);

                            termin.Datum = DateTime.Parse(dateStr);
                            termin.Uhrzeit = TimeSpan.Parse(uhrzeitStr);
                            
                            termins.Add(termin);
                        }
                    }
                }
            }
            return termins;
        }

        public static Termin NewTermin(string vorname, string nachname, string telefonnummer, DateTime datum, TimeSpan uhrzeit, int dauer, int dienstleistung)
        {
            Termin newTermin = new Termin
            {
                Vorname = vorname,
                Nachname = nachname,
                Telefonnummer = telefonnummer,
                Datum = datum,
                Uhrzeit = uhrzeit,
                Dauer = dauer,
                Dienst = dienstleistung
            };
            AddTerminToSql(newTermin);
            

            return newTermin;

        }

		public static void RemoveTermin(int id)
		{
			string path = "Data Source=database/friseur.db";
			using (SqliteConnection connection = new SqliteConnection(path))
			{
				connection.Open();
				string query = "DELETE FROM Termine WHERE Id = @Id";
				using (SqliteCommand command = new SqliteCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.ExecuteNonQuery();
				}
			}
		}

        public static void EditTermine(string vorname, string nachname, string telefonnummer, DateTime datum, TimeSpan uhrzeit, int dauer, int dienstleistung, int id)
        {
            string path = "Data Source=database/friseur.db";
            using (SqliteConnection connection = new SqliteConnection(path))
            {
                connection.Open();
                string query = "UPDATE Termine SET Vorname = @Vorname, Nachname = @Nachname, Telefonnummer = @Telefonnummer, Datum = @Datum, Uhrzeit = @Uhrzeit, Dauer = @Dauer, DienstID = @DienstID WHERE Id = @Id";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Vorname", vorname);
                    command.Parameters.AddWithValue("@Nachname", nachname);
                    command.Parameters.AddWithValue("@Telefonnummer", telefonnummer);
                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@Uhrzeit", uhrzeit);
                    command.Parameters.AddWithValue("@Dauer", dauer);
                    command.Parameters.AddWithValue("@DienstID", dienstleistung);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
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
                    command.Parameters.AddWithValue("@DienstID", termin.Dienst);
                    command.ExecuteNonQuery();
                }
                
            }

        }


    }
}
