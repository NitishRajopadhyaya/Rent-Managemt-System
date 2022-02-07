using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using RMS.Models;
using RMS.Service.TenantInfo;
using BusinessModel.FamilyInfo;

namespace RMS.Controllers
{
    public class FamilyInfoController : Controller
    {
        private string connString = ConfigurationManager.ConnectionStrings["DBstring"].ToString();

        private readonly IFamilyInfoService ser;

        public FamilyInfoController()
        {
            ser = new FamilyInfoService();
        }
        public ActionResult Index(int? id)
        {
            ViewBag.Id = id;
            if (id == null)
            {
                FamilyInfoModel model = new FamilyInfoModel();
                model.List = ser.GetList();
                return View(model);
            }

            else
            {
                FamilyInfoModel model = new FamilyInfoModel();
                model.List = ser.FamilyList(id);
                return View(model);
            }
        }
        public ActionResult Create(int? id)
        {

            FamilyInfoModel model = new FamilyInfoModel();

            model = ser.Create(id);
            ViewBag.Name = model.FirstName;
            // ViewBag.Id = id;
            ViewBag.Floor = model.FloorId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(FamilyInfoModel model)
        {
            var model2 = new FamilyInfoModel();
            model2 = ser.Create(model);
            model2.List = ser.GetList();
            return View("Index", model2);
        }


        public ActionResult Edit(int? id)
        {

            return View(ser.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(FamilyInfoModel model)
        {
            var model2 = new FamilyInfoModel();
            model2 = ser.Edit(model);
            model2.List = ser.GetList();
            return View("Index", model2);
        }

        public ActionResult Delete(int? id)
        {
            return View(ser.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(FamilyInfoModel model)
        {
            var model2 = new FamilyInfoModel();
            model2 = ser.Delete(model);
            model2.List = ser.GetList();

            return View("Index", model2);
        }

    }
}