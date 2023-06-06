using BlogNotas_Cliente.model.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.Utileria
{
    public class UsuarioActivo
    {
        private static UsuarioActivo instancia;
        public Usuario Usuario { get; set; }
        public String SesionToken { get; set; }

        private UsuarioActivo()
        {
            Usuario = new Usuario();
            SesionToken = "";
        }

        public static UsuarioActivo ObtenerUsuarioActivo()
        {
            if (instancia == null)
            {
                instancia = new UsuarioActivo();
            }
            return instancia;
        }
    }
}
