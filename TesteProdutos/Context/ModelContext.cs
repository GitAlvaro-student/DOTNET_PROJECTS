using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TesteProdutos.Models;

namespace TesteProdutos.Context;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=ALVARO;Password=ALVARO_2004;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ALVARO")
            .UseCollation("USING_NLS_COMP");
        
        OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("TesteProdutos.Models.TdbProduto", entity =>
        {

            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property<string>("Categoria")
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATEGORIA");
            entity.Property<DateTime>("DataLancamento")
                .HasColumnType("DATE")
                .HasColumnName("DATA_LANCAMENTO");
            entity.Property<string>("LojaVendedora")
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOJA_VENDEDORA");
            entity.Property<string>("MarcaProduto")
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARCA_PRODUTO");
            entity.Property<string>("NomeProduto")
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME_PRODUTO");
            entity.Property<decimal>("Preco")
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECO");
            entity.Property<int?>("QuantidadeEstoque")
                .HasPrecision(10)
                .HasDefaultValueSql("0\n     ")
                .HasColumnName("QUANTIDADE_ESTOQUE");
            
            entity.HasKey("Id");

            entity.ToTable("TDB_PRODUTOS", "PRODS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
