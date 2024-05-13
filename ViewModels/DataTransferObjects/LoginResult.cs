namespace Supermarket.ViewModels.DataTransferObjects;

public class LoginResult(string username, string password)
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}