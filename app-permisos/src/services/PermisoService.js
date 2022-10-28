import http from "../http-common";

const getAll = () => {
  return http.post("/GetAllPermisos");
};

const getAllTipo = () => {
    return http.post("/GetAllTipoPermisos");
  };

const get = id => {
  return http.post("/GetPermiso?id=" + id);
};

const save = data => {
  return http.post("/SavePermiso", data);
};

const PermisoService = {
  getAll,
  getAllTipo,
  get,
  save
};

export default PermisoService;