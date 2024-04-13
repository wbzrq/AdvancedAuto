using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAuto.database;

public partial class AdvancedautoContext : DbContext
{
    public AdvancedautoContext()
    {
    }

    public AdvancedautoContext(DbContextOptions<AdvancedautoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carimage> Carimages { get; set; }

    public virtual DbSet<Interiorimage> Interiorimages { get; set; }

    public virtual DbSet<Teaserauto> Teaserautos { get; set; }

    public virtual DbSet<Teaserwheel> Teaserwheels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=advancedauto;Username=postgres;Password=sqlbetter");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carimage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carimages_pkey");

            entity.ToTable("carimages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasColumnName("color");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.View)
                .HasMaxLength(255)
                .HasColumnName("view");
        });

        modelBuilder.Entity<Interiorimage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("interiorimages_pkey");

            entity.ToTable("interiorimages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .HasColumnName("brand");
            entity.Property(e => e.InteriorPath)
                .HasMaxLength(255)
                .HasColumnName("interior_path");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
        });

        modelBuilder.Entity<Teaserauto>(entity =>
        {
            entity.HasKey(e => e.IdTeaserauto).HasName("teaserauto_pkey");

            entity.ToTable("teaserauto");

            entity.Property(e => e.IdTeaserauto).HasColumnName("id_teaserauto");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .HasColumnName("brand");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
        });

        modelBuilder.Entity<Teaserwheel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teaserwheels_pkey");

            entity.ToTable("teaserwheels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .HasColumnName("brand");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.TwPath)
                .HasMaxLength(255)
                .HasColumnName("tw_path");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
