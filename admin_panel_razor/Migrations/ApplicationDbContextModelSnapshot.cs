﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using admin_panel_razor.Data;

#nullable disable

namespace admin_panel_razor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            

            modelBuilder.Entity("admin_panel_razor.Models.AboutUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("admin_panel_razor.Models.BidValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BidValues");
                });

            modelBuilder.Entity("admin_panel_razor.Models.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrimaryEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrimaryTollFreeNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondaryEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondaryTollFreeNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("admin_panel_razor.Models.GameConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminCommission")
                        .HasColumnType("integer");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SignupBonus")
                        .HasColumnType("integer");

                    b.Property<string>("SupportMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WhatsappLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("YoutubeLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GameConfigs");
                });

            modelBuilder.Entity("admin_panel_razor.Models.GeneralSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FooterCopyright")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebsiteDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebsiteKeyword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebsiteName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebsiteTagline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebsiteURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GeneralSettings");
                });

            modelBuilder.Entity("admin_panel_razor.Models.LogoSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Favicon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FooterLogo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HeaderLogo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LogoSettings");
                });

            modelBuilder.Entity("admin_panel_razor.Models.PrivacyPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("privacyPolicies");
                });

            modelBuilder.Entity("admin_panel_razor.Models.ShopCoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ShopCoins");
                });

            modelBuilder.Entity("admin_panel_razor.Models.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GitHub")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pinterest")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Twitter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("YouTube")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("admin_panel_razor.Models.TermsAndConditions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("TermsAndConditions");
                });

            modelBuilder.Entity("admin_panel_razor.Models.Transaction", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TxnId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("admin_panel_razor.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("WalletAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("WinAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("admin_panel_razor.Models.WithdrawRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RequestId"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("RequestId");

                    b.ToTable("WithdrawRequests");
                });

           
#pragma warning restore 612, 618
        }
    }
}
