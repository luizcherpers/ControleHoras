using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Enumerados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Application.Application.Infrastructure.Mapping
{
    public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(p => p.Descricao).HasMaxLength(50).IsRequired();

            builder.HasData(new Perfil
            {
                Id = Guid.Parse("E94483D3-D719-4D51-9D7C-0B1AD0BCFEFF"),
                Descricao = "Colaborador",
                PerfilEnum = PerfilEnum.Colaborador
            },
           new Perfil
           {
               Id = Guid.Parse("4FFFC135-CCC8-412E-9505-192BC6BD1CCA"),
               Descricao = "Gestor",
               PerfilEnum = PerfilEnum.Gestor
           });
        }
    }
}
