using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestReact.Models.Entities;

namespace TestReact.Models.StoredProcedures;

public class StoredProceduresContext : TestReactContext
{
    public StoredProceduresContext()
    {
    }

    public StoredProceduresContext(DbContextOptions<TestReactContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GetAllArticles> GetAllArticles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GetAllArticles>(entity =>
        {
            entity.HasKey(e => e.article_id);
        });
        base.OnModelCreating(modelBuilder);
    }
}