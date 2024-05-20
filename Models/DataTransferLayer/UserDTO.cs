namespace Supermarket.Models.DataTransferLayer;

public class UserDTO
{
    public int? Id { get; init; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? UserType { get; set; }
}