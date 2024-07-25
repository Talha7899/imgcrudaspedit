using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Image_Crud_in_Asp.Models;

public partial class ImgCrudContext : DbContext
{
    public ImgCrudContext()
    {
    }

    public ImgCrudContext(DbContextOptions<ImgCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=.;initial catalog=ImgCrud;user id=sa;password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Catid).HasName("PK__Categori__6A1D86D21A9EC513");

            entity.Property(e => e.CatName).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Items__3214EC0715F920A6");

            entity.Property(e => e.Pname).HasMaxLength(50);

            entity.HasOne(d => d.Cat).WithMany(p => p.Items)
                .HasForeignKey(d => d.Catid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
