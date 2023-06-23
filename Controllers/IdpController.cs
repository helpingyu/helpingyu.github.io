using Microsoft.AspNetCore.Mvc;
using RestApi.Helpers;
using RestApi.Models;
using System.Data;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/idp")]
    public class IdpController : Controller
    {
        private IdpModel _idpmodel;
        private IdpHelper _dphelper;
        public List<IdpModel>? _listidp;

        [HttpGet]
        public async Task<IdpModel> GetToken()
        {
            _idpmodel = new();
            _dphelper = new IdpHelper(_idpmodel);

            _listidp = new List<IdpModel>();

            _listidp = await _dphelper.getMHToken();
            _idpmodel.Access_Token = _listidp[0].Access_Token;


            return _idpmodel;
        }
    }
}
