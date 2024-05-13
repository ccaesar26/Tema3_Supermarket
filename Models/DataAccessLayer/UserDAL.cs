using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.DataAccessLayer;

public static class UserDAL
{
    public static IEnumerable<User> GetUsers()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();
            
            var reader = command.ExecuteReader();
            var users = new List<User>();
            
            while (reader.Read())
            {
                var user = new User
                {
                    UserId = (int) reader["UserId"],
                    Username = reader["Username"].ToString()!,
                    Password = reader["Password"].ToString()!,
                    UserType = (EUserType) reader["UserType"],
                    IsActive = (bool)reader["IsActive"]
                };
                users.Add(user);
            }
            
            reader.Close();
            
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<User>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static User GetUserById(int userId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", userId);
            
            connection.Open();
            
            var reader = command.ExecuteReader();
            var user = new User();
            
            if (reader.Read())
            {
                user.UserId = (int) reader["UserId"];
                user.Username = reader["Username"].ToString()!;
                user.Password = reader["Password"].ToString()!;
                user.UserType = (EUserType) reader["UserType"];
                user.IsActive = (bool)reader["IsActive"];
            }
            
            reader.Close();
            
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new User();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool InsertUser(User user)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@UserType", user.UserType);
            
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
    
    public static bool UpdateUser(User user)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", user.UserId);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@UserType", user.UserType);
            
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
    
    public static bool DeleteUser(int userId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spUserDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@UserId", userId);
            
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