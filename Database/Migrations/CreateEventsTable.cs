using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Migrations
{
    //treba pozavti Add-Migration CreateEventsTable u package manager kozoli kako bi se tabela generisala
    public partial class CreateEventsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true), // specify primary key
                    Name = c.String(nullable: false, maxLength: 100), // specify data type and max length
                    Location = c.String(nullable: false, maxLength: 100),
                    Topic = c.String(nullable: false, maxLength: 100),
                    Date = c.DateTime(nullable: false),
                    StartTime = c.DateTime(nullable: false),
                    EndTime = c.DateTime(nullable: false),
                    Duration = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id); // specify primary key
        }

        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
