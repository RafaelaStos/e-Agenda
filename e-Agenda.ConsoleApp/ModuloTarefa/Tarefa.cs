using e_Agenda.ConsoleApp.ModuloCompatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
        private string _titulo;
        private DateTime _dataCriacao= DateTime.Now;
        private StatusPrioridade _statusPrioridade;

        public Tarefa(string titulo)
        {
            _titulo = titulo;
        }

        public string Titulo { get => _titulo; }
        public StatusPrioridade Prioridade { get => _statusPrioridade; }

       

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Tutulo: " + Titulo + Environment.NewLine +
                "Prioridade: " + Prioridade + Environment.NewLine +
                "Data criação da terefa: " + _dataCriacao.ToShortDateString() + Environment.NewLine;
               
        }


        public override ResultadoValidacao Validar()
        {
            throw new NotImplementedException();
        }
       

    }
}
