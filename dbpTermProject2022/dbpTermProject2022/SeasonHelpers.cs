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
    public class SeasonHelpers
    {
        public static void BindSeason(ComboBox cmb1, bool insertBlank)
        {
            List<KeyValuePair<int, string>> lstSeasons = new List<KeyValuePair<int, string>>();
            Array seasons = Enum.GetValues(typeof(Seasons));
            foreach (Seasons season in seasons)
            {
                lstSeasons.Add(new KeyValuePair<int, string>((int)season, season.ToString()));
            }
            if (insertBlank)
            {
                lstSeasons.Add(new KeyValuePair<int, string>(Enum.GetNames(typeof(Seasons)).Length, null));
            }

            cmb1.DataSource = lstSeasons;
            cmb1.DisplayMember = "Value";
            cmb1.ValueMember = "Key";
        }
        public static string CmbToData(List<ListControl> controls)
        {
            List<string> preSeason = new List<string>();
            foreach (ListControl c in controls)
            {
                if (c.SelectedIndex != Enum.GetNames(typeof(Seasons)).Length)
                {
                    Seasons s = (Seasons)c.SelectedIndex;
                    preSeason.Add(s.ToString());
                }
            }

            string seasons = String.Join("-", preSeason);

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
