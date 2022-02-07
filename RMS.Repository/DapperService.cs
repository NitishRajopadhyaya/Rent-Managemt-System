using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RMS.Repository
{
    public  class DapperService
    {
        private static readonly string connstring = ConfigurationManager.ConnectionStrings["Dbstring"].ToString();

        public static List<T> Query<T>(string sql)
        {
            using (var con = new SqlConnection(connstring))
            {
                con.Open();
                return con.Query<T>(sql).ToList();
            }
        }

        public static List<T> Query<T>(string sql,DynamicParameters param)
        {
            using (var con = new SqlConnection(connstring))
            {
                con.Open();
                return con.Query<T>(sql,param).ToList();
            }
        }

        public static int Execute(string sql, DynamicParameters param)
        {
            using (var con = new SqlConnection(connstring))
            {
                con.Open();
                return con.Execute(sql, param);
            }
        }

        public static DynamicParameters AddParam(object param)
        {
            // param.GetType().GetProperties();

            DynamicParameters tset = new DynamicParameters();
            if(param.GetType().IsValueType)
            {
                tset.Add("id", param);

                return tset;
            }

            
            foreach (var item in param.GetType().GetProperties())
            {
                tset.Add(item.Name, item.GetValue(param));
            }

            return tset;


        }

        }
}
