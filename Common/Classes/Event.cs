using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Classes
{
    [DataContract]
   public class Event
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Topic { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public double Duration { get; set; }


        public Event() { }
    }
}
