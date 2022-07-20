﻿// <auto-generated />
using CatalogoEmprego.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatalogoEmprego.Migrations
{
    [DbContext(typeof(CatalogoContexto))]
    partial class CatalogoContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CatalogoEmprego.Models.Curriculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CursosComplementares")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ExperienciaProfissional")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Formacao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Curriculos");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EnderecoCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Empresaid")
                        .HasColumnType("int");

                    b.Property<string>("Especificacoes")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NumeroVagas")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Salario")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("TipoVaga")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Empresaid");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Curriculo", b =>
                {
                    b.HasOne("CatalogoEmprego.Models.Usuario", "Usuario")
                        .WithOne("Curriculo")
                        .HasForeignKey("CatalogoEmprego.Models.Curriculo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Empresa", b =>
                {
                    b.HasOne("CatalogoEmprego.Models.Usuario", "Usuario")
                        .WithMany("Empresas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Vaga", b =>
                {
                    b.HasOne("CatalogoEmprego.Models.Empresa", "Empresa")
                        .WithMany("Vagas")
                        .HasForeignKey("Empresaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Empresa", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("CatalogoEmprego.Models.Usuario", b =>
                {
                    b.Navigation("Curriculo");

                    b.Navigation("Empresas");
                });
#pragma warning restore 612, 618
        }
    }
}
