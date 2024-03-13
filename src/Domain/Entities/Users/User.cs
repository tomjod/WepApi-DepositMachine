
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Users;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Users;

/// <summary>
/// Class ApplicationUser that inherit from IdentityUser.
/// </summary>
public sealed class User : IdentityUser<UserId>
{
    public UserId Id { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public new RUN UserName
    {
        get => RUN.Create(base.UserName!).Value;
        private set => base.UserName = value.Value.ToString(); 
    }
    public new Email Email
    {  
        get => Email.Create(base.Email!).Value; 
        private set => base.Email = value.Value.ToString(); 
    }
    public bool IsActive { get; private set; }

    private User(
        FirstName firstName,
        LastName lastName,
        RUN userName,
        Email email,
        string passwordHash)
    {
        Id = new UserId(Guid.NewGuid());
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
    }


    public static User Create(
        FirstName firstName,
        LastName lastName,
        RUN userName,
        Email email,
        string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        var hashedPassword = passwordHasher.HashPassword(null, password);

        var user = new User(
            firstName,
            lastName,
            userName,
            email,
            hashedPassword);

        return user;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}

