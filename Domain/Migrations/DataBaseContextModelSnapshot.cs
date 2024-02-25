﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VinilProjeto.Repository;

#nullable disable

namespace VinilProjeto.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VinilProjeto.Entity.Usuario.Admin", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("VinilProjeto.Entity.Usuario.UsuarioComprador", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("UsuarioComprador", (string)null);
                });

            modelBuilder.Entity("VinilProjeto.Entity.VinilVenda.Vinil", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("descricaoVinil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("estiloMusical")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<string>("nomeVinil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("precoVinil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("quantiaVinil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Vinil", (string)null);
                });

            modelBuilder.Entity("VinilProjeto.Entity.Usuario.UsuarioComprador", b =>
                {
                    b.OwnsOne("VinilProjeto.Entity.Usuario.Endereco.Endereco", "endereco", b1 =>
                        {
                            b1.Property<Guid>("UsuarioCompradorid")
                                .HasColumnType("uuid");

                            b1.Property<string>("bairro")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("cep")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("cidade")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("complemento")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("estado")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("logradouro")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("numero")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("referencia")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UsuarioCompradorid");

                            b1.ToTable("UsuarioComprador");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioCompradorid");
                        });

                    b.OwnsOne("VinilProjeto.Entity.Usuario.Telefone.Telefone", "telefone", b1 =>
                        {
                            b1.Property<Guid>("UsuarioCompradorid")
                                .HasColumnType("uuid");

                            b1.Property<string>("codigo")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ddd")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("numero")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UsuarioCompradorid");

                            b1.ToTable("UsuarioComprador");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioCompradorid");
                        });

                    b.Navigation("endereco")
                        .IsRequired();

                    b.Navigation("telefone")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
