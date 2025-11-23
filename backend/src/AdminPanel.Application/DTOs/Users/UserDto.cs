namespace AdminPanel.Application.DTOs.Users;

public record UserDto(
    Guid Id,
    string Name,
    string Email,
    string Role,
    bool IsActive,
    string? PhoneNumber,
    string? Avatar,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
