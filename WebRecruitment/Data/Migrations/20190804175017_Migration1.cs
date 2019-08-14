using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRecruitment.Data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32ff273e-e327-4f0b-b08e-a2e02b0880d6", "c6c609bd-85da-4629-9c56-f23c489830d2", "Admin", "Admin" },
                    { "04e83eaf-298f-4be6-9f05-2956b2030e5e", "5402d890-3359-4b8f-a144-9d2afee67e1d", "Peserta", "Peserta" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 0, "18b1bf67-97ba-4a33-b6d5-3bc81e1e705a", "admin@rekrutmen.com", true, false, null, "admin@rekrutmen.com", "admin", "AQAAAAEAACcQAAAAEAKbxgDi8bIcJ163mI9L1B6KmuaM5ad0r7UuoBbepsykz/T8qiCpTZp9zNbvjDir5Q==", null, true, "7a1e8e47-50f4-4922-a855-7001a615fb5e", false, "admin" },
                    { "77e285fb-43e8-4846-b763-9fcc0138ea99", 0, "f9ba8713-2c9e-441d-be62-89dc9ce6c903", "peserta@rekrutmen.com", true, false, null, "peserta@rekrutmen.com", "peserta", "AQAAAAEAACcQAAAAEMd9ZbIdSUfRpESXkT/hR621m6fTtJEp9BIOHcLNQjsP9BSHk7I0sQraxEM4hzjGOQ==", null, true, "80b9327b-15db-49c9-86fa-1e3f21b74bb7", false, "peserta" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "32ff273e-e327-4f0b-b08e-a2e02b0880d6" },
                    { "77e285fb-43e8-4846-b763-9fcc0138ea99", "04e83eaf-298f-4be6-9f05-2956b2030e5e" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "77e285fb-43e8-4846-b763-9fcc0138ea99", "04e83eaf-298f-4be6-9f05-2956b2030e5e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "32ff273e-e327-4f0b-b08e-a2e02b0880d6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04e83eaf-298f-4be6-9f05-2956b2030e5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ff273e-e327-4f0b-b08e-a2e02b0880d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77e285fb-43e8-4846-b763-9fcc0138ea99");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f91a6f48-4c5b-4750-8341-bbb4d6905c74");
        }
    }
}
