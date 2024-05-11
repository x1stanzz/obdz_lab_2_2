namespace lab_2_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublisherName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Name", c => c.String());
            AddColumn("dbo.Publishers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "Name");
            DropColumn("dbo.Genres", "Name");
        }
    }
}
