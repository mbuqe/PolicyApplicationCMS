namespace PolicyApplicationCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        QuotationID = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Pre_existing_Conditions = c.String(),
                        NumberofDepandents = c.Int(),
                        SpouseAge = c.Int(),
                        CoverAmount = c.Decimal(precision: 18, scale: 2),
                        Premium = c.Decimal(precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.QuotationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quotations");
        }
    }
}
