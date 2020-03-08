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
                keyValue: 637192821991058520L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192821991100140L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192821991100206L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192821991115993L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192821991116061L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192821991116068L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192821991116904L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192821991116944L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192821991116950L);

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192824338423016L, "Thin Crust", 2.00m },
                    { 637192824338463216L, "New York Style", 3.00m },
                    { 637192824338463282L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192824338478496L, "Small", 10.00m },
                    { 637192824338478654L, "Medium", 12.00m },
                    { 637192824338478661L, "Large", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192824338479415L, "Cheese", 0.25m },
                    { 637192824338479452L, "Pepperoni", 0.75m },
                    { 637192824338479458L, "Sauce", 0.55m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192824338423016L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192824338463216L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637192824338463282L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192824338478496L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192824338478654L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637192824338478661L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192824338479415L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192824338479452L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637192824338479458L);

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192821991058520L, "Thin Crust", 2.00m },
                    { 637192821991100140L, "New York Style", 3.00m },
                    { 637192821991100206L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192821991115993L, "Small", 10.00m },
                    { 637192821991116061L, "Medium", 12.00m },
                    { 637192821991116068L, "Large", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637192821991116904L, "Cheese", 0.25m },
                    { 637192821991116944L, "Pepperoni", 0.75m },
                    { 637192821991116950L, "Sauce", 0.55m }
                });
        }
    }
}
