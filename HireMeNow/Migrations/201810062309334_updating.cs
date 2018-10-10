namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empleado", "Creado", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleado", "Creado", c => c.DateTime());
        }
    }
}
