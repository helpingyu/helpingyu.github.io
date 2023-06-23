using Microsoft.AspNetCore.Mvc;
using RestApi.Datos;
using RestApi.Models;
using System.Data;

namespace RestApi.Helpers
{
    public class TipoUnidadesHelper
    {
        private BaseDatos? _datos;
        DataTable _dT = new();
        private readonly TipoUnidades? _tipoU;

        public TipoUnidadesHelper(TipoUnidades? tipoU) { 
            _tipoU = tipoU;
        }

        [HttpGet]
        public DataTable getTipoUnidades() {
            try
            {
                _dT = new DataTable();
                _datos = new BaseDatos();
                string query = "SELECT * FROM tipo_unidad";
                _dT = _datos.RetornaTablaText(query);
                return _dT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


    }
}
