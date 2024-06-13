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

        public TerminList() 
        { 
            termins = TerminManager.LoadTerminsFromSql(termins);
        }

        public void Visualize(ListBox box)
        {
            for(int i = 0; i < termins.Count; i++)
            {
                box.Items.Add(termins[i].ToString());
            }
        }
    }
}