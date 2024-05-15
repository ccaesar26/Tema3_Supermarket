using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Extensions.Mapping;

public static class UserME
{
    public static UserDTO ToDTO(this User user)
    {
        return new UserDTO
        {
            Id = user.UserId,
            Username = user.Username,
            Password = user.Password,
            UserType = user.UserType.ToString()
        };
    }
    
    public static User ToEntity(this UserDTO userDTO)
    {
        return new User
        {
            UserId = userDTO.Id,
            Username = userDTO.Username ?? "",
            Password = userDTO.Password ?? "",
            UserType = userDTO.UserType switch
            {
                "Admin" => EUserType.Admin,
                "Cashier" => EUserType.Cashier,
                _ => throw new ArgumentException("Invalid user type")
            }
        };
    }
}