namespace Services.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 15),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Address = c.String(),
                        NamedayDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
