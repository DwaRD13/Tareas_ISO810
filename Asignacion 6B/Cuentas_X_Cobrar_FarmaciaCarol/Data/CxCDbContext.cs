using System;
using System.Collections.Generic;
using Cuentas_X_Cobrar_FarmaciaCarol.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuentas_X_Cobrar_FarmaciaCarol.Data;

public partial class CxCDbContext : DbContext
{
    public CxCDbContext(DbContextOptions<CxCDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CxC_Documento> CxC_Documentos { get; set; }

    public virtual DbSet<CxC_IntegracionAplicadum> CxC_IntegracionAplicada { get; set; }

    public virtual DbSet<CxC_Movimiento> CxC_Movimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CxC_Documento>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__CxC_Docu__5DDBFC76F10D210B");

            entity.ToTable("CxC_Documento");

            entity.HasIndex(e => new { e.ClienteId, e.Estado }, "IX_CxC_Documento_Cliente");

            entity.HasIndex(e => new { e.TipoDocumento, e.ReferenciaExterna }, "UX_CxC_Documento_Ref").IsUnique();

            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.MontoOriginal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReferenciaExterna)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaldoActual).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<CxC_IntegracionAplicadum>(entity =>
        {
            entity.HasKey(e => new { e.TipoEvento, e.EntidadId });

            entity.Property(e => e.TipoEvento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaAplicado).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<CxC_Movimiento>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__CxC_Movi__BF923C2C87AEC6B0");

            entity.ToTable("CxC_Movimiento");

            entity.HasIndex(e => new { e.DocumentoId, e.Fecha }, "IX_CxC_Mov_DocFecha");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReferenciaExterna)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Documento).WithMany(p => p.CxC_Movimientos)
                .HasForeignKey(d => d.DocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CxC_Mov_Doc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
