using Common.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Migrations
{
    public partial class CreatePlannerTable : DbMigration
    {

        public override void Up()
        {
            CreateTable(
                "dbo.Planners",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 100), // specify primary key
                    //Events = c., // specify a navigation property for the Events collection
                })
                .PrimaryKey(t => t.Id); // specify primary key
        }

    }


}
