namespace Appliances.Kernel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ryan.City",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CityName = c.String(),
                        ZipCode = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        State_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ryan.State", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "ryan.State",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StateName = c.String(),
                        StateCode = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ryan.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "ryan.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CountryName = c.String(),
                        CountryCode = c.String(),
                        CountryPhoneCode = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ryan.EXHIBITORADDRESS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PhoneNo = c.String(),
                        OfficeNo = c.String(),
                        ExhibitorName = c.String(),
                        EmailId = c.String(),
                        Longitude = c.String(),
                        Latitude = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        Country_Id = c.Guid(),
                        Exhibitor_Id = c.Guid(),
                        State_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ryan.Country", t => t.Country_Id)
                .ForeignKey("ryan.ExhibitorStores", t => t.Exhibitor_Id)
                .ForeignKey("ryan.State", t => t.State_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Exhibitor_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "ryan.ExhibitorStores",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        WebsiteURL = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ryan.ProductCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ryan.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        ModelNo = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        Weight = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        ProductCategory_Id = c.Guid(),
                        ProductSubCategory_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ryan.ProductCategory", t => t.ProductCategory_Id)
                .ForeignKey("ryan.ProductSubCategory", t => t.ProductSubCategory_Id)
                .Index(t => t.ProductCategory_Id)
                .Index(t => t.ProductSubCategory_Id);
            
            CreateTable(
                "ryan.ProductSubCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        BrandName = c.String(),
                        OperatingSystem = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        ProductCategory_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ryan.ProductCategory", t => t.ProductCategory_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "ryan.ProductCategoryExhibitorStores",
                c => new
                    {
                        ProductCategory_Id = c.Guid(nullable: false),
                        ExhibitorStore_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductCategory_Id, t.ExhibitorStore_Id })
                .ForeignKey("ryan.ProductCategory", t => t.ProductCategory_Id, cascadeDelete: true)
                .ForeignKey("ryan.ExhibitorStores", t => t.ExhibitorStore_Id, cascadeDelete: true)
                .Index(t => t.ProductCategory_Id)
                .Index(t => t.ExhibitorStore_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ryan.Products", "ProductSubCategory_Id", "ryan.ProductSubCategory");
            DropForeignKey("ryan.ProductSubCategory", "ProductCategory_Id", "ryan.ProductCategory");
            DropForeignKey("ryan.Products", "ProductCategory_Id", "ryan.ProductCategory");
            DropForeignKey("ryan.EXHIBITORADDRESS", "State_Id", "ryan.State");
            DropForeignKey("ryan.EXHIBITORADDRESS", "Exhibitor_Id", "ryan.ExhibitorStores");
            DropForeignKey("ryan.ProductCategoryExhibitorStores", "ExhibitorStore_Id", "ryan.ExhibitorStores");
            DropForeignKey("ryan.ProductCategoryExhibitorStores", "ProductCategory_Id", "ryan.ProductCategory");
            DropForeignKey("ryan.EXHIBITORADDRESS", "Country_Id", "ryan.Country");
            DropForeignKey("ryan.City", "State_Id", "ryan.State");
            DropForeignKey("ryan.State", "Country_Id", "ryan.Country");
            DropIndex("ryan.ProductCategoryExhibitorStores", new[] { "ExhibitorStore_Id" });
            DropIndex("ryan.ProductCategoryExhibitorStores", new[] { "ProductCategory_Id" });
            DropIndex("ryan.ProductSubCategory", new[] { "ProductCategory_Id" });
            DropIndex("ryan.Products", new[] { "ProductSubCategory_Id" });
            DropIndex("ryan.Products", new[] { "ProductCategory_Id" });
            DropIndex("ryan.EXHIBITORADDRESS", new[] { "State_Id" });
            DropIndex("ryan.EXHIBITORADDRESS", new[] { "Exhibitor_Id" });
            DropIndex("ryan.EXHIBITORADDRESS", new[] { "Country_Id" });
            DropIndex("ryan.State", new[] { "Country_Id" });
            DropIndex("ryan.City", new[] { "State_Id" });
            DropTable("ryan.ProductCategoryExhibitorStores");
            DropTable("ryan.ProductSubCategory");
            DropTable("ryan.Products");
            DropTable("ryan.ProductCategory");
            DropTable("ryan.ExhibitorStores");
            DropTable("ryan.EXHIBITORADDRESS");
            DropTable("ryan.Country");
            DropTable("ryan.State");
            DropTable("ryan.City");
        }
    }
}
