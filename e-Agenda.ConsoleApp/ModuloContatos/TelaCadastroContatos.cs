using e_Agenda.ConsoleApp.ModuloCompatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloContatos
{
    public class TelaCadastroContatos : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Contato> _repositorioContatos;
        private readonly Notificador _notificador;
       
            

        public TelaCadastroContatos(IRepositorio<Contato> repositorioContatos, Notificador notificador) : base("Cadastro de Contatos")
        {
            _notificador = notificador;
            _repositorioContatos = repositorioContatos;
        }

        public void Editar()
        {
            MostrarTitulo("Editando Conatato");

            bool temContatoCadastrada = Visualizar("Pesquisando");

            if (temContatoCadastrada == false)
            {
                _notificador.ApresentarMensagem("Nenhum Contato cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroRegistro();

            Contato contatoAtualizado = ObterContato();

            bool conseguiuEditar = _repositorioContatos.Editar(numeroContato, contatoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Funcionário editado com sucesso!", TipoMensagem.Sucesso);

        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Contato");

            bool temContatoRegistrados = Visualizar("Pesquisando");

            if (temContatoRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum COntato cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato= ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioContatos.Excluir(numeroContato);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Contato excluído com sucesso!", TipoMensagem.Sucesso);

        }

        public void Inserir()
        {
            MostrarTitulo("Cadastrar Contatos");

            Contato novoContato = ObterContato();

            _repositorioContatos.Inserir(novoContato);  

            _notificador.ApresentarMensagem("Contato cadastrado com sucesso!", TipoMensagem.Sucesso);

        }

        public bool Visualizar(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualizar de Contatos");

            List<Contato> contatos = _repositorioContatos.SelecionarTodos();

            if (contatos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum contato disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato contato in contatos)
                Console.WriteLine(contato.ToString());

            Console.ReadLine();

            return true;
        }

        private Contato ObterContato()
        {
            Console.Write("Digite o nome do contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite email: ");
            string email = Console.ReadLine();

            Console.Write("Digite o Empresa: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o cargo: ");
            string cargo = Console.ReadLine();


            return new Contato(nome,telefone,email,empresa,cargo);
        }

        private int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Contato que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioContatos.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do contatto não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
