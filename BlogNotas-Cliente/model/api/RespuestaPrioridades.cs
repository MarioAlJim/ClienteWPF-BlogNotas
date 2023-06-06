using BlogNotas_Cliente.model.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.api
{
    public class RespuestaPrioridades
    {
        public bool error { get; set; }
        public string mensaje { get; set; }
        public List<Prioridad> Prioridades { get; set; }
    }
}
