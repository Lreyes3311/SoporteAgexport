using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FacturaCRUD.Models;

public partial class FacturaDbContext : DbContext
{
    public FacturaDbContext()
    {
    }

    public FacturaDbContext(DbContextOptions<FacturaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-8RKE13C;Database=FacturaDB;User Id=sa;Password=12345;Encrypt=False;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleF__3214EC0740B3BCCE");

            entity.ToTable("DetalleFactura");

            entity.Property(e => e.MontoTotalLinea).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Producto).HasMaxLength(255);

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK__DetalleFa__Factu__398D8EEE");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3214EC077C412917");

            entity.ToTable("Factura");

            entity.Property(e => e.Correlativo).HasMaxLength(50);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nit).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
