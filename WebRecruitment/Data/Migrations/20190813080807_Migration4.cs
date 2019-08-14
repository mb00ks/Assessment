using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRecruitment.Data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77e285fb-43e8-4846-b763-9fcc0138ea99",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "93182e87-c18a-4fc7-8ac7-63100c9e803e", "adindanamira97@gmail.com", "ADINDANAMIRA97@GMAIL.COM", "ADINDANAMIRA97@GMAIL.COM", "adindanamira97@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                column: "ConcurrencyStamp",
                value: "233e5870-bfa6-4ba4-b3bd-73cf85c5d173");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "L", "Laki-laki" },
                    { 2, "P", "Perempuan" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "BK", "Belum Kawin" },
                    { 2, "K", "Kawin" }
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "ISL", "Islam" },
                    { 2, "KTP", "Kristen Protestan" },
                    { 3, "KTK", "Kristen Katolik" },
                    { 4, "HIN", "Hindu" },
                    { 5, "BUD", "Buddha" },
                    { 6, "KHO", "Khonghucu" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "BirthDatePlace", "GenderId", "IdentityNumber", "MaritalStatusId", "Name", "ReligionId", "UserForeignKey" },
                values: new object[] { 1, "Jl Surabaya No 1", new DateTime(1990, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surabaya", 2, 1234567890, 1, "Adinda Namira", 1, "77e285fb-43e8-4846-b763-9fcc0138ea99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaritalStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaritalStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Religions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77e285fb-43e8-4846-b763-9fcc0138ea99",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "41eb6144-e245-4ac6-bb25-c3bd20e54fa2", "peserta@rekrutmen.com", "PESERTA@REKRUTMEN.COM", "PESERTA@REKRUTMEN.COM", "peserta@rekrutmen.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                column: "ConcurrencyStamp",
                value: "90e79431-8d05-4f5b-bba9-c394c31eab27");
        }
    }
}
