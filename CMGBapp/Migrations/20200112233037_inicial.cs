using Microsoft.EntityFrameworkCore.Migrations;

namespace CMGBapp.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(21,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensDoPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoID = table.Column<int>(nullable: false),
                    ProdutoID = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensDoPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensDoPedidos_Pedidos_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensDoPedidos_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoPedidos_PedidoID",
                table: "ItensDoPedidos",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_ItensDoPedidos_ProdutoID",
                table: "ItensDoPedidos",
                column: "ProdutoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensDoPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
