namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingModelsDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleado", "DepartamentosId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleado", "DepartamentosId");
            AddForeignKey("dbo.Empleado", "DepartamentosId", "dbo.Departamento", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleado", "DepartamentosId", "dbo.Departamento");
            DropIndex("dbo.Empleado", new[] { "DepartamentosId" });
            DropColumn("dbo.Empleado", "DepartamentosId");
        }
    }
}
