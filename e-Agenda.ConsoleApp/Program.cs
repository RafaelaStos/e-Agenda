
using System;

namespace e_Agenda.ConsoleApp.ModuloCompatilhado
{
    internal class Program
    {
        static void Main(string[] args)
        { 
       
            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal(new Notificador());
            
            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();


                
                if (telaSelecionada is null)
                    break;

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ITelaCadastravel)
                {
                    ITelaCadastravel telaCadastroBasico = (ITelaCadastravel)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.Inserir();


                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.Excluir();

                    if (opcaoSelecionada == "4")
                        telaCadastroBasico.Visualizar("Tela");
        
                }

            }
        }
    }
}
