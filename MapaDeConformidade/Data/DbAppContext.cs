using MapaDeConformidade.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaDeConformidade.Data
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options) { }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<CategoriaRequisito> CategoriasRequisitos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<RequisitoRegulatorio> RequisitosRegulatorios { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
    }
}