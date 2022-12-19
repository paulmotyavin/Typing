using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaderboard
{

    public class Leaderboard
    {
        public string Name;
        public int Cpm;
        public double Cps;
        public int Mistakes;

        public Leaderboard(string Name, int Cpm, double Cps, int Mistakes)
        {
            this.Name = Name;
            this.Cpm = Cpm;
            this.Cps = Cps;
            this.Mistakes = Mistakes;
        }
    }
}
