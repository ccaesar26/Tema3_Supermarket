using System.Data;
using Microsoft.Data.SqlClient;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.DataAccessLayer;

public static class StockDAL
{
    public static IEnumerable<Stock> GetStocks()
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spStockSelectAll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            connection.Open();
            
            var reader = command.ExecuteReader();
            var stocks = new List<Stock>();
            
            while (reader.Read())
            {
                var stock = new Stock
                {
                    StockId = (int) reader["StockId"],
                    ProductId = (int) reader["ProductId"],
                    Quantity = (int) reader["Quantity"],
                    Unit = (EUnit) reader["Unit"],
                    SupplyDate = (DateTime) reader["SupplyDate"],
                    ExpiryDate = (DateTime) reader["ExpiryDate"],
                    PurchasePrice = (decimal) reader["PurchasePrice"],
                    IsActive = (bool) reader["IsActive"]
                };
                stocks.Add(stock);
            }
            
            reader.Close();
            
            return stocks;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Stock>();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static Stock GetStockById(int stockId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spStockSelectOne", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@StockId", stockId);
            
            connection.Open();
            
            var reader = command.ExecuteReader();
            var stock = new Stock();
            
            if (reader.Read())
            {
                stock.StockId = (int) reader["StockId"];
                stock.ProductId = (int) reader["ProductId"];
                stock.Quantity = (int) reader["Quantity"];
                stock.Unit = (EUnit) reader["Unit"];
                stock.SupplyDate = (DateTime) reader["SupplyDate"];
                stock.ExpiryDate = (DateTime) reader["ExpiryDate"];
                stock.PurchasePrice = (decimal) reader["PurchasePrice"];
                stock.IsActive = (bool) reader["IsActive"];
            }
            
            reader.Close();
            
            return stock;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Stock();
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static bool InsertStock(Stock stock)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spStockInsert", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Quantity", stock.Quantity);
            command.Parameters.AddWithValue("@Unit", stock.Unit);
            command.Parameters.AddWithValue("@SupplyDate", stock.SupplyDate);
            command.Parameters.AddWithValue("@ExpiryDate", stock.ExpiryDate);
            command.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
            
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
    
    public static bool UpdateStock(Stock stock)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spStockUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@StockId", stock.StockId);
            command.Parameters.AddWithValue("@Quantity", stock.Quantity);
            command.Parameters.AddWithValue("@Unit", stock.Unit);
            command.Parameters.AddWithValue("@SupplyDate", stock.SupplyDate);
            command.Parameters.AddWithValue("@ExpiryDate", stock.ExpiryDate);
            command.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
            
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
    
    public static bool DeleteStock(int stockId)
    {
        var connection = DALHelper.Connection;
        try
        {
            var command = new SqlCommand("spStockDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@StockId", stockId);
            
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