namespace CinemaApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSalle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salles", "movie_id", "dbo.movies");
            DropIndex("dbo.Salles", new[] { "movie_id" });
            AddColumn("dbo.movies", "salle_id", c => c.Int());
            CreateIndex("dbo.movies", "salle_id");
            AddForeignKey("dbo.movies", "salle_id", "dbo.Salles", "id");
            DropColumn("dbo.Salles", "movie_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salles", "movie_id", c => c.Int());
            DropForeignKey("dbo.movies", "salle_id", "dbo.Salles");
            DropIndex("dbo.movies", new[] { "salle_id" });
            DropColumn("dbo.movies", "salle_id");
            CreateIndex("dbo.Salles", "movie_id");
            AddForeignKey("dbo.Salles", "movie_id", "dbo.movies", "id");
        }
    }
}
