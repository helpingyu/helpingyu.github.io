using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Helpers;
using System.Data;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : Controller
    {
        DataTable _dt = new();
        private Clientes? _clientes;
        private ClientesHelper? _clientesHelper;

        [HttpGet]
        public dynamic GetClientes(){
            _dt = new DataTable();
            _clientes = new();
            _clientes.Opcion = 1;
            _clientesHelper = new ClientesHelper(_clientes);
            _dt = _clientesHelper.MostrarClientes();


            List<Clientes> Listaclientes = new();
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                Clientes cliente = new();
                cliente.Opcion = 1;
                cliente.CliCedula = Convert.ToInt32(_dt.Rows[i]["id"].ToString());
                cliente.CliNombre = _dt.Rows[i]["nombre"].ToString();
                //cliente.CliCorreo = _dt.Rows[i]["cliCorreo"].ToString();

                Listaclientes.Add(cliente);
            }
            return Listaclientes;
        }

        

    }
}
    
