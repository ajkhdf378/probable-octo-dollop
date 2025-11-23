using AdminPanel.Domain.Common;
using AdminPanel.Domain.Enums;

namespace AdminPanel.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Avatar { get; private set; }

    private User() { }

    public User(string name, string email, string passwordHash, UserRole role)
    {
        Name = name;
        Email = email.ToLowerInvariant();
        PasswordHash = passwordHash;
        Role = role;
        IsActive = true;
    }

    public void UpdateProfile(string name, string? phoneNumber, string? avatar)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Avatar = avatar;
        UpdateTimestamp();
    }

    public void UpdatePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        UpdateTimestamp();
    }

    public void UpdateRole(UserRole role)
    {
        Role = role;
        UpdateTimestamp();
    }

    public void Activate()
    {
        IsActive = true;
        UpdateTimestamp();
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdateTimestamp();
    }
}
