using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Models;

namespace WebRecruitment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Navigation> Navigations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(p => p.Employee)
                .WithOne(i => i.ApplicationUser)
                .HasForeignKey<Employee>(e => e.UserForeignKey);

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
            builder.Entity<ApplicationUser>().HasData(userAdmin, userPeserta);
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
                }
            );
            #endregion

            #region GenderSeed
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, Code = "L", Name = "Laki-laki" },
                new Gender { Id = 2, Code = "P", Name = "Perempuan" }
            );
            #endregion

            #region ReligionSeed
            builder.Entity<Religion>().HasData(
                new Religion { Id = 1, Code = "ISL", Name = "Islam" },
                new Religion { Id = 2, Code = "KTP", Name = "Kristen Protestan" },
                new Religion { Id = 3, Code = "KTK", Name = "Kristen Katolik" },
                new Religion { Id = 4, Code = "HIN", Name = "Hindu" },
                new Religion { Id = 5, Code = "BUD", Name = "Buddha" },
                new Religion { Id = 6, Code = "KHO", Name = "Khonghucu" }
            );
            #endregion

            #region MaritalStatusSeed
            builder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = 1, Code = "BK", Name = "Belum Kawin" },
                new MaritalStatus { Id = 2, Code = "K", Name = "Kawin" }
            );
            #endregion

            #region EmployeeSeed
            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, UserForeignKey = "77e285fb-43e8-4846-b763-9fcc0138ea99", GenderId = 2, ReligionId = 1, MaritalStatusId = 1, IdentityNumber = 1234567890, Name = "Adinda Namira", BirthDate = new DateTime(1990, 4, 28), BirthDatePlace = "Surabaya", Address = "Jl Surabaya No 1" }
            );
            #endregion
        }
    }
}
