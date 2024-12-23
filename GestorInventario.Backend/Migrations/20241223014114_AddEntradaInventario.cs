using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorInventario.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddEntradaInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_proveedores",
                table: "proveedores");

            migrationBuilder.RenameTable(
                name: "proveedores",
                newName: "Proveedor");

            migrationBuilder.RenameIndex(
                name: "IX_proveedores_nombre",
                table: "Proveedor",
                newName: "IX_Proveedor_nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "ID_Proveedor");

            migrationBuilder.CreateTable(
                name: "Entrada_Inventario",
                columns: table => new
                {
                    ID_Entrada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ID_Producto = table.Column<int>(type: "int", nullable: false),
                    ID_Proveedor = table.Column<int>(type: "int", nullable: false),
                    productosIdProducto = table.Column<int>(type: "int", nullable: false),
                    proveedoresID_Proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada_Inventario", x => x.ID_Entrada);
                    table.ForeignKey(
                        name: "FK_Entrada_Inventario_Productos_productosIdProducto",
                        column: x => x.productosIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Inventario_Proveedor_proveedoresID_Proveedor",
                        column: x => x.proveedoresID_Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "ID_Proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Inventario_Cantidad",
                table: "Entrada_Inventario",
                column: "Cantidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Inventario_productosIdProducto",
                table: "Entrada_Inventario",
                column: "productosIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Inventario_proveedoresID_Proveedor",
                table: "Entrada_Inventario",
                column: "proveedoresID_Proveedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada_Inventario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "proveedores");

            migrationBuilder.RenameIndex(
                name: "IX_Proveedor_nombre",
                table: "proveedores",
                newName: "IX_proveedores_nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proveedores",
                table: "proveedores",
                column: "ID_Proveedor");
        }
    }
}
