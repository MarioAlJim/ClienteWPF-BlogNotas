using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.objetos
{
    public class Usuario
    {
        public int usuario_id { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public DateTime tiempo_registro { get; set; }
        public int activo { get; set; }
        public String celular { get; set; }
        public String contrasena { get; set; }
        public String ultimo_token_acceso { get; set; }
        public DateTime tiempo_ultimo_acceso { get; set; }
        public String otp { get; set; }
        public DateTime tiempo_activacion { get; set; }
    }
}
