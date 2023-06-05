using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.objetos
{
    public class Nota
    {
        public int nota_id { get; set; }
        public String titulo { get; set; }
        public String contenido { get; set; }
        public DateTime tiempo_creacion { get; set; }
        public int eliminado { get; set; }
        public int usuario_id { get; set; }
        public int libreta_id { get; set; }
        public int prioridad_id { get; set; }
    }
}
