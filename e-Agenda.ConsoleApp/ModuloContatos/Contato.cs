using e_Agenda.ConsoleApp.ModuloCompatilhado;
using System;
using System.Collections.Generic;
namespace e_Agenda.ConsoleApp.ModuloContatos
{
    public class Contato : EntidadeBase
    {
        private string _nome;
        private string _telefone;
        private string _email;
        private string _empresa;
        private string _cargo;

        public string Nome { get => _nome; }
        public string Telefone { get => _telefone; }
        public string Email { get => _email; }
        public string Empresa { get => _empresa; }
        public string Cargo { get => _cargo; }

        public Contato(string nome, string telefone, string email, string empresa, string cargo)
        {
            _nome = nome;
            _telefone = telefone;
            _email = email;
            _empresa = empresa;
            _cargo = cargo;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome: " + Nome + Environment.NewLine +
                "Telefone: " + Telefone + Environment.NewLine +
                "Email: " + Email + Environment.NewLine +
                "Cargo: " + Cargo + Environment.NewLine +
                "Empresa: " + Empresa + Environment.NewLine;


        }

        public override ResultadoValidacao Validar()
        {
            List<string> erros = new List<string>();

            if (_telefone.Length < 9)
                erros.Add("Um Contato precisa ter um número de telefone com 9 digitos!");
           
            return new ResultadoValidacao(erros);
        }
    }
}
