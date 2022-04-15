using e_Agenda.ConsoleApp.ModuloCompatilhado;
using e_Agenda.ConsoleApp.ModuloContatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {

        private string _assusnto;
        private string _local;
        private DateTime _diaCompromisso;
        private DateTime _horaInicio;
        private DateTime _horaFinal;
        public Contato contatos;

        public Compromisso(string assusnto, string local, DateTime diaCompromisso, DateTime horaInicio, DateTime horaFinal, Contato contatosSelecionado)
        {
            Assusnto = assusnto;
            Local = local;
            DiaCompromisso = diaCompromisso;
            HoraInicio = horaInicio;
            HoraFinal = horaFinal;
           contatos=contatosSelecionado;
        }

        public string Assusnto { get => _assusnto; set => _assusnto = value; }
        public string Local { get => _local; set => _local = value; }
        public DateTime DiaCompromisso { get => _diaCompromisso; set => _diaCompromisso = value; }
        public DateTime HoraInicio { get => _horaInicio; set => _horaInicio = value; }
        public DateTime HoraFinal { get => _horaFinal; set => _horaFinal = value; }


        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Assunto: " + Assusnto + Environment.NewLine +
                "Local: " + Local + Environment.NewLine +
                "Dia : " + DiaCompromisso.ToShortDateString() + Environment.NewLine +
                "Hora Inicio : " + HoraInicio.ToShortTimeString()+ Environment.NewLine +
                "horario final : " + DiaCompromisso.ToShortTimeString() + Environment.NewLine; 

        }
        public override ResultadoValidacao Validar()
        {
            throw new NotImplementedException();
        }
    }
}
