using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRecruitment.Data.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77e285fb-43e8-4846-b763-9fcc0138ea99",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "fb20edf4-05d0-443f-9c89-5df367f1f23a", "PESERTA@REKRUTMEN.COM", "PESERTA@REKRUTMEN.COM", "AQAAAAEAACcQAAAAEEytdy1yBgoktK17boU9s8aEJqzbNIDehdx0FrZd4dJBQyjSg9pJ4+bYJiQJwJI4ig==", "peserta@rekrutmen.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "53f4d2a6-8e78-4b79-a9d2-00a8a9d1e288", "ADMIN@REKRUTMEN.COM", "ADMIN@REKRUTMEN.COM", "AQAAAAEAACcQAAAAEByoqzTpYUM+qjDTQmu4K2iCt/eAQQMZik/SKCx0LqY/h4D59e0vxVD9k4rvNGAwyQ==", "admin@rekrutmen.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77e285fb-43e8-4846-b763-9fcc0138ea99",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "f9ba8713-2c9e-441d-be62-89dc9ce6c903", "peserta@rekrutmen.com", "peserta", "AQAAAAEAACcQAAAAEMd9ZbIdSUfRpESXkT/hR621m6fTtJEp9BIOHcLNQjsP9BSHk7I0sQraxEM4hzjGOQ==", "peserta" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "18b1bf67-97ba-4a33-b6d5-3bc81e1e705a", "admin@rekrutmen.com", "admin", "AQAAAAEAACcQAAAAEAKbxgDi8bIcJ163mI9L1B6KmuaM5ad0r7UuoBbepsykz/T8qiCpTZp9zNbvjDir5Q==", "admin" });
        }
    }
}
