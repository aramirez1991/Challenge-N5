﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface IQueryOperationsTipoPermiso
    {
        IEnumerable<Entidades.TipoPermiso> getTipoPermisos();
    }
}
