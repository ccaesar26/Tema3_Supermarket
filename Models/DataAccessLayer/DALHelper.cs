using Microsoft.Data.SqlClient;
using Supermarket.Services;

namespace Supermarket.Models.DataAccessLayer;

public static class DALHelper
{
    public static SqlConnection Connection => new SqlConnection(ConfigurationManager.GetSetting("ConnectionStrings:SupermarketDb"));
}