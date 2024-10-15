using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgenciaArriendo.Server.Models;

public partial class AgenciaarriendoContext : DbContext
{
    public AgenciaarriendoContext()
    {
    }

    public AgenciaarriendoContext(DbContextOptions<AgenciaarriendoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TableApartamentoVisitum> TableApartamentoVisita { get; set; }

    public virtual DbSet<TableAsesor> TableAsesors { get; set; }

    public virtual DbSet<TableAsesorApartamento> TableAsesorApartamentos { get; set; }

    public virtual DbSet<TableAsesorHorario> TableAsesorHorarios { get; set; }

    public virtual DbSet<TableAsesorTaquilla> TableAsesorTaquillas { get; set; }

    public virtual DbSet<TableClientesCita> TableClientesCitas { get; set; }

    public virtual DbSet<TableEstado> TableEstados { get; set; }

    public virtual DbSet<TableHorario> TableHorarios { get; set; }

    public virtual DbSet<TableSectorApartamento> TableSectorApartamentos { get; set; }

    public virtual DbSet<TableTaquilla> TableTaquillas { get; set; }

    public virtual DbSet<TableTipoDocumento> TableTipoDocumentos { get; set; }

    public virtual DbSet<TableTipoPersona> TableTipoPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableApartamentoVisitum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_APARTAMENTO_VISITA");

            entity.Property(e => e.Strapartamentovisita)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STRAPARTAMENTOVISITA");
            entity.Property(e => e.Strcodigo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("STRCODIGO");
            entity.Property(e => e.Strcodigosector).HasColumnName("STRCODIGOSECTOR");
            entity.Property(e => e.Strestado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STRESTADO");

            entity.HasOne(d => d.StrcodigosectorNavigation).WithMany()
                .HasForeignKey(d => d.Strcodigosector)
                .HasConstraintName("FK__TABLE_APA__STRCO__59FA5E80");
        });

        modelBuilder.Entity<TableAsesor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_ASESOR");

            entity.Property(e => e.Strcedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCEDULA");
            entity.Property(e => e.Strcodigoasesor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOASESOR");
            entity.Property(e => e.Stremail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STREMAIL");
            entity.Property(e => e.Strestado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STRESTADO");
            entity.Property(e => e.Strnombreasesor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STRNOMBREASESOR");
        });

        modelBuilder.Entity<TableAsesorApartamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_ASESOR_APARTAMENTO");

            entity.Property(e => e.Strcodigoapartamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOAPARTAMENTO");
            entity.Property(e => e.Strcodigoaserapartamento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOASERAPARTAMENTO");
            entity.Property(e => e.Strcodigoasesor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOASESOR");
        });

        modelBuilder.Entity<TableAsesorHorario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_ASESOR_HORARIO");

            entity.Property(e => e.Dtrhorsvisita)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DTRHORSVISITA");
            entity.Property(e => e.Strcedulacliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCEDULACLIENTE");
            entity.Property(e => e.Strcodigoapartamentovisita)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOAPARTAMENTOVISITA");
            entity.Property(e => e.Strcodigoasesor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOASESOR");
            entity.Property(e => e.Strcodigohorario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOHORARIO");
            entity.Property(e => e.Strcodigoreserva)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STRCODIGORESERVA");
            entity.Property(e => e.Strestadovisita)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STRESTADOVISITA");
            entity.Property(e => e.Strfechareserva)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRFECHARESERVA");
            entity.Property(e => e.Strfechavisita)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRFECHAVISITA");
            entity.Property(e => e.Strhorareserva)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRHORARESERVA");
            entity.Property(e => e.Strobservacion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STROBSERVACION");
        });

        modelBuilder.Entity<TableAsesorTaquilla>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_ASESOR_TAQUILLA");

            entity.Property(e => e.CodAsesor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COD_ASESOR");
            entity.Property(e => e.CodTaquilla).HasColumnName("COD_TAQUILLA");
            entity.Property(e => e.Codigo)
                .ValueGeneratedOnAdd()
                .HasColumnName("CODIGO");
        });

        modelBuilder.Entity<TableClientesCita>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_CLIENTES_CITAS");

            entity.Property(e => e.Strapellidos)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STRAPELLIDOS");
            entity.Property(e => e.Strcedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCEDULA");
            entity.Property(e => e.Strcodigotipodocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOTIPODOCUMENTO");
            entity.Property(e => e.Strcodigotipopersona)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOTIPOPERSONA");
            entity.Property(e => e.Stremail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STREMAIL");
            entity.Property(e => e.Strnombres)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STRNOMBRES");
            entity.Property(e => e.Strtelefonocelular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRTELEFONOCELULAR");
            entity.Property(e => e.Strtelefonofijo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRTELEFONOFIJO");
        });

        modelBuilder.Entity<TableEstado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_ESTADOS");

            entity.Property(e => e.Descestado)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DESCESTADO");
            entity.Property(e => e.Strcodigoestado).HasColumnName("STRCODIGOESTADO");
        });

        modelBuilder.Entity<TableHorario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_HORARIOS");

            entity.Property(e => e.Orden).HasColumnName("ORDEN");
            entity.Property(e => e.Strcodigohorario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGOHORARIO");
            entity.Property(e => e.Strestado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STRESTADO");
            entity.Property(e => e.Strhorario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("STRHORARIO");
        });

        modelBuilder.Entity<TableSectorApartamento>(entity =>
        {
            entity.HasKey(e => e.Strcodigosector).HasName("PK__Sector__9A086DD2A216846F");

            entity.ToTable("TABLE_SECTOR_APARTAMENTO");

            entity.Property(e => e.Strcodigosector)
                .ValueGeneratedNever()
                .HasColumnName("STRCODIGOSECTOR");
            entity.Property(e => e.Strnombresector)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STRNOMBRESECTOR");
        });

        modelBuilder.Entity<TableTaquilla>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_TAQUILLA");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<TableTipoDocumento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_TIPO_DOCUMENTO");

            entity.Property(e => e.Strcodigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGO");
            entity.Property(e => e.Strtipodocumento)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STRTIPODOCUMENTO");
        });

        modelBuilder.Entity<TableTipoPersona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TABLE_TIPO_PERSONA");

            entity.Property(e => e.Strcodigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STRCODIGO");
            entity.Property(e => e.Strtipopersona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STRTIPOPERSONA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
