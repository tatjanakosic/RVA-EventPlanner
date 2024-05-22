using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Migrations
{
    public partial class CreateUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true), // specify primary key
                    Username = c.String(nullable: false, maxLength: 50), // specify data type and max length
                    Password = c.String(nullable: false, maxLength: 100),
                    Name = c.String(nullable: false, maxLength: 100),
                    LastName = c.String(nullable: false, maxLength: 100),
                    IsAdmin = c.Boolean(nullable: false),
                    IsLogged = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id); // specify primary key
        }

        public override void Down()
        {
         
      
            DropTable("dbo.Users");
        
        }
    }
}
