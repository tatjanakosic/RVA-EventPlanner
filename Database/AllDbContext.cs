using Common.Classes;
using System;
using System.Data.Entity;

namespace Database
{
    public class AllDbContext : DbContext
    {


        public AllDbContext()
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Planner> Planner { get; set; }


    }
}
