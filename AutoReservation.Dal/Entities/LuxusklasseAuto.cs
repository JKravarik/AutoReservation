using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Dal.Entities
{
    public class LuxusklasseAuto : Auto
    {
        public int Basistarif { get; set; }

        public LuxusklasseAuto() { }

        public LuxusklasseAuto(int id, string marke, int tagestarif,int basistarif, byte[] rowVersion)
            : base(id, marke, tagestarif, rowVersion)
        {
            this.Basistarif = basistarif;
        }

        public LuxusklasseAuto(int id, string marke, int tagestarif, int basistarif)
            : this(id, marke, tagestarif,basistarif, new byte[0] )
        {

        }


    }
}
