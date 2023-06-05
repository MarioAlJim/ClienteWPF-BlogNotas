using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.objetos
{
    public class Usuario
    {
        public int activo { get; set; }
        public string apellidos { get; set; }
        public string celular { get; set; }
        public string contrasena { get; set; }
        public string nombres { get; set; }
        public string otp { get; set; }
        public string tiempo_registro { get; set; }
        public int usuario_id { get; set; }
    }
}
