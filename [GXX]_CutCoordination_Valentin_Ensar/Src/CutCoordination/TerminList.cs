using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G06_DBI_CutCoordination
{
    public class TerminList
    {
        private List<Termin> termins = new List<Termin>();
        private int maxTermins = 0;

        public TerminList() 
        { 
            (termins, maxTermins) = TerminManager.LoadTerminsFromSql(termins);
        }

        public void Visualize(ListBox box, TextBlock info)
        {
            SortToNextFit();
            for(int i = 0; i < termins.Count; i++)
            {
                box.Items.Add(termins[i].ToString());
            }
            info.Text = maxTermins.ToString();
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