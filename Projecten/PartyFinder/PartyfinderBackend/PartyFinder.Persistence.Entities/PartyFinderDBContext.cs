using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PartyFinder.Persistence.Entities;

public class PartyFinderDBContext : DbContext
{
    public PartyFinderDBContext() { }

    public PartyFinderDBContext(DbContextOptions<PartyFinderDBContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Store MemberState as string
        modelBuilder
            .Entity<Member>()
            .Property(m => m.State)
            .HasConversion<string>()
            .HasMaxLength(50);

        modelBuilder
            .Entity<PreLobby>()
            .Property(pl => pl.PreLobbyState)
            .HasConversion<string>()
            .HasMaxLength(25);
        modelBuilder.Entity<Member>().HasIndex(m => m.Username).IsUnique();
        modelBuilder.Entity<Member>().HasIndex(m => m.IdentityServerId).IsUnique();
    }

    public DbSet<Lobby> Lobbies { get; set; }
    public DbSet<Member> Members { get; set; }

    public DbSet<QueueParty> QueueParties { get; set; }

    public DbSet<PreLobby> PreLobbies { get; set; }
}
