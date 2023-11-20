using System;
using System.Collections.Generic;
using GameGraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGraphQLAPI.Context;

public partial class GamesDBContext : DbContext
{
    public GamesDBContext()
    {
    }

    public GamesDBContext(DbContextOptions<GamesDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Editor> Editors { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=admin;database=GamesDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Editor>(entity =>
        {
            entity.HasKey(e => e.EditorId).HasName("PRIMARY");

            entity.ToTable("Editor");

            entity.Property(e => e.EditorId)
                .ValueGeneratedNever()
                .HasColumnName("EditorID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PRIMARY");

            entity.ToTable("Game");

            entity.Property(e => e.GameId)
                .ValueGeneratedNever()
                .HasColumnName("GameID");
            entity.Property(e => e.Genres).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Platform).HasMaxLength(255);

            entity.HasMany(d => d.Editors).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GameEditor",
                    r => r.HasOne<Editor>().WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("GameEditor_ibfk_2"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("GameEditor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("GameId", "EditorId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("GameEditor");
                        j.HasIndex(new[] { "EditorId" }, "EditorID");
                        j.IndexerProperty<int>("GameId").HasColumnName("GameID");
                        j.IndexerProperty<int>("EditorId").HasColumnName("EditorID");
                    });

            entity.HasMany(d => d.Studios).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GameStudio",
                    r => r.HasOne<Studio>().WithMany()
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("GameStudio_ibfk_2"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("GameStudio_ibfk_1"),
                    j =>
                    {
                        j.HasKey("GameId", "StudioId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("GameStudio");
                        j.HasIndex(new[] { "StudioId" }, "StudioID");
                        j.IndexerProperty<int>("GameId").HasColumnName("GameID");
                        j.IndexerProperty<int>("StudioId").HasColumnName("StudioID");
                    });
        });

        modelBuilder.Entity<Studio>(entity =>
        {
            entity.HasKey(e => e.StudioId).HasName("PRIMARY");

            entity.ToTable("Studio");

            entity.Property(e => e.StudioId)
                .ValueGeneratedNever()
                .HasColumnName("StudioID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
