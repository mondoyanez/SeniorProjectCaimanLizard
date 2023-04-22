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

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<FollowingList> FollowingLists { get; set; }

    public virtual DbSet<LikePost> LikePosts { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reshare> Reshares { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<WatchList> WatchLists { get; set; }

    public virtual DbSet<WatchListItem> WatchListItems { get; set; }

    public virtual DbSet<Watcher> Watchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseLazyLoadingProxies()        // <-- add this line
                .UseSqlServer("Name=WatchPartyConnection");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC2777A1926A");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Comment_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Comment_UserID");
        });

        modelBuilder.Entity<FollowingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Followin__3214EC2722A55D86");

            entity.HasOne(d => d.Following).WithMany(p => p.FollowingListFollowings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_FollowingList_FollowingID");

            entity.HasOne(d => d.User).WithMany(p => p.FollowingListUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_FollowingList_UserID");
        });

        modelBuilder.Entity<LikePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LikePost__3214EC27C3301D41");

            entity.HasOne(d => d.Post).WithMany(p => p.LikePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.LikePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_UserID");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC27B679CE08");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC271985CB02");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Post_UserID");
        });

        modelBuilder.Entity<Reshare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reshare__3214EC27A42841E7");

            entity.HasOne(d => d.Post).WithMany(p => p.Reshares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.Reshares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_UserID");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Show__3214EC275F6B7A6D");
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchLis__3214EC27D0E53B50");

            entity.HasOne(d => d.User).WithMany(p => p.WatchLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchList_UserID");
        });

        modelBuilder.Entity<WatchListItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchLis__3214EC27B6B06C50");

            entity.HasOne(d => d.Movie).WithMany(p => p.WatchListItems).HasConstraintName("Fk_WatchListItems_Movie");

            entity.HasOne(d => d.Show).WithMany(p => p.WatchListItems).HasConstraintName("Fk_WatchListItems_Show");

            entity.HasOne(d => d.WatchList).WithMany(p => p.WatchListItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchListItems_WatchList");
        });

        modelBuilder.Entity<Watcher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Watcher__3214EC07185DF15C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
