﻿using BlogNotas_Cliente.model.objetos;

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
