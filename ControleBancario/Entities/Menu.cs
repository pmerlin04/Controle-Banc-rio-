using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBancario.Entities
{
    internal class Menu
    {
        private int Opcao { get; set; }
        private string MensagemMenu { get; set; }

        public void setOpcao(int opcao)
        {
            this.Opcao = opcao;
        }

        public int getOpcao()
        {
            return this.Opcao;
        }

        public void setMensagemMenu(string mensagemMenu)
        {
            this.MensagemMenu = mensagemMenu;
        }

        public string getMensagemMenu()
        {
            return this.MensagemMenu;
        }



        protected virtual void ExecutarMenu()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Conta Corrente \n2 - Conta Poupança\n0 - Sair ");
            int escolhaMenu = int.Parse(Console.ReadLine());
            setOpcao(escolhaMenu);
        }

        protected virtual void AvaliarOpcaoEscolhida()
        {
            getOpcao();
        }

        public void executar()
        {
            ExecutarMenu();
            AvaliarOpcaoEscolhida();

        }


    }
}
