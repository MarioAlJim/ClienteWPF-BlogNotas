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
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public Usuario UsuarioActual { get; set; }
        public SesionToken SesionToken { get; set; }
    }
}
