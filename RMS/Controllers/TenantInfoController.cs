using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel.TenantInfo;
using RMS.Models;
using RMS.Service.TenantInfo;
//using RMS.Utility;
namespace RMS.Controllers
{
    public class TenantInfoController : Controller
    {
        private string connString = ConfigurationManager.ConnectionStrings["DBstring"].ToString();
        private readonly ITenantInfoService ser;

        public TenantInfoController()
        {
            ser = new TenantInfoService();
        }
        public ActionResult Index()
        {
            TenantInfoModel model = new TenantInfoModel();
            model.List = ser.GetList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TenantInfoModel model)
        {
            var model2 = new TenantInfoModel();
            model2 = ser.Create(model);
            model2.List = ser.GetList();
            return View("Index", model2);
        }

        public ActionResult Edit(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = ser.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TenantInfoModel model)
        {
            var model1 = ser.Edit(model);
            model.List = ser.GetList();
            return View("Index", model1);
        }


        public ActionResult Delete(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = ser.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(TenantInfoModel model)
        {
            var model1 = ser.Delete(model);
            model1.List = ser.GetList();
            return View("Index", model1);
        }


    }
}