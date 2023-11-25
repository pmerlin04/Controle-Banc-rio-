using ControleBancario.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBancario.Entities
{    internal class ContaPoupanca : Conta
    {

        double reajuste = 0;

        private double ReajusteMensal { get; set; }

        public ContaPoupanca(double saldo, double reajusteMensal) : base(saldo)
        {
            ReajusteMensal = reajusteMensal;
        }

        public void AtualizarSaldo(double reajuste)
        {
            if (reajuste <= 0)
            {
                throw new DomainExceptions("Valor igual ou menor que zero");
            }
            else
            {
                reajuste = reajuste / 100;
                double result = (getSaldo() * reajuste) + getSaldo();
                setSaldo(result);
                
            }
        }

        public override string ToString()
        {
            return "Saldo R$ " + getSaldo().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
