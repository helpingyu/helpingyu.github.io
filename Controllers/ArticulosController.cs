using Microsoft.AspNetCore.Mvc;
using RestApi.Helpers;
using RestApi.Models;
using System.Data;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/articulos")]

    public class ArticulosController : Controller
    {

        DataTable _dt = new();
        private Articulos? _articulos;
        private ArticulosHelper? _articulosHelper;
        public List<Articulos>? _listarticulos;

        [HttpGet]
        public dynamic GetArticulos()
        {
            _dt = new DataTable();
            _articulos = new();

            _articulosHelper = new ArticulosHelper(_articulos);
            _dt = _articulosHelper.MostrarArticulos();

            _listarticulos = new List<Articulos>();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                Articulos articulos = new()
                {
                    Art_id = Convert.ToInt32(_dt.Rows[i]["art_id"].ToString()),
                    Art_nombre = _dt.Rows[i]["art_nombre"].ToString()!,
                    Tipou_nombre = _dt.Rows[i]["tipou_nombre"].ToString()!
                };
                _listarticulos.Add(articulos);
            }
            return _listarticulos;
        }

        [HttpPost]
        public void InsertData(Articulos _articulos) {
            
            _articulosHelper = new ArticulosHelper(_articulos);
            _articulosHelper.InserData(_articulos);
        }
    }
}
