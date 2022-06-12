using Microsoft.EntityFrameworkCore.Migrations;

namespace DBLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pokemones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<int>(type: "int", nullable: false),
                    TipoPrimario = table.Column<int>(type: "int", nullable: false),
                    TipoSecundario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pokemones_Regiones_Region",
                        column: x => x.Region,
                        principalTable: "Regiones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_TipoPrimario",
                        column: x => x.TipoPrimario,
                        principalTable: "Tipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_TipoSecundario",
                        column: x => x.TipoSecundario,
                        principalTable: "Tipos",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_Region",
                table: "Pokemones",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_TipoPrimario",
                table: "Pokemones",
                column: "TipoPrimario");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_TipoSecundario",
                table: "Pokemones",
                column: "TipoSecundario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemones");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
