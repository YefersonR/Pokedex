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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<int>(type: "int", nullable: false),
                    TipoPrimario = table.Column<int>(type: "int", nullable: false),
                    TipoSecundario = table.Column<int>(type: "int", nullable: false),
                    IdRegion = table.Column<int>(type: "int", nullable: false),
                    IdTipos = table.Column<int>(type: "int", nullable: false),
                    NavigationTipoPrimarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pokemones_Regiones_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Regiones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_IdTipos",
                        column: x => x.IdTipos,
                        principalTable: "Tipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_NavigationTipoPrimarioID",
                        column: x => x.NavigationTipoPrimarioID,
                        principalTable: "Tipos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IdRegion",
                table: "Pokemones",
                column: "IdRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IdTipos",
                table: "Pokemones",
                column: "IdTipos");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_NavigationTipoPrimarioID",
                table: "Pokemones",
                column: "NavigationTipoPrimarioID");
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
