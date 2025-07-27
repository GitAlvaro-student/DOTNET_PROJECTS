using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Modelos
{
    internal class Maquina
    {
        public Maquina(string operacao, int num1, int num2)
        {
            Operacao = operacao;
            Num1 = num1;
            Num2 = num2;
        }

        public int Calculo {
            get
            {
                switch (Operacao)
                {
                    case "+":
                        return Num1 + Num2;
                    case "-":
                        return Num1 - Num2;
                    case "*":
                        return Num1 * Num2;
                    case "/":
                        return Num1 / Num2;
                    case "**":
                        return (int)Math.Pow((double)Num1, (double)Num2);
                    case "%":
                        return (int)Math.Sqrt(Num1);
                    default: return 0;
                }

            }
        }
        public void ExibirResultado(Maquina Calculo)    
        {
            Console.WriteLine($"Resultado: {this.Calculo}");
        }

        public string Operacao { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
    }
}
