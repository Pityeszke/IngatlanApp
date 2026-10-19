using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanApp
{
    public class Ingatlan
    {
        public string Helyrajziszam { get; set; }
        protected int alapterulet;
        public int Alapterulet
        {
            get { return alapterulet; }
            set
            {
                if( value <= 0)
                {
                    alapterulet = 10;
                }
                else
                {
                    alapterulet = value;
                }
            }
        }
        private static int osszesIngatlanSzama = 0;
        public static int OsszesIngatlanSzama { get { return osszesIngatlanSzama; } }

        public Ingatlan(string helyrajz, int alapterulet)
        {
            Helyrajziszam = helyrajz;
            Alapterulet = alapterulet;
            osszesIngatlanSzama++;
        }

        public virtual int BecsultErtek()
        {
            return alapterulet * 400_000;
        }

        public override string ToString()
        {
            return $"Ingatlan {Helyrajziszam} | Terület: {alapterulet} m2 | Becsült érték: {BecsultErtek()} Ft";
        }
    }
}
