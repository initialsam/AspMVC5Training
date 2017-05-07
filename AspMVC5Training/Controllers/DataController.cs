using AspMVC5Training.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMVC5Training.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Exclude = "Id")] DataViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.Name = "FFFFFFFFF";
                return View(model);
            }
            

            model.Name = "DDDDDDD";
            return View(model);

        }
    }
}