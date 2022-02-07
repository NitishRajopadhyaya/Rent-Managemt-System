using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS.Service.Report;
using BusinessModel.Report;  

namespace RMS.Controllers
{
    public class ReportController : Controller
    {
       private readonly IReportService ser;
       public ReportController()
        {
            ser =  new IReportService();
        }
        public ActionResult MonthlyReport()
        {
            return View();
        }

        public ActionResult GetMonthlyReport(ReportModel model)
        {
            model.list = ser.Getlist(model);
            return View(model);
        }

        public ActionResult GetDailyReportDate()
        {
            return View();
        }
 
        public ActionResult GetDailyReport(ReportModel model)
        {
            model = ser.DailyReport(model);
            return View(model);
           
        }
       
        public ActionResult GetTenant()
        {
            return View();
        }

        public ActionResult GetLastPaid(ReportModel model)
      {
            
            model = ser.LastPaid(model.TenantId);
            return View(model);
        }

        public ActionResult GetMonthlySummary(ReportModel model)
        {
            
            model = ser.MonthlySummary(model);
            return View(model);
        }

    }
}