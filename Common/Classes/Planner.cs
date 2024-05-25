using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Classes
{
   [DataContract]
   public class Planner
    {
        [DataMember]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        [DataMember]
        public List<Event> Events { get; set; }

        public Planner() { }

    }
}
