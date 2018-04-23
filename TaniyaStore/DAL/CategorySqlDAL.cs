using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaniyaStore.Models;
using System.Data.SqlClient;


namespace TaniyaStore.DAL
{
    public class CategorySqlDAL : ICategoryDAL
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=taniyastore;Trusted_Connection=True;";

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM categories;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Category category = MapRowToCategory(reader);
                        categories.Add(category);
                    }
                    return categories;
                }

            }
            catch (SqlException)
            {
                throw;
            }
        }
        private static Category MapRowToCategory(SqlDataReader reader)
        {
            return new Category
            {
                CategoryId = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
            };
        }
    }
}