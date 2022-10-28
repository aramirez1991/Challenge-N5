using Persistencia.QueryOperations;
using Aplicacion.Interfaces;
using Models = Infraestructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Mapper;

namespace Aplicacion.Servicios
{
    public class AppQueryOperationsPermiso : IQueryOperationsPermiso
    {

        public Entidades.Permiso getPermiso(int id)
        {

            Entidades.Permiso entidad = new Entidades.Permiso();

            try
            {

                QueryOperationsPermiso repositorio = new QueryOperationsPermiso();

                Models.Permiso model = repositorio.Get(id);
                
                if (model != null) { 
                    entidad = MapperObject.ConvertoToEntidad(model);
                }
            }
            catch {
                entidad = new Entidades.Permiso();
            }
            return entidad;
        }

        public IEnumerable<Entidades.Permiso> getPermisos()
        {
            List<Entidades.Permiso> listEntidades = new List<Entidades.Permiso>();

            try
            {
                QueryOperationsPermiso repositorio = new QueryOperationsPermiso();

                Entidades.Permiso entidad;

                IEnumerable<Models.Permiso> listModels = repositorio.GetAll();

                foreach (var model in listModels)
                {

                    entidad = new Entidades.Permiso();

                    entidad = MapperObject.ConvertoToEntidad(model);

                    listEntidades.Add(entidad);
                }
            }

            catch {

                listEntidades = new List<Entidades.Permiso>();
            }
            return listEntidades;
        }

    }
}
