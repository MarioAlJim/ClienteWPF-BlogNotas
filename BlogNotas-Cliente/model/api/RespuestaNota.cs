using BlogNotas_Cliente.model.objetos;
using System.Collections.Generic;

namespace BlogNotas_Cliente.model.api
{
    public class RespuestaNota
    {
        public bool error { get; set; }
        public string mensaje { get; set; }
        public List<Nota>? notas { get; set; }
    }
}
