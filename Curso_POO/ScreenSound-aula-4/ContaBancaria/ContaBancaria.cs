using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    internal class ContaBancaria
    {
        public string Agencia { get; set; }
        public int NumeroConta { get; set; }
        public string Titular { get; set; }
        public double Saldo  { get; set; }

        public virtual double ExibirSaldo()
        {
            return Saldo;
        }
    }
}
