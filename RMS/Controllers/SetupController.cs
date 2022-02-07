using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel.Setup;
using RMS.Service;

namespace RMS.Controllers
{
    public class SetupController : Controller
    {
        private readonly ISetupServices ser;
        public SetupController()
        {
            ser = new SetupService();
        }
        // GET: Setup
        
        public ActionResult Index()
        {
            SetupModel model = new SetupModel();

            model.list = ser.GetList();

            return View(model);
        }
        

        public ActionResult CreateFlor()
        {
            return View();
        }

        public ActionResult CreateRent()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SetupModel model)
        {
            SetupModel model1 = new SetupModel();
            
            model1 = ser.Create(model);
            model1.list = ser.GetList();
            return View("Index",model1);
        }

        public ActionResult Edit(int? id)
        {
            SetupModel model = new SetupModel();

            model = ser.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SetupModel model)
        {
            SetupModel model1 = new SetupModel();

            model1 = ser.Edit(model);
            model1.list = ser.GetList();

            return View("Index", model1);
        } 

        public ActionResult Delete(int? id)
        {
            return View(ser.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(SetupModel model)
        {
            model = ser.Delete(model);
            model.list = ser.GetList();
            return RedirectToAction("Index",model);
        }


    }
}