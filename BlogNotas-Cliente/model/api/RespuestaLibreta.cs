using BlogNotas_Cliente.model.objetos;
using System.Collections.Generic;

namespace BlogNotas_Cliente.model.api
{
    public class RespuestaLibreta
    {
        public bool error { get; set; }
        public List<Libreta>? libretas { get; set; }
        public string mensaje { get; set; }
    }
}
