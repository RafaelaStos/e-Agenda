using e_Agenda.ConsoleApp.ModuloCompromisso;
using e_Agenda.ConsoleApp.ModuloContatos;
using e_Agenda.ConsoleApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloCompatilhado
{
    public class TelaMenuPrincipal
    {
        private IRepositorio<Tarefa> repositorioTarefa;
        private TelaCadastroTarefa telaCadastroTarefa;


        private IRepositorio<Contato> repositorioContato;
        private TelaCadastroContatos telaCadastroContatos;
      
        private IRepositorio<Compromisso> repositorioCompromisso;
        private TelaCadastroCompromisso telaCadastroCompromisso;
        public TelaMenuPrincipal(Notificador notificador)
        {
            repositorioContato =new RepositorioContatos();
            telaCadastroContatos = new TelaCadastroContatos(repositorioContato, notificador);
            
            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador); 

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, notificador, repositorioContato, telaCadastroContatos);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("eAgenda 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Tarefa");
            Console.WriteLine("Digite 2 para Cadastrar Comprimisso");
            Console.WriteLine("Digite 3 para Cadastrar Contato");
            

            Console.WriteLine("Digite s para sair");

           string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCadastroTarefa;

            else if (opcao == "2")
                tela = telaCadastroCompromisso;

            else if (opcao == "3")
                tela = telaCadastroContatos;

           
            return tela;
        }
    }
}
