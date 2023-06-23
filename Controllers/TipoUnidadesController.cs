using Microsoft.AspNetCore.Mvc;
using RestApi.Helpers;
using RestApi.Models;
using System.Data;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/tipo_unidades")]
    public class TipoUnidadesController : Controller
    {
        DataTable _dt = new();
        private TipoUnidades? _tipoU;
        private TipoUnidadesHelper? _tipoUHelper;
        public List<TipoUnidades>? _list_tipoU;


        [HttpGet]
        public List<TipoUnidades> GetArticulos()
        {
            _dt = new DataTable();
            _tipoU = new TipoUnidades();

            _tipoUHelper = new TipoUnidadesHelper(_tipoU);
            _dt = _tipoUHelper.getTipoUnidades();

            _list_tipoU = new List<TipoUnidades>();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                TipoUnidades tipoU = new()
                {
                    Tipou_id = Convert.ToInt32(_dt.Rows[i]["tipou_id"].ToString()),
                    Tipou_nombre = _dt.Rows[i]["tipou_nombre"].ToString()!
                };
                _list_tipoU.Add(tipoU);
            }
            return _list_tipoU;
        }

    }
}
