using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.DataAccessLayer.Helpers;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.DataAccessLayer;

public static class ProducerDAL
{
    public static IEnumerable<Producer> GetProducers()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProducerSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();
            
            var reader = command.ExecuteReader();
            var producers = new List<Producer>();
            
            while (reader.Read())
            {
                var producer = new Producer
                {
                    ProducerId = (int) reader["ProducerId"],
                    Name = reader["Name"].ToString()!,
                    OriginCountry = reader["OriginCountry"].ToString()!,
                    IsActive = (bool)reader["IsActive"]
                };
                producers.Add(producer);
            }
            
            reader.Close();
            
            return producers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Producer>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static Producer GetProducerById(int producerId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProducerSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProducerId", producerId);
            
            connection.Open();
            
            var reader = command.ExecuteReader();
            var producer = new Producer();
            
            if (reader.Read())
            {
                producer.ProducerId = (int) reader["ProducerId"];
                producer.Name = reader["Name"].ToString()!;
                producer.OriginCountry = reader["OriginCountry"].ToString()!;
                producer.IsActive = (bool)reader["IsActive"];
            }
            
            reader.Close();
            
            return producer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Producer();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool InsertProducer(Producer producer)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProducerInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Name", producer.Name);
            command.Parameters.AddWithValue("@OriginCountry", producer.OriginCountry);
            
            connection.Open();
            command.ExecuteNonQuery();
            
            return true;
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
    
    public static bool UpdateProducer(Producer producer)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProducerUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProducerId", producer.ProducerId);
            command.Parameters.AddWithValue("@Name", producer.Name);
            command.Parameters.AddWithValue("@OriginCountry", producer.OriginCountry);
            
            connection.Open();
            command.ExecuteNonQuery();
            
            return true;
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
    
    public static bool DeleteProducer(Producer producer)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProducerDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProducerId", producer.ProducerId);
            
            connection.Open();
            command.ExecuteNonQuery();
            
            return true;
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