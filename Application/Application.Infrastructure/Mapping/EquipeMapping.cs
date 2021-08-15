using Application.Appliaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Application.Infrastructure.Mapping
{
    public class EquipeMapping : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipe");
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Descricao).HasMaxLength(50).IsRequired();
        }
    }
}