using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaniyaStore.Models;
using System.Data.SqlClient;

namespace TaniyaStore.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=taniyastore;Trusted_Connection=True;";

        public Product GetProduct(int id)
        {
            Product product = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM products WHERE id = @productId;", conn);
                    cmd.Parameters.AddWithValue("@productId", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        product = MapRowToProduct(reader);
                    }
                    return product;
                }
            }
            catch(SqlException)
            {
                throw;
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM products;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Product product = MapRowToProduct(reader);
                        products.Add(product);
                    }
                    return products;
                }

            }
            catch(SqlException)
            {
                throw;
            }
        }
        public List<Product> GetAllFromCategoryId(int id)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM products WHERE category_id = @categoryId;", conn);
                    cmd.Parameters.AddWithValue("@categoryId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    {
                        Product product = MapRowToProduct(reader);
                        products.Add(product);
                    }
                    return products;
                }
            }
            catch(SqlException)
            {
                throw;
            }
        }

        private static Product MapRowToProduct(SqlDataReader reader)
        {
            return new Product
            {
                ProductId = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["product"]),
                Price = Convert.ToDecimal(reader["price"]),
                CategoryId = Convert.ToInt32(reader["category_id"]),
                Image = Convert.ToString(reader["image"])
            };
        }
    }
}