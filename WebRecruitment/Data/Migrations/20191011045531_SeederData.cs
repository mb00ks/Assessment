﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment.Data.Migrations
{
    public partial class SeederData : Migration
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
                    { "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 0, "233e5870-bfa6-4ba4-b3bd-73cf85c5d173", "admin@rekrutmen.com", true, false, null, "ADMIN@REKRUTMEN.COM", "ADMIN@REKRUTMEN.COM", "AQAAAAEAACcQAAAAEEp1sap4dxD2mtlMuEPd5CIN2p1lcaKGjOejHk2GjLl+BwkmCW38AtHU5fhBkmlOOA==", null, true, "7a1e8e47-50f4-4922-a855-7001a615fb5e", false, "admin@rekrutmen.com" },
                    { "77e285fb-43e8-4846-b763-9fcc0138ea99", 0, "93182e87-c18a-4fc7-8ac7-63100c9e803e", "adindanamira97@gmail.com", true, false, null, "ADINDANAMIRA97@GMAIL.COM", "ADINDANAMIRA97@GMAIL.COM", "AQAAAAEAACcQAAAAEMiQscjx4+VAFyt6lKUPW2AkZ6mLOtJcnTST6KOYclS3VFLwMFKdD61UA2S9iVlYig==", null, true, "80b9327b-15db-49c9-86fa-1e3f21b74bb7", false, "adindanamira97@gmail.com" },
                    { "02840db7-b582-454f-a83b-802b68cd33f0", 0, "216c4a56-0c6d-4908-87d4-7388153f4926", "testing@gmail.com", true, false, null, "TESTING@GMAIL.COM", "TESTING@GMAIL.COM", "AQAAAAEAACcQAAAAEMiQscjx4+VAFyt6lKUPW2AkZ6mLOtJcnTST6KOYclS3VFLwMFKdD61UA2S9iVlYig==", null, true, "8067b3a3-a100-43a5-ae6a-0e294f817f9e", false, "testing@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "02840db7-b582-454f-a83b-802b68cd33f0", "04e83eaf-298f-4be6-9f05-2956b2030e5e" },
                    { "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "32ff273e-e327-4f0b-b08e-a2e02b0880d6" },
                    { "77e285fb-43e8-4846-b763-9fcc0138ea99", "04e83eaf-298f-4be6-9f05-2956b2030e5e" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedId", "Name" },
                values: new object[,]
                {
                    { 2, "CGK", new DateTime(2019, 10, 11, 11, 55, 30, 888, DateTimeKind.Local).AddTicks(3641), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Jakarta" },
                    { 1, "SUB", new DateTime(2019, 10, 11, 11, 55, 30, 888, DateTimeKind.Local).AddTicks(3201), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Surabaya" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Duration", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 890, DateTimeKind.Local).AddTicks(2082), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), "Rekrutmen Grade 7A" },
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(9179), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), "Rekrutmen Grade 6A" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedId", "Name" },
                values: new object[,]
                {
                    { 1, "L", new DateTime(2019, 10, 11, 11, 55, 30, 886, DateTimeKind.Local).AddTicks(9560), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Laki-laki" },
                    { 2, "P", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(5445), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Perempuan" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedId", "Name" },
                values: new object[,]
                {
                    { 2, "K", new DateTime(2019, 10, 11, 11, 55, 30, 888, DateTimeKind.Local).AddTicks(1049), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Kawin" },
                    { 1, "BK", new DateTime(2019, 10, 11, 11, 55, 30, 888, DateTimeKind.Local).AddTicks(616), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Belum Kawin" }
                });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(1195), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Essay" },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(1190), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Multiple Answer" },
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(774), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Multiple Choice" }
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedId", "Name" },
                values: new object[,]
                {
                    { 2, "KTP", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(8436), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Kristen Protestan" },
                    { 4, "HIN", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(8444), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Hindu" },
                    { 5, "BUD", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(8445), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Buddha" },
                    { 6, "KHO", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(8446), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Khonghucu" },
                    { 1, "ISL", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(7983), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Islam" },
                    { 3, "KTK", new DateTime(2019, 10, 11, 11, 55, 30, 887, DateTimeKind.Local).AddTicks(8442), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Kristen Katolik" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "BirthDate", "BirthDatePlace", "CityId", "CreatedDate", "CreatedId", "GenderId", "IdentityNumber", "MaritalStatusId", "Name", "ReligionId", "UserForeignKey" },
                values: new object[,]
                {
                    { 1, "Jl Surabaya No 1", new DateTime(1990, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surabaya", 1, new DateTime(2019, 10, 11, 11, 55, 30, 888, DateTimeKind.Local).AddTicks(8633), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 2, 1234567890L, 1, "Adinda Namira", 1, "77e285fb-43e8-4846-b763-9fcc0138ea99" },
                    { 2, "Jl Surabaya No 1", new DateTime(1991, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surabaya", 1, new DateTime(2019, 10, 11, 11, 55, 30, 888, DateTimeKind.Local).AddTicks(9071), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 2, 9999999999L, 1, "Testing Dua", 1, "02840db7-b582-454f-a83b-802b68cd33f0" }
                });

            migrationBuilder.InsertData(
                table: "ExamSchedules",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "DateExam", "Duration", "ExamId", "Notes" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(2789), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), 1, "" },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(3579), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0), 2, "" }
                });

            migrationBuilder.InsertData(
                table: "ExamSections",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Duration", "ExamId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 890, DateTimeKind.Local).AddTicks(5468), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 1, "Tes Potensi Akademik 6A" },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 890, DateTimeKind.Local).AddTicks(6660), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 1, "Tes Psikotes 6A" },
                    { 3, new DateTime(2019, 10, 11, 11, 55, 30, 890, DateTimeKind.Local).AddTicks(6669), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 2, "Tes Potensi Akademik 7A" },
                    { 4, new DateTime(2019, 10, 11, 11, 55, 30, 890, DateTimeKind.Local).AddTicks(6670), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 2, "Tes Psikotes 7A" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Duration", "Item", "QuestionTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(3219), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), "1, 3, 2, 6, 5, 15, 14, ....", 1 },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(4012), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), "100, 95, ..., 91, 92, 87, 88, 83.", 1 },
                    { 3, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(4021), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), "INSOMNIA = ...", 1 },
                    { 4, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(4023), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), "BONGSOR >< ...", 1 }
                });

            migrationBuilder.InsertData(
                table: "ExamEmployees",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "EmployeeId", "ExamScheduleId" },
                values: new object[,]
                {
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(6066), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 2, 1 },
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(5653), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ExamQuestions",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Duration", "ExamSectionId", "QuestionId" },
                values: new object[,]
                {
                    { 8, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(262), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 4, 4 },
                    { 6, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(259), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 3, 2 },
                    { 5, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(257), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 3, 1 },
                    { 4, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(256), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 2, 4 },
                    { 3, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(254), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 2, 3 },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(246), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 1, 2 },
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 890, DateTimeKind.Local).AddTicks(9427), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 1, 1 },
                    { 7, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(260), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", new TimeSpan(0, 0, 0, 0, 0), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "QuestionDetails",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Item", "QuestionId" },
                values: new object[,]
                {
                    { 18, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6500), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Susut", 4 },
                    { 17, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6499), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Macet", 4 },
                    { 16, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6497), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Kerdil", 4 },
                    { 15, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6496), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Menumpuk", 4 },
                    { 14, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6495), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Kenyataanya", 3 },
                    { 12, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6494), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Sedih", 3 },
                    { 11, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6493), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Cemas", 3 },
                    { 10, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6492), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "97", 2 },
                    { 9, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6490), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "96", 2 },
                    { 8, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6489), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "94", 2 },
                    { 7, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6488), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "92", 2 },
                    { 6, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6487), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "90", 2 },
                    { 5, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6486), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "52", 1 },
                    { 4, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6485), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "42", 1 },
                    { 3, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6483), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "32", 1 },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6477), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "28", 1 },
                    { 13, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6494), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Tidak bisa tidur", 3 },
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 889, DateTimeKind.Local).AddTicks(6062), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "24", 1 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "ExamEmployeeId", "Item", "QuestionId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(8553), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 1, "1, 3, 2, 6, 5, 15, 14, ....", 1 },
                    { 2, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(8974), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 1, "100, 95, ..., 91, 92, 87, 88, 83.", 2 },
                    { 3, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(8980), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 1, "INSOMNIA = ...", 3 },
                    { 4, new DateTime(2019, 10, 11, 11, 55, 30, 891, DateTimeKind.Local).AddTicks(8982), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", 1, "BONGSOR >< ...", 4 }
                });

            migrationBuilder.InsertData(
                table: "AnswerDetails",
                columns: new[] { "Id", "AnswerId", "CreatedDate", "CreatedId", "Item", "QuestionDetailId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 10, 11, 11, 55, 30, 892, DateTimeKind.Local).AddTicks(1407), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "42", 4 },
                    { 2, 2, new DateTime(2019, 10, 11, 11, 55, 30, 892, DateTimeKind.Local).AddTicks(1827), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "96", 9 },
                    { 3, 3, new DateTime(2019, 10, 11, 11, 55, 30, 892, DateTimeKind.Local).AddTicks(1835), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Tidak bisa tidur", 13 },
                    { 4, 4, new DateTime(2019, 10, 11, 11, 55, 30, 892, DateTimeKind.Local).AddTicks(1837), "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "Kerdil", 16 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnswerDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnswerDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnswerDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "02840db7-b582-454f-a83b-802b68cd33f0", "04e83eaf-298f-4be6-9f05-2956b2030e5e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "77e285fb-43e8-4846-b763-9fcc0138ea99", "04e83eaf-298f-4be6-9f05-2956b2030e5e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f91a6f48-4c5b-4750-8341-bbb4d6905c74", "32ff273e-e327-4f0b-b08e-a2e02b0880d6" });

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamEmployees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExamQuestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExamSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaritalStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04e83eaf-298f-4be6-9f05-2956b2030e5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ff273e-e327-4f0b-b08e-a2e02b0880d6");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamSections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExamSections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamSections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExamSections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuestionDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02840db7-b582-454f-a83b-802b68cd33f0");

            migrationBuilder.DeleteData(
                table: "ExamEmployees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExamSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77e285fb-43e8-4846-b763-9fcc0138ea99");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f91a6f48-4c5b-4750-8341-bbb4d6905c74");
        }
    }
}