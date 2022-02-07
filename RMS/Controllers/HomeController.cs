using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS.Service.Home;
using BusinessModel.Home;

namespace RMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeServices ser;

        public HomeController()
        {
            ser = new IHomeServices();
        }
        public ActionResult Index()
        {

            HomeModel model = new HomeModel();
            model.list = ser.GetList();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            HomeModel model = new HomeModel();
            model = ser.Getbyid(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HomeModel model)
        {
            HomeModel model1 = new HomeModel();
            model1 = ser.Edit(model);

            model.list = ser.GetList();

            return View("Index", model1);
        }
    }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
