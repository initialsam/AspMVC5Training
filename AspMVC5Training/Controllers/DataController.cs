﻿using AspMVC5Training.ViewModel;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AspMVC5Training.Controllers
{
    [Authorize]
    public class DataController : Controller
    {
        private TraceSource traceSource = new TraceSource("AspMVC5Training");
        
        // GET: Data
        public ActionResult Index()
        {
            var a = new GoodsContext();
            traceSource.TraceEvent(TraceEventType.Start,0, "Cars SQL");
            var cars = a.Cars.Where(x => x.Name.StartsWith("S")).ToList();
            traceSource.TraceEvent(TraceEventType.Stop, 0, "Cars SQL");
            traceSource.TraceEvent(TraceEventType.Start,1, "aaaa");
            Thread.Sleep(1111);
            traceSource.TraceEvent(TraceEventType.Stop,1, "bbbb");

            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Exclude = "Id")] DataViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            return View(model);

        }


        public ActionResult IndexAJAX()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexAJAX([Bind(Exclude = "Id")] DataViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var returnData = new
                {
                    // ModelState錯誤訊息 
                    // Ref https://dotblogs.com.tw/wasichris/2015/03/11/150705
                    ModelStateErrors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                                 .ToDictionary(k => k.Key,
                                                               k => k.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                };
                return Content(JsonConvert.SerializeObject(returnData), "application/json");
            }


            return Content(JsonConvert.SerializeObject(new { Success = true }), "application/json");

        }
    }
}