﻿// <auto-generated />
using System;
using GatePass_DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GatePass_Migrations.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230323074320_Company-Addition")]
    partial class CompanyAddition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GatePass_Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("CompanyKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("company");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            CompanyKey = "468C8C57A591B",
                            CompanyName = "Barakha Flour Mills"
                        });
                });

            modelBuilder.Entity("GatePass_Models.dispatchItems", b =>
                {
                    b.Property<int>("dispatchItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dispatchItemId"), 1L, 1);

                    b.Property<int>("OutwardGatePassModeldispatchId")
                        .HasColumnType("int");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("productArea")
                        .HasColumnType("real");

                    b.Property<float>("quantity")
                        .HasColumnType("real");

                    b.Property<float>("sizeValue")
                        .HasColumnType("real");

                    b.Property<int>("uom")
                        .HasColumnType("int");

                    b.HasKey("dispatchItemId");

                    b.HasIndex("OutwardGatePassModeldispatchId");

                    b.ToTable("dispatchItems");
                });

            modelBuilder.Entity("GatePass_Models.InwardGatePassModel", b =>
                {
                    b.Property<int>("GatePassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GatePassId"), 1L, 1);

                    b.Property<string>("GatePassCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("driverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("licensePlateNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("partyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vehicleMake")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vehicleType")
                        .HasColumnType("int");

                    b.HasKey("GatePassId");

                    b.ToTable("inwardGatePass");
                });

            modelBuilder.Entity("GatePass_Models.ItemsModel", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"), 1L, 1);

                    b.Property<int>("InwardGatePassModelGatePassId")
                        .HasColumnType("int");

                    b.Property<string>("additionalSpecs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("itemId");

                    b.HasIndex("InwardGatePassModelGatePassId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("GatePass_Models.OutwardGatePassModel", b =>
                {
                    b.Property<int>("dispatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("dispatchId"), 1L, 1);

                    b.Property<DateTime>("addedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("carriage")
                        .HasColumnType("real");

                    b.Property<string>("custAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("custContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("custName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("deliveryNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dispatchCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fromDept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("hoisting")
                        .HasColumnType("real");

                    b.Property<string>("hoistingBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("loading")
                        .HasColumnType("real");

                    b.Property<string>("salesOrderNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salesPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("shifting")
                        .HasColumnType("real");

                    b.Property<string>("toDept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dispatchId");

                    b.ToTable("outwardGatePass");
                });

            modelBuilder.Entity("GatePass_Models.UOMModel", b =>
                {
                    b.Property<int>("unitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("unitId"), 1L, 1);

                    b.Property<string>("unitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("unitId");

                    b.ToTable("UOM");

                    b.HasData(
                        new
                        {
                            unitId = 1,
                            unitName = "No's"
                        },
                        new
                        {
                            unitId = 2,
                            unitName = "kg"
                        },
                        new
                        {
                            unitId = 3,
                            unitName = "mm"
                        },
                        new
                        {
                            unitId = 4,
                            unitName = "cm"
                        },
                        new
                        {
                            unitId = 5,
                            unitName = "sqft"
                        });
                });

            modelBuilder.Entity("GatePass_Models.VehicleTypeModel", b =>
                {
                    b.Property<int>("vehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vehicleTypeId"), 1L, 1);

                    b.Property<string>("vehicleTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("vehicleTypeId");

                    b.ToTable("vehicleTypes");

                    b.HasData(
                        new
                        {
                            vehicleTypeId = 1,
                            vehicleTypeName = "Car"
                        },
                        new
                        {
                            vehicleTypeId = 2,
                            vehicleTypeName = "Truck"
                        },
                        new
                        {
                            vehicleTypeId = 3,
                            vehicleTypeName = "Cargo Van"
                        },
                        new
                        {
                            vehicleTypeId = 4,
                            vehicleTypeName = "Bus"
                        },
                        new
                        {
                            vehicleTypeId = 5,
                            vehicleTypeName = "Motorcycle"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GatePass_Models.dispatchItems", b =>
                {
                    b.HasOne("GatePass_Models.OutwardGatePassModel", null)
                        .WithMany("dispatchItems")
                        .HasForeignKey("OutwardGatePassModeldispatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GatePass_Models.ItemsModel", b =>
                {
                    b.HasOne("GatePass_Models.InwardGatePassModel", null)
                        .WithMany("itemDetails")
                        .HasForeignKey("InwardGatePassModelGatePassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GatePass_Models.InwardGatePassModel", b =>
                {
                    b.Navigation("itemDetails");
                });

            modelBuilder.Entity("GatePass_Models.OutwardGatePassModel", b =>
                {
                    b.Navigation("dispatchItems");
                });
#pragma warning restore 612, 618
        }
    }
}
