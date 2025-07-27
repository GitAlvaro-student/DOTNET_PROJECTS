using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modelos.Cars
{
    internal class Cars
    {
        [JsonPropertyName("marca")]
        public string Marca { get; set; }
        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }
    }
}
