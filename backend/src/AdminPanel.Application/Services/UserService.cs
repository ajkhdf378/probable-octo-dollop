using AdminPanel.Application.DTOs.Users;
using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.Interfaces;

namespace AdminPanel.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _unitOfWork.Users.FindAsync(u => !u.IsDeleted, cancellationToken);
        return users.Select(MapToDto);
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);
        return user != null && !user.IsDeleted ? MapToDto(user) : null;
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        if (await _unitOfWork.Users.EmailExistsAsync(dto.Email, null, cancellationToken))
            throw new InvalidOperationException("Email already exists");

        if (!Enum.TryParse<UserRole>(dto.Role, out var role))
            throw new ArgumentException("Invalid role");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        var user = new User(dto.Name, dto.Email, passwordHash, role);

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
            user.UpdateProfile(user.Name, dto.PhoneNumber, null);

        await _unitOfWork.Users.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(user);
    }

    public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);

        if (user == null || user.IsDeleted)
            throw new KeyNotFoundException("User not found");

        user.UpdateProfile(dto.Name, dto.PhoneNumber, dto.Avatar);

        await _unitOfWork.Users.UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(user);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id, cancellationToken);

        if (user == null || user.IsDeleted)
            throw new KeyNotFoundException("User not found");

        user.MarkAsDeleted();
        await _unitOfWork.Users.UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static UserDto MapToDto(User user) => new(
        user.Id,
        user.Name,
        user.Email,
        user.Role.ToString(),
        user.IsActive,
        user.PhoneNumber,
        user.Avatar,
        user.CreatedAt,
        user.UpdatedAt
    );
}
