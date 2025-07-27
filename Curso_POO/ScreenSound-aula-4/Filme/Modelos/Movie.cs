using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modelos.Filme
{
    internal class Movie
    {
        [JsonPropertyName("fullTitle")]
        public string Title { get; set; }
        [JsonPropertyName("crew")]
        public string Crew { get; set; }
        [JsonPropertyName("imDbRating")]
        public string imDbRating { get; set; }
    }
}
