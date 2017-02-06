using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiSuperZapatos.Controllers
{
    public class StoreController : ApiController
    {
        [HttpGet]
        public string[] GetStores()
        {
            return new string[]
            {
                 "'id': 1",
                 "'address': 'Somewhere over the shadows'",
                 "'name': 'Mega store"
            };
        }
    }
}