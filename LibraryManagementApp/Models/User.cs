using Utils.Enums;

namespace LibraryManagementApp.Models;

public class User : BaseEntity
{
    public string UserName { get; set; } 
    public string Email { get; set; } 
    public Role Role { get; set; }

    public User(string userName, string email, Role role)
    {
        UserName = userName;
        Email = email;
        Role = role;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"UserName : {UserName} | Email : {Email} | Role {Role}");
    }

}
