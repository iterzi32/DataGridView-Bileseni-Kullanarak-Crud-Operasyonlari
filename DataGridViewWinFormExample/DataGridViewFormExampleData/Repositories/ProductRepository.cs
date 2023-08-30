using DataGridViewFormExampleData.Helpers;
using DataGridViewFormExampleData.Interfaces;
using DataGridViewWinFormExampleEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewFormExampleData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        SqlConnection connection;
        public ProductRepository()
        {
            connection = new DbConnectionHelper().GetSqlConnection();
        }              
        public void Add(Product product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            command.CommandText = "insert into Products values(@name, @price)";
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);

            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }
        
        public void Delete(Product product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            command.CommandText = "delete from Products where Id = @id";
            command.Parameters.AddWithValue("@id", product.Id);

            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }       
       
        public void Update(Product product)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            command.CommandText = "update Products set Name = @name , Price = @price where Id=@id";
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@id", product.Id);

            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close();
        }
        
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            command.CommandText = "select * from Products";

            connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product();
                product.Id = reader.GetInt32(0);
                product.Name = reader.GetString(1);
                product.Price = reader.GetInt32(2);
                products.Add(product);
            }

            reader.Close();
            connection.Close();

            return products;
        }
    }
}
