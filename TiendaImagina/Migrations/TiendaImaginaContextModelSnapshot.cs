﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaImagina.Models;

namespace TiendaImagina.Migrations
{
    [DbContext(typeof(TiendaImaginaContext))]
    partial class TiendaImaginaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TiendaImagina.Models.Categoria", b =>
                {
                    b.Property<long>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nombre");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("TiendaImagina.Models.Comentario", b =>
                {
                    b.Property<long>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("NombreUsuario");

                    b.Property<long>("ProductoId");

                    b.Property<string>("Texto");

                    b.HasKey("ComentarioId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("TiendaImagina.Models.Producto", b =>
                {
                    b.Property<long>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoriaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nombre");

                    b.Property<decimal>("Precio");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("TiendaImagina.Models.Comentario", b =>
                {
                    b.HasOne("TiendaImagina.Models.Producto", "Producto")
                        .WithMany("Comentarios")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TiendaImagina.Models.Producto", b =>
                {
                    b.HasOne("TiendaImagina.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
