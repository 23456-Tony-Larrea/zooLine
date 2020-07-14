using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zooLine.Migrations
{
    public partial class InicioUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    NombreCientifico = table.Column<string>(nullable: true),
                    año_nacimiento = table.Column<int>(nullable: false),
                    año_muerte = table.Column<int>(nullable: false),
                    estatura = table.Column<decimal>(nullable: false),
                    ancho = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    segundoNombre = table.Column<string>(nullable: true),
                    primerApellido = table.Column<string>(nullable: true),
                    segundoApellido = table.Column<string>(nullable: true),
                    CI = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    contraseña = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
