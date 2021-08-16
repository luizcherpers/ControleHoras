using Application.Appliaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Application.Infrastructure.Mapping
{
    public class ColaboradorEquipeMapping : IEntityTypeConfiguration<ColaboradorEquipe>
    {
        public void Configure(EntityTypeBuilder<ColaboradorEquipe> builder)
        {
            builder.ToTable("ColaboradorEquipe");
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasOne(c => c.Colaborador)
                .WithMany(b => b.ColaboradorEquipes)
                 .HasForeignKey(c => c.ColaboradorId);

            builder.HasOne(c => c.Equipe)
                .WithMany(b => b.ColaboradorEquipes)
                 .HasForeignKey(c => c.EquipeId);
        }
    }
}
