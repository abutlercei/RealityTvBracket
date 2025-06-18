using DotNet.Models;
using Microsoft.EntityFrameworkCore;

public class SamplePoolDBContext : DbContext
{
    public SamplePoolDBContext(DbContextOptions<SamplePoolDBContext> options): base(options)
    {

    }

    // Sample Pool Tables (DbSets)
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Pool> Pools { get; set; }
    public DbSet<PoolMember> PoolMembers { get; set; }

    // Uses onModelCreating to define composite key in PoolMember class
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoolMember>().HasKey(table => new
        {
            table.Username,
            table.PoolName
        });
    }
}