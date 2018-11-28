using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Dal.Entities
{
    public class MittelklasseAuto : Auto
    {
        public MittelklasseAuto() { }

        public MittelklasseAuto(int id, string marke, int tagestarif, DateTime rowVersion)
            : base(id, marke, tagestarif, rowVersion)
        {

        }

        public MittelklasseAuto(int id, string marke, int tagestarif)
            : base(id, marke, tagestarif)
        {

        }
    }
}
