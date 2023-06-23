using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApi.Models;
using System.Net.Http;

namespace RestApi.Datos
{
    public class ConexionMinisterioHacienda
    {
        readonly HttpClientHandler _clienteHandler = new();
        public HttpClient httpCliente = new();

        [HttpPost]
        public async Task<dynamic> getToken() {

            try
            {
                httpCliente = new HttpClient(_clienteHandler);

                string url = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token"; //Comprobantes electrónicos

                var requestContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("client_id", "api-stag"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "cpj-3-101-607717@stag.comprobanteselectronicos.go.cr"),
                new KeyValuePair<string, string>("password", "?_^ig.Y$p?zV-e?-cxme"),
                });

                var response = await httpCliente.PostAsync(url, requestContent);

                string apiResponse = await response.Content.ReadAsStringAsync();
                var resultados = JsonConvert.DeserializeObject<IdpModel>(apiResponse);

                List<IdpModel> _list = new ();

                IdpModel idModel = new ()
                {
                    Access_Token = resultados!.Access_Token
                };
               _list.Add(idModel);

                return _list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
