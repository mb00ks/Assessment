﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebRecruitment.Data;

namespace WebRecruitment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.HasData(
                        new
                        {
                            Id = "32ff273e-e327-4f0b-b08e-a2e02b0880d6",
                            ConcurrencyStamp = "c6c609bd-85da-4629-9c56-f23c489830d2",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "04e83eaf-298f-4be6-9f05-2956b2030e5e",
                            ConcurrencyStamp = "5402d890-3359-4b8f-a144-9d2afee67e1d",
                            Name = "Peserta",
                            NormalizedName = "Peserta"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                            RoleId = "32ff273e-e327-4f0b-b08e-a2e02b0880d6"
                        },
                        new
                        {
                            UserId = "77e285fb-43e8-4846-b763-9fcc0138ea99",
                            RoleId = "04e83eaf-298f-4be6-9f05-2956b2030e5e"
                        });
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

            modelBuilder.Entity("WebRecruitment.Models.ApplicationUser", b =>
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

                    b.HasData(
                        new
                        {
                            Id = "f91a6f48-4c5b-4750-8341-bbb4d6905c74",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "233e5870-bfa6-4ba4-b3bd-73cf85c5d173",
                            Email = "admin@rekrutmen.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@REKRUTMEN.COM",
                            NormalizedUserName = "ADMIN@REKRUTMEN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEp1sap4dxD2mtlMuEPd5CIN2p1lcaKGjOejHk2GjLl+BwkmCW38AtHU5fhBkmlOOA==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "7a1e8e47-50f4-4922-a855-7001a615fb5e",
                            TwoFactorEnabled = false,
                            UserName = "admin@rekrutmen.com"
                        },
                        new
                        {
                            Id = "77e285fb-43e8-4846-b763-9fcc0138ea99",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "93182e87-c18a-4fc7-8ac7-63100c9e803e",
                            Email = "adindanamira97@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADINDANAMIRA97@GMAIL.COM",
                            NormalizedUserName = "ADINDANAMIRA97@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMiQscjx4+VAFyt6lKUPW2AkZ6mLOtJcnTST6KOYclS3VFLwMFKdD61UA2S9iVlYig==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "80b9327b-15db-49c9-86fa-1e3f21b74bb7",
                            TwoFactorEnabled = false,
                            UserName = "adindanamira97@gmail.com"
                        });
                });

            modelBuilder.Entity("WebRecruitment.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthDatePlace")
                        .IsRequired();

                    b.Property<int>("GenderId");

                    b.Property<int>("IdentityNumber");

                    b.Property<int>("MaritalStatusId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ReligionId");

                    b.Property<string>("UserForeignKey")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("UserForeignKey")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Jl Surabaya No 1",
                            BirthDate = new DateTime(1990, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthDatePlace = "Surabaya",
                            GenderId = 2,
                            IdentityNumber = 1234567890,
                            MaritalStatusId = 1,
                            Name = "Adinda Namira",
                            ReligionId = 1,
                            UserForeignKey = "77e285fb-43e8-4846-b763-9fcc0138ea99"
                        });
                });

            modelBuilder.Entity("WebRecruitment.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "L",
                            Name = "Laki-laki"
                        },
                        new
                        {
                            Id = 2,
                            Code = "P",
                            Name = "Perempuan"
                        });
                });

            modelBuilder.Entity("WebRecruitment.Models.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("MaritalStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "BK",
                            Name = "Belum Kawin"
                        },
                        new
                        {
                            Id = 2,
                            Code = "K",
                            Name = "Kawin"
                        });
                });

            modelBuilder.Entity("WebRecruitment.Models.Navigation", b =>
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

            modelBuilder.Entity("WebRecruitment.Models.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Religions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "ISL",
                            Name = "Islam"
                        },
                        new
                        {
                            Id = 2,
                            Code = "KTP",
                            Name = "Kristen Protestan"
                        },
                        new
                        {
                            Id = 3,
                            Code = "KTK",
                            Name = "Kristen Katolik"
                        },
                        new
                        {
                            Id = 4,
                            Code = "HIN",
                            Name = "Hindu"
                        },
                        new
                        {
                            Id = 5,
                            Code = "BUD",
                            Name = "Buddha"
                        },
                        new
                        {
                            Id = 6,
                            Code = "KHO",
                            Name = "Khonghucu"
                        });
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
                    b.HasOne("WebRecruitment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebRecruitment.Models.ApplicationUser")
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

                    b.HasOne("WebRecruitment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebRecruitment.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebRecruitment.Models.Employee", b =>
                {
                    b.HasOne("WebRecruitment.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRecruitment.Models.MaritalStatus", "MaritalStatus")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRecruitment.Models.Religion", "Religion")
                        .WithMany()
                        .HasForeignKey("ReligionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebRecruitment.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Employee")
                        .HasForeignKey("WebRecruitment.Models.Employee", "UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
