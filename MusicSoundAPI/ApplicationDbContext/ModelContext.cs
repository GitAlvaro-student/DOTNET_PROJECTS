using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.ApplicationDbContext;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbdArtist> TbdArtists { get; set; }

    public virtual DbSet<TbdPlaylist> TbdPlaylists { get; set; }

    public virtual DbSet<TbdPlaylistMusic> TbdPlaylistMusics { get; set; }

    public virtual DbSet<TbdSong> TbdSongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=ALVARO;Password=ALVARO_2004;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ALVARO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TbdArtist>(entity =>
        {
            entity.HasKey(e => e.IdArtist).HasName("SYS_C008282");

            entity.Property(e => e.IdArtist).HasDefaultValueSql("MUSICA.SQ_ARTISTA_ID.NEXTVAL ");
        });

        modelBuilder.Entity<TbdPlaylist>(entity =>
        {
            entity.HasKey(e => e.IdPlaylist).HasName("SYS_C008287");

            entity.Property(e => e.IdPlaylist).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TbdPlaylistMusic>(entity =>
        {
            entity.HasOne(d => d.IdMusicNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MUSIC_FK");

            entity.HasOne(d => d.IdPlaylistNavigation).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PLAYLIST_FK");
        });

        modelBuilder.Entity<TbdSong>(entity =>
        {
            entity.HasKey(e => e.IdMusic).HasName("SYS_C008267");

            entity.Property(e => e.IdMusic).ValueGeneratedOnAdd();
            entity.Property(e => e.Popularidade).HasDefaultValueSql("0");

            entity.HasOne(d => d.IdArtistNavigation).WithMany(p => p.TbdSongs).HasConstraintName("FK_ID_ARTISTA");
        });
        modelBuilder.HasSequence("SQ_ARTISTA_ID", "MUSICA");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
