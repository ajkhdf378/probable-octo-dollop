namespace AdminPanel.Application.DTOs.Users;

public record UpdateUserDto(
    string Name,
    string? PhoneNumber,
    string? Avatar
);
