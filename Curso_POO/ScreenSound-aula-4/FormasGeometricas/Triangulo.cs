using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormasGeometricas
{
    class Triangulo : IForma
    {
        public string Nome { get; set; } = "Triângulo";
        public Triangulo(double altura, double largura)
        {
            Altura = altura;
            Base = largura;
        }

        public double Altura { get; set; }
        public double Base { get; set; }

        public double CalcularArea()
        {
            return (Base * Altura) / 2;
        }
        public double CalcularPerimetro()
        {
            // Considerando um triângulo equilátero para simplificação
            double lado = Math.Sqrt(Math.Pow(Base / 2, 2) + Math.Pow(Altura, 2));
            return 3 * lado;
        }
    }
}
