using e_Agenda.ConsoleApp.ModuloCompatilhado;
using e_Agenda.ConsoleApp.ModuloContatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Compromisso> _repositorioCompromisso;
        private readonly Notificador _notificador;
        private readonly IRepositorio<Contato> repositorioContato;
        private readonly TelaCadastroContatos telaCadastroContatos;

        public TelaCadastroCompromisso(IRepositorio<Compromisso> repositorioCompromisso, Notificador notificador, IRepositorio<Contato> repositorioContato, TelaCadastroContatos telaCadastroContatos)
            : base("Cadastro Compromisso")
        {
            _repositorioCompromisso = repositorioCompromisso;
            _notificador = notificador;
            this.repositorioContato = repositorioContato;
            this.telaCadastroContatos = telaCadastroContatos;
        }

        public void Editar()
        {
            MostrarTitulo("Editando Compromisso");

            bool temContatoCadastrada = Visualizar("Pesquisando");

            if (temContatoCadastrada == false)
            {
                _notificador.ApresentarMensagem("Nenhum Contato cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroRegistro();


            Contato contatoSeleciona =ObtemContato();
            Compromisso compromissoAtualizado = ObterCompromisso(contatoSeleciona);

            bool conseguiuEditar = _repositorioCompromisso.Editar(numeroContato, compromissoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Funcionário editado com sucesso!", TipoMensagem.Sucesso);

        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Compromisso");

            bool temCompromissoRegistrados = Visualizar("Pesquisando");

            if (temCompromissoRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Compromisso cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroCompromisso = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioCompromisso.Excluir(numeroCompromisso);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Compromisso excluído com sucesso!", TipoMensagem.Sucesso);

        }

        public void Inserir()
        {

            Contato contatoselecionado = ObtemContato();

            Compromisso novoCompromisso = ObterCompromisso(contatoselecionado);

            _repositorioCompromisso.Inserir(novoCompromisso);

            _notificador.ApresentarMensagem("Compromisso cadastrado com sucesso!", TipoMensagem.Sucesso);

        }

        public bool Visualizar(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualizar de Compromissos");

            List<Compromisso> Compromissos = _repositorioCompromisso.SelecionarTodos();

            if (Compromissos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum Compromisso disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Compromisso Compromisso in Compromissos)
                Console.WriteLine(Compromisso.ToString());

            Console.ReadLine();

            return true;
        }

        private Compromisso ObterCompromisso(Contato contatoselecionado)
        {
            Console.Write("Digite o assunto: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local: ");
            string local = Console.ReadLine();

            Console.Write("Digite dia: ");
            DateTime dia = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite hora inicial: ");
            DateTime inicio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite horari final: ");
            DateTime fim = Convert.ToDateTime(Console.ReadLine());


            return new Compromisso(assunto, local, dia, inicio, fim, contatoselecionado);
        }

        private Contato ObtemContato()
        {
            MostrarTitulo("Cadastrar Compromissos");
            Console.WriteLine("Deseja vincular aum contato? (s/n)");
            string opcao = Console.ReadLine();

            if (opcao == "s" || opcao == "S")
            {
                bool temContatoCadastrado = telaCadastroContatos.Visualizar("");
                if (!temContatoCadastrado)
                {
                    _notificador.ApresentarMensagem("Você precisa cadastrar um contato antes!", TipoMensagem.Atencao);
                    return null;
                }

                Console.Write("Digite o ID do Contato que deseja Selecionar: ");
                int numeroFilmeSelecionado = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Contato contatoSelecionado = repositorioContato.SelecionarRegistro(numeroFilmeSelecionado);
                return contatoSelecionado;

            }else
      return null;

        }
            private int ObterNumeroRegistro()
            {
                int numeroRegistro;
                bool numeroRegistroEncontrado;

                do
                {
                    Console.Write("Digite o ID do Compromisso que deseja editar: ");
                    numeroRegistro = Convert.ToInt32(Console.ReadLine());

                    numeroRegistroEncontrado = _repositorioCompromisso.ExisteRegistro(numeroRegistro);

                    if (numeroRegistroEncontrado == false)
                        _notificador.ApresentarMensagem("ID do contatto não foi encontrado, digite novamente", TipoMensagem.Atencao);

                } while (numeroRegistroEncontrado == false);

                return numeroRegistro;
            }
        

    } 
}
