using Application.Appliaction.Domain.Entities;
using Application.Application.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<ColaboradorEquipe> ColaboradorEquipe { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<ProjetoHoras> ProjetoHoras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PerfilMapping());
            builder.ApplyConfiguration(new EquipeMapping());
            builder.ApplyConfiguration(new ColaboradorMapping());
            builder.ApplyConfiguration(new ProjetoMapping());
        }
    }
}
