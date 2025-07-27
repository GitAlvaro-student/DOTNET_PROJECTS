using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modelos.Pais
{
    internal class Country
    {
        [JsonPropertyName("nome")]
        public string Title { get; set; }
        [JsonPropertyName("capital")]
        public string Crew { get; set; }
        [JsonPropertyName("populacao")]
        public int imDbRating { get; set; }
    }
}
