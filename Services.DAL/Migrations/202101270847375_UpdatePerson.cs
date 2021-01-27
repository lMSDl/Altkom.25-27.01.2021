namespace Services.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePerson : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Address");
            DropColumn("dbo.People", "NamedayDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "NamedayDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "Address", c => c.String());
        }
    }
}
