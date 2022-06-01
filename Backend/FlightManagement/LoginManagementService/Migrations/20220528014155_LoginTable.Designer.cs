﻿// <auto-generated />
using LoginManagementService.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoginManagementService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220528014155_LoginTable")]
    partial class LoginTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoginManagementService.Models.AdminLogin", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.HasKey("UserName");

                    b.ToTable("adminlogin");
                });

            modelBuilder.Entity("LoginManagementService.Models.UserLogin", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailID")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("userlogin");
                });
#pragma warning restore 612, 618
        }
    }
}