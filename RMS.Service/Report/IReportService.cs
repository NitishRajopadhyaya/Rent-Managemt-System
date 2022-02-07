using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Repository.Report;
using BusinessModel.Report;

namespace RMS.Service.Report
{
   public class IReportService
    {
        private readonly IReportRepository repo;
        public IReportService()
        {
            repo = new ReportRepository();
        }

        public List<ReportModel> Getlist(ReportModel model)
        {
            var list = repo.Getlist(model);
            return list;
            
        }

        public ReportModel LastPaid(int? id)
        {
            ReportModel model = new ReportModel();
            model = repo.LastPaid(id);
            return model;
        }

        public ReportModel MonthlySummary(ReportModel model)
        {
            var Month = 0;
            List<ReportModel> list = new List<ReportModel>();
            while (Month<13)
            {
                Month++;
                decimal? TotalPaid = 0;
                model.From = Month.ToString();
                model.To = Month.ToString();
               var model1= repo.MonthlySummary(model);
               
                if (model1 == null)
                    continue;
                else
                {
                    model1.list = repo.Getlist(model);
                    model1.From = Month.ToString();
                    foreach(var item in model1.list)
                    {
                         TotalPaid += item.PaidAmount; 
                    }
                    model1.TotalPaid = TotalPaid;
                    list.Add(model1);
                }
                

               
            }

            model.list = list;
            return model;
        } 

        public ReportModel DailyReport(ReportModel model)
        {
             model.list = repo.DailyReport(model);
            
             return model;
        }
    }
}
