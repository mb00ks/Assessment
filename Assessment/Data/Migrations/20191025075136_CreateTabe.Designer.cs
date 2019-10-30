﻿// <auto-generated />
using System;
using Assessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Assessment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191025075136_CreateTabe")]
    partial class CreateTabe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Assessment.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerSectionId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<int>("ExamEmployeeId");

                    b.Property<int>("ExamSectionId");

                    b.Property<string>("Item");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerSectionId");

                    b.HasIndex("CreatedId");

                    b.HasIndex("ExamEmployeeId");

                    b.HasIndex("ExamSectionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Assessment.Models.AnswerDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<bool?>("IsTrue");

                    b.Property<string>("Item");

                    b.Property<int?>("QuestionDetailId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("CreatedId");

                    b.HasIndex("QuestionDetailId");

                    b.ToTable("AnswerDetails");
                });

            modelBuilder.Entity("Assessment.Models.AnswerQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerSectionId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("Number");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerSectionId");

                    b.HasIndex("CreatedId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerQuestion");
                });

            modelBuilder.Entity("Assessment.Models.AnswerSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("ExamEmployeeId");

                    b.Property<int>("ExamId");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("ExamEmployeeId");

                    b.HasIndex("ExamId");

                    b.HasIndex("SectionId");

                    b.ToTable("AnswerSections");
                });

            modelBuilder.Entity("Assessment.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Assessment.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Assessment.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthDatePlace")
                        .IsRequired();

                    b.Property<int>("CityId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<int>("GenderId");

                    b.Property<long>("IdentityNumber");

                    b.Property<int>("MaritalStatusId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ReligionId");

                    b.Property<string>("UserForeignKey")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CreatedId");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("UserForeignKey")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Assessment.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Assessment.Models.ExamEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("ExamScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ExamScheduleId");

                    b.ToTable("ExamEmployees");
                });

            modelBuilder.Entity("Assessment.Models.ExamQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("ExamSectionId");

                    b.Property<int>("Number");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("ExamSectionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamQuestions");
                });

            modelBuilder.Entity("Assessment.Models.ExamSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<DateTime>("DateExam");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("ExamId");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamSchedules");
                });

            modelBuilder.Entity("Assessment.Models.ExamSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("ExamId");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("ExamId");

                    b.HasIndex("SectionId");

                    b.ToTable("ExamSections");
                });

            modelBuilder.Entity("Assessment.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Assessment.Models.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("MaritalStatuses");
                });

            modelBuilder.Entity("Assessment.Models.Navigation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Area");

                    b.Property<string>("Controller");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("NextOrderId");

                    b.Property<int>("OrderId");

                    b.Property<string>("Path");

                    b.Property<int?>("PrevOrderId");

                    b.Property<string>("Route");

                    b.HasKey("Id");

                    b.ToTable("Navigations");
                });

            modelBuilder.Entity("Assessment.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Item");

                    b.Property<int>("QuestionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Assessment.Models.QuestionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<bool?>("IsTrue");

                    b.Property<string>("Item");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionDetails");
                });

            modelBuilder.Entity("Assessment.Models.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("Assessment.Models.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("Assessment.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("CreatedId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatedId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Assessment.Models.Answer", b =>
                {
                    b.HasOne("Assessment.Models.AnswerSection")
                        .WithMany("Answers")
                        .HasForeignKey("AnswerSectionId");

                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Answers")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.ExamEmployee", "ExamEmployee")
                        .WithMany("Answers")
                        .HasForeignKey("ExamEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ExamSection", "ExamSection")
                        .WithMany("Answers")
                        .HasForeignKey("ExamSectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.AnswerDetail", b =>
                {
                    b.HasOne("Assessment.Models.Answer", "Answer")
                        .WithMany("AnswerDetails")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("AnswerDetails")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.QuestionDetail", "QuestionDetail")
                        .WithMany("AnswerDetails")
                        .HasForeignKey("QuestionDetailId");
                });

            modelBuilder.Entity("Assessment.Models.AnswerQuestion", b =>
                {
                    b.HasOne("Assessment.Models.AnswerSection", "AnswerSection")
                        .WithMany("AnswerQuestions")
                        .HasForeignKey("AnswerSectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany()
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.AnswerSection", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany()
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.ExamEmployee", "ExamEmployee")
                        .WithMany()
                        .HasForeignKey("ExamEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.City", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Cities")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Assessment.Models.Employee", b =>
                {
                    b.HasOne("Assessment.Models.City", "City")
                        .WithMany("Employees")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Employees")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.MaritalStatus", "MaritalStatus")
                        .WithMany("Employees")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.Religion", "Religion")
                        .WithMany("Employees")
                        .HasForeignKey("ReligionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Employee")
                        .HasForeignKey("Assessment.Models.Employee", "UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.Exam", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Exams")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Assessment.Models.ExamEmployee", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("ExamEmployees")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.Employee", "Employee")
                        .WithMany("ExamEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ExamSchedule", "ExamSchedule")
                        .WithMany("ExamEmployees")
                        .HasForeignKey("ExamScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.ExamQuestion", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.ExamSection", "ExamSection")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("ExamSectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.Question", "Question")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.ExamSchedule", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("ExamSchedules")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.Exam", "Exam")
                        .WithMany("ExamSchedules")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.ExamSection", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("ExamSections")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.Exam", "Exam")
                        .WithMany("ExamSections")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.Section", "Section")
                        .WithMany("ExamSections")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.Gender", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Genders")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Assessment.Models.MaritalStatus", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("MaritalStatuses")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Assessment.Models.Question", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Questions")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.QuestionType", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.QuestionDetail", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("QuestionDetails")
                        .HasForeignKey("CreatedId");

                    b.HasOne("Assessment.Models.Question", "Question")
                        .WithMany("QuestionDetails")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assessment.Models.QuestionType", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("QuestionTypes")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Assessment.Models.Religion", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Religions")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Assessment.Models.Section", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser", "Created")
                        .WithMany("Sections")
                        .HasForeignKey("CreatedId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assessment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Assessment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}