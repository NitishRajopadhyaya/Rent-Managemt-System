using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Repository.Home;
using BusinessModel.Home;


namespace RMS.Service.Home
{
   public class IHomeServices 
    {
        private readonly IHomeRepository repo;

        public IHomeServices()
        {
            repo = new IHomeRepository();
        }
        public List<HomeModel> GetList()
        {
            
            return (repo.GetList());
        }

        public HomeModel Getbyid(int? id)
        {
            return (repo.GetbyId(id));
        }

        public HomeModel Edit(HomeModel model)
        {
            var Edited = repo.Edit(model);
            
            if(Edited)
            {
                model.flag = 0;
                model.IsSuccess = true;
                model.SuccessMessage = "Edited successfully";
            }
            else
            {
                model.flag = 1;
                model.IsSuccess = false;
                model.SuccessMessage = "Failed , Try again";
            }

            return model;
        }
    }
}
