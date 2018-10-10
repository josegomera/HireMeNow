namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingEmpleadosModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empleado", "Creado", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleado", "Creado", c => c.DateTime(nullable: false));
        }
    }
}
