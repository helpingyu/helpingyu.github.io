using Microsoft.AspNetCore.Mvc;
using RestApi.Datos;
using RestApi.Models;
using System.Data;

namespace RestApi.Helpers
{
    public class GruposEmpHelper
    {
        private BaseDatos? _datos;
        DataTable _dT = new();
        private readonly GruposEmp _gruposEmp;


        public GruposEmpHelper(GruposEmp gruposEmp)
        {
            _gruposEmp = gruposEmp;
        }


        [HttpGet]
        //Tabla para mostrar los clientes registrados
        public DataTable GetGruposEmpresariales()
        {
            _dT = new DataTable();
            try
            {
                _datos = new BaseDatos();
                string query = "SELECT * FROM grupo_empresarial";
                _dT = _datos.RetornaTablaText(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _dT;
        }

    }
}
