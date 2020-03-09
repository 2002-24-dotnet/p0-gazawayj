using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637193588579145321L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637193588579147128L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637193588579147202L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637193588579148213L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637193588579148266L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637193588579148273L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637193588579072962L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637193588579121430L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637193588579149132L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637193588579149179L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637193588579149186L);

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637193591486547947L, "Thin Crust", 2.00m },
                    { 637193591486549515L, "New York Style", 3.00m },
                    { 637193591486549574L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637193591486550941L, "Small", 10.00m },
                    { 637193591486550990L, "Medium", 12.00m },
                    { 637193591486550997L, "Large", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Phone", "StoreName" },
                values: new object[,]
                {
                    { 637193591486484061L, "501 Main St, Fake_City, Fake_State, 90210", "1900pizzapls", "Jim's Pizza #1" },
                    { 637193591486526324L, "2435 W 57th Ave, Fake_City, Fake_State, 90210", "1900pizzanow", "Jim's Pizza #32" }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637193591486552007L, "Cheese", 0.25m },
                    { 637193591486552057L, "Pepperoni", 0.75m },
                    { 637193591486552063L, "Sauce", 0.55m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637193591486547947L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637193591486549515L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "Id",
                keyValue: 637193591486549574L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637193591486550941L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637193591486550990L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 637193591486550997L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637193591486484061L);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreId",
                keyValue: 637193591486526324L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637193591486552007L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637193591486552057L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "Id",
                keyValue: 637193591486552063L);

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637193588579145321L, "Thin Crust", 2.00m },
                    { 637193588579147128L, "New York Style", 3.00m },
                    { 637193588579147202L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637193588579148213L, "Small", 10.00m },
                    { 637193588579148266L, "Medium", 12.00m },
                    { 637193588579148273L, "Large", 14.00m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Address", "Phone", "StoreName" },
                values: new object[,]
                {
                    { 637193588579072962L, "501 Main St, Fake_City, Fake_State, 90210", "1900pizzapls", "Jim's Pizza #1" },
                    { 637193588579121430L, "2435 W 57th Ave, Fake_City, Fake_State, 90210", "1900pizzanow", "Jim's Pizza #32" }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637193588579149132L, "Cheese", 0.25m },
                    { 637193588579149179L, "Pepperoni", 0.75m },
                    { 637193588579149186L, "Sauce", 0.55m }
                });
        }
    }
}
