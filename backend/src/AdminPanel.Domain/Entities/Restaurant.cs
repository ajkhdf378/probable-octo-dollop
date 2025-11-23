using AdminPanel.Domain.Common;

namespace AdminPanel.Domain.Entities;

public class Restaurant : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    public string? Website { get; private set; }
    public string? LogoUrl { get; private set; }
    public bool IsActive { get; private set; }
    public decimal Rating { get; private set; }
    public TimeSpan OpeningTime { get; private set; }
    public TimeSpan ClosingTime { get; private set; }

    private Restaurant() { }

    public Restaurant(
        string name,
        string description,
        string address,
        string city,
        string state,
        string zipCode,
        string phoneNumber,
        TimeSpan openingTime,
        TimeSpan closingTime)
    {
        Name = name;
        Description = description;
        Address = address;
        City = city;
        State = state;
        ZipCode = zipCode;
        PhoneNumber = phoneNumber;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
        IsActive = true;
        Rating = 0;
    }

    public void UpdateInfo(
        string name,
        string description,
        string address,
        string city,
        string state,
        string zipCode,
        string phoneNumber,
        string? email,
        string? website,
        TimeSpan openingTime,
        TimeSpan closingTime)
    {
        Name = name;
        Description = description;
        Address = address;
        City = city;
        State = state;
        ZipCode = zipCode;
        PhoneNumber = phoneNumber;
        Email = email;
        Website = website;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
        UpdateTimestamp();
    }

    public void UpdateLogo(string logoUrl)
    {
        LogoUrl = logoUrl;
        UpdateTimestamp();
    }

    public void UpdateRating(decimal rating)
    {
        if (rating < 0 || rating > 5)
            throw new ArgumentException("Rating must be between 0 and 5");

        Rating = rating;
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
