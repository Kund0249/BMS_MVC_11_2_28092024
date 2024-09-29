using BMS_MVC.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_MVC.DataAccess.Repositories
{
    public class CategoryRepository
    {
        public void Add(CategoryEntity entity)
        {
            string  cs = "data source=DESKTOP-G3RV5V6;database=BookManagementDB;TrustServerCertificate=True;trusted_connection=true";
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertBookCategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Discription", entity.Discription);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<CategoryEntity> Get()
        {
            List<CategoryEntity> list = null;
            string cs = "data source=DESKTOP-G3RV5V6;database=BookManagementDB;TrustServerCertificate=True;trusted_connection=true";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
               
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    list = new List<CategoryEntity>();
                    while (reader.Read())
                    {
                        list.Add(new CategoryEntity()
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            Name = reader["Name"].ToString(),
                            Discription = reader["Discription"].ToString()
                        });                 
                    }
                }
                con.Close();
            }

            return list;
        }

        public bool Remove(int CategoryId)
        {
            string cs = "data source=DESKTOP-G3RV5V6;database=BookManagementDB;TrustServerCertificate=True;trusted_connection=true";
            int row = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spRemoveCategory", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
               
                con.Open();
               row = cmd.ExecuteNonQuery();
                con.Close();
            }

            if (row > 0)
                return true;
            else
                return false;
        }
    }
}
