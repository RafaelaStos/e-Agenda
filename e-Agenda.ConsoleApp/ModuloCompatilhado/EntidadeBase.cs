using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.ConsoleApp.ModuloCompatilhado 
{ 
    public abstract class EntidadeBase
    {
        public int id;

        public abstract ResultadoValidacao Validar();

    }
}
