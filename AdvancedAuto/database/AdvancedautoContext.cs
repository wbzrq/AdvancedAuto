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

    public virtual DbSet<Teaserauto> Teaserautos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=advancedauto;Username=postgres;Password=sqlbetter");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
