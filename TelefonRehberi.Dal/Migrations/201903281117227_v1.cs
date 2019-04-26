namespace TelefonRehberi.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calisan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Soyad = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        YoneticiBilgisiId = c.Int(),
                        DepartmanId = c.Int(nullable: false),
                        Ad = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        GuncellenmeTarihi = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departman", t => t.DepartmanId, cascadeDelete: true)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Departman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        GuncellenmeTarihi = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calisan", "DepartmanId", "dbo.Departman");
            DropIndex("dbo.Calisan", new[] { "DepartmanId" });
            DropTable("dbo.Departman");
            DropTable("dbo.Calisan");
        }
    }
}
