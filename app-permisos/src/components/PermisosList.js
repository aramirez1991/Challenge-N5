import React, { useState, useEffect, useMemo, useRef } from "react";
import PermisoDataService from "../services/PermisoService";
import { useTable } from "react-table";
import { useNavigate } from 'react-router-dom';

const PermisosList = (props) => {
  const [Permisos, setPermisos] = useState([]);
  const PermisosRef = useRef();

  const navigate = useNavigate();
  PermisosRef.current = Permisos;

  useEffect(() => {
    retrievePermisos();
  }, []);


  const retrievePermisos = () => {
    PermisoDataService.getAll()
      .then((response) => {
        setPermisos(response.data);
      })
      .catch((e) => {
        console.log(e);
      });
  };

  const openPermiso = (rowIndex) => {
    const id = PermisosRef.current[rowIndex].id;
    
    navigate("/Permiso/" + id);
  };


  const columns = useMemo(
    () => [
        {
        Header: "ID",
        accessor: "id",
        },
      {
        Header: "Nombres",
        accessor: "nombreEmpleado",
      },
      {
        Header: "Apellidos",
        accessor: "apellidoEmpleado",
         },
      {
        Header: "Tipo Permiso",
        accessor: "tipoPermiso",
      },
      {
        Header: "Edit",
        accessor: "actions",
        Cell: (props) => {
          const rowIdx = props.row.id;
          return (
            <div>
              <span onClick={() => openPermiso(rowIdx)}>
                <i className="far fa-edit action mr-2"></i>
              </span>
            </div>
          );
        },
      },
    ],
    []
  );

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow,
  } = useTable({
    columns,
    data: Permisos,
  });

  return (
    <div className="list row">
      <div className="col-md-12 list">
        <table
          className="table table-striped table-bordered"
          {...getTableProps()}
        >
          <thead>
            {headerGroups.map((headerGroup) => (
              <tr {...headerGroup.getHeaderGroupProps()}>
                {headerGroup.headers.map((column) => (
                  <th {...column.getHeaderProps()}>
                    {column.render("Header")}
                  </th>
                ))}
              </tr>
            ))}
          </thead>
          <tbody {...getTableBodyProps()}>
            {rows.map((row, i) => {
              prepareRow(row);
              return (
                <tr {...row.getRowProps()}>
                  {row.cells.map((cell) => {
                    return (
                      <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                    );
                  })}
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default PermisosList;