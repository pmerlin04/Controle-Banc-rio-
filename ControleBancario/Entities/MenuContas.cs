namespace ControleBancario.Entities
{
    internal class MenuContas : Menu
    {
        //objeto do tipo Conta Corrente, com Saldo = 500.00 e Limite Especial = 1000.00
        ContaCorrente cc = new ContaCorrente(500.00, 1000.00);

        //objeto do tipo Conta Poupança, com Saldo = 500.00 e RejusteMensal = 1%
        ContaPoupanca cp = new ContaPoupanca(500.00, 0.01);

        //inicialização de variaveis para os metodos
        int opcoesContaCorrente = 0;
        int opcoesContaPoupanca = 0;
        bool valor = true;


        //metodo da superclasse Menu
        protected override void ExecutarMenu()
        {
            try
            {
                base.ExecutarMenu();
                //getOpcao();

            }catch(FormatException ex)//caso o usuário digite caracter
            {
                Console.WriteLine("Escolha apenas um número da lista\n" + ex.Message);
            }
           
        }


        //metodo para chamar a Operação Conta Corrente
        private void OperarContaCC()
        {
            Console.WriteLine("1 - Consultar Saldo " +
              "\n2 - Depositar" +
              "\n3 - Sacar" +
              "\n4 - Atualizar Saldo" +
              "\n0 - Voltar");
        }

        //metodo para chamar a Operação Conta Poupança
        private void OperarContaCP()
        {
            Console.WriteLine("1 - Consultar Saldo " +
                  "\n2 - Depositar" +
                  "\n3 - Sacar" +
                  "\n4 - Atualizar Saldo" +
                  "\n0 - Voltar");
        }

        protected override void AvaliarOpcaoEscolhida()
        {

               while (valor == true)//repita até o usuário digitar outra opção diferente de 0 no Executar Menu
               {

                    switch (getOpcao())//casos da opção Executar Menu
                    {

                        //caso o usuário escolha Conta Corrente no menu inicial
                        case 1:

                            //try catch caso usuário digite caracteres nas opções da conta Corrente
                            try
                            {
                                OperarContaCC();
                                opcoesContaCorrente = int.Parse(Console.ReadLine());

                            //se a opcao for Consultar Saldo
                            if (opcoesContaCorrente == 1)
                            {
                                Console.WriteLine(cc.ToString());
                            }

                            //se a opção for Depositar
                            else if (opcoesContaCorrente == 2)
                            {
                                try
                                {
                                    Console.WriteLine("Coloque um valor para depositar");
                                    double deposito = double.Parse(Console.ReadLine());
                                    cc.Depositar(deposito);

                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Digite apenas números positivos\n" + e.Message);

                                }

                            }

                            //se a opção for Sacar
                            else if (opcoesContaCorrente == 3)
                            {

                                try
                                {
                                    if (cc.getSaldo() <= -1000.00)//verifica se o Saldo é superior ao Limite Especial
                                    {
                                        Console.WriteLine("Saldo igual ao limite especial");

                                    }
                                    //se for superior, pede ao usuário o valor de saque
                                    else
                                    {
                                        Console.WriteLine("Coloque um valor para sacar");
                                        double saque = double.Parse(Console.ReadLine());

                                        if ((cc.getSaldo() - saque) < -1000.00)
                                        {
                                            Console.WriteLine("Valor para saque deixará saldo em abaixo do que o Limite Especial. Digite outro valor");
                                        }
                                        else
                                        {
                                            cc.Sacar(saque);
                                        }
                                    }

                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Digite apenas números positivos para saque na Conta Corrente\n" + e.Message);
                                }
                            }

                            //se a opção for Atualizar Saldo
                            else if (opcoesContaCorrente == 4)
                            {
                                cc.AtualizarSaldo();
                                Console.WriteLine("Saldo atualizado");
                            }

                            //se a opção for Voltar
                            else if (opcoesContaCorrente == 0)
                            {
                                ExecutarMenu();
                            }

                            //caso o usuário digitar outro valor nas opções da Conta Corrente
                            else
                            {
                                setMensagemMenu("Opção Inválida\nPor favor, escolha uma opção");
                                Console.WriteLine(getMensagemMenu());
                            }

                            }
                            catch (FormatException)//caso o usuário digite caracteres nas opções da conta Corrente
                            {
                                Console.WriteLine("Digite apenas números para as opções da Conta Corrente");
                            }

                        break;//final do case 1 do menu inicial


                        //colocar case para conta Poupança
                        case 2:

                            try
                            {
                                                    
                                OperarContaCP();
                                opcoesContaPoupanca = int.Parse(Console.ReadLine());

                            //se o usuário esolher Consultar Saldo
                            if (opcoesContaPoupanca == 1)
                            {
                                Console.WriteLine(cp.ToString());
                            }

                            //se o usuário escolher Depositar
                            else if (opcoesContaPoupanca == 2)
                            {
                                try
                                {
                                    Console.WriteLine("Digite um valor para depositar na Conta Poupança");
                                    double valor = double.Parse(Console.ReadLine());
                                    cp.Depositar(valor);
                                }
                                catch (FormatException)//caso digite caracteres
                                {
                                    Console.WriteLine("Digite apenas números positivos para depositar na Conta Poupança");
                                }

                            }

                            //se o usuário escolher Sacar
                            else if (opcoesContaPoupanca == 3)
                            {
                                try
                                {
                                    if (cp.getSaldo() == 0)
                                    {
                                        Console.WriteLine("Saldo está zerado");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Digite um valor para saque na Conta Poupança");
                                        double valor = double.Parse(Console.ReadLine());
                                        if ((cp.getSaldo() - valor) < 0)//verifica se a subtração do valor no saldo deixará o saldo menor que zero
                                        {
                                            Console.WriteLine("Valor para saque deixará saldo em negativo. Digite outro valor");

                                        }
                                        else
                                        {
                                            cp.Sacar(valor);

                                        }
                                    }
                                  
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Digite apenas números positivos\n" + e.Message);
                                }
                            }

                            //se o usuario escolher Atualizar Saldo
                            else if (opcoesContaPoupanca == 4)
                            {
                                try
                                {
                                    Console.WriteLine("Digite a porcentagem para o reajuste da Conta Poupança");
                                    double reajuste = double.Parse(Console.ReadLine());
                                    cp.AtualizarSaldo(reajuste);
                                    Console.WriteLine("Saldo Atualizado, o reajuste foi de: " + reajuste/100);
                                }catch(FormatException e)
                                {
                                    Console.WriteLine("Digite apenas númerospositivos\n" + e.Message);

                                }

                            }

                            //se o usuário escolher Voltar
                            else if (opcoesContaPoupanca == 0)
                            {
                                ExecutarMenu();
                            }

                            //se o usuário escolher outra opção na Conta Poupança
                            else
                            {
                                setMensagemMenu("Opção Inválida\nPor favor, escolha uma opção");
                                Console.WriteLine(getMensagemMenu());
                            }


                            } catch (FormatException e)//caso o usuário digite caracter nas opções da Conta Poupança
                            {
                                Console.WriteLine("Digite apenas números para as opções da Conta Poupança");
                            }
                           
                           
                        break;//final do case 2 do menu inicial




                        case 0:
                            Console.WriteLine("Fim do programa");
                            valor = false;
                        break;//final do case 0 do menu inicial


                        //caso o usuário escolha outra opção a nao ser Conta Corrente, Conta Poupança, nem Sair
                        default:
                            setMensagemMenu("Opção Inválida");
                            Console.WriteLine(getMensagemMenu());
                            valor = false;
                        break;


                    }//final do switch

               }//final while

        }//final do metodo AvaliarOpcaoEscolhida
    }
}
