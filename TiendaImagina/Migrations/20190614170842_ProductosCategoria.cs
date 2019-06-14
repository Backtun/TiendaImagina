using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaImagina.Migrations
{
    public partial class ProductosCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Producto",
                newName: "ProductoId");

            migrationBuilder.AddColumn<long>(
                name: "CategoriaId",
                table: "Producto",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_CategoriaId",
                table: "Producto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_CategoriaId",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "Producto",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Producto",
                nullable: true);
        }
    }
}
