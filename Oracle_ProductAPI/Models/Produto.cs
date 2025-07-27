using System.ComponentModel.DataAnnotations;

namespace Oracle_ProductAPI.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome Pode Ter no Máximo 50 Caracteres")]
        public string Nome { get; set; }

        public string Marca { get; set; }
        public double Preco { get; set; }
    }
}

