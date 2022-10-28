using Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Aplicacion.Interfaces
{
    public interface IOperationsPermiso
    {
        Entidades.Respuesta InsertPermiso(Permiso permiso);

        Entidades.Respuesta UpdatePermiso(Permiso permiso);
    }
}
