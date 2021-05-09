﻿// <auto-generated />
using System;
using AgendaAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgendaAPI.Migrations
{
    [DbContext(typeof(AgendaDbContext))]
    [Migration("20210509010022_Comentarios")]
    partial class Comentarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgendaAPI.Entities.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactoId")
                        .HasColumnType("int");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("ComentarioId");

                    b.HasIndex("ContactoId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("AgendaAPI.Entities.Contacto", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("FechaCaptura")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("TelefonoCelular")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TelefonoParticular")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("ContactoId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("AgendaAPI.Entities.Comentario", b =>
                {
                    b.HasOne("AgendaAPI.Entities.Contacto", "Contacto")
                        .WithMany("Comentarios")
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");
                });

            modelBuilder.Entity("AgendaAPI.Entities.Contacto", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}