using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Musicas_Oracle.Models;

namespace Musicas_Oracle.Context;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbdSong> TbdSongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=ALVARO;Password=ALVARO_2004;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ALVARO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TbdSong>(entity =>
        {
            entity.HasKey(e => e.IdMusic).HasName("SYS_C008267");

            entity.ToTable("TBD_SONGS", "MUSICA");

            entity.Property(e => e.IdMusic)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID_MUSIC");
            entity.Property(e => e.Ano)
                .HasPrecision(4)
                .HasColumnName("ANO");
            entity.Property(e => e.Artista)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ARTISTA");
            entity.Property(e => e.Duracao)
                .HasPrecision(10)
                .HasColumnName("DURACAO");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENERO");
            entity.Property(e => e.Musica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MUSICA");
            entity.Property(e => e.Popularidade)
                .HasPrecision(3)
                .HasDefaultValueSql("0")
                .HasColumnName("POPULARIDADE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
