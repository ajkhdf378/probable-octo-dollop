namespace AdminPanel.Application.DTOs.Auth;

public record LoginResponseDto(
    string Token,
    string Email,
    string Name,
    string Role,
    DateTime ExpiresAt
);
