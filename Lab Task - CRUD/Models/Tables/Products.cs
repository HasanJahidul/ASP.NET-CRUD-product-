using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab_Task___CRUD.Models.Entity;
using System.Data.SqlClient;

namespace Lab_Task___CRUD.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Create(Product p)
        {
            string query = String.Format("Insert into Products values ('{name}','{price}','{quantity}','{description}')", p.Name, p.Price,
                p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public List<Product> GetAll()
        {
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Price = reader.GetInt32(reader.GetOrdinal("price")),
                    Quantity = reader.GetString(reader.GetOrdinal("quantity")),
                    Description  = reader.GetString(reader.GetOrdinal("description")),

                };
                products.Add(p);
            }
            conn.Close();
            return products;
        }
        public Product Get(int id)
        {
            conn.Open();
            string query = String.Format("Select * from Students where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while (reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Price = reader.GetInt32(reader.GetOrdinal("price")),
                    Quantity = reader.GetString(reader.GetOrdinal("quantity")),
                    Description = reader.GetString(reader.GetOrdinal("description")),
                };
            }
            conn.Close();
            return p;
        }

    }
}