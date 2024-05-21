using Microsoft.Data.SqlClient;
using Supermarket.Services;

namespace Supermarket.Models.DataAccessLayer.Helpers;

public static class DALHelper
{
    public static SqlConnection Connection => new(ConfigurationManager.GetConnectionString());
}