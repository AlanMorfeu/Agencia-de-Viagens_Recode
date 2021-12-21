using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTripTravel.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id_clientes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id_clientes);
                });

            migrationBuilder.CreateTable(
                name: "destinos",
                columns: table => new
                {
                    id_destinos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destino = table.Column<string>(nullable: true),
                    local_destino = table.Column<string>(nullable: true),
                    data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinos", x => x.id_destinos);
                });

            migrationBuilder.CreateTable(
                name: "promocoes",
                columns: table => new
                {
                    id_promocoes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_clientes = table.Column<int>(nullable: false),
                    id_destinos = table.Column<int>(nullable: false),
                    promocao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promocoes", x => x.id_promocoes);
                    table.ForeignKey(
                        name: "FK_promocoes_clientes_id_clientes",
                        column: x => x.id_clientes,
                        principalTable: "clientes",
                        principalColumn: "id_clientes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_promocoes_destinos_id_destinos",
                        column: x => x.id_destinos,
                        principalTable: "destinos",
                        principalColumn: "id_destinos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_promocoes_id_clientes",
                table: "promocoes",
                column: "id_clientes");

            migrationBuilder.CreateIndex(
                name: "IX_promocoes_id_destinos",
                table: "promocoes",
                column: "id_destinos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "promocoes");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "destinos");
        }
    }
}
