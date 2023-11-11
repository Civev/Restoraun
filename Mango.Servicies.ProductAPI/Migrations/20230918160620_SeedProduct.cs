using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Servicies.ProductAPI.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Ladno", "https://www.gamberorossointernational.com/wp-content/uploads/2022/11/samosas.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "Ok", "https://i.pinimg.com/originals/ba/e6/81/bae681e42f19849474d825e5a0ca6f3f.jpg", "Paneer Tikka", 13.99 },
                    { 3, "Dessert", "Norm", "https://i.pinimg.com/originals/70/cd/54/70cd5435c438141df65542d33340f98e.jpg", "Sweet pie", 10.99 },
                    { 4, "Snacks", "lll", "https://storage.myseldon.com/news-pict-e7/E762CB007B23468FE0B8D7FD994EEEE2", "Shaurma", 5.5 },
                    { 5, "Alcochool", "Privet From Russia", "https://fikiwiki.com/uploads/posts/2022-02/1645022844_34-fikiwiki-com-p-kartinki-vodka-36.jpg", "Vodka", 1.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);
        }
    }
}
