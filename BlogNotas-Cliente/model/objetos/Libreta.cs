using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.objetos
{
    public class Libreta
    {
        public int libreta_id {  get; set; }
        public String nombre { get; set; }
        public String color { get; set; }
        public int usuario_id { get; set; }
    }
}
