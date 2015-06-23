namespace MeghanGroceryList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroceryItems");
        }
    }
}
