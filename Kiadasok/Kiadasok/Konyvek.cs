using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiadasok
{
    internal class Konyvek
    {
        public string Szerzo_Cim { get; set; }
        public int Ev { get; set; }
        public int NegyedEv { get; set; }
        public bool Hazai { get; set; }
        public int Peldany { get; set; }
        public int Ev_Negyedev { get { return int.Parse(Ev.ToString() + NegyedEv.ToString()); } }
        public Konyvek(int ev, int negyedev, bool hazai, string szerzo_cim, int peldany)
        {
            Ev = ev;
            NegyedEv = negyedev;
            Hazai = hazai;
            Szerzo_Cim = szerzo_cim;
            Peldany = peldany;
        }
    }
}