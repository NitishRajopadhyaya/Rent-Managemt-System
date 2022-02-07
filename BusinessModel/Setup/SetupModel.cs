using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel.Common;

namespace BusinessModel.Setup
{
    public class SetupModel :BaseModel
    {
        public int Id { get; set; }

        public int FloorId { get; set; }
        public int Amount { get; set; }

        public List<SetupModel> list { get; set; }

    }
    public class RentSetupModel : BaseModel
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public int Amount { get; set; }
        public List<RentSetupModel> List { get; set; }

    }

    public class FloorSetup:BaseModel
    {

    }
}
