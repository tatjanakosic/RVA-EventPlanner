﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Model
{
    public class Planner : BindableBase
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Event> Events { get; set; }

        public Planner() { }
        
    }
}
