using Microsoft.AspNetCore.Mvc;
using RestApi.Datos;
using RestApi.Models;
using System.Data;

namespace RestApi.Helpers
{
    public class ArticulosHelper
    {
        private BaseDatos? _datos;
        DataTable _dT = new();
        private readonly Articulos _articulos;


        public ArticulosHelper(Articulos articulos)
        {
            _articulos = articulos;
        }
        //Tabla para mostrar los clientes registrados
        [HttpGet]
        public DataTable MostrarArticulos()
        {
            _dT = new DataTable();
            try
            {
                _datos = new BaseDatos();
                string query = "SELECT art.art_id,art.art_nombre,tipou.tipou_nombre FROM " +
                    "articulos art INNER JOIN tipo_unidad tipou ON tipou.tipou_id = art.tipou_id";
                _dT = _datos.RetornaTablaText(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _dT;
        }

        [HttpPost]
        public void InserData(Articulos articulos) {
            try
            {
                _datos = new BaseDatos();
                string query = "insert into articulos (art_nombre, tipou_id) values ('" + articulos.Art_nombre + "', '"+articulos.Tipou_id+"')";

                _datos.EjecutartCommandoTexto(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
