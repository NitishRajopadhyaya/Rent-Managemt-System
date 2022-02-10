using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel.Common;
using System.Threading.Tasks;

namespace BusinessModel.Report
{
    public class ReportModel:BaseModel
    {
        
        // public string PaidBy { get; set; }

        public int TenantId { get; set; }

        // public string TenantName { get; set; }

        public int FloorId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string From { get; set; }
        public string To { get; set; }
       
        public decimal? DueAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Advance { get; set; }
        public List<ReportModel> list { get; set; }
        public int TransactionCount { get; set; }
        public string Year { get; set; }
        public decimal? TotalPaid { get; set; }
    }
}
