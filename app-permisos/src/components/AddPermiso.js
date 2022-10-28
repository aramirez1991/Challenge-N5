import React, { useState } from "react";

import PermisoDataService from "../services/PermisoService";

const AddPermiso = () => {
 
  const initialPermisoState = {
    id: 0,
    nombreEmpleado: "",
    apellidoEmpleado: "",
    tipoPermiso: 0,
    fechaPermiso: new Date().getFullYear() + '-' + (new Date().getMonth() + 1) + '-' + new Date().getDate()
  };
  const [Permiso, setPermiso] = useState(initialPermisoState);
  const [submitted, setSubmitted] = useState(false);
  const [message, setMessage] = useState("");

  const handleInputChange = event => {
    const { name, value } = event.target;
    setPermiso({ ...Permiso, [name]: value });
  };

  
  const savePermiso = () => {
    var data = {
        id:0,
        nombreEmpleado: Permiso.nombreEmpleado,
        apellidoEmpleado: Permiso.apellidoEmpleado,
        tipoPermiso: parseInt(Permiso.tipoPermiso),
        fechaPermiso: Permiso.fechaPermiso
    };

    PermisoDataService.save(data)
      .then(response => {
        setPermiso({
          id: data.id,
          nombreEmpleado: data.nombreEmpleado,
          apellidoEmpleado: data.apellidoEmpleado,
          tipoPermiso: data.tipoPermiso,
          fechaPermiso: data.fechaPermiso
        });
        
        if (response.data.codigo===0){
            setSubmitted(true);
        }else{
            setMessage("Error: " + response.data.mensaje);
        }
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const newPermiso = () => {
    setMessage("");
    setPermiso(initialPermisoState);
    setSubmitted(false);
  };

  return (
    <div className="submit-form">
        <h4>Add Permiso</h4>
      {submitted ? (
        <div>
          <h4>Grabado con exito!</h4>
          <button className="btn btn-success" onClick={newPermiso}>
            Add
          </button>

        </div>
      ) : (
        <div>
          <div className="form-group">
         
            <label htmlFor="nombreEmpleado">Nombres</label>
            <input
              type="text"
              className="form-control"
              id="nombreEmpleado"
              required
              value={Permiso.nombreEmpleado}
              onChange={handleInputChange}
              name="nombreEmpleado"
            />
          </div>

          <div className="form-group">
            <label htmlFor="apellidoEmpleado">Apellido</label>
            <input
              type="text"
              className="form-control"
              id="apellidoEmpleado"
              required
              value={Permiso.apellidoEmpleado}
              onChange={handleInputChange}
              name="apellidoEmpleado"
            />
          </div>

          <div className="form-group">
            <label htmlFor="tipoPermiso">Tipo Permiso</label>
            <input
              type="text"
              className="form-control"
              id="tipoPermiso"
              required
              value={Permiso.tipoPermiso}
              onChange={handleInputChange}
              name="tipoPermiso"
            />
          </div>
            <br></br>
          <button onClick={savePermiso} className="btn btn-success">
            Save
          </button>
          <p>{message}</p>
        </div>
      )}
    </div>
  );
};

export default AddPermiso;