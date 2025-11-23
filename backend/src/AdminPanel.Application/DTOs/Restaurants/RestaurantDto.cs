namespace AdminPanel.Application.DTOs.Restaurants;

public record RestaurantDto(
    Guid Id,
    string Name,
    string Description,
    string Address,
    string City,
    string State,
    string ZipCode,
    string PhoneNumber,
    string? Email,
    string? Website,
    string? LogoUrl,
    bool IsActive,
    decimal Rating,
    string OpeningTime,
    string ClosingTime,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
