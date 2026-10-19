using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanApp
{
    public class Lakas : Ingatlan
    {
        public int Emelet { get; set; }

        public Lakas(string helyrajz, int alapterulet, int emelet) : base( helyrajz, alapterulet)
        {
            Emelet = emelet;
        }

        public override int BecsultErtek()
        {
            if(Emelet > 0)
            {
                double szam = base.BecsultErtek() * 1.05;
                return Convert.ToInt32(szam) ;
            }
            else
            {
                return base.BecsultErtek();
            }
        }

        public override string ToString()
        {
            return base.ToString()+$" | Emelet: {Emelet}";
        }
    }
}
