using Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface IQueryOperationsPermiso
    {

        IEnumerable<Entidades.Permiso> getPermisos();

        Permiso getPermiso(int id);

    }
}
