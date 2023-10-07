using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ColaboradoresCRUD.Models;

public partial class DatosColaboradoresContext : DbContext
{
    public DatosColaboradoresContext()
    {
    }

    public DatosColaboradoresContext(DbContextOptions<DatosColaboradoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colaboradore> Colaboradores { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("Server=DESKTOP-8RKE13C;Database=DatosColaboradores;User Id=sa;Password=12345;Encrypt=False;Connect Timeout=120;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colaboradore>(entity =>
        {
            entity.HasKey(e => e.ColaboradorId).HasName("PK__Colabora__28AA72C1E3CA1472");

            entity.Property(e => e.ColaboradorId).HasColumnName("ColaboradorID");
            entity.Property(e => e.AfIgss)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AfIGSS");
            entity.Property(e => e.AfIrtra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AfIRTRA");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dpi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DPI");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaNac).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pasaporte)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
