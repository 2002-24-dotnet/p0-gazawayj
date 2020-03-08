using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192627959578321L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192627959627191L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192627959627290L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192627959645301L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192627959645368L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192627959645376L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192627959646864L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192627959646917L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192627959646924L);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192655634319521L, "Thin Crust", 2.00m },
                    { 637192655634365108L, "New York Style", 3.00m },
                    { 637192655634365182L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192655634382883L, "Small", 10.00m },
                    { 637192655634382943L, "Medium", 12.00m },
                    { 637192655634382950L, "Large", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192655634383717L, "Cheese", 0.25m },
                    { 637192655634383754L, "Pepperoni", 0.75m },
                    { 637192655634383760L, "Sauce", 0.55m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192655634319521L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192655634365108L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192655634365182L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192655634382883L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192655634382943L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192655634382950L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192655634383717L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192655634383754L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192655634383760L);

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192627959578321L, "Thin Crust", 2.00m },
                    { 637192627959627191L, "New York Style", 3.00m },
                    { 637192627959627290L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192627959645301L, "Small", 10.00m },
                    { 637192627959645368L, "Medium", 12.00m },
                    { 637192627959645376L, "Large", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192627959646864L, "Cheese", 0.25m },
                    { 637192627959646917L, "Pepperoni", 0.75m },
                    { 637192627959646924L, "Sauce", 0.55m }
                });
        }
    }
}
