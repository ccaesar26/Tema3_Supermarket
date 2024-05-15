using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.DataAccessLayer;

public static class CategoryDAL
{
    public static IEnumerable<Category> GetCategories()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategorySelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();
            
            var reader = command.ExecuteReader();
            var categories = new List<Category>();
            
            while (reader.Read())
            {
                var category = new Category
                {
                    CategoryId = (int) reader["CategoryId"],
                    Name = reader["Name"].ToString()!,
                    Image = reader["Image"].ToString(),
                    IsActive = (bool)reader["IsActive"]
                };
                categories.Add(category);
            }
            
            reader.Close();
            
            return categories;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Category>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static Category GetCategoryById(int categoryId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategorySelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", categoryId);

            connection.Open();
            
            var reader = command.ExecuteReader();
            var category = new Category();
            
            while (reader.Read())
            {
                category.CategoryId = (int) reader["CategoryId"];
                category.Name = reader["Name"].ToString()!;
                category.Image = reader["Image"].ToString();
                category.IsActive = (bool)reader["IsActive"];
            }
            
            reader.Close();
            
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Category();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool InsertCategory(Category category)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategoryInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Image", category.Image);

            connection.Open();
            var result = command.ExecuteNonQuery();
            
            return result > 0;
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
    
    public static bool UpdateCategory(Category category)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategoryUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Image", category.Image);

            connection.Open();
            var result = command.ExecuteNonQuery();
            
            return result > 0;
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
    
    public static bool DeleteCategory(Category category)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spCategoryDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);

            connection.Open();
            var result = command.ExecuteNonQuery();
            
            return result > 0;
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