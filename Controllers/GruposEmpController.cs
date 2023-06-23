using Microsoft.AspNetCore.Mvc;
using RestApi.Helpers;
using RestApi.Models;
using System.Data;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/grupos_empresariales")]
    public class GruposEmpController : Controller
    {

        DataTable _dt = new();
        private GruposEmp? _gruposEmp;
        private GruposEmpHelper? _gruposEmpHelper;
        public List<GruposEmp>? _listagruposEmp;


        [HttpGet]
        public dynamic GetArticulos()
        {
            _dt = new DataTable();
            _gruposEmp = new GruposEmp();

            _gruposEmpHelper = new GruposEmpHelper(_gruposEmp);
            _dt = _gruposEmpHelper.GetGruposEmpresariales();

            _listagruposEmp = new List<GruposEmp>();

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                GruposEmp gruposEmp = new GruposEmp()
                {
                    Grupo_emp_id = Convert.ToInt32(_dt.Rows[i]["grupo_emp_id"].ToString()),
                    Grupo_emp_nombre = _dt.Rows[i]["grupo_emp_nombre"].ToString()!,
                };
                _listagruposEmp.Add(gruposEmp);
            }
            return _listagruposEmp;
        }

    }
}
