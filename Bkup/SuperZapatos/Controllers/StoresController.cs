using SuperZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.Controllers
{
    public class StoresController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            StoreModel store = new StoreModel();

            return View(store);
        }
    }
}