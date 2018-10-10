namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingEmpleadoModelandController : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleado", "DepartamentosId", "dbo.Departamento");
            DropIndex("dbo.Empleado", new[] { "DepartamentosId" });
            DropColumn("dbo.Empleado", "DepartamentosId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleado", "DepartamentosId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleado", "DepartamentosId");
            AddForeignKey("dbo.Empleado", "DepartamentosId", "dbo.Departamento", "Id", cascadeDelete: true);
        }
    }
}
