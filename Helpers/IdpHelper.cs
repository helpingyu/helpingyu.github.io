using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApi.Datos;
using RestApi.Models;
using System.Data;
using System.Net.Http;

namespace RestApi.Helpers
{
    public class IdpHelper
    {
        readonly HttpClientHandler _clienteHandler = new();
        public HttpClient httpCliente = new();
        private readonly IdpModel _idpmodel;
        private ConexionMinisterioHacienda? _hacienda;
        public List<IdpModel>? _listDatosHacienda;
       

        public IdpHelper(IdpModel idpModel) {
            _idpmodel = idpModel; 
        }


        /*Obtener el token y datos del ministerio de hacienda*/
        [HttpGet]
        public async Task<List<IdpModel>> getMHToken()
        {
            try
            {
                _listDatosHacienda = new List<IdpModel>();
                _hacienda = new ConexionMinisterioHacienda();
                List<IdpModel> datos = await _hacienda.getToken();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }



    }
}
