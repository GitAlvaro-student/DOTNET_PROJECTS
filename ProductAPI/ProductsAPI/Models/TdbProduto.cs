using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models;

[Table("TDB_PRODUTOS", Schema = "PRODS")]
public partial class TdbProduto
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public int Id { get; set; }

    [Column("NOME_PRODUTO")]
    [StringLength(100)]
    [Unicode(false)]
    public string NomeProduto { get; set; } = null!;

    [Column("CATEGORIA")]
    [StringLength(50)]
    [Unicode(false)]
    public string Categoria { get; set; } = null!;

    [Column("PRECO", TypeName = "NUMBER(10,2)")]
    public decimal Preco { get; set; }

    [Column("LOJA_VENDEDORA")]
    [StringLength(100)]
    [Unicode(false)]
    public string LojaVendedora { get; set; } = null!;

    [Column("MARCA_PRODUTO")]
    [StringLength(50)]
    [Unicode(false)]
    public string MarcaProduto { get; set; } = null!;

    [Column("DATA_LANCAMENTO", TypeName = "DATE")]
    public DateTime DataLancamento { get; set; }

    [Column("QUANTIDADE_ESTOQUE")]
    [Precision(10)]
    public int? QuantidadeEstoque { get; set; }
}
