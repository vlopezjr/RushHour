using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RushHour.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RushHour.DAL.Initializers.SampleDataInitializer.SeedData(new DAL.EF.RushHourContext());
            RushHour.DAL.Initializers.SampleDataInitializer.InitializeData(new DAL.EF.RushHourContext());
        }
    }
}
