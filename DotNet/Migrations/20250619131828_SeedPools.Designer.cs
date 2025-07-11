﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNet.Migrations
{
    [DbContext(typeof(SamplePoolDBContext))]
    [Migration("20250619131828_SeedPools")]
    partial class SeedPools
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNet.Models.Pool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostFK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HostFK");

                    b.ToTable("Pools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Join this test league to see other features within the environment. As Survivor Season 1 aired in 2000, this current league is closed for actual participants. This pool shows a type where participants gain points as their contestant stays in the competition. The other type of pool allows players to guess when contestants get eliminated similar to NCAA brackets.",
                            HostFK = "abutler",
                            Name = "Lone Survivors",
                            SourceLink = "https://en.wikipedia.org/wiki/Survivor:_Borneo",
                            SourceName = "Survivor Season 1"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Here is another test league to see how data can transition within the application. Survivor Season 2 allows us to see how to use the same host name and participants within a new pool.",
                            HostFK = "abutler",
                            Name = "Lone Survivors Revival",
                            SourceLink = "https://en.wikipedia.org/wiki/Survivor:_The_Australian_Outback",
                            SourceName = "Survivor Season 2"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "We have another Survivor league! Our fake participants hyped up the stakes and did their final season with our league.",
                            HostFK = "abutler",
                            Name = "Lone Survivors Final Boss",
                            SourceLink = "https://en.wikipedia.org/wiki/Survivor:_Africa",
                            SourceName = "Survivor Season 3"
                        });
                });

            modelBuilder.Entity("DotNet.Models.PoolMember", b =>
                {
                    b.Property<string>("UsernameFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PoolNameFK")
                        .HasColumnType("int");

                    b.Property<string>("Contestant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<int?>("Rank")
                        .HasColumnType("int");

                    b.HasKey("UsernameFK", "PoolNameFK");

                    b.HasIndex("PoolNameFK");

                    b.ToTable("PoolMembers");
                });

            modelBuilder.Entity("DotNet.Models.UserProfile", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Username = "rrosalind",
                            Name = "Rosalind",
                            Password = "password"
                        },
                        new
                        {
                            Username = "jjeff",
                            Name = "Jeff",
                            Password = "password"
                        },
                        new
                        {
                            Username = "abutler",
                            Name = "Alex",
                            Password = "password"
                        },
                        new
                        {
                            Username = "nnina",
                            Name = "Nina",
                            Password = "password"
                        },
                        new
                        {
                            Username = "ppatrica",
                            Name = "Patrica",
                            Password = "password"
                        },
                        new
                        {
                            Username = "kkelley",
                            Name = "Kelley",
                            Password = "password"
                        },
                        new
                        {
                            Username = "jjayden",
                            Name = "Jayden",
                            Password = "password"
                        },
                        new
                        {
                            Username = "ttaylor",
                            Name = "Taylor",
                            Password = "password"
                        },
                        new
                        {
                            Username = "pparis",
                            Name = "Paris",
                            Password = "password"
                        },
                        new
                        {
                            Username = "kkathleen",
                            Name = "Kathleen",
                            Password = "password"
                        },
                        new
                        {
                            Username = "aadam",
                            Name = "Adam",
                            Password = "password"
                        },
                        new
                        {
                            Username = "sstephan",
                            Name = "Stephan",
                            Password = "password"
                        },
                        new
                        {
                            Username = "ffrancis",
                            Name = "Francis",
                            Password = "password"
                        },
                        new
                        {
                            Username = "aapril",
                            Name = "April",
                            Password = "password"
                        },
                        new
                        {
                            Username = "llucy",
                            Name = "Lucy",
                            Password = "password"
                        },
                        new
                        {
                            Username = "mmorgan",
                            Name = "Morgan",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("DotNet.Models.Pool", b =>
                {
                    b.HasOne("DotNet.Models.UserProfile", "UserProfile")
                        .WithMany("Pools")
                        .HasForeignKey("HostFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DotNet.Models.PoolMember", b =>
                {
                    b.HasOne("DotNet.Models.Pool", "Pool")
                        .WithMany("Members")
                        .HasForeignKey("PoolNameFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DotNet.Models.UserProfile", "UserProfile")
                        .WithMany("Members")
                        .HasForeignKey("UsernameFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pool");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DotNet.Models.Pool", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("DotNet.Models.UserProfile", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Pools");
                });
#pragma warning restore 612, 618
        }
    }
}
