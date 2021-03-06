// <auto-generated />
using System;
using Application.Application.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210815212234_ColaboradorEquipe")]
    partial class ColaboradorEquipe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Colaborador", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.ColaboradorEquipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColaboradorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("EquipeId");

                    b.ToTable("ColaboradorEquipe");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Equipe", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PerfilEnum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Perfil");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e94483d3-d719-4d51-9d7c-0b1ad0bcfeff"),
                            Descricao = "Colaborador",
                            PerfilEnum = 0
                        },
                        new
                        {
                            Id = new Guid("4fffc135-ccc8-412e-9505-192bc6bd1cca"),
                            Descricao = "Gestor",
                            PerfilEnum = 1
                        });
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Colaborador", b =>
                {
                    b.HasOne("Application.Appliaction.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Colaborador")
                        .HasForeignKey("PerfilId")
                        .HasConstraintName("FK_Colaborador_Perfil_PerfilId")
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.ColaboradorEquipe", b =>
                {
                    b.HasOne("Application.Appliaction.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany("ColaboradorEquipes")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Appliaction.Domain.Entities.Equipe", "Equipe")
                        .WithMany("ColaboradorEquipes")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Colaborador", b =>
                {
                    b.Navigation("ColaboradorEquipes");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Equipe", b =>
                {
                    b.Navigation("ColaboradorEquipes");
                });

            modelBuilder.Entity("Application.Appliaction.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("Colaborador");
                });
#pragma warning restore 612, 618
        }
    }
}
