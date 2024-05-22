using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Classes
{
    [DataContract]
   public class User
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
        public bool IsLogged { get; set; }

        public User() { }
    }
}
