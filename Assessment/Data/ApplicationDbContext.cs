using System;
using System.Collections.Generic;
using System.Text;
using Assessment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assessment.Models;

namespace Assessment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionDetail> QuestionDetails { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ExamSection> ExamSections { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamSchedule> ExamSchedules { get; set; }
        public DbSet<ExamEmployee> ExamEmployees { get; set; }
        public DbSet<AnswerSection> AnswerSections { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerDetail> AnswerDetails { get; set; }
        public DbSet<Navigation> Navigations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasOne(p => p.Employee).WithOne(i => i.ApplicationUser).HasForeignKey<Employee>(e => e.UserForeignKey);
            builder.Entity<AnswerSection>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Answer>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<AnswerDetail>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<City>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Employee>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Exam>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Section>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<ExamEmployee>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<ExamQuestion>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<ExamSchedule>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<ExamSection>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Gender>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<MaritalStatus>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Question>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<QuestionDetail>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<QuestionType>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Entity<Religion>().Property(m => m.CreatedDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            //builder.Entity<City>().ToTable("Cities", "coba");

            #region RoleSeed
            var roleAdmin = new IdentityRole
            {
                Id = "32ff273e-e327-4f0b-b08e-a2e02b0880d6",
                Name = "Admin",
                NormalizedName = "Admin",
                ConcurrencyStamp = "c6c609bd-85da-4629-9c56-f23c489830d2"
            };
            var rolePeserta = new IdentityRole
            {
                Id = "04e83eaf-298f-4be6-9f05-2956b2030e5e",
                Name = "Peserta",
                NormalizedName = "Peserta",
                ConcurrencyStamp = "5402d890-3359-4b8f-a144-9d2afee67e1d"
            };
            builder.Entity<IdentityRole>().HasData(roleAdmin, rolePeserta);
            #endregion

            #region UserSeed
            var userAdmin = new ApplicationUser
            {
                Id = "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                Email = "admin@rekrutmen.com",
                NormalizedEmail = "ADMIN@REKRUTMEN.COM",
                UserName = "admin@rekrutmen.com",
                NormalizedUserName = "ADMIN@REKRUTMEN.COM",
                SecurityStamp = "7a1e8e47-50f4-4922-a855-7001a615fb5e",
                PasswordHash = "AQAAAAEAACcQAAAAEEp1sap4dxD2mtlMuEPd5CIN2p1lcaKGjOejHk2GjLl+BwkmCW38AtHU5fhBkmlOOA==",
                ConcurrencyStamp = "233e5870-bfa6-4ba4-b3bd-73cf85c5d173",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true
            };
            //userAdmin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(userAdmin, "123qwe");
            var userPeserta = new ApplicationUser
            {
                Id = "77e285fb-43e8-4846-b763-9fcc0138ea99",
                Email = "adindanamira97@gmail.com",
                NormalizedEmail = "ADINDANAMIRA97@GMAIL.COM",
                UserName = "adindanamira97@gmail.com",
                NormalizedUserName = "ADINDANAMIRA97@GMAIL.COM",
                SecurityStamp = "80b9327b-15db-49c9-86fa-1e3f21b74bb7",
                PasswordHash = "AQAAAAEAACcQAAAAEMiQscjx4+VAFyt6lKUPW2AkZ6mLOtJcnTST6KOYclS3VFLwMFKdD61UA2S9iVlYig==",
                ConcurrencyStamp = "93182e87-c18a-4fc7-8ac7-63100c9e803e",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true
            };
            //userPeserta.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(userPeserta, "123qwe");
            var userPeserta2 = new ApplicationUser
            {
                Id = "02840db7-b582-454f-a83b-802b68cd33f0",
                Email = "testing@gmail.com",
                NormalizedEmail = "TESTING@GMAIL.COM",
                UserName = "testing@gmail.com",
                NormalizedUserName = "TESTING@GMAIL.COM",
                SecurityStamp = "8067b3a3-a100-43a5-ae6a-0e294f817f9e",
                PasswordHash = "AQAAAAEAACcQAAAAEMiQscjx4+VAFyt6lKUPW2AkZ6mLOtJcnTST6KOYclS3VFLwMFKdD61UA2S9iVlYig==",
                ConcurrencyStamp = "216c4a56-0c6d-4908-87d4-7388153f4926",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true
            };
            builder.Entity<ApplicationUser>().HasData(userAdmin, userPeserta, userPeserta2);
            #endregion

            #region UserRoleSeed
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = userAdmin.Id,
                    RoleId = roleAdmin.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = userPeserta.Id,
                    RoleId = rolePeserta.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = userPeserta2.Id,
                    RoleId = rolePeserta.Id
                }
            );
            #endregion

