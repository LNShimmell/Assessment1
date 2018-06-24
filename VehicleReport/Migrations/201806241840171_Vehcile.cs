namespace VehicleReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vehcile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehciles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehciles", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Vehciles", new[] { "OwnerId" });
            DropTable("dbo.Vehciles");
        }
    }
}
