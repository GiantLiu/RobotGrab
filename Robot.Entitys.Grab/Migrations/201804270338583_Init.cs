namespace Robot.Entitys.Grab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SearchData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaskGroup = c.Guid(nullable: false),
                        TaskID = c.Int(nullable: false),
                        SoruceID = c.Int(nullable: false),
                        Title = c.String(maxLength: 100),
                        SourceUrl = c.String(maxLength: 1000),
                        RealUrl = c.String(maxLength: 1000),
                        Content = c.String(maxLength: 2000),
                        CreateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SearchTask",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaskGroup = c.Guid(nullable: false),
                        SourceID = c.Int(nullable: false),
                        Keyword = c.String(maxLength: 100),
                        CreateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Source",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        Code = c.String(maxLength: 100),
                        Home = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Source");
            DropTable("dbo.SearchTask");
            DropTable("dbo.SearchData");
            DropTable("dbo.Category");
        }
    }
}
