namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingCandidatosModelNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Candidato", name: "CapacitacionId", newName: "CapacitacionesId");
            RenameColumn(table: "dbo.Candidato", name: "PuestoId", newName: "PuestosId");
            RenameColumn(table: "dbo.Candidato", name: "ExperienciaId", newName: "ExperienciasId");
            RenameIndex(table: "dbo.Candidato", name: "IX_PuestoId", newName: "IX_PuestosId");
            RenameIndex(table: "dbo.Candidato", name: "IX_CapacitacionId", newName: "IX_CapacitacionesId");
            RenameIndex(table: "dbo.Candidato", name: "IX_ExperienciaId", newName: "IX_ExperienciasId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Candidato", name: "IX_ExperienciasId", newName: "IX_ExperienciaId");
            RenameIndex(table: "dbo.Candidato", name: "IX_CapacitacionesId", newName: "IX_CapacitacionId");
            RenameIndex(table: "dbo.Candidato", name: "IX_PuestosId", newName: "IX_PuestoId");
            RenameColumn(table: "dbo.Candidato", name: "ExperienciasId", newName: "ExperienciaId");
            RenameColumn(table: "dbo.Candidato", name: "PuestosId", newName: "PuestoId");
            RenameColumn(table: "dbo.Candidato", name: "CapacitacionesId", newName: "CapacitacionId");
        }
    }
}
