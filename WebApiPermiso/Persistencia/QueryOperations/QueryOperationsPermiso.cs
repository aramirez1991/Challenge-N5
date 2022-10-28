using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistencia.QueryOperations
{
    public class QueryOperationsPermiso
    {
        public Permiso Get(int id)
        {
            using (var db = new testContext())
            {
                return db.Permisos.Find(id);
            }
        }

        public IEnumerable<Permiso> GetAll()
        {
            using (var db = new testContext())
            {
                return db.Permisos.ToList();
            }
        }

    }
}
