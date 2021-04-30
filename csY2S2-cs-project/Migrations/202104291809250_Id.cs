namespace csY2S2_cs_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Id : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
