using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteProdutos.Models;

public partial class TdbProduto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string NomeProduto { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public decimal Preco { get; set; }

    public string LojaVendedora { get; set; } = null!;

    public string MarcaProduto { get; set; } = null!;

    public DateTime DataLancamento { get; set; }

    public int? QuantidadeEstoque { get; set; }
}
