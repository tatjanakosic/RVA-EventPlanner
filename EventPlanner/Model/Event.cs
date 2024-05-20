using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Model
{
    
    public class Event : BindableBase
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duration { get; set; }


        public Event() { }
    }
}
