import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import PermisoDataService from "../services/PermisoService";

const Permiso = props => {
  const { id } = useParams();

  const initialPermisoState = {
    id: 0,
    nombreEmpleado: "",
    apellidoEmpleado: "",
    tipoPermiso: 0,
    fechaPermiso: new Date()
  };

  const [currentPermiso, setCurrentPermiso] = useState(initialPermisoState);
  const [message, setMessage] = useState("");

  const getPermiso = id => {

    PermisoDataService.get(id)
      .then(response => {
        setCurrentPermiso(response.data);
  
      })
      .catch(e => {
        console.log(e);
      });
  };

  useEffect(() => {
  
    if (id)
      getPermiso(id);
  }, [id]);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setCurrentPermiso({ ...currentPermiso, [name]: value });
  };

  const savePermiso = () => {

    var data = {
        id:currentPermiso.id,
        nombreEmpleado: currentPermiso.nombreEmpleado,
        apellidoEmpleado: currentPermiso.apellidoEmpleado,
        tipoPermiso: parseInt(currentPermiso.tipoPermiso),
        fechaPermiso: currentPermiso.fechaPermiso
    };

    //console.log(data);

    PermisoDataService.save(data)
      .then(response => {
        if (response.data){
           if (response.data.codigo === 0){
            setMessage("El registro fue salvado con exito!");
           } 
           else{
            setMessage("Error: " + response.data.mensaje);
           }
        }else{
            setMessage("Ocurrio un error!"); 
        }
        
      })
      .catch(e => {
        console.log(e);
      });
  };

  return (
    <div>
      {currentPermiso ? (
        <div className="edit-form">
          <h4>Update Permiso</h4>
          <form>
            <div className="form-group">
            <label htmlFor="id">Id</label>
            <input
                type="text"
                className="form-control"
                id="id"
                name="id"
                value={currentPermiso.id}
                readOnly="true"
              />
              <label htmlFor="nombreEmpleado">Nombres</label>
              <input
                type="text"
                className="form-control"
                id="nombreEmpleado"
                name="nombreEmpleado"
                value={currentPermiso.nombreEmpleado}
                onChange={handleInputChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="apellidoEmpleado">Apellido</label>
              <input
                type="text"
                className="form-control"
                id="apellidoEmpleado"
                name="apellidoEmpleado"
                value={currentPermiso.apellidoEmpleado}
                onChange={handleInputChange}
              />
            </div>

            <div className="form-group">
              <label htmlFor="tipoPermiso">Tipo Permiso</label>
              <input
                type="text"
                className="form-control"
                id="tipoPermiso"
                name="tipoPermiso"
                value={currentPermiso.tipoPermiso}
                onChange={handleInputChange}
              />
            </div>

          </form>
        <br></br>
          <button
            type="submit"
            className="btn btn-success"
            onClick={savePermiso}
          >
            Save
          </button>
          <p>{message}</p>
        </div>
      ) : (
        <div>
          <br />
          <p>Please click on a Permiso...</p>
        </div>
      )}
    </div>
  );
};

export default Permiso;