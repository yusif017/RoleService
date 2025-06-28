using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoleMenecment.Models;

namespace RoleMenecment.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Composite keys for join tables
    modelBuilder.Entity<RolePermission>()
        .HasKey(rp => new { rp.RoleId, rp.PermissionId });

    modelBuilder.Entity<UserRole>()
        .HasKey(ur => new { ur.UserId, ur.RoleId });

    // Seed Roles
    modelBuilder.Entity<Role>().HasData(
        new Role { Id = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"), Name = "Admin" },
        new Role { Id = Guid.Parse("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3"), Name = "User" }
    );

    // Seed Permissions
    modelBuilder.Entity<Permission>().HasData(
        new Permission { Id = Guid.Parse("a3f01a5b-c6f1-4f9e-8425-97e2e2c02a5e"), Name = "Product.Create" },
        new Permission { Id = Guid.Parse("e19d62d4-c3a7-4c1b-84aa-fb54505db8b1"), Name = "Product.Update" },
        new Permission { Id = Guid.Parse("f27e5d1a-7ad6-41b7-8d45-0f65b2d6cd18"), Name = "Product.View" }
    );

    // Seed RolePermissions
    modelBuilder.Entity<RolePermission>().HasData(
        new RolePermission { RoleId = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"), PermissionId = Guid.Parse("a3f01a5b-c6f1-4f9e-8425-97e2e2c02a5e") },
        new RolePermission { RoleId = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"), PermissionId = Guid.Parse("e19d62d4-c3a7-4c1b-84aa-fb54505db8b1") },
        new RolePermission { RoleId = Guid.Parse("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3"), PermissionId = Guid.Parse("f27e5d1a-7ad6-41b7-8d45-0f65b2d6cd18") }
    );

    // Seed Users
    modelBuilder.Entity<User>().HasData(
        new User
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            UserName = "user1",
            PasswordHash = "demo",
        },
        new User
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            UserName = "user2",
            PasswordHash = "demo",
        }
    );

    // Seed UserRoles
    modelBuilder.Entity<UserRole>().HasData(
        // user1 - Admin + User
        new UserRole
        {
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            RoleId = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538") // Admin
        },
        new UserRole
        {
            UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            RoleId = Guid.Parse("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3") // User
        },
        // user2 - yalnız User
        new UserRole
        {
            UserId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            RoleId = Guid.Parse("d14a1f59-8e8a-4f30-8f16-247d7e47d9c3") // User
        }
    );
}

}
