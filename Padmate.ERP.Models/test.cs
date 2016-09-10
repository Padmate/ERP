using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Padmate.ERP.Models
{
    [DataContract]
    public class test
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string TypeID { get; set; }

        [DataMember]
        public string LogConetnt { get; set; }
    }
}
