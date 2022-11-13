// <auto-generated />
using System;
using MusicRancho_RanchoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
#nullable disable
namespace MusicRancho_RanchoAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);
            modelBuilder.Entity("MusicRancho_RanchoAPI.Models.ApplicationUser", b =>
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
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");
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
            modelBuilder.Entity("MusicRancho_RanchoAPI.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("LocalUsers");
                });
            modelBuilder.Entity("MusicRancho_RanchoAPI.Models.Rancho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");
                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);
                    b.Property<string>("Amenity")
                        .HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");
                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<int>("Occupancy")
                        .HasColumnType("int");
                    b.Property<double>("Rate")
                        .HasColumnType("float");
                    b.Property<int>("Sqft")
                        .HasColumnType("int");
                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");
                    b.HasKey("Id");
                    b.ToTable("Ranchos");
                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 7, 14, 11, 1, 43, 354, DateTimeKind.Local).AddTicks(4886),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://someWebSite.com/blueranchoimages/rancho3.jpg",
                            Name = "Royal Rancho",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 7, 14, 11, 1, 43, 354, DateTimeKind.Local).AddTicks(4934),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://someWebSite.com/blueranchoimages/rancho1.jpg",
                            Name = "Premium Pool Rancho",
                            Occupancy = 4,
                            Rate = 300.0,
                            Sqft = 550,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 7, 14, 11, 1, 43, 354, DateTimeKind.Local).AddTicks(4936),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://someWebSite.com/blueranchoimages/rancho4.jpg",
                            Name = "Luxury Pool Rancho",
                            Occupancy = 4,
                            Rate = 400.0,
                            Sqft = 750,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 7, 14, 11, 1, 43, 354, DateTimeKind.Local).AddTicks(4939),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://someWebSite.com/blueranchoimages/rancho5.jpg",
                            Name = "Diamond Rancho",
                            Occupancy = 4,
                            Rate = 550.0,
                            Sqft = 900,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(2022, 7, 14, 11, 1, 43, 354, DateTimeKind.Local).AddTicks(4941),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://someWebSite.com/blueranchoimages/rancho2.jpg",
                            Name = "Diamond Pool Rancho",
                            Occupancy = 4,
                            Rate = 600.0,
                            Sqft = 1100,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
            modelBuilder.Entity("MusicRancho_RanchoAPI.Models.RanchoNumber", b =>
                {
                    b.Property<int>("RanchoNo")
                        .HasColumnType("int");
                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");
                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");
                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");
                    b.Property<int>("RanchoID")
                        .HasColumnType("int");
                    b.HasKey("RanchoNo");
                    b.HasIndex("RanchoID");
                    b.ToTable("RanchoNumbers");
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
            modelBuilder.Entity("MusicRancho_RanchoAPI.Models.RanchoNumber", b =>
                {
                    b.HasOne("MusicRancho_RanchoAPI.Models.Rancho", "Rancho")
                        .WithMany()
                        .HasForeignKey("RanchoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                    b.Navigation("Rancho");
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
                    b.HasOne("MusicRancho_RanchoAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MusicRancho_RanchoAPI.Models.ApplicationUser", null)
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
                    b.HasOne("MusicRancho_RanchoAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MusicRancho_RanchoAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
