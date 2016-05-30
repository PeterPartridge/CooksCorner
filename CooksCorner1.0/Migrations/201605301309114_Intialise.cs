namespace CooksCorner1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intialise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        comment = c.String(),
                        RecipeId = c.Int(nullable: false),
                        MessageTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecipeModels", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.RecipeModels",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Ingrediants = c.String(),
                        Instructions = c.String(),
                        PrepTimeMins = c.Int(nullable: false),
                        PrepTimeHours = c.Int(nullable: false),
                        CookingTimeHours = c.Int(nullable: false),
                        CookingTimeMins = c.Int(nullable: false),
                        CusineId = c.Int(nullable: false),
                        DiffcultyId = c.Int(nullable: false),
                        AuthorName = c.String(),
                        Blurb = c.String(),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Cuisine_Type", t => t.CusineId, cascadeDelete: true)
                .ForeignKey("dbo.DiffcultyModels", t => t.DiffcultyId, cascadeDelete: true)
                .Index(t => t.CusineId)
                .Index(t => t.DiffcultyId);
            
            CreateTable(
                "dbo.Cuisine_Type",
                c => new
                    {
                        CusineId = c.Int(nullable: false, identity: true),
                        type_of_Cusine = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CusineId);
            
            CreateTable(
                "dbo.DiffcultyModels",
                c => new
                    {
                        DiffcultyId = c.Int(nullable: false, identity: true),
                        Diffculty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiffcultyId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.RecipeModels", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Files", "RecipeId", "dbo.RecipeModels");
            DropForeignKey("dbo.RecipeModels", "DiffcultyId", "dbo.DiffcultyModels");
            DropForeignKey("dbo.RecipeModels", "CusineId", "dbo.Cuisine_Type");
            DropForeignKey("dbo.CommentModels", "RecipeId", "dbo.RecipeModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Files", new[] { "RecipeId" });
            DropIndex("dbo.RecipeModels", new[] { "DiffcultyId" });
            DropIndex("dbo.RecipeModels", new[] { "CusineId" });
            DropIndex("dbo.CommentModels", new[] { "RecipeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Files");
            DropTable("dbo.DiffcultyModels");
            DropTable("dbo.Cuisine_Type");
            DropTable("dbo.RecipeModels");
            DropTable("dbo.CommentModels");
        }
    }
}
