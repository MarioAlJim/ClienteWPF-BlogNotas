using BlogNotas_Cliente.model.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.api
{
    public class RespuestaAcceso
    {
        public bool error { get; set; }
        public string mensaje { get; set; }
        public SesionToken sesionToken { get; set; }
        public Usuario usuario { get; set; }
    }
}
