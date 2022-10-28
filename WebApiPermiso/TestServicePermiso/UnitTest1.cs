using Aplicacion.Entidades;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebApiPermiso;

namespace TestServicePermiso
{
    public class Tests
    {
        WebApiPermiso.Controllers.PermisoController controller;

        [SetUp]
        public void Setup()
        {
            //Create an instance of controller by passing repository
            controller = new WebApiPermiso.Controllers.PermisoController();
        }

        [Test]
        public void Test_GetPermiso()
        {
            // Act on Test  
            Permiso permiso = controller.GetPermiso(1);

            // Assert the result  
            Assert.IsNotNull(permiso);
            Assert.IsInstanceOf<Permiso>(permiso);
            Assert.IsTrue(permiso.Id.Equals(1));
            Assert.AreEqual("Webster", permiso.NombreEmpleado);
        }

        [Test]
        public void Test_GetAllPermiso()
        {
            // Act on Test  
            IEnumerable<Permiso> listPermisos = controller.GetAllPermisos();
            // Assert the result  
             
            Assert.IsNotNull(listPermisos);
            Assert.IsInstanceOf<IEnumerable<Permiso>>(listPermisos);
            Assert.IsTrue(listPermisos.Count() > 0);
            
        }

        [Test]
        public void Test_GetAllTipoPermiso()
        {
            // Act on Test  
            IEnumerable<TipoPermiso> listTipoPermisos = controller.GetAllTipoPermisos();
            // Assert the result  

            Assert.IsNotNull(listTipoPermisos);
            Assert.IsInstanceOf<IEnumerable<TipoPermiso>>(listTipoPermisos);
            Assert.IsTrue(listTipoPermisos.Count() > 0);

        }

        [Test]
        public void Test_SavePermiso()
        {
            Permiso permiso = new Permiso();
            permiso.NombreEmpleado = "Prueba";
            permiso.ApellidoEmpleado = "ApellidoPrueba";
            permiso.TipoPermiso = 1;
            permiso.FechaPermiso = System.DateTime.Now;

            // Act on Test  
            Respuesta result = controller.SavePermiso(permiso);
            // Assert the result  

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Respuesta>(result);
            Assert.IsTrue(result.Codigo.Equals(0));
            
        }
    }
}