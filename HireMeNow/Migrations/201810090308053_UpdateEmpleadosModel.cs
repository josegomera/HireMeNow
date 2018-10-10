namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmpleadosModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleado", "PuestosId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleado", "PuestosId");
            AddForeignKey("dbo.Empleado", "PuestosId", "dbo.Puesto", "Id", cascadeDelete: false);
            DropColumn("dbo.Empleado", "Puesto");
            DropColumn("dbo.Empleado", "Departamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleado", "Departamento", c => c.String(maxLength: 50));
            AddColumn("dbo.Empleado", "Puesto", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Empleado", "PuestosId", "dbo.Puesto");
            DropIndex("dbo.Empleado", new[] { "PuestosId" });
            DropColumn("dbo.Empleado", "PuestosId");
        }
    }
}
