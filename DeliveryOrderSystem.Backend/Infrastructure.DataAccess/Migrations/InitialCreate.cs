using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations;

public partial class InitialCreate: Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Orders",
            schema: "public",
            columns: table => new
            {
                OrderId = table.Column<string>(nullable: false),
                SenderCity = table.Column<string>(maxLength: 100, nullable: false),
                SenderAddress = table.Column<string>(maxLength: 200, nullable: false),
                ReceiverCity = table.Column<string>(maxLength: 100, nullable: false),
                ReceiverAddress = table.Column<string>(maxLength: 200, nullable: false),
                Weight = table.Column<double>(nullable: false),
                PickupDate = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.OrderId);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Orders");
    }
}