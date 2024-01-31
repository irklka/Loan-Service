using System.Reflection;

using LoanService.Core.Loan;
using LoanService.Core.User;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoanService.Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public IConfiguration Configuration { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options,
        IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<LoanRequest> LoanRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.EnableDetailedErrors();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Firstname = "Vaja",
                Lastname = "Kacia",
                IdNumber = "01010100032",
                DateOfBirth = new DateTime(1990, 1, 1),
                Email = "Vaja.Kacia@example.com",
                Password = "C62D1C801386EDBDB84735BA14E873B007AF19841A5EC0BE22AD34478FD33086",// tormetii
                Salt = "qzlxcBpNh8pJq5GP1V7OBA=="
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
