namespace AdminPanel.Application.DTOs.Restaurants;

public record CreateRestaurantDto(
    string Name,
    string Description,
    string Address,
    string City,
    string State,
    string ZipCode,
    string PhoneNumber,
    string? Email,
    string? Website,
    string OpeningTime,
    string ClosingTime
);
