using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel.Common;

namespace BusinessModel.Home
{
    public class HomeModel:BaseModel
    {
        public int id { get; set; }
        public string  BrandName { get; set; }
        public string  Name { get; set; }
        public int Availability { get; set; }
        public List<HomeModel> list { get; set; }
    }


}
