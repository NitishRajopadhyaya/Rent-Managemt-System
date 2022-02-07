using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel.Report;
using Dapper;

namespace RMS.Repository.Report
{
    public interface IReportRepository
    {
        List<ReportModel> Getlist(ReportModel model);
        ReportModel LastPaid(int? id);
        ReportModel MonthlySummary(ReportModel model);
        List<ReportModel> DailyReport(ReportModel model);
    }

   public class ReportRepository: IReportRepository
    {
        public List<ReportModel> Getlist(ReportModel model)
        {
            string sql = @"Select tenantId,floorId,PaidAmount,PaymentDate,DueAmount,Advance from payment where((MONTH(PaymentDate) between @From and @To) and tenantId = @Id)";

            var parameters = DapperService.AddParam(model.TenantId);
            parameters.Add("From", model.From);
            parameters.Add("To", model.To);

            var list = DapperService.Query<ReportModel>(sql, parameters).ToList();

            return list;

        }
         
        public ReportModel LastPaid(int? id)
        {
            string sql = @"Select * from Payment where TenantID =@id";
            var parameters = DapperService.AddParam(id);

            var model = DapperService.Query<ReportModel>(sql, parameters).LastOrDefault();

            return model;
        }

        public ReportModel MonthlySummary(ReportModel model)
        {
            string sql = @"select * from payment where MONTH(PaymentDate) = @Month and TenantId=@id";
            var parameter = DapperService.AddParam(model.TenantId);
            parameter.Add("Month", model.From);

             model = DapperService.Query<ReportModel>(sql, parameter).LastOrDefault();
             
            return model;
        } 

        public List<ReportModel> DailyReport(ReportModel model)
        {
            string sql = @"Select * from Payment where (PaymentDate between @From and @To) and TenantId = @id";
            var parameter = DapperService.AddParam(model.TenantId);
            parameter.Add("From",model.FromDate);
            parameter.Add("To", model.ToDate);

            var list = DapperService.Query<ReportModel>(sql, parameter).ToList();

            return list;
        }


    }
}
