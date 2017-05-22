using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMVC5Training.ViewModel
{
    public class GoogleAuthenticatorViewModel
    {
        public string BarcodeUrl { get; set; }
        public string Code { get; set; }
        public string SecretKey { get; set; }
    }
}