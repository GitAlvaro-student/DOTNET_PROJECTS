using System.Runtime.Intrinsics.X86;

namespace FormasGeometricas
{
    abstract class FormaGeometrica
    {
        public string Nome { get; set; }
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();
    }
}
