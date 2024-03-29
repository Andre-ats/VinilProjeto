﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VinilProjeto.Repository;

#nullable disable

namespace VinilProjeto.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240327155414_migracao0001")]
    partial class migracao0001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("UsuarioComprador", (string)null);
                });

            modelBuilder.Entity("VinilProjeto.Entity.VinilVenda.Vinil", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("StatusVinil")
                        .HasColumnType("integer");

                    b.Property<string>("descricaoVinil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("estiloMusical")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("EstiloMusical");

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

            modelBuilder.Entity("VinilProjeto.Entity.VinilVenda.VinilImagem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("hashName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("vinilId")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("vinilId");

                    b.ToTable("VinilImagem", (string)null);
                });

            modelBuilder.Entity("VinilProjeto.Entity.Usuario.UsuarioComprador", b =>
                {
                    b.OwnsOne("VinilProjeto.ValueObject.Endereco.Endereco", "endereco", b1 =>
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

                    b.OwnsOne("VinilProjeto.ValueObject.Telefone.Telefone", "telefone", b1 =>
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

            modelBuilder.Entity("VinilProjeto.Entity.VinilVenda.VinilImagem", b =>
                {
                    b.HasOne("VinilProjeto.Entity.VinilVenda.Vinil", null)
                        .WithMany("VinilImagem")
                        .HasForeignKey("vinilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VinilProjeto.Entity.VinilVenda.Vinil", b =>
                {
                    b.Navigation("VinilImagem");
                });
#pragma warning restore 612, 618
        }
    }
}
