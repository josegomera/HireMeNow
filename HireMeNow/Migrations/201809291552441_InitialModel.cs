namespace HireMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 11),
                        Nombres = c.String(nullable: false, maxLength: 100),
                        Apellidos = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PuestoId = c.Int(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CapacitacionId = c.Int(nullable: false),
                        ExperienciaId = c.Int(nullable: false),
                        RecomendadoPor = c.String(maxLength: 60),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Capacitacion", t => t.CapacitacionId, cascadeDelete: true)
                .ForeignKey("dbo.ExperienciaLaboral", t => t.ExperienciaId, cascadeDelete: true)
                .ForeignKey("dbo.Puesto", t => t.PuestoId, cascadeDelete: false)
                .Index(t => t.PuestoId)
                .Index(t => t.CapacitacionId)
                .Index(t => t.ExperienciaId);
            
            CreateTable(
                "dbo.Capacitacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        NivelId = c.Int(nullable: false),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        Institucion = c.String(nullable: false, maxLength: 50),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nivel", t => t.NivelId, cascadeDelete: false)
                .Index(t => t.NivelId);
            
            CreateTable(
                "dbo.Nivel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 25),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperienciaLaboral",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Empresa = c.String(nullable: false, maxLength: 70),
                        PuestoOcupado = c.String(nullable: false, maxLength: 70),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Puesto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        NivelRiesgosId = c.Int(nullable: false),
                        CompetenciasId = c.Int(nullable: false),
                        DepartamentosId = c.Int(nullable: false),
                        SalarioMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalarioMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoId = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competencia", t => t.CompetenciasId, cascadeDelete: false)
                .ForeignKey("dbo.Departamento", t => t.DepartamentosId, cascadeDelete: false)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: false)
                .ForeignKey("dbo.NivelRiesgo", t => t.NivelRiesgosId, cascadeDelete: false)
                .Index(t => t.NivelRiesgosId)
                .Index(t => t.CompetenciasId)
                .Index(t => t.DepartamentosId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Competencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Descripcion = c.String(nullable: false, maxLength: 255),
                        IdiomasId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: false)
                .ForeignKey("dbo.Idioma", t => t.IdiomasId, cascadeDelete: false)
                .Index(t => t.IdiomasId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estados = c.String(maxLength: 10),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombres = c.String(maxLength: 100),
                        Apellidos = c.String(maxLength: 100),
                        Email = c.String(),
                        Puesto = c.String(maxLength: 50),
                        Departamento = c.String(maxLength: 50),
                        FechaIngreso = c.DateTime(nullable: false),
                        SalarioMensual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoId = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: false)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Idioma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 10),
                        EstadoId = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: false)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Departamentos = c.String(maxLength: 30),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NivelRiesgo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 6),
                        Creado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Puesto", "NivelRiesgosId", "dbo.NivelRiesgo");
            DropForeignKey("dbo.Puesto", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Puesto", "DepartamentosId", "dbo.Departamento");
            DropForeignKey("dbo.Puesto", "CompetenciasId", "dbo.Competencia");
            DropForeignKey("dbo.Idioma", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Competencia", "IdiomasId", "dbo.Idioma");
            DropForeignKey("dbo.Empleado", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Competencia", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Candidato", "PuestoId", "dbo.Puesto");
            DropForeignKey("dbo.Candidato", "ExperienciaId", "dbo.ExperienciaLaboral");
            DropForeignKey("dbo.Capacitacion", "NivelId", "dbo.Nivel");
            DropForeignKey("dbo.Candidato", "CapacitacionId", "dbo.Capacitacion");
            DropIndex("dbo.Idioma", new[] { "EstadoId" });
            DropIndex("dbo.Empleado", new[] { "EstadoId" });
            DropIndex("dbo.Competencia", new[] { "EstadoId" });
            DropIndex("dbo.Competencia", new[] { "IdiomasId" });
            DropIndex("dbo.Puesto", new[] { "EstadoId" });
            DropIndex("dbo.Puesto", new[] { "DepartamentosId" });
            DropIndex("dbo.Puesto", new[] { "CompetenciasId" });
            DropIndex("dbo.Puesto", new[] { "NivelRiesgosId" });
            DropIndex("dbo.Capacitacion", new[] { "NivelId" });
            DropIndex("dbo.Candidato", new[] { "ExperienciaId" });
            DropIndex("dbo.Candidato", new[] { "CapacitacionId" });
            DropIndex("dbo.Candidato", new[] { "PuestoId" });
            DropTable("dbo.NivelRiesgo");
            DropTable("dbo.Departamento");
            DropTable("dbo.Idioma");
            DropTable("dbo.Empleado");
            DropTable("dbo.Estado");
            DropTable("dbo.Competencia");
            DropTable("dbo.Puesto");
            DropTable("dbo.ExperienciaLaboral");
            DropTable("dbo.Nivel");
            DropTable("dbo.Capacitacion");
            DropTable("dbo.Candidato");
        }
    }
}
