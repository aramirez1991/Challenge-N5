using Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Operations
{
    public class OperationsPermiso
    {
        public void Add(Permiso permiso)
        {
            using (var db = new testContext())
            {
                db.Permisos.Add(permiso);
                db.SaveChanges();
            }
        }

        public void Update(Permiso permiso)
        {
            using (var db = new testContext())
            {
                db.Permisos.Update(permiso);
                db.SaveChanges();

            }
        }
    }
}
