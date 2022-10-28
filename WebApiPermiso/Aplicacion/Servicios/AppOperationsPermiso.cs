using Aplicacion.Interfaces;
using Persistencia.Operations;
using Models = Infraestructura.Models;
using Aplicacion.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia.QueryOperations;

namespace Aplicacion.Servicios
{
    public class AppOperationsPermiso: IOperationsPermiso
    {

        public Entidades.Respuesta InsertPermiso(Entidades.Permiso entidad)
        {
            Entidades.Respuesta respuesta = new Entidades.Respuesta();


            try
            {

                OperationsPermiso repositorio = new OperationsPermiso();

                Models.Permiso model = new Models.Permiso();

                model = MapperObject.ConvertoToModels(entidad);

                repositorio.Add(model);


            }
            catch (Exception e)
            {
                respuesta.Codigo = 9999;
                respuesta.Mensaje = e.Message;
            }

            return respuesta;
        }

        public Entidades.Respuesta UpdatePermiso(Entidades.Permiso entidad)
        {
            Entidades.Respuesta respuesta = new Entidades.Respuesta();


            try
            {

                QueryOperationsPermiso repositorioQuery = new QueryOperationsPermiso();

                OperationsPermiso repositorioOperations = new OperationsPermiso();

                Models.Permiso modelConsulta = repositorioQuery.Get(entidad.Id);

                if (modelConsulta != null)
                {

                    Models.Permiso model = new Models.Permiso();

                    model = MapperObject.ConvertoToModels(entidad);

                    repositorioOperations.Update(model);

                }
                else
                {

                    respuesta.Codigo = 1000;
                    respuesta.Mensaje = "Permiso no existe.";
                }

            }
            catch (Exception e)
            {
                respuesta.Codigo = 9999;
                respuesta.Mensaje = e.Message;
            }

            return respuesta;
        }

    }
}
