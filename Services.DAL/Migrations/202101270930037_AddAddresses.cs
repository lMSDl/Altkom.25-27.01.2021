namespace Services.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "Address_Id", c => c.Int());
            CreateIndex("dbo.People", "Address_Id");
            AddForeignKey("dbo.People", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropColumn("dbo.People", "Address_Id");
            DropTable("dbo.Addresses");
        }
    }
}
