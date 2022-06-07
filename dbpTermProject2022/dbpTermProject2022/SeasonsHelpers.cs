using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbpTermProject2022
{
    public enum Seasons
    {
        Winter,
        Spring,
        Summer,
        Autumn,
        All
    }
    public class SeasonsHelpers
    {
        public static string RdoToData(GroupBox grp)
        {
            List<string> preSeason = new List<string>();
            foreach (CheckBox r in grp.Controls.OfType<CheckBox>())
            {
                if (r.Checked)
                {
                    preSeason.Add(r.Text);
                }
            }

            string seasons = String.Join("-", preSeason);
            if (seasons == "Autumn-Summer-Spring-Winter")
            {
                seasons = "All";
            }

            return seasons;
        }

        public static List<Seasons> Parse(string data)
        {
            string[] preSeason = data.Split('-');
            List<Seasons> seasons = new List<Seasons> { };
            foreach (string s in preSeason)
            {
                Enum.TryParse(s, out Seasons season);
                seasons.Add(season);
            }

            return seasons;
        }
    }
}
