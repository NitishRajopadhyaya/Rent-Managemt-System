using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult GetDistrict(int stateId)
        {
            var districtList = Utility.Utilities.GetDistrict(stateId);

            return Json(new SelectList(districtList, "Value", "Text"));

        }

        public  ActionResult GetFloor(int Id)
        {
            var Floor = Utility.Utilities.GetFloor(Id);
            return Json(Floor,JsonRequestBehavior.AllowGet);
        }
            
    }
}