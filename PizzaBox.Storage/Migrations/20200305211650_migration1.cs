using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustId = table.Column<long>(nullable: true),
                    SizeId = table.Column<long>(nullable: true),
                    ToppingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    CrustId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaId = table.Column<long>(nullable: true),
                    CrustType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.CrustId);
                    table.ForeignKey(
                        name: "FK_Crust_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaId = table.Column<long>(nullable: true),
                    PizzaSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Size_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaId = table.Column<long>(nullable: true),
                    ToppingName = table.Column<string>(nullable: true),
                    Prices = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingId);
                    table.ForeignKey(
                        name: "FK_Topping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "CrustId", "CrustType", "Name", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 637190182094169893L, null, "Thin Crust", null, 2.00m },
                    { 637190182094223048L, null, "New York Style", null, 3.00m },
                    { 637190182094223162L, null, "Deep Dish", null, 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "Name", "PizzaId", "PizzaSize", "Price" },
                values: new object[,]
                {
                    { 637190182094244019L, "Small", null, null, 10.00m },
                    { 637190182094244635L, "Medium", null, null, 12.00m },
                    { 637190182094244665L, "Large", null, null, 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingId", "Name", "PizzaId", "Price", "Prices", "ToppingName" },
                values: new object[,]
                {
                    { 637190182094246103L, "Cheese", null, 0m, 0m, null },
                    { 637190182094246644L, "Pepperoni", null, 0m, 0m, null },
                    { 637190182094246678L, "Sauce", null, 0m, 0m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crust_PizzaId",
                table: "Crust",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizza",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ToppingId",
                table: "Pizza",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_PizzaId",
                table: "Size",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_PizzaId",
                table: "Topping",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustId",
                table: "Pizza",
                column: "CrustId",
                principalTable: "Crust",
                principalColumn: "CrustId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Size_SizeId",
                table: "Pizza",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Topping_ToppingId",
                table: "Pizza",
                column: "ToppingId",
                principalTable: "Topping",
                principalColumn: "ToppingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crust_Pizza_PizzaId",
                table: "Crust");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_Pizza_PizzaId",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizza_PizzaId",
                table: "Topping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Topping");
        }
    }
}
