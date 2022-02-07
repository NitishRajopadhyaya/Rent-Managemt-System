using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Models
{
    public class RentmanagementModel  // model ma chahi data haru  declare garincha 
    {
        public int FloorNumber { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal Contact { get; set; }
        public int State { get; set; }
        public int District { get; set; }
        public string City { get; set; }
        public int WardNo {get; set; }
        //public FamilyInfoModel FamilyModel { get; set; }
        
    }

    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

    public class DistrictModel
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}