using e_Agenda.ConsoleApp.ModuloCompatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Tarefa> _repositorioTarefa;
        private readonly Notificador _notificador;



        public TelaCadastroTarefa(IRepositorio<Tarefa> repositorioTarefa, Notificador notificador) : base("Cadastro de Tarefas")
        {
            _notificador = notificador;
            _repositorioTarefa = repositorioTarefa;
        }

        public void Editar()
        {
            MostrarTitulo("Editando Conatato");

            bool temTarefaCadastrada = Visualizar("Pesquisando");

            if (temTarefaCadastrada == false)
            {
                _notificador.ApresentarMensagem("Nenhum Tarefa cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            Console.Write("Digite o Titulo da Tarefa: ");
            string tarefa = Console.ReadLine();
            StatusPrioridade statusPrioridade= ObterPrioridade();
            Tarefa TarefaAtualizado = ObterTarefa(statusPrioridade);

            bool conseguiuEditar = _repositorioTarefa.Editar(numeroTarefa, TarefaAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Funcionário editado com sucesso!", TipoMensagem.Sucesso);

        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Tarefa");

            bool temTarefaRegistrados = Visualizar("Pesquisando");

            if (temTarefaRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Tarefa cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioTarefa.Excluir(numeroTarefa);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa excluído com sucesso!", TipoMensagem.Sucesso);

        }

        public void Inserir()
        {
            MostrarTitulo("Cadastrar Tarefas");

            StatusPrioridade statusPrioridade = ObterPrioridade();
            Tarefa novoTarefa = ObterTarefa(statusPrioridade);
            _repositorioTarefa.Inserir(novoTarefa);

            _notificador.ApresentarMensagem("Tarefa cadastrado com sucesso!", TipoMensagem.Sucesso);

        }

        public bool Visualizar(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualizar de Tarefas");

            List<Tarefa> tarefas = _repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum Tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

        private Tarefa ObterTarefa(StatusPrioridade statusPrioridade)
        {
            Console.Write("Digite o Titulo da Tarefa: ");
            string titulo = Console.ReadLine();

          
            return new Tarefa(titulo);
        }

        private int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Tarefa que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioTarefa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do contatto não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        private StatusPrioridade ObterPrioridade()
        {

            Console.Write(" 1- Alta\n 2- Normal\n 3- Baixa\n Digite a prioridade:");
            string opcaoSelecionada = Console.ReadLine();

            while (opcaoSelecionada != "1" && opcaoSelecionada != "2" && opcaoSelecionada != "3")
            {
                _notificador.ApresentarMensagem("Opção inválida", TipoMensagem.Atencao);

                Console.Write(" 1- Alta\n 2- Normal\n 3- Baixa\n Digite a prioridade:");
                opcaoSelecionada = Console.ReadLine();
            }

            switch (opcaoSelecionada)
            {
                case "1":
                    return StatusPrioridade.Alta;

                case "2":
                    return StatusPrioridade.Normal;

                case "3":
                    return StatusPrioridade.Baixa;

                default:
                    return StatusPrioridade.Normal;
            }
        }
    }
}
