using ControleBancario.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ControleBancario.Entities
{
    internal class Conta
    {
        private double Saldo { get; set; }

        public void setSaldo(double saldo)
        {
            this.Saldo = saldo;
        }

        public double getSaldo()
        {
             return this.Saldo;
        }

        public Conta(double saldo)
        {
            Saldo = saldo;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                //lançando uma exceção
                throw new DomainExceptions("Valor igual ou menor que zero para depositar");
            }
            else
            {
                Saldo += valor;
            }

        }

        public virtual void Sacar(double valor)
        {
            if (Saldo < -1000.00)
            {
                throw new DomainExceptions("Saldo insuficiente");

            }
            else if (valor <= 0)
            {
                throw new DomainExceptions("Valor igual ou menor que zero para sacar");
            }
            else
            {
                Saldo -= valor;
            }
        }

        public void AtualizarSaldo()
        {
            if (Saldo < 0)
            {
                Saldo -= 0.08;
            }
        }
    }
}
