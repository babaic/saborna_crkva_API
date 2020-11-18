﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using saborna_crkva_API.EF;

namespace saborna_crkva_API.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201112150522_EditObredZahtjev")]
    partial class EditObredZahtjev
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserOneId");

                    b.Property<bool>("UserOneRead");

                    b.Property<int>("UserTwoId");

                    b.Property<bool>("UserTwoRead");

                    b.HasKey("Id");

                    b.HasIndex("UserOneId");

                    b.HasIndex("UserTwoId");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Donacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<double>("Iznos");

                    b.Property<string>("Poruka");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Donacije");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConversationId");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Novosti", b =>
                {
                    b.Property<int>("NovostiID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumObjavljivanja");

                    b.Property<string>("Naslov");

                    b.Property<byte[]>("Slika");

                    b.Property<string>("Text");

                    b.HasKey("NovostiID");

                    b.ToTable("Novosti");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.NovostiSlike", b =>
                {
                    b.Property<int>("NovostiSlikeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NovostiID");

                    b.Property<byte[]>("Slika");

                    b.HasKey("NovostiSlikeID");

                    b.HasIndex("NovostiID");

                    b.ToTable("NovostiSlike");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Obavjestenja", b =>
                {
                    b.Property<int>("ObavjestenjaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumObjavljivanja");

                    b.Property<string>("Naslov");

                    b.Property<byte[]>("Slika");

                    b.Property<string>("Text");

                    b.HasKey("ObavjestenjaID");

                    b.ToTable("Obavjestenja");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObavjestenjaKategorije", b =>
                {
                    b.Property<int>("ObavjestenjaKategorijeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("ObavjestenjaKategorijeID");

                    b.ToTable("ObavjestenjaKategorije");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObavjestenjaKategorijeObavjestenja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ObavjestenjaID");

                    b.Property<int>("ObavjestenjaKategorijeID");

                    b.HasKey("Id");

                    b.HasIndex("ObavjestenjaID");

                    b.HasIndex("ObavjestenjaKategorijeID");

                    b.ToTable("ObavjestenjaKategorijeObavjestenja");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObavjestenjaSlike", b =>
                {
                    b.Property<int>("ObavjestenjaSlikeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ObavjestenjaID");

                    b.Property<byte[]>("Slika");

                    b.HasKey("ObavjestenjaSlikeID");

                    b.HasIndex("ObavjestenjaID");

                    b.ToTable("ObavjestenjaSlike");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObredKategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("ObredKategorija");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObredZahtjev", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("ObredKategorijaId");

                    b.Property<string>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ObredKategorijaId");

                    b.HasIndex("UserId");

                    b.ToTable("ObredZahtjev");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Adresa");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Ime");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prezime");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("saborna_crkva_API.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Conversation", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.User", "UserOne")
                        .WithMany()
                        .HasForeignKey("UserOneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("saborna_crkva_API.Models.User", "UserTwo")
                        .WithMany()
                        .HasForeignKey("UserTwoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Donacije", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.Message", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.Conversation", "Conversation")
                        .WithMany()
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("saborna_crkva_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.NovostiSlike", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.Novosti", "Novosti")
                        .WithMany()
                        .HasForeignKey("NovostiID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObavjestenjaKategorijeObavjestenja", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.Obavjestenja", "Obavjestenja")
                        .WithMany()
                        .HasForeignKey("ObavjestenjaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("saborna_crkva_API.Models.ObavjestenjaKategorije", "ObavjestenjaKategorije")
                        .WithMany()
                        .HasForeignKey("ObavjestenjaKategorijeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObavjestenjaSlike", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.Obavjestenja", "Obavjestenja")
                        .WithMany()
                        .HasForeignKey("ObavjestenjaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.ObredZahtjev", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.ObredKategorija", "ObredKategorija")
                        .WithMany()
                        .HasForeignKey("ObredKategorijaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("saborna_crkva_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("saborna_crkva_API.Models.UserRole", b =>
                {
                    b.HasOne("saborna_crkva_API.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("saborna_crkva_API.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
