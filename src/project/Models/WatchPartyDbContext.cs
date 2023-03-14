using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

public partial class WatchPartyDbContext : DbContext
{
    public WatchPartyDbContext()
    {
    }

    public WatchPartyDbContext(DbContextOptions<WatchPartyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LikePost> LikePosts { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reshare> Reshares { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<WatchList> WatchLists { get; set; }

    public virtual DbSet<Watcher> Watchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=WatchPartyConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LikePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LikePost__3214EC2757CFD2C2");

            entity.HasOne(d => d.Post).WithMany(p => p.LikePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.LikePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_UserID");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC27071E8778");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC27E4612162");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Post_UserID");
        });

        modelBuilder.Entity<Reshare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reshare__3214EC27D0CD0B35");

            entity.HasOne(d => d.Post).WithMany(p => p.Reshares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.Reshares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_UserID");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Show__3214EC27C14FFAA2");
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchLis__3214EC275C05BFEF");

            entity.HasOne(d => d.Movie).WithMany(p => p.WatchLists).HasConstraintName("Fk_WatchList_MovieID");

            entity.HasOne(d => d.Show).WithMany(p => p.WatchLists).HasConstraintName("Fk_WatchList_ShowID");

            entity.HasOne(d => d.User).WithMany(p => p.WatchLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchList_UserID");
        });

        modelBuilder.Entity<Watcher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Watcher__3214EC077C8F0D5D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
