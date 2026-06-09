using Microsoft.EntityFrameworkCore;
using Aegis.Api.Models;
using Aegis.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aegis.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Satelite> Satelites { get; set; }
        public DbSet<DetritoEspacial> Detritos { get; set; }
        public DbSet<Chaser> Chasers { get; set; }
        public DbSet<AlertaColisao> AlertasColisao { get; set; }
        public DbSet<MissaoInterceptacao> Missoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Aplica seus mappings manuais (se existirem)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            // 2. CONFIGURAÇÃO GLOBAL PARA ORACLE 11g
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Desativa IDENTITY para todos os IDs (evita ORA-02000)
                var idProperty = entityType.FindProperty("Id");
                if (idProperty != null)
                {
                    idProperty.ValueGenerated = ValueGenerated.Never;
                }

                // Corrige precisão de todos os decimais (evita warnings)
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal))
                    {
                        property.SetPrecision(18);
                        property.SetScale(2);
                    }
                }
            }
        }
    }
}