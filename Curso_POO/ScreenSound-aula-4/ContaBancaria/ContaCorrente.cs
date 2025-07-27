using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    internal class ContaCorrente: ContaBancaria
    {
        public override double ExibirSaldo()
        {
            return Saldo * 0.02;
        }
    }
}
