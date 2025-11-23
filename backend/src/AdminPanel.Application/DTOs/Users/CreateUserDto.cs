namespace AdminPanel.Application.DTOs.Users;

public record CreateUserDto(
    string Name,
    string Email,
    string Password,
    string Role,
    string? PhoneNumber
);
