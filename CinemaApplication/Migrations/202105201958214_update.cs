namespace CinemaApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.movies", "salle_id", "dbo.Salles");
            DropIndex("dbo.movies", new[] { "salle_id" });
            RenameColumn(table: "dbo.movies", name: "salle_id", newName: "salleId");
            AlterColumn("dbo.movies", "salleId", c => c.Int(nullable: false));
            CreateIndex("dbo.movies", "salleId");
            AddForeignKey("dbo.movies", "salleId", "dbo.Salles", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.movies", "salleId", "dbo.Salles");
            DropIndex("dbo.movies", new[] { "salleId" });
            AlterColumn("dbo.movies", "salleId", c => c.Int());
            RenameColumn(table: "dbo.movies", name: "salleId", newName: "salle_id");
            CreateIndex("dbo.movies", "salle_id");
            AddForeignKey("dbo.movies", "salle_id", "dbo.Salles", "id");
        }
    }
}
