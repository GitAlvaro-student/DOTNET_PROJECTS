using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Filme.Modelos
{
    internal class Book
    {
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }
        [JsonPropertyName("autor")]
        public string Autor { get; set; }
        [JsonPropertyName("ano_publicacao")]
        public int AnoPubli { get; set; }
        public string Detalhes => $"{Titulo} -> {Autor} -> {AnoPubli}";
    }
}
