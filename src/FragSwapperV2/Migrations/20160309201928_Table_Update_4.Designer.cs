using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using FragSwapperV2.Models;

namespace FragSwapperV2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160309201928_Table_Update_4")]
    partial class Table_Update_4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FragSwapperV2.Models.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("DestinationURL")
                        .IsRequired();

                    b.Property<DateTime>("EndSDateTime");

                    b.Property<int?>("EventID");

                    b.Property<string>("ImageURL")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<DateTime>("StartSDateTime");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.AdvertisementAdministrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdvertisementID");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.AdvertisementHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvertisementID");

                    b.Property<int>("Clicked");

                    b.Property<int>("Month");

                    b.Property<int>("Shown");

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("AdvertisementID", "Year", "Month")
                        .IsUnique();
                });

            modelBuilder.Entity("FragSwapperV2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("oldSwapperKey");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("FragSwapperV2.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountType");

                    b.Property<DateTime>("ArchiveSDateTime");

                    b.Property<DateTime>("EventDate");

                    b.Property<DateTime>("EventDaySDateTime");

                    b.Property<int?>("HostID")
                        .IsRequired();

                    b.Property<string>("LocationFormattedAddress");

                    b.Property<string>("LocationLat");

                    b.Property<string>("LocationLng");

                    b.Property<bool>("LocationServices");

                    b.Property<string>("LocationType");

                    b.Property<bool>("ModuleCarPool");

                    b.Property<bool>("ModuleChatRoom");

                    b.Property<bool>("ModuleSpecialRequestBoard");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("OpenSDateTime");

                    b.Property<DateTime>("PostEventSDateTime");

                    b.Property<int>("Status");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.EventAdministrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("EventID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.Host", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime?>("AccountExpiration");

                    b.Property<int>("AccountType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.HostAdministrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("HostID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message");

                    b.Property<int>("Type");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.State", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("RegionID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.v1Swapper", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Address2")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool>("AllowEmail");

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("CratedOn");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool>("EmailTrades");

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LaseName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Location")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 12);

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 2);

                    b.Property<int>("SwapperKey");

                    b.Property<string>("SwapperName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("WishList")
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Zip")
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("ID");

                    b.HasIndex("SwapperKey")
                        .IsUnique();
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("FragSwapperV2.Models.Advertisement", b =>
                {
                    b.HasOne("FragSwapperV2.Models.Event")
                        .WithMany()
                        .HasForeignKey("EventID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.AdvertisementAdministrator", b =>
                {
                    b.HasOne("FragSwapperV2.Models.Advertisement")
                        .WithMany()
                        .HasForeignKey("AdvertisementID");

                    b.HasOne("FragSwapperV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("FragSwapperV2.Models.AdvertisementHistory", b =>
                {
                    b.HasOne("FragSwapperV2.Models.Advertisement")
                        .WithMany()
                        .HasForeignKey("AdvertisementID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.Event", b =>
                {
                    b.HasOne("FragSwapperV2.Models.Host")
                        .WithMany()
                        .HasForeignKey("HostID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.EventAdministrator", b =>
                {
                    b.HasOne("FragSwapperV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("FragSwapperV2.Models.Event")
                        .WithMany()
                        .HasForeignKey("EventID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.HostAdministrator", b =>
                {
                    b.HasOne("FragSwapperV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("FragSwapperV2.Models.Host")
                        .WithMany()
                        .HasForeignKey("HostID");
                });

            modelBuilder.Entity("FragSwapperV2.Models.State", b =>
                {
                    b.HasOne("FragSwapperV2.Models.Region")
                        .WithMany()
                        .HasForeignKey("RegionID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FragSwapperV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FragSwapperV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("FragSwapperV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
