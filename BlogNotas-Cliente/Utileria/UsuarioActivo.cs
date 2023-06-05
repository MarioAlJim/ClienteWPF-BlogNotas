using BlogNotas_Cliente.model.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.Utileria
{
    public static class UsuarioActivo
    {
        public static Usuario? Usuario;

        public static Usuario getUsuarioActivo()
        {
            return Usuario;
        }

        public static void setUsuarioActivo (Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
