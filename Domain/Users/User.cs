
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Branch;
using Domain.Client;
using Microsoft.AspNetCore.Identity;

namespace Domain.User;

/// <summary>
/// Class ApplicationUser that inherit from IdentityUser.
/// </summary>
public class User : IdentityUser<UserId>
{
    public UserId UserId {get; private set;}
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public bool IsActive { get; private set; }
    
    private User(string firstName, string lastName, string userName, string email, string passwordHash)
    {
        UserId = new UserId(Guid.NewGuid());
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        NormalizedUserName = userName.ToUpper();
        NormalizedEmail = email.ToUpper();
        IsActive = true;
    }
    
    public static User Create(string firstName, string lastName, string userName, string email, string password)
    {
        if(email == null)
        {
            throw new Exception("El email no pueden ser null");
        }

        if (password == null)
        {
            throw new Exception("La contraseña no pueden ser null");
        }

        if(userName == null)
        {
            throw new Exception("El nombre de usuario no pueden ser null");
        }

        var passwordHasher = new PasswordHasher<User>();
        var hashedPassword = passwordHasher.HashPassword(null, password);
        
        var user = new User(
            firstName, 
            lastName, 
            email,
            userName, hashedPassword);

        return user;
    }
}