            #region GenderSeed
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, CreatedId = userAdmin.Id, Code = "L", Name = "Laki-laki", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Gender { Id = 2, CreatedId = userAdmin.Id, Code = "P", Name = "Perempuan", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region ReligionSeed
            builder.Entity<Religion>().HasData(
                new Religion { Id = 1, CreatedId = userAdmin.Id, Code = "ISL", Name = "Islam", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Religion { Id = 2, CreatedId = userAdmin.Id, Code = "KTP", Name = "Kristen Protestan", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Religion { Id = 3, CreatedId = userAdmin.Id, Code = "KTK", Name = "Kristen Katolik", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Religion { Id = 4, CreatedId = userAdmin.Id, Code = "HIN", Name = "Hindu", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Religion { Id = 5, CreatedId = userAdmin.Id, Code = "BUD", Name = "Buddha", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Religion { Id = 6, CreatedId = userAdmin.Id, Code = "KHO", Name = "Khonghucu", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region MaritalStatusSeed
            builder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = 1, CreatedId = userAdmin.Id, Code = "BK", Name = "Belum Kawin", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new MaritalStatus { Id = 2, CreatedId = userAdmin.Id, Code = "K", Name = "Kawin", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region CitySeed
            builder.Entity<City>().HasData(
                new City { Id = 1, CreatedId = userAdmin.Id, Code = "SUB", Name = "Surabaya", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new City { Id = 2, CreatedId = userAdmin.Id, Code = "CGK", Name = "Jakarta", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region EmployeeSeed
            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, UserForeignKey = userPeserta.Id, GenderId = 2, ReligionId = 1, MaritalStatusId = 1, CityId = 1, CreatedId = userAdmin.Id, IdentityNumber = 1234567890, Name = "Adinda Namira", BirthDate = new DateTime(1990, 4, 28), BirthDatePlace = "Surabaya", Address = "Jl Surabaya No 1", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Employee { Id = 2, UserForeignKey = userPeserta2.Id, GenderId = 2, ReligionId = 1, MaritalStatusId = 1, CityId = 1, CreatedId = userAdmin.Id, IdentityNumber = 9999999999, Name = "Testing Dua", BirthDate = new DateTime(1991, 4, 28), BirthDatePlace = "Surabaya", Address = "Jl Surabaya No 1", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region QuestionTypeSeed
            builder.Entity<QuestionType>().HasData(
                new QuestionType { Id = 1, CreatedId = userAdmin.Id, Name = "Multiple Choice", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionType { Id = 2, CreatedId = userAdmin.Id, Name = "Multiple Answer", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionType { Id = 3, CreatedId = userAdmin.Id, Name = "Essay", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region QuestionSeed
            builder.Entity<Question>().HasData(
                new Question { Id = 1, QuestionTypeId = 1, CreatedId = userAdmin.Id, Item = "1, 3, 2, 6, 5, 15, 14, ....", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new Question { Id = 2, QuestionTypeId = 1, CreatedId = userAdmin.Id, Item = "100, 95, ..., 91, 92, 87, 88, 83.", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new Question { Id = 3, QuestionTypeId = 1, CreatedId = userAdmin.Id, Item = "INSOMNIA = ...", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new Question { Id = 4, QuestionTypeId = 1, CreatedId = userAdmin.Id, Item = "BONGSOR >< ...", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() }
            );
            #endregion

            #region QuestionDetailSeed
            builder.Entity<QuestionDetail>().HasData(
                new QuestionDetail { Id = 1, Item = "24", IsTrue = false, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 2, Item = "28", IsTrue = false, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 3, Item = "32", IsTrue = false, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 4, Item = "42", IsTrue = true, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 5, Item = "52", IsTrue = false, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 6, Item = "90", IsTrue = false, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 7, Item = "92", IsTrue = false, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 8, Item = "94", IsTrue = false, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 9, Item = "96", IsTrue = true, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 10, Item = "97", IsTrue = false, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 11, Item = "Cemas", IsTrue = false, QuestionId = 3, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 12, Item = "Sedih", IsTrue = false, QuestionId = 3, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 13, Item = "Tidak bisa tidur", IsTrue = true, QuestionId = 3, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 14, Item = "Kenyataanya", IsTrue = false, QuestionId = 3, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 15, Item = "Menumpuk", IsTrue = false, QuestionId = 4, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 16, Item = "Kerdil", IsTrue = true, QuestionId = 4, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 17, Item = "Macet", IsTrue = false, QuestionId = 4, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new QuestionDetail { Id = 18, Item = "Susut", IsTrue = false, QuestionId = 4, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region ExamSeed
            builder.Entity<Exam>().HasData(
                new Exam { Id = 1, CreatedId = userAdmin.Id, Name = "Rekrutmen Grade 6A", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new Exam { Id = 2, CreatedId = userAdmin.Id, Name = "Rekrutmen Grade 7A", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() }
            );
            #endregion

            #region SectionSeed
            builder.Entity<Section>().HasData(
                new Section { Id = 1, CreatedId = userAdmin.Id, Name = "Tes Potensi Akademik", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new Section { Id = 2, CreatedId = userAdmin.Id, Name = "Tes Psikotes", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() }
            );
            #endregion

            #region ExamSectionSeed
            builder.Entity<ExamSection>().HasData(
                new ExamSection { Id = 1, ExamId = 1, SectionId = 1, CreatedId = userAdmin.Id, Name = "Tes Potensi Akademik 6A", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamSection { Id = 2, ExamId = 1, SectionId = 2, CreatedId = userAdmin.Id, Name = "Tes Psikotes 6A", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamSection { Id = 3, ExamId = 2, SectionId = 1, CreatedId = userAdmin.Id, Name = "Tes Potensi Akademik 7A", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamSection { Id = 4, ExamId = 2, SectionId = 2, CreatedId = userAdmin.Id, Name = "Tes Psikotes 7A", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() }
            );
            #endregion

            #region ExamQuestionSeed
            builder.Entity<ExamQuestion>().HasData(
                new ExamQuestion { Id = 1, ExamSectionId = 1, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 2, ExamSectionId = 1, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 3, ExamSectionId = 2, QuestionId = 3, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 4, ExamSectionId = 2, QuestionId = 4, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 5, ExamSectionId = 3, QuestionId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 6, ExamSectionId = 3, QuestionId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 7, ExamSectionId = 4, QuestionId = 3, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamQuestion { Id = 8, ExamSectionId = 4, QuestionId = 4, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() }
            );
            #endregion

            #region ExamScheduleSeed
            builder.Entity<ExamSchedule>().HasData(
                new ExamSchedule { Id = 1, CreatedId = userAdmin.Id, ExamId = 1, DateExam = new DateTime(2019, 10, 11), Notes = "", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() },
                new ExamSchedule { Id = 2, CreatedId = userAdmin.Id, ExamId = 2, DateExam = new DateTime(2019, 10, 12), Notes = "", CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local), Duration = new TimeSpan() }
            );
            #endregion

            #region ExamEmployeeSeed
            builder.Entity<ExamEmployee>().HasData(
                new ExamEmployee { Id = 1, ExamScheduleId = 1, EmployeeId = 1, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new ExamEmployee { Id = 2, ExamScheduleId = 1, EmployeeId = 2, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region AnswerSeed
            builder.Entity<Answer>().HasData(
                new Answer { Id = 1, ExamEmployeeId = 1, ExamSectionId = 1, QuestionId = 1, Item = "1, 3, 2, 6, 5, 15, 14, ....", CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Answer { Id = 2, ExamEmployeeId = 1, ExamSectionId = 1, QuestionId = 2, Item = "100, 95, ..., 91, 92, 87, 88, 83.", CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Answer { Id = 3, ExamEmployeeId = 1, ExamSectionId = 2, QuestionId = 3, Item = "INSOMNIA = ...", CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new Answer { Id = 4, ExamEmployeeId = 1, ExamSectionId = 2, QuestionId = 4, Item = "BONGSOR >< ...", CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion

            #region AnswerDetailSeed
            builder.Entity<AnswerDetail>().HasData(
                new AnswerDetail { Id = 1, AnswerId = 1, QuestionDetailId = 4, Item = "42", IsTrue = true, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new AnswerDetail { Id = 2, AnswerId = 2, QuestionDetailId = 9, Item = "96", IsTrue = true, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new AnswerDetail { Id = 3, AnswerId = 3, QuestionDetailId = 13, Item = "Tidak bisa tidur", IsTrue = true, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) },
                new AnswerDetail { Id = 4, AnswerId = 4, QuestionDetailId = 16, Item = "Kerdil", IsTrue = true, CreatedId = userAdmin.Id, CreatedDate = new DateTime(2019, 10, 14, 18, 2, 41, 714, DateTimeKind.Local) }
            );
            #endregion
        }
    }
}
