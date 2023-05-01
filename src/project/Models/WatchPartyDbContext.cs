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

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reshare> Reshares { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<WatchList> WatchLists { get; set; }

    public virtual DbSet<WatchListItem> WatchListItems { get; set; }

    public virtual DbSet<WatchPartyGroup> WatchPartyGroups { get; set; }

    public virtual DbSet<WatchPartyGroupAssignment> WatchPartyGroupAssignments { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC277F56B4D9");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Comment_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Comment_UserID");
        });

        modelBuilder.Entity<FollowingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Followin__3214EC27F07B56C6");

            entity.HasOne(d => d.Following).WithMany(p => p.FollowingListFollowings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_FollowingList_FollowingID");

            entity.HasOne(d => d.User).WithMany(p => p.FollowingListUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_FollowingList_UserID");
        });

        modelBuilder.Entity<LikePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LikePost__3214EC27D30BF0D6");

            entity.HasOne(d => d.Post).WithMany(p => p.LikePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.LikePosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_UserID");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC2762597F36");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC27C39740AA");

            entity.HasOne(d => d.NotifType).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Notification_NotifTypeID");

            entity.HasOne(d => d.Notifier).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Notification_NotifierID");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC27C500D1E8");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC279D8FF74E");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Post_UserID");
        });

        modelBuilder.Entity<Reshare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reshare__3214EC27C6C8AFF0");

            entity.HasOne(d => d.Post).WithMany(p => p.Reshares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.Reshares)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_UserID");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Show__3214EC2776CB92F1");
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchLis__3214EC27499102AE");

            entity.HasOne(d => d.User).WithMany(p => p.WatchLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchList_UserID");
        });

        modelBuilder.Entity<WatchListItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchLis__3214EC27E520B872");

            entity.HasOne(d => d.Movie).WithMany(p => p.WatchListItems).HasConstraintName("Fk_WatchListItems_Movie");

            entity.HasOne(d => d.Show).WithMany(p => p.WatchListItems).HasConstraintName("Fk_WatchListItems_Show");

            entity.HasOne(d => d.WatchList).WithMany(p => p.WatchListItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchListItems_WatchList");
        });

        modelBuilder.Entity<WatchPartyGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchPar__3214EC27083B47D8");

            entity.HasOne(d => d.Host).WithMany(p => p.WatchPartyGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchPartyGroup_Watcher");
        });

        modelBuilder.Entity<WatchPartyGroupAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WatchPar__3214EC2700E920DD");

            entity.HasOne(d => d.Group).WithMany(p => p.WatchPartyGroupAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchPartyGroupAssignment_WatchPartyGroup");

            entity.HasOne(d => d.Watcher).WithMany(p => p.WatchPartyGroupAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_WatchPartyGroupAssignment_Watcher");
        });

        modelBuilder.Entity<Watcher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Watcher__3214EC07816AE94B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
