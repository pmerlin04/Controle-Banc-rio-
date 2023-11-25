
using ControleBancario.Entities;
using System.Globalization;
using ControleBancario.Entities.Exceptions;

namespace ControleBancario.Entities
{
    internal class ContaCorrente : Conta
    {
        private double LimiteEspecial { get; set; }

        public ContaCorrente(double saldo, double limiteEspecial) : base (saldo)
        {
            LimiteEspecial = limiteEspecial;
        }
        
        public override void Sacar(double valor)
        {

            if (getSaldo() <= (LimiteEspecial * -1))//* -1 serve para deixar o numero negativo, ja que o limite especial é um crédito a mais na conta
            {
                throw new DomainExceptions("Saldo menor ou igual ao limite especial");
            }
            else if (valor <= 0)
            {
                throw new DomainExceptions("Valor para saque na Conta Corrente menor ou igual a zero");
            }
            else
            {
                double result =  getSaldo() - valor;
                setSaldo(result);
            }
        }

        public override string ToString()
        {
            return "Saldo R$ " + getSaldo().ToString("F2", CultureInfo.InvariantCulture)
                + " Limite Especial R$" + LimiteEspecial.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
