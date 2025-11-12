using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial3_Web.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Departamento = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreUsuario = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NombreCompleto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contactos",
                columns: new[] { "Id", "Activo", "Departamento", "Email", "FechaCreacion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, true, "Ventas", "juan@email.com", new DateTime(2025, 11, 12, 12, 4, 31, 343, DateTimeKind.Local).AddTicks(3198), "Juan Pérez", "555-0101" },
                    { 2, true, "Soporte", "maria@email.com", new DateTime(2025, 11, 12, 12, 4, 31, 343, DateTimeKind.Local).AddTicks(3201), "María García", "555-0102" },
                    { 3, true, "IT", "carlos@email.com", new DateTime(2025, 11, 12, 12, 4, 31, 343, DateTimeKind.Local).AddTicks(3203), "Carlos López", "555-0103" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "FechaCreacion", "NombreCompleto", "NombreUsuario", "Password" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 12, 12, 4, 31, 343, DateTimeKind.Local).AddTicks(3013), "Administrador del Sistema", "admin", "123456" },
                    { 2, true, new DateTime(2025, 11, 12, 12, 4, 31, 343, DateTimeKind.Local).AddTicks(3017), "Usuario Demo", "usuario", "password" },
                    { 3, true, new DateTime(2025, 11, 12, 12, 4, 31, 343, DateTimeKind.Local).AddTicks(3019), "Usuario de Demo", "demo", "demo123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
