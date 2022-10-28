using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Entidades
{
    public class Respuesta
    {
        public Int32 Codigo { get; set; }
        public String Mensaje { get; set; }

        public Respuesta() {

            Codigo = 0;
            Mensaje = string.Empty;
        }
    }
}
