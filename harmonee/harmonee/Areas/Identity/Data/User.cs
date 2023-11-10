using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace harmonee.Areas.Identity.Data;

// Add profile data for application users by adding properties to the harmoneeUser class
public class User : IdentityUser
{
    [Required, Key]
    private Guid UserId { get; set; }
    [Required, MaxLength(255), MinLength(2)]
    private string FirstName { get; set; }
    [Required, MaxLength(255), MinLength(2)]
    private string LastName { get; set; }
    [Required, EmailAddress]
    private string Email { get; set; }
    [Required, Phone]
    private string Phone { get; set; }
    [Required, MinLength(8), PersonalData, ProtectedPersonalData]
    private string Password { get; set; }
    [Required]
    private bool GetsEmail { get; set; }
    [Required]
    private bool GetsText { get; set; }
    [Required]
    private bool IsActive { get; set; }

    public User()
    {
        UserId = Guid.NewGuid();
        FirstName = String.Empty;
        LastName = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        Password = String.Empty;
        IsActive = false;
        GetsEmail = false;
        GetsText = false;
    }

    public User(UserDTO user)
    {
        UserId = user.UserId ?? Guid.NewGuid();
        FirstName = user.FirstName ?? string.Empty;
        LastName = user.LastName ?? string.Empty;
        Email = user.Email ?? string.Empty;
        Phone = user.Phone ?? string.Empty;
        GetsEmail = user.GetsEmail;
        GetsText = user.GetsText;
        IsActive = user.IsActive;
    }
}

public class UserDTO
{
    public Guid? UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool GetsEmail { get; set; }
    public bool GetsText { get; set; }
    public bool IsActive { get; set; }
}

