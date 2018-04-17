using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class ModelRepository : IModelRepository
    {
        public List<Model> GetAllModels()
        {
            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                List<Model> models = new List<Model>();
                SqlCommand cmd = new SqlCommand("GetModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model row = new Model();
                        row.Make = new Make();
                        row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.Make.MakeId = (int)dr["MakeId"];
                        row.Make.MakeName = dr["MakeName"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserName = dr["UserName"].ToString();

                        models.Add(row);
                    }
                }
                if (models.Any())
                {
                    return models;
                }
                return null;
            }
        }

        public List<Model> GetModelsByMakeId(int makeId)
        {
            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                List<Model> models = new List<Model>();
                SqlCommand cmd = new SqlCommand("GetModelsByMakeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model row = new Model();
                        row.Make = new Make();
                        row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.Make.MakeId = (int)dr["MakeId"];
                        row.Make.MakeName = dr["MakeName"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserName = dr["UserName"].ToString();

                        models.Add(row);
                    }
                }
                if (models.Any())
                {
                    return models;
                }
                return null;
            }
        }

        public Model Save(Model model)
        {
            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ModelId", model.ModelId, DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@MakeId", model.Make.MakeId);
                parameters.Add("@ModelName", model.ModelName);
                parameters.Add("@UserName", model.UserName);
                parameters.Add("@DateAdded", model.DateAdded);
                cn.Execute("SaveModel", parameters, commandType: CommandType.StoredProcedure);
                return model;
            }
        }
    }
}
