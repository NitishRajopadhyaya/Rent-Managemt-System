using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Models
{
    public class PaymentModel
    {
         public int Id { get; set; }
         public int PaymentId { get; set; }
         public string PaidBy { get; set; }
         public string PaymentDate { get; set; }
         public char IsDue { get; set; }
         public int DueAmount { get; set; }
         public int PaidAmount{ get; set; }

         public List<PaymentModel> list { get; set; }
    }
}