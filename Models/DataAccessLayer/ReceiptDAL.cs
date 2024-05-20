using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataAccessLayer.Helpers;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.DataAccessLayer;

public static class ReceiptDAL
{
    public static IEnumerable<Receipt> GetReceipts()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spReceiptSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();

            var reader = command.ExecuteReader();
            var receipts = new List<Receipt>();

            while (reader.Read())
            {
                var receipt = new Receipt
                {
                    ReceiptId = (int)reader["ReceiptId"],
                    UserId = (int)reader["UserId"],
                    IssueDate = (DateTime)reader["IssueDate"],
                    AmountReceived = (decimal)reader["AmountReceived"],
                    IsActive = (bool)reader["IsActive"],
                    User = UserDAL.GetUserById((int)reader["UserId"])
                };
                receipts.Add(receipt);
            }

            reader.Close();

            return receipts;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Receipt>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static Receipt GetReceiptById(int receiptId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spReceiptSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ReceiptId", receiptId);

            connection.Open();

            var reader = command.ExecuteReader();
            var receipt = new Receipt();

            while (reader.Read())
            {
                receipt.ReceiptId = (int)reader["ReceiptId"];
                receipt.UserId = (int)reader["UserId"];
                receipt.IssueDate = (DateTime)reader["IssueDate"];
                receipt.AmountReceived = (decimal)reader["AmountReceived"];
                receipt.IsActive = (bool)reader["IsActive"];
                receipt.User = UserDAL.GetUserById(receipt.UserId);
            }

            reader.Close();

            return receipt;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Receipt();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static void InsertReceipt(Receipt receipt)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spReceiptInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            
            command.Parameters.AddWithValue("@UserId", receipt.UserId);
            command.Parameters.AddWithValue("@IssueDate", receipt.IssueDate);
            command.Parameters.AddWithValue("@AmountReceived", receipt.AmountReceived);

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

    public static void UpdateReceipt(Receipt receipt)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spReceiptUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ReceiptId", receipt.ReceiptId);
            command.Parameters.AddWithValue("@UserId", receipt.UserId);
            command.Parameters.AddWithValue("@IssueDate", receipt.IssueDate);
            command.Parameters.AddWithValue("@AmountReceived", receipt.AmountReceived);

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
    
    public static void DeleteReceipt(Receipt receipt)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spReceiptDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ReceiptId", receipt.ReceiptId);

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
}