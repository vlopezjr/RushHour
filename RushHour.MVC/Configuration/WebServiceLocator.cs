using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RushHour.MVC.Configuration
{
    public class WebServiceLocator : IWebServiceLocator
    {
        public WebServiceLocator()
        {
            ServiceAddress = ConfigurationManager.AppSettings["ServiceAddress"].ToString();
        }

        public string ServiceAddress { get; }
    }
}