using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.DataAccessLayer;

public static class OfferDAL
{
    public static IEnumerable<Offer> GetOffers()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOfferSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            
            connection.Open();
            
            var reader = command.ExecuteReader();
            var offers = new List<Offer>();
            
            while (reader.Read())
            {
                var offer = new Offer
                {
                    OfferId = (int) reader["OfferId"],
                    ProductId = (int) reader["ProductId"],
                    DiscountPercentage = (int) reader["DiscountPercentage"],
                    StartDate = (DateTime) reader["StartDate"],
                    EndDate = (DateTime) reader["EndDate"],
                    Reason = (EReason) reader["Reason"],
                    IsActive = (bool)reader["IsActive"]
                };
                offers.Add(offer);
            }
            
            reader.Close();
            
            return offers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Offer>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static Offer GetOfferById(int offerId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOfferSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OfferId", offerId);
            
            connection.Open();
            
            var reader = command.ExecuteReader();
            var offer = new Offer();
            
            while (reader.Read())
            {
                offer.OfferId = (int) reader["OfferId"];
                offer.ProductId = (int) reader["ProductId"];
                offer.DiscountPercentage = (int) reader["DiscountPercentage"];
                offer.StartDate = (DateTime) reader["StartDate"];
                offer.EndDate = (DateTime) reader["EndDate"];
                offer.Reason = (EReason) reader["Reason"];
                offer.IsActive = (bool)reader["IsActive"];
            }
            
            reader.Close();
            
            return offer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Offer();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static void AddOffer(Offer offer)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOfferInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@DiscountPercentage", offer.DiscountPercentage);
            command.Parameters.AddWithValue("@StartDate", offer.StartDate);
            command.Parameters.AddWithValue("@EndDate", offer.EndDate);
            command.Parameters.AddWithValue("@Reason", offer.Reason);
            
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool UpdateOffer(Offer offer)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOfferUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", offer.ProductId);
            command.Parameters.AddWithValue("@DiscountPercentage", offer.DiscountPercentage);
            command.Parameters.AddWithValue("@StartDate", offer.StartDate);
            command.Parameters.AddWithValue("@EndDate", offer.EndDate);
            command.Parameters.AddWithValue("@Reason", offer.Reason);
            
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
    
    public static bool DeleteOffer(int offerId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spOfferDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@OfferId", offerId);
            
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