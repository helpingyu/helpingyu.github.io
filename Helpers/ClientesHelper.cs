using RestApi.Datos;
using System.Data;
using RestApi.Models;
using System.Data.SqlClient;
using Npgsql;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Helpers
{
    public class ClientesHelper
    {
        private BaseDatos? _datos;
        DataTable _dT = new();
        private readonly Clientes _clientes;

        public ClientesHelper(Clientes clientes) { 
            _clientes = clientes;
        }
        //Tabla para mostrar los clientes registrados
        [HttpGet]
        public DataTable MostrarClientes() {
            _dT = new DataTable();
            try
            {
                _datos = new BaseDatos();
                
                //_dT = _datos.RetornaTablaText();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _dT;
        }


    }
}
