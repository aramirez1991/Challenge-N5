using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia.QueryOperations
{
    public class QueryOperationsTipoPermiso
    {
        public IEnumerable<TipoPermiso> GetAll()
        {
            using (var db = new testContext())
            {
                return db.TipoPermisos.ToList();
            }
        }
    }
}
