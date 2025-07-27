using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    internal class ContaPoupanca : ContaBancaria
    {
        public override double ExibirSaldo()
        {
            return Saldo + (Saldo * 0.05); // Adiciona 5% de juros ao saldo
        }
    }
}
