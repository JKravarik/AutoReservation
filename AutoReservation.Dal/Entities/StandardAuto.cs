using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Dal.Entities
{
    public class StandardAuto : Auto
    {
        public StandardAuto() { }

        public StandardAuto(int id, string marke, int tagestarif, DateTime rowVersion)
         :base(id, marke, tagestarif, rowVersion)
        {

        }

        public StandardAuto(int id, string marke, int tagestarif)
            : base(id, marke, tagestarif)
        {

        }
    }
}
