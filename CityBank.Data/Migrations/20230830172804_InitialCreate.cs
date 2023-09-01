using Microsoft.EntityFrameworkCore.Migrations;

namespace CityBank.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Age = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountsInfo",
                columns: table => new
                {
                    AccountNumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalBalance = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    AccountType = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__BE2ACD6EDA9AC85A", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK__AccountsI__Custo__2B3F6F97",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsInfo_CustomerID",
                table: "AccountsInfo",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsInfo");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
