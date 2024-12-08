﻿// <auto-generated />
using System;
using FitnessTrackingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessTrackingApp.Data.Migrations
{
    [DbContext(typeof(FitnessTrackingAppDbContext))]
    [Migration("20241208164946_AddDateToWeeklyPlan")]
    partial class AddDateToWeeklyPlan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3d6800ac-f4d4-4dac-b454-f35bbf904b0c",
                            Email = "trainer@getfit.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TRAINER@GETFIT.COM",
                            NormalizedUserName = "TRAINER@GETFIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELgDoi5HDG8Pug6HCYSQo6/+SA6L54OY4AGwUyjd0USCYX57uHHIIiuFLC3bJxuafA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4JZZ3RICHGHZ3WDZWHJICS76QRJAESPV",
                            TwoFactorEnabled = false,
                            UserName = "trainer@getfit.com"
                        },
                        new
                        {
                            Id = new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "553ae0d1-a935-4117-ab69-ec6e0880f624",
                            Email = "trainer2@getfit.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TRAINER2@GETFIT.COM",
                            NormalizedUserName = "TRAINER2@GETFIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKi4X8jlIeKb2Ks+WTYxDzXEtjWoEEUxXkHQwV4gNQ4Y55lp3v9e73xxGJRC82dC6A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3AYQOQVOUTYD57DGY46IMWFVAQFC7BXE",
                            TwoFactorEnabled = false,
                            UserName = "trainer2@getfit.com"
                        },
                        new
                        {
                            Id = new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4dec321c-aaa3-4262-b508-fa373f8a7626",
                            Email = "trainer3@getfit.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TRAINER3@GETFIT.COM",
                            NormalizedUserName = "TRAINER3@GETFIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEM091clNOAmxwsYSHkdKdFrIX9VqVNOlisCtHCMQsHrCwjO8n3FkR/aTOzjO7U39rA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "PS3NQ5SUDKLIPXVZUOLB2WUVYWSCGT4B",
                            TwoFactorEnabled = false,
                            UserName = "trainer3@getfit.com"
                        },
                        new
                        {
                            Id = new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "da4a1713-d6eb-4185-bfea-6867b1d7102b",
                            Email = "trainer4@getfit.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TRAINER4@GETFIT.COM",
                            NormalizedUserName = "TRAINER4@GETFIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAED2P7oQH2z6h/CMWDPHngCMirJN+RM3sCXtpmUdMSkRd2HzDYMyxw1Vnu0/ynO1BHA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "CPRDG6HRGDF2RZSL25ZQTAQN6CCFN3OU",
                            TwoFactorEnabled = false,
                            UserName = "trainer4@getfit.com"
                        },
                        new
                        {
                            Id = new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6b049beb-a5ef-4378-bf9b-2a3023b97ad7",
                            Email = "trainer5@getfit.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TRAINER5@GETFIT.COM",
                            NormalizedUserName = "TRAINER5@GETFIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBlaW8OGa3wuT5fTPou0rvz6TpIbQo8fuiXX64BxjqQDguHMTGANK8dsSA2yotbUig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "KLUU7OY42MOI2B6YKLLUTT5KTZX5P4SN",
                            TwoFactorEnabled = false,
                            UserName = "trainer5@getfit.com"
                        });
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.BodyWeightGoal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GoalWeight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BodyWeightGoals");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.BodyWeightLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("CurrentWeight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("DateLogged")
                        .HasColumnType("datetime2");

                    b.Property<long>("WeeklyPlanId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyPlanId");

                    b.HasIndex("DateLogged", "WeeklyPlanId")
                        .IsUnique();

                    b.ToTable("BodyWeightLogs");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.CardioSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<bool>("IsHIIT")
                        .HasColumnType("bit");

                    b.Property<int>("SessionsPerWeek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CardioSessions");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.CustomerDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AdditionalNotes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoalDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("GoalPlanId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("StartingWeight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("TargetWeight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("GoalPlanId")
                        .IsUnique();

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.GoalPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("CurrentWeight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GoalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoalPlanStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("GoalWeigh")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[GoalPlanStatus] = 0");

                    b.ToTable("GoalPlans");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.Macro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("DailyCarbohydrates")
                        .HasColumnType("int");

                    b.Property<int>("DailyFat")
                        .HasColumnType("int");

                    b.Property<int>("DailyProtein")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Macros");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Trainers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8da2c4e-44f5-427d-b6f5-0dccfa1e2a46"),
                            AverageRating = 6.4000000000000004,
                            IsAvailable = true,
                            UserId = new Guid("417ae2a4-ffbb-4e27-855e-d353004e0e91"),
                            YearsOfExperience = 7
                        },
                        new
                        {
                            Id = new Guid("ec163c02-6fdd-4e66-bec7-a1418a2fe85a"),
                            AverageRating = 8.1999999999999993,
                            IsAvailable = true,
                            UserId = new Guid("e61ce637-3ba1-44a2-8c05-b7c0595c3e5b"),
                            YearsOfExperience = 12
                        },
                        new
                        {
                            Id = new Guid("d6644f7d-214a-4295-a971-7b065bd5c5ac"),
                            AverageRating = 3.8999999999999999,
                            IsAvailable = true,
                            UserId = new Guid("cba94579-9df9-4cda-bf3e-ff5f51048d4b"),
                            YearsOfExperience = 4
                        },
                        new
                        {
                            Id = new Guid("df3e0b57-1b43-497a-87d0-97a34ba21c92"),
                            AverageRating = 2.2000000000000002,
                            IsAvailable = false,
                            UserId = new Guid("90162da5-8408-493a-8dae-99995094cf09"),
                            YearsOfExperience = 2
                        },
                        new
                        {
                            Id = new Guid("538c0f88-cd08-4dff-9a9e-0b612e436f03"),
                            AverageRating = 0.0,
                            IsAvailable = true,
                            UserId = new Guid("b0209e85-b41c-472b-a767-037253b72665"),
                            YearsOfExperience = 0
                        });
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.WeeklyPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CardioSessionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GoalPlanId")
                        .HasColumnType("bigint");

                    b.Property<long>("MacroId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardioSessionId");

                    b.HasIndex("GoalPlanId");

                    b.HasIndex("MacroId");

                    b.HasIndex("Week", "GoalPlanId")
                        .IsUnique();

                    b.ToTable("WeeklyPlans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.BodyWeightGoal", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.BodyWeightLog", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.WeeklyPlan", "WeeklyPlan")
                        .WithMany("BodyWeightLogs")
                        .HasForeignKey("WeeklyPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WeeklyPlan");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.CustomerDetails", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.GoalPlan", "GoalPlan")
                        .WithOne("CustomerDetails")
                        .HasForeignKey("FitnessTrackingApp.Data.Models.CustomerDetails", "GoalPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoalPlan");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.GoalPlan", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.Trainer", "Trainer")
                        .WithMany("GoalPlans")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.Trainer", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", "User")
                        .WithOne()
                        .HasForeignKey("FitnessTrackingApp.Data.Models.Trainer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.WeeklyPlan", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.CardioSession", "CardioSession")
                        .WithMany()
                        .HasForeignKey("CardioSessionId");

                    b.HasOne("FitnessTrackingApp.Data.Models.GoalPlan", "GoalPlan")
                        .WithMany("WeeklyPlans")
                        .HasForeignKey("GoalPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessTrackingApp.Data.Models.Macro", "Macro")
                        .WithMany()
                        .HasForeignKey("MacroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardioSession");

                    b.Navigation("GoalPlan");

                    b.Navigation("Macro");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FitnessTrackingApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.GoalPlan", b =>
                {
                    b.Navigation("CustomerDetails")
                        .IsRequired();

                    b.Navigation("WeeklyPlans");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.Trainer", b =>
                {
                    b.Navigation("GoalPlans");
                });

            modelBuilder.Entity("FitnessTrackingApp.Data.Models.WeeklyPlan", b =>
                {
                    b.Navigation("BodyWeightLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
