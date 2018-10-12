using RushHour.Models.Entities;
using RushHour.MVC.Configuration;
using RushHour.MVC.WebServiceAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RushHour.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebApiCalls _webApiCalls;

        public HomeController() : this(new WebApiCalls(new WebServiceLocator())) { }

        public HomeController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        public async Task<ActionResult> Index()
        {
            var customers = await _webApiCalls.GetCustomersAsync();
            return View(customers);
        }

        public async Task<ActionResult> AddDelivery(Delivery delivery)
        {
            int deliveryId = await _webApiCalls.AddDelivery(delivery);
            return View(deliveryId);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}