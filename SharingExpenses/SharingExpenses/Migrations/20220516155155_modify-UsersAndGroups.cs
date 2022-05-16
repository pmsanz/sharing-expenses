using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharingExpenses.Migrations
{
    public partial class modifyUsersAndGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Groups_GroupsId",
                schema: "SharingExpenses",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_User_OwnerId",
                schema: "SharingExpenses",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Groups_GroupsId",
                schema: "SharingExpenses",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_User_FromUserId",
                schema: "SharingExpenses",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_User_ToUserId",
                schema: "SharingExpenses",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Groups_GroupsId",
                schema: "Config",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_GroupsId",
                schema: "SharingExpenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "Config",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupsId",
                schema: "Config",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                schema: "SharingExpenses",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "GroupsId",
                schema: "Config",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "SharingExpenses",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Groups",
                schema: "SharingExpenses",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Expenses",
                schema: "SharingExpenses",
                newName: "Expenses");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Config",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "Payments",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Payments",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_GroupsId",
                table: "Payments",
                newName: "IX_Payments_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_FromUserId",
                table: "Payments",
                newName: "IX_Payments_GroupId");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GroupsUsers",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsUsers", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupsUsers_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_GroupId",
                table: "Expenses",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_UsersId",
                table: "GroupsUsers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Groups_GroupId",
                table: "Expenses",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_OwnerId",
                table: "Expenses",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Groups_GroupId",
                table: "Payments",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_ToUserId",
                table: "Payments",
                column: "ToUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UsersId",
                table: "Payments",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Groups_GroupId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_OwnerId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Groups_GroupId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_ToUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UsersId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "GroupsUsers");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_GroupId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Expenses");

            migrationBuilder.EnsureSchema(
                name: "SharingExpenses");

            migrationBuilder.EnsureSchema(
                name: "Config");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payments",
                newSchema: "SharingExpenses");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Groups",
                newSchema: "SharingExpenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expenses",
                newSchema: "SharingExpenses");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "Config");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                schema: "SharingExpenses",
                table: "Payments",
                newName: "GroupsId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                schema: "SharingExpenses",
                table: "Payments",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UsersId",
                schema: "SharingExpenses",
                table: "Payments",
                newName: "IX_Payments_GroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_GroupId",
                schema: "SharingExpenses",
                table: "Payments",
                newName: "IX_Payments_FromUserId");

            migrationBuilder.AddColumn<int>(
                name: "GroupsId",
                schema: "SharingExpenses",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupsId",
                schema: "Config",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "Config",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_GroupsId",
                schema: "SharingExpenses",
                table: "Expenses",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupsId",
                schema: "Config",
                table: "User",
                column: "GroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Groups_GroupsId",
                schema: "SharingExpenses",
                table: "Expenses",
                column: "GroupsId",
                principalSchema: "SharingExpenses",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_User_OwnerId",
                schema: "SharingExpenses",
                table: "Expenses",
                column: "OwnerId",
                principalSchema: "Config",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Groups_GroupsId",
                schema: "SharingExpenses",
                table: "Payments",
                column: "GroupsId",
                principalSchema: "SharingExpenses",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_User_FromUserId",
                schema: "SharingExpenses",
                table: "Payments",
                column: "FromUserId",
                principalSchema: "Config",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_User_ToUserId",
                schema: "SharingExpenses",
                table: "Payments",
                column: "ToUserId",
                principalSchema: "Config",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Groups_GroupsId",
                schema: "Config",
                table: "User",
                column: "GroupsId",
                principalSchema: "SharingExpenses",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
