using DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SamplePoolDBContext : DbContext
{
    public SamplePoolDBContext(DbContextOptions<SamplePoolDBContext> options) : base(options)
    {

    }

    // Sample Pool Tables (DbSets)
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Pool> Pools { get; set; }
    public DbSet<PoolMember> PoolMembers { get; set; }
    public DbSet<BracketMember> BracketMembers { get; set; }

    // Uses onModelCreating to define composite key in PoolMember class
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Specifying foreign keys and composite primary keys
        modelBuilder.Entity<Pool>()
            .HasOne(p => p.UserProfile)
            .WithMany(u => u.Pools)
            .HasForeignKey(p => p.HostFK)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PoolMember>()
            .HasKey(table => new { table.UsernameFK, table.PoolNameFK });

        modelBuilder.Entity<PoolMember>()
            .HasOne(pm => pm.UserProfile)
            .WithMany(u => u.Members)
            .HasForeignKey(pm => pm.UsernameFK)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PoolMember>()
            .HasOne(pm => pm.Pool)
            .WithMany(p => p.Members)
            .HasForeignKey(pm => pm.PoolNameFK)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BracketMember>()
            .HasKey(table => new { table.UserFK, table.PoolIdFK, table.OrderOut });

        modelBuilder.Entity<BracketMember>()
            .HasOne(b => b.UserProfile)
            .WithMany(u => u.Brackets)
            .HasForeignKey(b => b.UserFK)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BracketMember>()
            .HasOne(b => b.Pool)
            .WithMany(p => p.Brackets)
            .HasForeignKey(b => b.PoolIdFK)
            .OnDelete(DeleteBehavior.Restrict);
    }
}