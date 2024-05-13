using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.BusinessLogicLayer;

public static class UserBLL
{
    public static bool IsValidAdmin(string username, string password)
    {
        var admins = UserDAL.GetAllAdmins();
        return admins.Any(a => a.Username == username && a.Password == password);
    }
    
    public static bool IsValidCashier(string username, string password)
    {
        var cashiers = UserDAL.GetAllCashiers();
        return cashiers.Any(c => c.Username == username && c.Password == password);
    }
}