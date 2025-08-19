using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TdbProduto> TdbProdutos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=ALVARO;Password=ALVARO_2004;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ALVARO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TdbProduto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008275");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.QuantidadeEstoque).HasDefaultValueSql("0\n     ");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
