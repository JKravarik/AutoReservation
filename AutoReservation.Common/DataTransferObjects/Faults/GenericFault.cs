using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Common.DataTransferObjects.Faults
{
    [DataContract]
    public class GenericFault
    {
        public GenericFault() { }

        public GenericFault(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
