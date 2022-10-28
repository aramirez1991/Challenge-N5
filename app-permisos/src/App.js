import React from "react";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import AddPermiso from "./components/AddPermiso";
import Permiso from "./components/Permiso";
import PermisosList from "./components/PermisosList";

function App() {
  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/permisos" className="navbar-brand">
          App-Permisos
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/permisos"} className="nav-link">
              Permisos
            </Link>
          </li>
          <li className="nav-item">
            <Link to={"/add"} className="nav-link">
              Add
            </Link>
          </li>
        </div>
      </nav>

      <div className="container mt-3">
        <Routes>
          <Route path="/" element={<PermisosList/>} />
          <Route path="/permisos" element={<PermisosList/>} />
          <Route path="/add" element={<AddPermiso/>} />
          <Route path="/permiso/:id" element={<Permiso/>} />
        </Routes>
      </div>
    </div>
  );
}

export default App;