using Persistencia.QueryOperations;
using Aplicacion.Interfaces;
using Models = Infraestructura.Models;
using Entidades = Aplicacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class AppQueryOperationsTipoPermiso:IQueryOperationsTipoPermiso
    {
        public IEnumerable<Entidades.TipoPermiso> getTipoPermisos()
        {
            List<Entidades.TipoPermiso> listEntidades = new List<Entidades.TipoPermiso>();

            try { 
                QueryOperationsTipoPermiso repositorio = new QueryOperationsTipoPermiso();

                Entidades.TipoPermiso entidad;

                IEnumerable<Models.TipoPermiso> listModels = repositorio.GetAll();

                foreach (var model in listModels)
                {

                    entidad = new Entidades.TipoPermiso();

                    entidad.Id = model.Id;
                    entidad.Descripcion = model.Descripcion;

                    listEntidades.Add(entidad);
                }
            }
            catch
            {
                listEntidades = new List<Entidades.TipoPermiso>();

            }
            return listEntidades;
        }
    }
}
