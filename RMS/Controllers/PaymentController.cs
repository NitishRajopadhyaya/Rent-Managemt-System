using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS.Service.Payment;
using BusinessModel.Payment;
using BusinessModel.TenantInfo;

namespace RMS.Controllers
{
    public class PaymentController : Controller
    {
        private string connString = ConfigurationManager.ConnectionStrings["DBstring"].ToString();
        private readonly IPaymentServices ser;

        public PaymentController()
        {
            ser = new PaymentServices();
        }
        public ActionResult Index()
        {
            return View();
        }
        

        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentModel model)
        {
            PaymentModel model1 = new PaymentModel();
            model1 = ser.Create(model);
            
            return RedirectToAction("Index", "TenantInfo");
        }

        
    }
}