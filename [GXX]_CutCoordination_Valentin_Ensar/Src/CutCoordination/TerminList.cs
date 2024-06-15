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
        private List<Termin> termins = new List<Termin>();

        public TerminList() 
        { 
            termins = TerminManager.LoadTerminsFromSql(termins);
        }

        public void Visualize(ListBox box, TextBlock info)
        {
            box.Items.Clear();
            SortToNextFit();
            for(int i = 0; i < termins.Count; i++)
            {
                box.Items.Add(termins[i].ToString());
            }
            info.Text = termins.Count.ToString();
        }

        public void RemoveItem(string item, TextBlock info)
        {
            for(int i = 0; i < termins.Count; i++)
            {
                if (termins[i].ToString() == item)
                {
                    termins.RemoveAt(i);
                    break;
                }
            }
            info.Text = termins.Count.ToString();
		}

		public void AddTermin(Termin termin)
        {
            termins.Add(termin);
        }

		public void SortToNextFit()
        {
            for (int i = 0; i < termins.Count - 1; i++)
            {
                for (int j = 0; j < termins.Count - i - 1; j++)
                {
                    DateTime dateTime1 = termins[j].Datum + termins[j].Uhrzeit;
                    DateTime dateTime2 = termins[j + 1].Datum + termins[j + 1].Uhrzeit;

                    if (dateTime1 > dateTime2)
                    {
                        (termins[j], termins[j + 1]) = (termins[j + 1], termins[j]);
                    }
                }
            }
        }
    }
}