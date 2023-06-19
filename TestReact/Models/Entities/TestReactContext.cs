using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestReact.Models.Entities;

public partial class TestReactContext : DbContext
{
    public TestReactContext()
    {
    }

    public TestReactContext(DbContextOptions<TestReactContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TestReactContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__article__3213E83F01A8F21B");

            entity.ToTable("article");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(250)
                .HasColumnName("author");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comment__3213E83FD7C8A13A");

            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.Comment1)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.Pseudo)
                .HasMaxLength(250)
                .HasColumnName("pseudo");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83FD12EB00F");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .HasMaxLength(250)
                .HasColumnName("id");
            entity.Property(e => e.Mail)
                .HasMaxLength(250)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
            entity.Property(e => e.Pseudo)
                .HasMaxLength(250)
                .HasColumnName("pseudo");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("registration_date");
            entity.Property(e => e.Salt).HasColumnName("salt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
