using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AspMVC5Training.Areas.Tools.Controllers
{
    public class ValidController : Controller
    {
        [HttpPost]
        public ActionResult IpV6(string ipV6,string ipv4,string name)
        {
            IPAddress inputValue;
            if (IPAddress.TryParse(ipV6?.ToString() ?? string.Empty, out inputValue) &&
                inputValue.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return Json(true);
            }

            if(name == "DD")
            {
                Thread.Sleep(5000);
                return Json("你輸入DD 所以睡5秒");
            }

            if (ipv4 == "a.a")
            {
                return Json("這不是IP吧");
            }

            return Json(false);
        }
    }
}