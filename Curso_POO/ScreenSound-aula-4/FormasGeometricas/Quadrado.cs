using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormasGeometricas
{
    class Quadrado : IForma
    {
        public string Nome { get; set; } = "Quadrado";
        public Quadrado(double lado)
        {
            Lado = lado;
        }

        public double Lado { get; set; }
        public double CalcularArea()
        {
            return Lado * Lado;

        }
        public double CalcularPerimetro()
        {
            return 4 * Lado;
        }

    }
}
