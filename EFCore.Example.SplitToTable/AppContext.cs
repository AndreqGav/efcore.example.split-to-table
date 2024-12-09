using EFCore.Example.SplitToTable.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore.Example.SplitToTable;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Main>(builder =>
        {
            builder.HasOne(e => e.Details).WithOne()
                .HasForeignKey<Details>(e => e.Id);
        });

        modelBuilder.Entity<Details>(builder =>
        {
            builder.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Blog>(builder =>
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Main).WithOne(e => e.Blog)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Blog>(e => e.MainId);
        });
    }
}

public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
{
    public AppContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;...");

        return new AppContext(optionsBuilder.Options);
    }
}