using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.DataAccessLayer;

public static class ProductReceiptDAL
{
    public static IEnumerable<ProductReceipt> GetProductReceipts()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductReceiptSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();
            
            var reader = command.ExecuteReader();
            var productReceipts = new List<ProductReceipt>();
            
            while (reader.Read())
            {
                var productReceipt = new ProductReceipt
                {
                    ProductId = (int) reader["ProductId"],
                    ReceiptId = (int) reader["ReceiptId"],
                    Quantity = (int) reader["Quantity"],
                    Unit = (EUnit) reader["Unit"],
                    Subtotal = (decimal) reader["Subtotal"],
                    IsActive = (bool) reader["IsActive"]
                };
                productReceipts.Add(productReceipt);
            }
            
            reader.Close();
            
            return productReceipts;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<ProductReceipt>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static ProductReceipt GetProductReceiptById(int receiptId, int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductReceiptSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ReceiptId", receiptId);
            command.Parameters.AddWithValue("@ProductId", productId);

            connection.Open();
            
            var reader = command.ExecuteReader();
            var productReceipt = new ProductReceipt();
            
            while (reader.Read())
            {
                productReceipt.ProductId = (int) reader["ProductId"];
                productReceipt.ReceiptId = (int) reader["ReceiptId"];
                productReceipt.Quantity = (int) reader["Quantity"];
                productReceipt.Unit = (EUnit) reader["Unit"];
                productReceipt.Subtotal = (decimal) reader["Subtotal"];
                productReceipt.IsActive = (bool) reader["IsActive"];
            }
            
            reader.Close();
            
            return productReceipt;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ProductReceipt();
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool InsertProductReceipt(ProductReceipt productReceipt)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductReceiptInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ReceiptId", productReceipt.ReceiptId);
            command.Parameters.AddWithValue("@ProductId", productReceipt.ProductId);
            command.Parameters.AddWithValue("@Quantity", productReceipt.Quantity);
            command.Parameters.AddWithValue("@Unit", productReceipt.Unit);
            command.Parameters.AddWithValue("@Subtotal", productReceipt.Subtotal);

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
    
    public static bool UpdateProductReceipt(ProductReceipt productReceipt)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductReceiptUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ProductId", productReceipt.ProductId);
            command.Parameters.AddWithValue("@ReceiptId", productReceipt.ReceiptId);
            command.Parameters.AddWithValue("@Quantity", productReceipt.Quantity);
            command.Parameters.AddWithValue("@Unit", productReceipt.Unit);
            command.Parameters.AddWithValue("@Subtotal", productReceipt.Subtotal);

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
    
    public static bool DeleteProductReceipt(int receiptId, int productId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spProductReceiptDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@ReceiptId", receiptId);
            command.Parameters.AddWithValue("@ProductId", productId);

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