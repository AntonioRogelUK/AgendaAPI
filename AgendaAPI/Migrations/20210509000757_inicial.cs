using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaAPI.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCaptura = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    TelefonoParticular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    TelefonoCelular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ContactoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_Email",
                table: "Contactos",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactos");
        }
    }
}
