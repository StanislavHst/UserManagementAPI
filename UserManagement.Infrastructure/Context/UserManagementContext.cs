using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Context;

public class UserManagementContext : DbContext
{
    public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetInitialData(modelBuilder);
    }

    private void SetInitialData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = 1, Name = "Admin" },
            new Permission { Id = 2, Name = "User" }
        );
    }
}