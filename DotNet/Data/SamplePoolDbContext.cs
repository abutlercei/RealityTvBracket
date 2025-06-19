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

        // Seeds data when context is created
        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile { Username = "rrosalind", Name = "Rosalind", Password = "password" },
            new UserProfile { Username = "jjeff", Name = "Jeff", Password = "password" },
            new UserProfile { Username = "abutler", Name = "Alex", Password = "password" },
            new UserProfile { Username = "nnina", Name = "Nina", Password = "password" },
            new UserProfile { Username = "ppatrica", Name = "Patrica", Password = "password" },
            new UserProfile { Username = "kkelley", Name = "Kelley", Password = "password" },
            new UserProfile { Username = "jjayden", Name = "Jayden", Password = "password" },
            new UserProfile { Username = "ttaylor", Name = "Taylor", Password = "password" },
            new UserProfile { Username = "pparis", Name = "Paris", Password = "password" },
            new UserProfile { Username = "kkathleen", Name = "Kathleen", Password = "password" },
            new UserProfile { Username = "aadam", Name = "Adam", Password = "password" },
            new UserProfile { Username = "sstephan", Name = "Stephan", Password = "password" },
            new UserProfile { Username = "ffrancis", Name = "Francis", Password = "password" },
            new UserProfile { Username = "aapril", Name = "April", Password = "password" },
            new UserProfile { Username = "llucy", Name = "Lucy", Password = "password" },
            new UserProfile { Username = "mmorgan", Name = "Morgan", Password = "password" }
        );

        modelBuilder.Entity<Pool>().HasData(
            new Pool
            {
                Id = 1,
                Name = "Lone Survivors",
                SourceName = "Survivor Season 1",
                SourceLink = "https://en.wikipedia.org/wiki/Survivor:_Borneo",
                HostFK = "abutler",
                Bio = "Join this test league to see other features within the environment. As Survivor Season 1 aired in 2000, this current league is closed for actual participants. This pool shows a type where participants gain points as their contestant stays in the competition. The other type of pool allows players to guess when contestants get eliminated similar to NCAA brackets."
            },
            new Pool
            {
                Id = 2,
                Name = "Lone Survivors Revival",
                SourceName = "Survivor Season 2",
                SourceLink = "https://en.wikipedia.org/wiki/Survivor:_The_Australian_Outback",
                HostFK = "abutler",
                Bio = "Here is another test league to see how data can transition within the application. Survivor Season 2 allows us to see how to use the same host name and participants within a new pool."
            },
            new Pool
            {
                Id = 3,
                Name = "Lone Survivors Final Boss",
                SourceName = "Survivor Season 3",
                SourceLink = "https://en.wikipedia.org/wiki/Survivor:_Africa",
                HostFK = "abutler",
                Bio = "We have another Survivor league! Our fake participants hyped up the stakes and did their final season with our league."
            }
        );

        modelBuilder.Entity<PoolMember>().HasData(
            new PoolMember { UsernameFK = "rrosalind", PoolNameFK = 1, Rank = 1, Points = 15, Contestant = "Richard" },
            new PoolMember { UsernameFK = "jjeff", PoolNameFK = 1, Rank = 2, Points = 14, Contestant = "Kelly" },
            new PoolMember { UsernameFK = "abutler", PoolNameFK = 1, Rank = 3, Points = 13, Contestant = "Rudy" },
            new PoolMember { UsernameFK = "nnina", PoolNameFK = 1, Rank = 4, Points = 12, Contestant = "Susan" },
            new PoolMember { UsernameFK = "ppatrica", PoolNameFK = 1, Rank = 5, Points = 11, Contestant = "Sean" },
            new PoolMember { UsernameFK = "kkelley", PoolNameFK = 1, Rank = 6, Points = 10, Contestant = "Coleen" },
            new PoolMember { UsernameFK = "jjayden", PoolNameFK = 1, Rank = 7, Points = 9, Contestant = "Gervase" },
            new PoolMember { UsernameFK = "ttaylor", PoolNameFK = 1, Rank = 8, Points = 8, Contestant = "Jenna" },
            new PoolMember { UsernameFK = "pparis", PoolNameFK = 1, Rank = 9, Points = 7, Contestant = "Greg" },
            new PoolMember { UsernameFK = "kkathleen", PoolNameFK = 1, Rank = 10, Points = 6, Contestant = "Gretchen" },
            new PoolMember { UsernameFK = "aadam", PoolNameFK = 1, Rank = 11, Points = 5, Contestant = "Joel" },
            new PoolMember { UsernameFK = "sstephan", PoolNameFK = 1, Rank = 12, Points = 4, Contestant = "Dirk" },
            new PoolMember { UsernameFK = "ffrancis", PoolNameFK = 1, Rank = 13, Points = 3, Contestant = "Ramona" },
            new PoolMember { UsernameFK = "aapril", PoolNameFK = 1, Rank = 14, Points = 2, Contestant = "Stacey" },
            new PoolMember { UsernameFK = "llucy", PoolNameFK = 1, Rank = 15, Points = 1, Contestant = "BB" },
            new PoolMember { UsernameFK = "mmorgan", PoolNameFK = 1, Rank = 16, Points = 0, Contestant = "Sonja" },
            new PoolMember { UsernameFK = "ttaylor", PoolNameFK = 2, Rank = 1, Points = 15, Contestant = "Tina" },
            new PoolMember { UsernameFK = "aadam", PoolNameFK = 2, Rank = 2, Points = 14, Contestant = "Colby" },
            new PoolMember { UsernameFK = "mmorgan", PoolNameFK = 2, Rank = 3, Points = 13, Contestant = "Keith" },
            new PoolMember { UsernameFK = "nnina", PoolNameFK = 2, Rank = 4, Points = 12, Contestant = "Elisabeth" },
            new PoolMember { UsernameFK = "jjayden", PoolNameFK = 2, Rank = 5, Points = 11, Contestant = "Rodger" },
            new PoolMember { UsernameFK = "kkelley", PoolNameFK = 2, Rank = 6, Points = 10, Contestant = "Amber" },
            new PoolMember { UsernameFK = "kkathleen", PoolNameFK = 2, Rank = 7, Points = 9, Contestant = "Nick" },
            new PoolMember { UsernameFK = "pparis", PoolNameFK = 2, Rank = 8, Points = 8, Contestant = "Jerri" },
            new PoolMember { UsernameFK = "ffrancis", PoolNameFK = 2, Rank = 9, Points = 7, Contestant = "Alicia" },
            new PoolMember { UsernameFK = "aapril", PoolNameFK = 2, Rank = 10, Points = 6, Contestant = "Jeff" },
            new PoolMember { UsernameFK = "llucy", PoolNameFK = 2, Rank = 11, Points = 5, Contestant = "Michael" },
            new PoolMember { UsernameFK = "sstephan", PoolNameFK = 2, Rank = 12, Points = 4, Contestant = "Kimmi" },
            new PoolMember { UsernameFK = "abutler", PoolNameFK = 2, Rank = 13, Points = 3, Contestant = "Mitchell" },
            new PoolMember { UsernameFK = "ppatrica", PoolNameFK = 2, Rank = 14, Points = 2, Contestant = "Maralyn" },
            new PoolMember { UsernameFK = "rrosalind", PoolNameFK = 2, Rank = 15, Points = 1, Contestant = "Kel" },
            new PoolMember { UsernameFK = "jjeff", PoolNameFK = 2, Rank = 16, Points = 0, Contestant = "Debb" },
            new PoolMember { UsernameFK = "pparis", PoolNameFK = 3, Rank = 1, Points = 15, Contestant = "Kim J" },
            new PoolMember { UsernameFK = "mmorgan", PoolNameFK = 3, Rank = 2, Points = 14, Contestant = "Ethan" },
            new PoolMember { UsernameFK = "aapril", PoolNameFK = 3, Rank = 3, Points = 13, Contestant = "Lex" },
            new PoolMember { UsernameFK = "nnina", PoolNameFK = 3, Rank = 4, Points = 12, Contestant = "Tom" },
            new PoolMember { UsernameFK = "ttaylor", PoolNameFK = 3, Rank = 5, Points = 11, Contestant = "Teresa" },
            new PoolMember { UsernameFK = "jjeff", PoolNameFK = 3, Rank = 6, Points = 10, Contestant = "Kim P" },
            new PoolMember { UsernameFK = "kkathleen", PoolNameFK = 3, Rank = 7, Points = 9, Contestant = "Frank" },
            new PoolMember { UsernameFK = "ppatrica", PoolNameFK = 3, Rank = 8, Points = 8, Contestant = "Brandon" },
            new PoolMember { UsernameFK = "kkelley", PoolNameFK = 3, Rank = 9, Points = 7, Contestant = "Kelly" },
            new PoolMember { UsernameFK = "abutler", PoolNameFK = 3, Rank = 10, Points = 6, Contestant = "Clarence" },
            new PoolMember { UsernameFK = "sstephan", PoolNameFK = 3, Rank = 11, Points = 5, Contestant = "Lindsey" },
            new PoolMember { UsernameFK = "ffrancis", PoolNameFK = 3, Rank = 12, Points = 4, Contestant = "Silas" },
            new PoolMember { UsernameFK = "llucy", PoolNameFK = 3, Rank = 13, Points = 3, Contestant = "Linda" },
            new PoolMember { UsernameFK = "aadam", PoolNameFK = 3, Rank = 14, Points = 2, Contestant = "Carl" },
            new PoolMember { UsernameFK = "rrosalind", PoolNameFK = 3, Rank = 15, Points = 1, Contestant = "Jessie" },
            new PoolMember { UsernameFK = "jjayden", PoolNameFK = 3, Rank = 16, Points = 0, Contestant = "Diane" }
        );

        // Connect current methods within DataRepository interface & DataController
        // Transfer to individual controllers & fix GET/POST requests
        // Move to frontend fixes
    }
}