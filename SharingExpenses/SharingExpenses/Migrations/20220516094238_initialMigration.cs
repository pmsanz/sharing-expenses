using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharingExpenses.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SharingExpenses");

            migrationBuilder.EnsureSchema(
                name: "Config");

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "SharingExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalSchema: "SharingExpenses",
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                schema: "SharingExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalSchema: "SharingExpenses",
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Config",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "SharingExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<int>(type: "int", nullable: false),
                    ToUserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    GroupsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalSchema: "SharingExpenses",
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_User_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "Config",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_User_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "Config",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_GroupsId",
                schema: "SharingExpenses",
                table: "Expenses",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_OwnerId",
                schema: "SharingExpenses",
                table: "Expenses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FromUserId",
                schema: "SharingExpenses",
                table: "Payments",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GroupsId",
                schema: "SharingExpenses",
                table: "Payments",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ToUserId",
                schema: "SharingExpenses",
                table: "Payments",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupsId",
                schema: "Config",
                table: "User",
                column: "GroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses",
                schema: "SharingExpenses");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "SharingExpenses");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "SharingExpenses");
        }
    }
}
