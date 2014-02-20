using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [DataContract]
    public class MSMQMessage
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string JSONMessage { get; set; }
    }
}
