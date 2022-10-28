using Aplicacion.Entidades;
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPermiso.Controllers
{
    public class PermisoController : ControllerBase
    {

        IOperationsPermiso _OperationsPermiso;
        IQueryOperationsPermiso _QueryOperationsPermiso;
        IQueryOperationsTipoPermiso _QueryOperationsTipoPermiso;

        public PermisoController()
        {
            _OperationsPermiso = new AppOperationsPermiso();
            _QueryOperationsPermiso = new AppQueryOperationsPermiso();
            _QueryOperationsTipoPermiso = new AppQueryOperationsTipoPermiso();
        }

        [Route("GetAllTipoPermisos")]
        [HttpPost]
        public IEnumerable<TipoPermiso> GetAllTipoPermisos()
        {
            IEnumerable<TipoPermiso> listaTipoPermisos = new List<TipoPermiso>();
            listaTipoPermisos = _QueryOperationsTipoPermiso.getTipoPermisos();

            return listaTipoPermisos;
        }

        [Route("GetAllPermisos")]
        [HttpPost]
        public IEnumerable<Permiso> GetAllPermisos()
        {
            IEnumerable<Permiso> listaPermisos = new List<Permiso>();
            listaPermisos = _QueryOperationsPermiso.getPermisos();

            return listaPermisos;
        }

        [Route("GetPermiso")]
        [HttpPost]
        public Permiso GetPermiso(int id)
        {
            Permiso permiso = new Permiso();
            permiso = _QueryOperationsPermiso.getPermiso(id);

            return permiso;
        }

        [Route("SavePermiso")]
        [HttpPost]
        public Respuesta SavePermiso([FromBody] Permiso entidad)
        {
            Respuesta respuesta;

            if (entidad.Id == 0)
            {
                respuesta = _OperationsPermiso.InsertPermiso(entidad);
            }
            else {
                respuesta = _OperationsPermiso.UpdatePermiso(entidad);
            }
            
            return respuesta;
        }

        [Route("UpdatePermiso")]
        [HttpPost]
        public Respuesta UpdatePermiso([FromBody] Permiso entidad)
        {
            Respuesta respuesta = _OperationsPermiso.UpdatePermiso(entidad);

            return respuesta;
        }

    }
}
