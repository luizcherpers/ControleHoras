using Application.Appliaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Application.Infrastructure.Mapping
{
    public class ProjetoHorasMapping : IEntityTypeConfiguration<ProjetoHoras>
    {
        public void Configure(EntityTypeBuilder<ProjetoHoras> builder)
        {
            builder.ToTable("ProjetoHoras");
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasOne(c => c.Colaborador)
                .WithMany(b => b.ProjetoHoras)
                 .HasForeignKey(c => c.ColaboradorId);

            builder.HasOne(c => c.Projeto)
                .WithMany(b => b.ProjetoHoras)
                 .HasForeignKey(c => c.ProjetoId);
        }
    }
}
