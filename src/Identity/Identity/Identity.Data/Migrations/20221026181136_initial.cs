using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleToPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleToPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleToPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleToPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("146cec9e-8b73-4ace-8597-56e17dbd58fd"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9617), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9617), "CanAssignParcelDeliveryOrderToCourier" },
                    { new Guid("2f80f676-5bf2-42ab-b1b0-5c3ee58a8440"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9619), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9620), "CanLogInCreateCourierAccount" },
                    { new Guid("66e21778-7449-4a51-b31a-60f767e2332c"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9624), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9625), "CanSeeListOfCouriers" },
                    { new Guid("81c2cd00-649e-4269-be67-ec4555e94ec8"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9602), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9611), "CanChangeTheStatusOfParcelDeliveryOrder" },
                    { new Guid("92e43e7c-7bbb-4fdb-be62-3a292c9f00e3"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9622), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9622), "CanTrackTheDeliveryOrderByCoordinates" },
                    { new Guid("c47303a3-bf51-4abc-9caf-9f45c0145f2b"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9614), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9615), "CanViewAllParcelDeliveryOrders" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1fb87710-b0b0-454a-840f-39ec216c7f56"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9802), "courier", new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9803), "courier" },
                    { new Guid("341c19e2-942b-46bd-9e7d-5e829aebb579"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9796), "user", new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9796), "user" },
                    { new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9793), "admin", new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9794), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "Email", "LastModifiedDate", "Name", "PasswordHash", "PhoneNumber", "Salt", "Surname", "Username" },
                values: new object[] { new Guid("bdc85dc6-f413-49c7-832e-e9e830c0956c"), "", new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9881), "admin@admin.com", new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9881), "admin", "cf8fc2e4bae67334abd0d47b85146a0d6475bfc20e6d2ffed6d8e77c24dba6ee", "", "237bbc92-567f-4d1b-87f9-8cf34b6f2d76", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "RoleToPermissions",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("237c0f00-6e0d-4580-a83d-8049ab194da1"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9831), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9832), new Guid("2f80f676-5bf2-42ab-b1b0-5c3ee58a8440"), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a") },
                    { new Guid("5afe02eb-182a-42b8-b985-75d0d08223e1"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9823), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9823), new Guid("81c2cd00-649e-4269-be67-ec4555e94ec8"), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a") },
                    { new Guid("6c62e629-c433-49dc-b3e0-bf25602ea538"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9836), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9836), new Guid("66e21778-7449-4a51-b31a-60f767e2332c"), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a") },
                    { new Guid("910ed661-eaa1-4aa3-9e14-7052dbad08e3"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9826), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9826), new Guid("c47303a3-bf51-4abc-9caf-9f45c0145f2b"), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a") },
                    { new Guid("b53044aa-56d5-49d2-bbf2-e08a86703e84"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9829), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9829), new Guid("146cec9e-8b73-4ace-8597-56e17dbd58fd"), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a") },
                    { new Guid("df29f5cf-90e7-4593-8f74-09f299428cd3"), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9833), new DateTime(2022, 10, 26, 22, 11, 36, 505, DateTimeKind.Local).AddTicks(9834), new Guid("92e43e7c-7bbb-4fdb-be62-3a292c9f00e3"), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a") }
                });

            migrationBuilder.InsertData(
                table: "UserToRoles",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "RoleId", "UserId" },
                values: new object[] { new Guid("132e86ed-a662-45cc-991b-259c9c4962ec"), new DateTime(2022, 10, 26, 22, 11, 36, 506, DateTimeKind.Local).AddTicks(810), new DateTime(2022, 10, 26, 22, 11, 36, 506, DateTimeKind.Local).AddTicks(812), new Guid("a3a142a4-5210-45d9-b1b3-56da9ad2081a"), new Guid("bdc85dc6-f413-49c7-832e-e9e830c0956c") });

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermissions_PermissionId",
                table: "RoleToPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermissions_RoleId",
                table: "RoleToPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoles_RoleId",
                table: "UserToRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoles_UserId",
                table: "UserToRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleToPermissions");

            migrationBuilder.DropTable(
                name: "UserToRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
