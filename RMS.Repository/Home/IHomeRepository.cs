using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel.Home;
using Dapper;

namespace RMS.Repository.Home
{
    public class IHomeRepository
    {
        private string connstring = ConfigurationManager.ConnectionStrings["Dbstring"].ToString();
        public List<HomeModel> GetList()
        {
            string sql = @"Select * from Brand";

            #region without using clause
            SqlConnection con = new SqlConnection(connstring);
            con.Open();

            var list1 = con.Query<HomeModel>(sql);



            return list1.ToList();

            con.Close();
            #endregion

            #region with using clause
            //using (var con1 = new SqlConnection(connstring))
            //{
            //    con1.Open();
            //    return con.Query<HomeModel>(sql).ToList();
            //}
            #endregion


            #region using sqlcommand
            //SqlCommand homecmd = new SqlCommand(sql, con);

            //SqlDataReader dataReader = homecmd.ExecuteReader();
            //List<HomeModel> list = new List<HomeModel>();

            //while (dataReader.Read()) 
            //{
            //    HomeModel model = new HomeModel();

            //    model.id = Convert.ToInt32(dataReader["id"].ToString());
            //    model.BrandName = dataReader["BrandName"].ToString();
            //    model.Availability = Convert.ToInt32(dataReader["Availability"].ToString());
            //    list.Add(model);
            //}
            #endregion

            #region query with params

            //string sql1 = @"select * from brand where id = @Id";
            //DynamicParameters param = new DynamicParameters();
            //param.Add("Id", 1);
            //param.Add("FirstNAme", "Aayush");
            ////FirstName = "Aayush"
            ////    Lastname = "TEst";
            ////param.Add("FirstName", "Aayush");

            //var parameter = DapperService.AddParam(model);

            //var list = DapperService.Query<HomeModel>(sql1,param);
            #endregion



        }

        public HomeModel GetbyId(int? id)
        {
            string sql = @"Select * from Brand where id=@id";

            SqlConnection con = new SqlConnection(connstring);
            //SqlCommand cmd = new SqlCommand(sql, con);
            var Paramters = DapperService.AddParam(id);

            HomeModel model = new HomeModel();
            model = DapperService.Query<HomeModel>(sql, Paramters).FirstOrDefault();
            //var mm = con.Execute(sql1, Parameter);
            //var mm = con.Execute(sql2, Parameter);

            //SqlDataReader dataReader = cmd.ExecuteReader();
            //HomeModel model = new HomeModel();

            //while (dataReader.Read())
            //{
            //    model.id = Convert.ToInt32(dataReader["id"].ToString());
            //    model.BrandName = dataReader["BrandName"].ToString();
            //    model.Availability = Convert.ToInt32(dataReader["Availability"].ToString());
            //}

            //con.Close();
            return model;
        }
        public bool Edit(HomeModel model)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                //string sql = @"Update Brand set BrandName=@BrandName,Availability=@Availability-5 where id=@id";
                string sql1 = @"Insert into customer values(@Name,@BrandName,5)";
                model.Name = "Aayush";

                // SqlCommand cmd1 = new SqlCommand(sql, con, transaction);

                var Paramters = DapperService.AddParam(model);

                //cmd1.Parameters.AddWithValue("id", model.id);
                //cmd1.Parameters.AddWithValue("BrandName", model.BrandName);
                //cmd1.Parameters.AddWithValue("Availability", model.Availability);



                //con.Query<HomeModel>(sql,transaction:transaction,commandType:System.Data.CommandType.Text);
                DapperService.Execute(sql1, Paramters);
                

                //cmd1.ExecuteNonQuery();

               // SqlCommand cmd2 = new SqlCommand(sql1, con, transaction);

                //cmd2.Parameters.AddWithValue("BrandName", model.BrandName);

                //cmd2.ExecuteNonQuery();

                transaction.Commit();

                con.Close();

                return true;


            }

            catch (Exception)
            {
                // ex.Message;
                transaction.Rollback();
                return false;
            }







        }
    }
}
