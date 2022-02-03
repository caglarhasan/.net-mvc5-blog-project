namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingNewPropertyForAuthors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "AuthorAboutShort", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "AuthorMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "Password", c => c.String(maxLength: 50));
            AddColumn("dbo.Authors", "PhoneNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "PhoneNumber");
            DropColumn("dbo.Authors", "Password");
            DropColumn("dbo.Authors", "AuthorMail");
            DropColumn("dbo.Authors", "AuthorAboutShort");
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
