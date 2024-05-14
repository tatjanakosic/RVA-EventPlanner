using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Model
{
    public class User : BindableBase
    {
        // nasledjuje BindableBase klasu - dodati
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLogged { get; set; }

        public User() { }

        
    }
}
