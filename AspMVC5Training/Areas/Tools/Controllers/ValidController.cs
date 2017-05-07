using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace AspMVC5Training.Areas.Tools.Controllers
{
    public class ValidController : Controller
    {
        public ActionResult IpV6(string ipV6)
        {
            IPAddress inputValue;
            if (IPAddress.TryParse(ipV6?.ToString() ?? string.Empty, out inputValue) &&
                inputValue.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}