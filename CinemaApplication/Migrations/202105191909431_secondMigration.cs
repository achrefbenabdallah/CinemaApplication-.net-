namespace CinemaApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.factures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        somme = c.Single(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.LigneCommandes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantite = c.Int(nullable: false),
                        movies_id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.movies", t => t.movies_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.movies_id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        disponibilite = c.Boolean(nullable: false),
                        date = c.DateTime(nullable: false),
                        prix = c.Single(nullable: false),
                        pays = c.String(),
                        duree = c.Single(nullable: false),
                        underAge = c.Int(nullable: false),
                        annee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        NbPlaces = c.Int(nullable: false),
                        movie_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.movies", t => t.movie_id)
                .Index(t => t.movie_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salles", "movie_id", "dbo.movies");
            DropForeignKey("dbo.LigneCommandes", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LigneCommandes", "movies_id", "dbo.movies");
            DropForeignKey("dbo.factures", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Salles", new[] { "movie_id" });
            DropIndex("dbo.LigneCommandes", new[] { "user_Id" });
            DropIndex("dbo.LigneCommandes", new[] { "movies_id" });
            DropIndex("dbo.factures", new[] { "user_Id" });
            DropTable("dbo.Salles");
            DropTable("dbo.movies");
            DropTable("dbo.LigneCommandes");
            DropTable("dbo.factures");
        }
    }
}
