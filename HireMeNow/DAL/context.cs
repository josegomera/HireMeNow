using HireMeNow.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HireMeNow.DAL
{
    public class Context : DbContext
    {
        public Context()
           : base("HireMeNow_v1")
        {
        }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<ExperienciaLaboral> ExpLaboral { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<NivelRiesgo> Riesgos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}