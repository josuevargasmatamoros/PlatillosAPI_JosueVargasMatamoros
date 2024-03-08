using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class PlatillosDbContext : DbContext
{
    public PlatillosDbContext()
    {
    }

    public PlatillosDbContext(DbContextOptions<PlatillosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBebidum> TblBebida { get; set; }

    public virtual DbSet<TblCliente> TblClientes { get; set; }

    public virtual DbSet<TblFactura> TblFacturas { get; set; }

    public virtual DbSet<TblIngrediente> TblIngredientes { get; set; }

    public virtual DbSet<TblPlatillo> TblPlatillos { get; set; }

    public virtual DbSet<TblPlatilloIngrediente> TblPlatilloIngredientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //      => optionsBuilder.UseSqlServer("Server=tcp:azurejosue.database.windows.net,1433;Initial Catalog=Platillos_DB;Persist Security Info=False;User ID=CloudSA32c1bfb5;Password=Josuevm1701;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBebidum>(entity =>
        {
            entity.HasKey(e => e.IdBebida);

            entity.ToTable("tblBebida");

            entity.Property(e => e.IdBebida).HasColumnName("idBebida");
            entity.Property(e => e.CodigoBebida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoBebida");
            entity.Property(e => e.NombreBebida)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombreBebida");
            entity.Property(e => e.PrecioBebidaMililitros)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precioBebidaMililitros");
        });

        modelBuilder.Entity<TblCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_Cliente");

            entity.ToTable("tblCliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("primerApellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("segundoApellido");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono2");
        });

        modelBuilder.Entity<TblFactura>(entity =>
        {
            entity.HasKey(e => e.IdFactura);

            entity.ToTable("tblFactura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.CantidaMililitrosBebida).HasColumnName("cantidaMililitrosBebida");
            entity.Property(e => e.IdBebida).HasColumnName("idBebida");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdPlatillo).HasColumnName("idPlatillo");
            entity.Property(e => e.MontoAntesImpuestos)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("montoAntesImpuestos");
            entity.Property(e => e.MontoIva)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("montoIva");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("montoTotal");
            entity.Property(e => e.TotalBebida)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("totalBebida");
            entity.Property(e => e.TotalPlatillo)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("totalPlatillo");

            entity.HasOne(d => d.IdBebidaNavigation).WithMany(p => p.TblFacturas)
                .HasForeignKey(d => d.IdBebida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblFactura_tblBebida");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblFacturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblFactura_tblCliente");

            entity.HasOne(d => d.IdPlatilloNavigation).WithMany(p => p.TblFacturas)
                .HasForeignKey(d => d.IdPlatillo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblFactura_tblPlatillo");
        });

        modelBuilder.Entity<TblIngrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente);

            entity.ToTable("tblIngrediente");

            entity.Property(e => e.IdIngrediente).HasColumnName("idIngrediente");
            entity.Property(e => e.CodigoIngrediente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigoIngrediente");
            entity.Property(e => e.NombreIngrediente)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombreIngrediente");
            entity.Property(e => e.PrecioIngrediente)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("precioIngrediente");
        });

        modelBuilder.Entity<TblPlatillo>(entity =>
        {
            entity.HasKey(e => e.IdPlatillo);

            entity.ToTable("tblPlatillo");

            entity.Property(e => e.IdPlatillo).HasColumnName("idPlatillo");
            entity.Property(e => e.CodigoPlatillo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("codigoPlatillo");
            entity.Property(e => e.NombrePlatillo)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("nombrePlatillo");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPlatilloIngrediente>(entity =>
        {
            entity.HasKey(e => e.IdPlatilloIngrediente);

            entity.ToTable("tblPlatilloIngrediente");

            entity.Property(e => e.IdPlatilloIngrediente).HasColumnName("idPlatilloIngrediente");
            entity.Property(e => e.IdIngrediente).HasColumnName("idIngrediente");
            entity.Property(e => e.IdPlatillo).HasColumnName("idPlatillo");

            entity.HasOne(d => d.IdIngredienteNavigation).WithMany(p => p.TblPlatilloIngredientes)
                .HasForeignKey(d => d.IdIngrediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPlatilloIngrediente_tblIngrediente");

            entity.HasOne(d => d.IdPlatilloNavigation).WithMany(p => p.TblPlatilloIngredientes)
                .HasForeignKey(d => d.IdPlatillo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPlatilloIngrediente_tblPlatillo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
