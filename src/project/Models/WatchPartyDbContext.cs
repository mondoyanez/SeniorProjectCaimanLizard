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

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Reshare> Reshares { get; set; }

    public virtual DbSet<Watcher> Watchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=WatchPartyConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LikePost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LikePost__3214EC277E15EFA8");

            entity.ToTable("LikePost");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.LikePosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.LikePosts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_LikePost_UserID");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC27E56C014F");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DatePosted).HasColumnType("datetime");
            entity.Property(e => e.PostDescription).HasMaxLength(2048);
            entity.Property(e => e.PostTitle).HasMaxLength(2048);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Post_UserID");
        });

        modelBuilder.Entity<Reshare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reshare__3214EC27ECDA4D1F");

            entity.ToTable("Reshare");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Post).WithMany(p => p.Reshares)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_PostID");

            entity.HasOne(d => d.User).WithMany(p => p.Reshares)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Reshare_UserID");
        });

        modelBuilder.Entity<Watcher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Watcher__3214EC070B2CCAA3");

            entity.ToTable("Watcher");

            entity.Property(e => e.AspNetIdentityId).HasMaxLength(450);
            entity.Property(e => e.Bio).HasMaxLength(256);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(64);
            entity.Property(e => e.LastName).HasMaxLength(64);
            entity.Property(e => e.Username).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
