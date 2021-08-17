using Application.Appliaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Application.Application.Infrastructure.Mapping
{
    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Descricao).HasMaxLength(50).IsRequired();
            builder.HasData(
                new Projeto
                {
                    Id = Guid.Parse("C286CAD8-6681-4A89-BEF6-BF3C0097D9A7"),
                    Descricao = "Projeto Teste 01"
                },
                new Projeto
                {
                    Id = Guid.Parse("50953752-09B2-41E5-9B3E-52477CF45AEA"),
                    Descricao = "Projeto Teste 02"
                });
        }
    }
}
