using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Assessment.Data.Migrations
{
    public partial class CreateTabe : Migration
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

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genders_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaritalStatuses_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Navigations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrderId = table.Column<int>(nullable: false),
                    PrevOrderId = table.Column<int>(nullable: true),
                    NextOrderId = table.Column<int>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Route = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionTypes_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Religions_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExamId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    DateExam = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSchedules_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedules_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserForeignKey = table.Column<string>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    ReligionId = table.Column<int>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthDatePlace = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExamId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSections_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSections_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    IsTrue = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionDetails_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionDetails_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExamScheduleId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamEmployees_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamEmployees_ExamSchedules_ExamScheduleId",
                        column: x => x.ExamScheduleId,
                        principalTable: "ExamSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<int>(nullable: false),
                    ExamSectionId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_ExamSections_ExamSectionId",
                        column: x => x.ExamSectionId,
                        principalTable: "ExamSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExamEmployeeId = table.Column<int>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerSections_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerSections_ExamEmployees_ExamEmployeeId",
                        column: x => x.ExamEmployeeId,
                        principalTable: "ExamEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerSections_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Number = table.Column<int>(nullable: false),
                    AnswerSectionId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_AnswerSections_AnswerSectionId",
                        column: x => x.AnswerSectionId,
                        principalTable: "AnswerSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExamEmployeeId = table.Column<int>(nullable: false),
                    ExamSectionId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    CreatedId = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    AnswerSectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_AnswerSections_AnswerSectionId",
                        column: x => x.AnswerSectionId,
                        principalTable: "AnswerSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_ExamEmployees_ExamEmployeeId",
                        column: x => x.ExamEmployeeId,
                        principalTable: "ExamEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_ExamSections_ExamSectionId",
                        column: x => x.ExamSectionId,
                        principalTable: "ExamSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnswerId = table.Column<int>(nullable: false),
                    QuestionDetailId = table.Column<int>(nullable: true),
                    CreatedId = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    IsTrue = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerDetails_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerDetails_AspNetUsers_CreatedId",
                        column: x => x.CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerDetails_QuestionDetails_QuestionDetailId",
                        column: x => x.QuestionDetailId,
                        principalTable: "QuestionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerDetails_AnswerId",
                table: "AnswerDetails",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerDetails_CreatedId",
                table: "AnswerDetails",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerDetails_QuestionDetailId",
                table: "AnswerDetails",
                column: "QuestionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion_AnswerSectionId",
                table: "AnswerQuestion",
                column: "AnswerSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion_CreatedId",
                table: "AnswerQuestion",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion_QuestionId",
                table: "AnswerQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerSectionId",
                table: "Answers",
                column: "AnswerSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CreatedId",
                table: "Answers",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ExamEmployeeId",
                table: "Answers",
                column: "ExamEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ExamSectionId",
                table: "Answers",
                column: "ExamSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_CreatedId",
                table: "AnswerSections",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_ExamEmployeeId",
                table: "AnswerSections",
                column: "ExamEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_ExamId",
                table: "AnswerSections",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_SectionId",
                table: "AnswerSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedId",
                table: "Cities",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedId",
                table: "Employees",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MaritalStatusId",
                table: "Employees",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReligionId",
                table: "Employees",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserForeignKey",
                table: "Employees",
                column: "UserForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamEmployees_CreatedId",
                table: "ExamEmployees",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamEmployees_EmployeeId",
                table: "ExamEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamEmployees_ExamScheduleId",
                table: "ExamEmployees",
                column: "ExamScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_CreatedId",
                table: "ExamQuestions",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamSectionId",
                table: "ExamQuestions",
                column: "ExamSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedId",
                table: "Exams",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedules_CreatedId",
                table: "ExamSchedules",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedules_ExamId",
                table: "ExamSchedules",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSections_CreatedId",
                table: "ExamSections",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSections_ExamId",
                table: "ExamSections",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSections_SectionId",
                table: "ExamSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_CreatedId",
                table: "Genders",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatuses_CreatedId",
                table: "MaritalStatuses",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDetails_CreatedId",
                table: "QuestionDetails",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDetails_QuestionId",
                table: "QuestionDetails",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedId",
                table: "Questions",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_CreatedId",
                table: "QuestionTypes",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_CreatedId",
                table: "Religions",
                column: "CreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CreatedId",
                table: "Sections",
                column: "CreatedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerDetails");

            migrationBuilder.DropTable(
                name: "AnswerQuestion");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "Navigations");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionDetails");

            migrationBuilder.DropTable(
                name: "AnswerSections");

            migrationBuilder.DropTable(
                name: "ExamSections");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "ExamEmployees");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ExamSchedules");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "Exams");

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
        }
    }
}
