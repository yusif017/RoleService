﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoleMenecment.Data;

#nullable disable

namespace RoleMenecment.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250628162810_SeedTwoUsersWithRolesCorrect")]
    partial class SeedTwoUsersWithRolesCorrect
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoleMenecment.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3f01a5b-c6f1-4f9e-8425-97e2e2c02a5e"),
                            Name = "Product.Create"
                        },
                        new
                        {
                            Id = new Guid("e19d62d4-c3a7-4c1b-84aa-fb54505db8b1"),
                            Name = "Product.Update"
                        },
                        new
                        {
                            Id = new Guid("f27e5d1a-7ad6-41b7-8d45-0f65b2d6cd18"),
                            Name = "Product.View"
                        });
                });

            modelBuilder.Entity("RoleMenecment.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3"),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("RoleMenecment.Models.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                            PermissionId = new Guid("a3f01a5b-c6f1-4f9e-8425-97e2e2c02a5e")
                        },
                        new
                        {
                            RoleId = new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                            PermissionId = new Guid("e19d62d4-c3a7-4c1b-84aa-fb54505db8b1")
                        },
                        new
                        {
                            RoleId = new Guid("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3"),
                            PermissionId = new Guid("f27e5d1a-7ad6-41b7-8d45-0f65b2d6cd18")
                        });
                });

            modelBuilder.Entity("RoleMenecment.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            PasswordHash = "demo",
                            UserName = "user1"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            PasswordHash = "demo",
                            UserName = "user2"
                        });
                });

            modelBuilder.Entity("RoleMenecment.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("33333333-3333-3333-3333-333333333333"),
                            RoleId = new Guid("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            UserId = new Guid("33333333-3333-3333-3333-333333333333"),
                            RoleId = new Guid("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            UserId = new Guid("44444444-4444-4444-4444-444444444444"),
                            RoleId = new Guid("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("RoleMenecment.Models.RolePermission", b =>
                {
                    b.HasOne("RoleMenecment.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoleMenecment.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RoleMenecment.Models.UserRole", b =>
                {
                    b.HasOne("RoleMenecment.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoleMenecment.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoleMenecment.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("RoleMenecment.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("RoleMenecment.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
