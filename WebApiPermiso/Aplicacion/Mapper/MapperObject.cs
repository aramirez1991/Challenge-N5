using System;
using Models = Infraestructura.Models;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Mapper
{
    class MapperObject
    {
        public static Models.Permiso ConvertoToModels(Entidades.Permiso entidad)
        {

            Models.Permiso model = new Models.Permiso();

            model.ApellidoEmpleado = entidad.ApellidoEmpleado;
            model.FechaPermiso = entidad.FechaPermiso;
            model.Id = entidad.Id;
            model.NombreEmpleado = entidad.NombreEmpleado;
            model.TipoPermiso = entidad.TipoPermiso;

            return model;

        }

        public static Entidades.Permiso ConvertoToEntidad(Models.Permiso model)
        {
            Entidades.Permiso entidad = new Entidades.Permiso();

            entidad.ApellidoEmpleado = model.ApellidoEmpleado;
            entidad.FechaPermiso = model.FechaPermiso;
            entidad.Id = model.Id;
            entidad.NombreEmpleado = model.NombreEmpleado;
            entidad.TipoPermiso = model.TipoPermiso;

            return entidad;
        }
    }
}
