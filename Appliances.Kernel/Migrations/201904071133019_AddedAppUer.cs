namespace Appliances.Kernel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class AddedAppUer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ryan.AppUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailId = c.String(),
                        PhoneNo = c.String(),
                        Password = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        LastModifiedOn = c.DateTime(nullable: false),
                        LastModifiedBy = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("ryan.EXHIBITORADDRESS", "Location", c => c.Geography());
            DropColumn("ryan.EXHIBITORADDRESS", "Longitude");
            DropColumn("ryan.EXHIBITORADDRESS", "Latitude");
        }
        
        public override void Down()
        {
            AddColumn("ryan.EXHIBITORADDRESS", "Latitude", c => c.String());
            AddColumn("ryan.EXHIBITORADDRESS", "Longitude", c => c.String());
            DropColumn("ryan.EXHIBITORADDRESS", "Location");
            DropTable("ryan.AppUsers");
        }
    }
}
