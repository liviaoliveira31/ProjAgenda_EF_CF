namespace ProjAgenda_EF_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Telephone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Telephones");
        }
    }
}
