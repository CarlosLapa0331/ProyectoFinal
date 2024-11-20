using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final_Turicentro_Estructura_de_datos.Models;

public partial class DbTuricentroContext : DbContext
{
    public DbTuricentroContext()
    {
    }

    public DbTuricentroContext(DbContextOptions<DbTuricentroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblArea> TblAreas { get; set; }

    public virtual DbSet<TblExtra> TblExtras { get; set; }

    public virtual DbSet<TblReporte> TblReportes { get; set; }

    public virtual DbSet<TblReportediario> TblReportediarios { get; set; }

    public virtual DbSet<TblReserva> TblReservas { get; set; }

    public virtual DbSet<TblReservasExtra> TblReservasExtras { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=CALITO\\MSSQLSERVER01;Database=DB_TURICENTRO;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblArea>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__tbl_area__70B820286FB73D6E");

            entity.ToTable("tbl_areas");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioHora)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_hora");
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<TblExtra>(entity =>
        {
            entity.HasKey(e => e.ExtraId).HasName("PK__tbl_extr__D1F3A807637C19BD");

            entity.ToTable("tbl_extras");

            entity.Property(e => e.ExtraId).HasColumnName("ExtraID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TblReporte>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PK__tbl_repo__0B29EA4ED797023D");

            entity.ToTable("tbl_reportes");

            entity.Property(e => e.ReporteId).HasColumnName("ReporteID");
            entity.Property(e => e.IngresosTotales).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TblReportediario>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("tbl_reportediario");

            entity.Property(e => e.IngresosTotales).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<TblReserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__tbl_rese__C3993703C40C1EAE");

            entity.ToTable("tbl_reservas");

            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CostoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Area).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_reser__AreaI__3F466844");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_reser__Usuar__3E52440B");
        });

        modelBuilder.Entity<TblReservasExtra>(entity =>
        {
            entity.HasKey(e => e.ReservaExtraId).HasName("PK__tbl_rese__F0D5B82FAA428828");

            entity.ToTable("tbl_reservas_extras");

            entity.Property(e => e.ReservaExtraId).HasColumnName("ReservaExtraID");
            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.ExtraId).HasColumnName("ExtraID");
            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

            entity.HasOne(d => d.Extra).WithMany(p => p.TblReservasExtras)
                .HasForeignKey(d => d.ExtraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_reser__Extra__46E78A0C");

            entity.HasOne(d => d.Reserva).WithMany(p => p.TblReservasExtras)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_reser__Reser__45F365D3");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__tbl_usua__2B3DE798C86B3AAB");

            entity.ToTable("tbl_usuarios");

            entity.HasIndex(e => e.Correo, "UQ__tbl_usua__60695A190534D198").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasDefaultValue("Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
