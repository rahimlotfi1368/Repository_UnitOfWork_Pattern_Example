﻿using System.Linq;
namespace MY_APPLICATION.Controllers
{
    public partial class HomeController : Infrastracture.BaseController
    {
        public HomeController() : base()
        {
            
        }
        [System.Web.Mvc.HttpGet]
        public virtual System.Web.Mvc.ViewResult Index()
        {

            return View();
        }
    }
}