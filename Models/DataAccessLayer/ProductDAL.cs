using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.DataAccessLayer.Helpers;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.DataAccessLayer;

public static class ProductDAL
{
    public static IEnumerable<Product> GetProducts()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var products = new List<Product>();
            var categories = CategoryDAL.GetCategories().ToList();
            var producers = ProducerDAL.GetProducers().ToList();

            while (reader.Read())
            {
                var product = new Product
                {
                    ProductId = (int)reader["ProductId"],
                    Name = reader["Name"].ToString()!,
                    Barcode = reader["Barcode"].ToString()!,
                    CategoryId = (int)reader["CategoryId"],
                    ProducerId = (int)reader["ProducerId"],
                    Image = reader["Image"].ToString(),
                    IsActive = (bool)reader["IsActive"],
                    Category = (from c in categories
                                where c.CategoryId == (int)reader["CategoryId"]
                                select c).FirstOrDefault(),
                    Producer = (from p in producers
                                where p.ProducerId == (int)reader["ProducerId"]
                                select p).FirstOrDefault()
                };
                products.Add(product);
            }

            reader.Close();

            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Product>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static Product GetProductById(int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();
            
            var reader = command.ExecuteReader();
            var product = new Product();
            var categories = CategoryDAL.GetCategories().ToList();
            var producers = ProducerDAL.GetProducers().ToList();

            if (reader.Read())
            {
                product.ProductId = (int)reader["ProductId"];
                product.Name = reader["Name"].ToString()!;
                product.Barcode = reader["Barcode"].ToString()!;
                product.CategoryId = (int)reader["CategoryId"];
                product.ProducerId = (int)reader["ProducerId"];
                product.Image = reader["Image"].ToString();
                product.IsActive = (bool)reader["IsActive"];
                product.Category = (from c in categories
                                where c.CategoryId == (int)reader["CategoryId"]
                                select c).FirstOrDefault();
                product.Producer = (from p in producers
                                where p.ProducerId == (int)reader["ProducerId"]
                                select p).FirstOrDefault();
            }

            reader.Close();

            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Product();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool InsertProduct(Product product)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Barcode", product.Barcode);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@ProducerId", product.ProducerId);
            command.Parameters.AddWithValue("@Image", product.Image == null
                ? DBNull.Value
                : product.Image);

            connection.Open();
            
            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool UpdateProduct(Product product)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", product.ProductId);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Barcode", product.Barcode);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@ProducerId", product.ProducerId);
            command.Parameters.AddWithValue("@Image", product.Image);

            connection.Open();
            
            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool DeleteProduct(Product product)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", product.ProductId);

            connection.Open();
            
            return command.ExecuteNonQuery() > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
}