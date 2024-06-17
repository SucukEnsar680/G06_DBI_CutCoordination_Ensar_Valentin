using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G06_DBI_CutCoordination
{
    public class TerminList
    {
		#region variables
		private List<Termin> termins = new List<Termin>();
		#endregion

		#region constructors
		public TerminList() 
        { 
            this.termins = TerminManager.LoadTerminsFromSql(this.termins);
            SortToNextFit();
        }
		#endregion

		#region methods
        public void AddTermin(Termin termin)
		{
			this.termins.Add(termin);
		}

		public void RemoveTermin(Termin termin)
		{
			TerminManager.RemoveTermin(termin.Id);

			for (int i = 0; i < this.termins.Count; i++)
			{
				if (this.termins[i].Id == termin.Id) 
				{
					this.termins.RemoveAt(i);
					break;
				}
			}
		}

        public string GetUmsatz()
        {
            string path = "Data Source=database/friseur.db";
            string Umsatz = "";
            using (SqliteConnection connection = new SqliteConnection(path))
            {

                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT SUM(d.Preis) as Umsatz FROM Termine t JOIN Dienstleistungen d ON t.DienstID = d.DienstID;";
                
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Umsatz = $"{Convert.ToString(reader.GetInt32(0))}€";
                    }
                    
                }

            }
            return Umsatz;
        }

        public void UpdateTermin(Termin oldTermin, Termin newTermin)
        {
            for(int i = 0; i < this.termins.Count;i++)
            {
                if (this.termins[i].Id == oldTermin.Id)
                {
                    this.termins[i] = newTermin;
                    break;
                }
            }
        }

        public List<Termin> GetTodayTermins(DateTime selectedDate)
        {
            List<Termin> todayTermins = new List<Termin>();

            for(int i = 0; i < this.termins.Count; i++)
            {
                if (this.termins[i].Datum == selectedDate)
                {
                    todayTermins.Add(this.termins[i]);
                }
            }
            return todayTermins;
        }

		public void SortToNextFit()
        {
            for (int i = 0; i < this.termins.Count - 1; i++)
            {
                for (int j = 0; j < this.termins.Count - i - 1; j++)
                {
                    DateTime dateTimeFirst = this.termins[j].Datum + this.termins[j].Uhrzeit;
                    DateTime dateTimeSecond = this.termins[j + 1].Datum + this.termins[j + 1].Uhrzeit;

                    if (dateTimeFirst > dateTimeSecond)
                    {
                        (this.termins[j], this.termins[j + 1]) = (this.termins[j + 1], this.termins[j]);
                    }
                }
            }
        }
		#endregion
	}
}